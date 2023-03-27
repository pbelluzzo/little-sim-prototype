using UnityEngine;

namespace LittleSimPrototype.ShopSystem
{
    [CreateAssetMenu(fileName = "NewShopItem", menuName = "LittleSimPrototype/ShopSystem/New Shop Item")]
    public class ShopItem : ScriptableObject
    {
        [SerializeField] private Item _item;
        public Item Item { get => _item; }

        [SerializeField] private string _priceCurrency;
        public string PriceCurrency { get => _priceCurrency;}

        [SerializeField] private float _itemPrice;
        public float Price { get => _itemPrice; }
    }
}