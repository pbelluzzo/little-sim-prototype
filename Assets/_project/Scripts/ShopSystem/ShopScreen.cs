using LittleSimPrototype.UI;
using System.Collections.Generic;
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
        [SerializeField] private GameObject _shopBuyItemContainer;
        [SerializeField] private GameObject _shopSellItemContainer;
        [SerializeField] private ShopItemSlot _shopItemSlotPrefab;

        private Shop _shop;
        private List<ShopItemSlot> _shopItemSlots = new();

        public override void Enable()
        {
            base.Enable();

            foreach(ShopItemSlot slot in _shopItemSlots)
            {
                slot.OnSlotClickedEvent += HandleSlotClicked;
            }
        }

        public override void Disable()
        {
            base.Disable();

            foreach(ShopItemSlot slot in _shopItemSlots)
            {
                slot.OnSlotClickedEvent -= HandleSlotClicked;
            }
        }

        public void SetUpShopScreen(Shop shop)
        {
            _shop = shop;
            _shopTitle.text = shop.ShopName;
            _shopDescription.text = shop.ShopDescription;

            foreach(ShopItem shopItem in shop.ItemsOnSale)
            {
                ShopItemSlot slot = Instantiate(_shopItemSlotPrefab, _shopBuyItemContainer.transform);
                slot.SetupSlot(shopItem);
                _shopItemSlots.Add(slot);
            }
        }

        private void HandleSlotClicked(ShopItemSlot slot)
        {
            ShopEvents.NotifyItemBought(slot.ShopItem);
        }
    }
}
