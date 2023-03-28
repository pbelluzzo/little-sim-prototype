using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimPrototype.ShopSystem
{
    public class ShopItemSlot : MonoBehaviour
    {
        public event Action<ShopItemSlot> OnSlotClickedEvent;

        [SerializeField] private Image _itemImage;
        
        [SerializeField] private TextMeshProUGUI _priceTMP;

        [SerializeField] private Button _buttonComponent;

        private ShopItem _shopItem;
        public ShopItem ShopItem { get => _shopItem; }

        private void OnEnable()
        {
            _buttonComponent.onClick.AddListener(HandleClick);    
        }

        private void OnDisable()
        {
            _buttonComponent.onClick.RemoveListener(HandleClick);
        }

        public void RemoveItem()
        {
            _itemImage.sprite = null;
            _buttonComponent.interactable = false;
        }

        public void SetupSlot(ShopItem item)
        {
            _shopItem = item;
            _itemImage.sprite = ShopItem.Item.ItemImage;
            _priceTMP.text = item.PriceCurrency + item.Price.ToString() + ",00";
            _buttonComponent.interactable = true;
        }

        private void HandleClick()
        {
            OnSlotClickedEvent?.Invoke(this);
        }
    }
}