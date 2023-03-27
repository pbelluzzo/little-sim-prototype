using LittleSimPrototype.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LittleSimPrototype.ShopSystem
{
    public class ShopScreen : UIScreen
    {
        [SerializeField] private TextMeshProUGUI _shopTitle;
        [SerializeField] private TextMeshProUGUI _shopDescription;
        [SerializeField] private GameObject _shopItemContainer;
        [SerializeField] private ShopItemSlot _shopItemSlotPrefab;

        private List<ShopItemSlot> _shopItemSlots = new();

        public void SetUpShopScreen(Shop shop)
        {
            _shopTitle.text = shop.ShopName;
            _shopDescription.text = shop.ShopDescription;

            foreach(ShopItem shopItem in shop.ItemsOnSale)
            {
                ShopItemSlot slot = Instantiate(_shopItemSlotPrefab, _shopItemContainer.transform);
                slot.SetupSlot(shopItem);
                _shopItemSlots.Add(slot);
            }
        }
    }
}
