using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimPrototype.ShopSystem
{
    public class ShopItemSlot : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;
        
        [SerializeField] private TextMeshProUGUI _priceTMP;

        [SerializeField] private Button _buttonComponent;

        private ShopItem _shopItem;
        public ShopItem ShopItem { get => _shopItem; }

        public void RemoveItem()
        {
            _itemImage.sprite = null;
            _buttonComponent.interactable = false;
        }

        public void SetupSlot(ShopItem item)
        {
            _shopItem = item;
            _itemImage.sprite = ShopItem.Item.ItemImage;
            _priceTMP.text = item.PriceCurrency + item.Price.ToString();
            _buttonComponent.interactable = true;
        }
    }
}