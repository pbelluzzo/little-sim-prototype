using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleSimPrototype.Inventory
{
    [CreateAssetMenu(fileName = "PlayerItemData", menuName = "LittleSimPrototype/Inventory/PlayerItemData")]
    public class PlayerItemData : ScriptableObject
    {
        private int _money;
        public int Money 
        { 
            get => _money;
            set
            {
                _money = value >= 0 ? value : 0;
            }
        }

        private Dictionary<Item, int> _inventoryItems = new();
        public Dictionary<Item, int> InventoryItems { get => _inventoryItems; }

    }
}
