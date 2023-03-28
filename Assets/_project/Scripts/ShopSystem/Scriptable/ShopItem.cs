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

        [SerializeField] private int _itemPrice;
        public int Price { get => _itemPrice; }
    }
}