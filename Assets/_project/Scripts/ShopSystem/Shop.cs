using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.ShopSystem
{
    [CreateAssetMenu(fileName = "NewShop", menuName = "LittleSimPrototype/ShopSystem/New Shop")]
    public class Shop : ScriptableObject
    {
        [SerializeField] private string _shopName;
        [SerializeField, TextArea(2,4)] private string _shopDescription;
        [SerializeField, Range(0,1)] private float _percentagePaidForBoughtItems;
        [SerializeField] private List<ShopItem> _itemsSoldByThisShop = new();
        [SerializeField] private List<ShopItem> _itemsBoughtByThisShop = new();


    }
}