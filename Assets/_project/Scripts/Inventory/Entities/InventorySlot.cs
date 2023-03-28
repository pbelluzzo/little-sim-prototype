using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimPrototype.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;

        [SerializeField] private TextMeshProUGUI _quantityTMP;
        public string QuantityText { set => _quantityTMP.text = value; }

        [SerializeField] private Button _buttonComponent;
        
        private Item _slotItem;
        public Item SlotItem { get => _slotItem; }

        public void SetupSlot(Item item, int quantity)
        {
            _slotItem = item;
            _itemImage.sprite = item.ItemImage;
            _quantityTMP.text = quantity.ToString();
            _buttonComponent.interactable = true;
        }

        public void RemoveItem()
        {
            _itemImage.sprite = null;
            _buttonComponent.interactable = false;
            _quantityTMP.text = "";
            _slotItem = null;
        }
    }
}