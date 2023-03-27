using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimPrototype.ShopSystem
{
    public class ShopItemSlot : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;

        [SerializeField] private TextMeshProUGUI _quantityTMP;
        
        [SerializeField] private TextMeshProUGUI _priceTMP;

        private Button _buttonComponent;

        private ShopItem _shopItem;
        public ShopItem ShopItem { get => _shopItem; }

        public string QuantityText { set => _quantityTMP.text = value; }

        private void Start()
        {
            _buttonComponent = GetComponent<Button>();
        }

        public void RemoveItem()
        {
            _itemImage.sprite = null;
            _buttonComponent.interactable = false;
            _quantityTMP.text = "";
        }

        public void SetupSlot(ShopItem item, int quantity)
        {
            _shopItem = item;
            _itemImage.sprite = ShopItem.Item.ItemImage;
            _quantityTMP.text = quantity.ToString();
            _buttonComponent.interactable = true;
        }
    }
}