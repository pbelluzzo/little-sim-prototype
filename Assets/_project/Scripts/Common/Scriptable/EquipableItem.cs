using UnityEngine;
using LittleSimPrototype.Inventory;

namespace LittleSimPrototype
{
    [CreateAssetMenu(fileName ="NewEquippableItem", menuName = "LittleSimPrototype/New Equippable Item", order = 100)]
    public class EquipableItem : Item
    {
        [SerializeField] private string _assetLibraryLabel;
        public string AssetLibraryLabel { get => _assetLibraryLabel; }

        [SerializeField] private string _equipmentCategory;
        public string EquipmentCategory { get => _equipmentCategory; }

        private bool _isEquipped;
        public bool IsEquipped { get => _isEquipped; }

        public override void UseItem()
        {
            _isEquipped = !_isEquipped;
            InventoryEvents.NotifyItemEquiped(_assetLibraryLabel, _equipmentCategory, _isEquipped);
        }
    }
}
