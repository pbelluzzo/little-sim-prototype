using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimPrototype.Inventory
{
    public class InventorySlot : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;

        [SerializeField] private TextMeshProUGUI _quantityTMP;

        private Button _buttonComponent;
        
        private void Start()
        {
            _buttonComponent= GetComponent<Button>();
        }

        public void RemoveItem()
        {
            _itemImage.sprite = null;
            _buttonComponent.interactable = false;
        }

        public void SetupSlot(Item item, int quantity)
        {
            _itemImage.sprite = item.ItemImage;
            _quantityTMP.text = quantity.ToString();
            _buttonComponent.interactable = true;
        }
    }
}