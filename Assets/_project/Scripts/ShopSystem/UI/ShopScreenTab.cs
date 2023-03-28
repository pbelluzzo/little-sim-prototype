using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.ShopSystem
{
    public class ShopScreenTab : MonoBehaviour
    {
        [SerializeField] private GameObject _itemSlotContainer;
        public GameObject ItemSlotContainer { get => _itemSlotContainer; }

        private List<ShopItemSlot> _shopItemSlots = new();
        public List<ShopItemSlot> ShopItemSlots { get => _shopItemSlots; }
    }
}
