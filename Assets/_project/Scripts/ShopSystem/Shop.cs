using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.ShopSystem
{
    [CreateAssetMenu(fileName = "NewShop", menuName = "LittleSimPrototype/ShopSystem/New Shop")]
    public class Shop : ScriptableObject
    {
        [SerializeField] private string _shopName;
        public string ShopName { get => _shopName; }

        [SerializeField, TextArea(2,4)] private string _shopDescription;
        public string ShopDescription { get => _shopDescription;}

        [SerializeField, Range(0,1)] private float _percentagePaidForBoughtItems;

        [SerializeField] private List<ShopItem> _itemsSoldByThisShop = new();
        public List<ShopItem> ItemsOnSale { get => _itemsSoldByThisShop; }

        [SerializeField] private List<ShopItem> _itemsBoughtByThisShop = new();
        public List<ShopItem> ItemsBeingBought { get => _itemsBoughtByThisShop; }

        public void SellItem(ShopItem item)
        {

        }

        public void BuyItem(ShopItem item)
        {

        }
    }
}