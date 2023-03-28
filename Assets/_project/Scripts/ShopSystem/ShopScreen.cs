using LittleSimPrototype.Inventory;
using LittleSimPrototype.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimPrototype.ShopSystem
{
    public class ShopScreen : UIScreen
    {
        [SerializeField] private TextMeshProUGUI _shopTitle;
        [SerializeField] private TextMeshProUGUI _shopDescription;
        [SerializeField] private Button _buyTabButton;
        [SerializeField] private Button _sellTabButton;
        [SerializeField] private ShopItemSlot _shopItemSlotPrefab;

        [SerializeField] private ShopScreenTab _buyTab;
        [SerializeField] private ShopScreenTab _sellTab;

        private Shop _shop;
        private ShopScreenTab _activeTab;

        public override void Enable()
        {
            base.Enable();

            foreach(ShopItemSlot slot in _buyTab.ShopItemSlots)
            {
                slot.OnSlotClickedEvent += HandleSlotClicked;
            }

            foreach (ShopItemSlot slot in _sellTab.ShopItemSlots)
            {
                slot.OnSlotClickedEvent += HandleSlotClicked;
            }

            InventoryEvents.OnPlayerItemDataResponseEvent += HandlePlayerItemDataResponse;

            _buyTabButton.onClick.AddListener(HandleBuyTabButtonClick);
            _sellTabButton.onClick.AddListener(HandleSellTabButtonClick);

            ChangeActiveTab(_buyTab);
        }

        public override void Disable()
        {
            base.Disable();

            foreach(ShopItemSlot slot in _buyTab.ShopItemSlots)
            {
                slot.OnSlotClickedEvent -= HandleSlotClicked;
            }

            foreach (ShopItemSlot slot in _sellTab.ShopItemSlots)
            {
                slot.OnSlotClickedEvent -= HandleSlotClicked;
            }

            InventoryEvents.OnPlayerItemDataResponseEvent -= HandlePlayerItemDataResponse;

            _buyTabButton.onClick.RemoveListener(HandleBuyTabButtonClick);
            _sellTabButton.onClick.RemoveListener(HandleSellTabButtonClick);
        }

        public void SetUpShopScreen(Shop shop)
        {
            _shop = shop;
            _shopTitle.text = shop.ShopName;
            _shopDescription.text = shop.ShopDescription;

            SetUpBuyTab(shop);
        }

        private void SetUpBuyTab(Shop shop)
        {
            foreach (ShopItem shopItem in shop.ItemsOnSale)
            {
                ShopItemSlot slot = Instantiate(_shopItemSlotPrefab, _buyTab.ItemSlotContainer.transform);
                slot.SetupSlot(shopItem);
                _buyTab.ShopItemSlots.Add(slot);
            }
        }

        private void InstantiateNewShopItemSlots(List<ShopItemSlot> slotList, Transform container, int amount, ShopItem item = null)
        {
            for (int i = 0; i < amount; i++)
            {
                ShopItemSlot slot = Instantiate(_shopItemSlotPrefab, container);
                
                if (item != null)
                {
                    slot.SetupSlot(item);
                }

                slotList.Add(slot);
                slot.OnSlotClickedEvent += HandleSlotClicked;
            }
        }

        private void PrepareSellTabShopItemSlots(PlayerItemData playerItemData)
        {
            if (_sellTab.ShopItemSlots.Count < playerItemData.InventoryItems.Count)
            {
                int slotsDifference = playerItemData.InventoryItems.Count - _sellTab.ShopItemSlots.Count;
                InstantiateNewShopItemSlots(_sellTab.ShopItemSlots, _sellTab.ItemSlotContainer.transform, slotsDifference);
            }

            foreach (ShopItemSlot slot in _sellTab.ShopItemSlots)
            {
                slot.gameObject.SetActive(false);
            }
        }

        private void SetupShopItemSlotsWithItemsAvailableForSelling(List<ShopItem> itemsAvailableForSelling)
        {
            int index = 0;

            foreach (ShopItem item in itemsAvailableForSelling)
            {
                _sellTab.ShopItemSlots[index].SetupSlot(item, _shop.GetUsedItemPrice(item.Price));
                _sellTab.ShopItemSlots[index].gameObject.SetActive(true);
                index++;
            }
        }

        private void ChangeActiveTab(ShopScreenTab tab) 
        {
            _activeTab = tab;
            _buyTab.gameObject.SetActive(_activeTab == _buyTab);
            _sellTab.gameObject.SetActive(_activeTab == _sellTab);
        }

        private void HandleSlotClicked(ShopItemSlot slot)
        {
            if (_activeTab == _buyTab)
            {
                ShopEvents.NotifyItemBought(slot.ShopItem);
                return;
            }

            ShopEvents.NotifyItemSold(slot.ShopItem, _shop.GetUsedItemPrice(slot.ShopItem.Price));
            InventoryEvents.RequestPlayerItemData();
        }

        private void HandlePlayerItemDataResponse(PlayerItemData playerItemData)
        {
            PrepareSellTabShopItemSlots(playerItemData);

            List<ShopItem> itemsAvailableForSelling = new();
            itemsAvailableForSelling = _shop.ItemsBeingBought.Where(i => playerItemData.InventoryItems.Keys.Contains<Item>(i.Item)).ToList<ShopItem>();

            if (itemsAvailableForSelling.Count == 0)
            {
                return;
            }

            SetupShopItemSlotsWithItemsAvailableForSelling(itemsAvailableForSelling);
        }

        private void HandleBuyTabButtonClick()
        {
            ChangeActiveTab(_buyTab);
        }

        private void HandleSellTabButtonClick()
        {
            InventoryEvents.RequestPlayerItemData();
            ChangeActiveTab(_sellTab);
        }
    }
}
