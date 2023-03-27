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

        private Button _buttonComponent;
        
        private Item _equipedItem;
        public Item EquipedItem { get => _equipedItem; }


        private void Start()
        {
            _buttonComponent= GetComponent<Button>();
        }

        public void RemoveItem()
        {
            _itemImage.sprite = null;
            _buttonComponent.interactable = false;
            _quantityTMP.text = "";
        }

        public void SetupSlot(Item item, int quantity)
        {
            _equipedItem = item;
            _itemImage.sprite = item.ItemImage;
            _quantityTMP.text = quantity.ToString();
            _buttonComponent.interactable = true;
        }
    }
}