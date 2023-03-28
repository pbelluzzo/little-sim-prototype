using LittleSimPrototype.Inventory;
using LittleSimPrototype.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

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

            InventoryEvents.OnPlayerItemDataResponseEvent += HandlePlayerItemDataResponse;
            InventoryEvents.RequestPlayerItemData();

            _buyTabButton.onClick.AddListener(HandleBuyTabButtonClick);
            _sellTabButton.onClick.AddListener(HandleSellTabButtonClick);
        }

        public override void Disable()
        {
            base.Disable();

            foreach(ShopItemSlot slot in _buyTab.ShopItemSlots)
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
            }
        }

        private int GetUsedItemPrice(int price)
        {
            return Mathf.CeilToInt(price * _shop.PercentagePaidForBoughtItems);
        }

        private void HandleSlotClicked(ShopItemSlot slot)
        {
            if (_activeTab == _buyTab)
            {
                ShopEvents.NotifyItemBought(slot.ShopItem);
                return;
            }

            ShopEvents.NotifyItemSold(slot.ShopItem, GetUsedItemPrice(slot.ShopItem.Price));
        }

        private void HandlePlayerItemDataResponse(PlayerItemData playerItemData)
        {
            if (_sellTab.ShopItemSlots.Count < playerItemData.InventoryItems.Count)
            {
                int slotsDifference = _sellTab.ShopItemSlots.Count - playerItemData.InventoryItems.Count;
                InstantiateNewShopItemSlots(_sellTab.ShopItemSlots, _sellTab.ItemSlotContainer.transform, slotsDifference);
            }

            foreach (ShopItemSlot slot in _sellTab.ShopItemSlots)
            {
                gameObject.SetActive(false);
            }

            List<ShopItem> itemsAvailableForSelling = _shop.ItemsBeingBought.Where(i => playerItemData.InventoryItems.Keys.Contains<Item>(i.Item)).ToList<ShopItem>();

            int index = 0;

            foreach(ShopItem item in itemsAvailableForSelling)
            {
                _sellTab.ShopItemSlots[index].SetupSlot(item, GetUsedItemPrice(item.Price));
                _sellTab.ShopItemSlots[index].gameObject.SetActive(true);
                index++;
            }
        }

        private void HandleBuyTabButtonClick()
        {
            _activeTab = _buyTab;
            _buyTab.gameObject.SetActive(true);
            _sellTab.gameObject.SetActive(false);
        }

        private void HandleSellTabButtonClick()
        {
            _activeTab = _sellTab;
            _buyTab.gameObject.SetActive(false);
            _sellTab.gameObject.SetActive(true);
        }
    }
}
