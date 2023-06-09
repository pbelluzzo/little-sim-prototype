using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.Inventory
{
    [CreateAssetMenu(fileName = "InventoryConfigs", menuName ="LittleSimPrototype/Inventory/Inventory Configs")]
    public class InventoryConfigs : ScriptableObject
    {
        public int StartingMoney;
        public int InventorySlots;

        public List<Item> StartingItems = new();
    }
}
