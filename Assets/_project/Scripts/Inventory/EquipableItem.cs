using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.Inventory
{
    [CreateAssetMenu(fileName ="NewEquipableItem", menuName = "LittleSimPrototype/Inventory/New Equipable Item")]
    public class EquipableItem : Item
    {
        [SerializeField] private string _assetLibraryLabel;
        public string AssetLibraryLabel { get => _assetLibraryLabel; }
    }
}
