using UnityEngine;
using System;

namespace LittleSimPrototype
{
    [Serializable]
    public class EquipableSprite
    {
        [SerializeField] private string _assetLibraryLabel;
        public string AssetLibraryLabel { get => _assetLibraryLabel; }

        [SerializeField] private EquipmentCategory _equipmentCategory;
        public EquipmentCategory EquipmentCategory { get => _equipmentCategory; }
    }
}
