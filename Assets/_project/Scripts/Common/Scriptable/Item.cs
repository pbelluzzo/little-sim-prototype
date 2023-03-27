using UnityEngine;

namespace LittleSimPrototype
{
    public class Item : ScriptableObject
    {
        [SerializeField] private Sprite _itemImage;
        public Sprite ItemImage { get => _itemImage; }

        [SerializeField] private string _itemName;
        public string ItemName { get => _itemName; }

        [SerializeField, TextArea(2,4)] private string _itemDescription;
        public string ItemDescription { get => _itemDescription; }

        public virtual void UseItem()
        {

        }
    }

}
