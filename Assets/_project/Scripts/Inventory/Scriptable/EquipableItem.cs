using UnityEngine;

namespace LittleSimPrototype.Inventory
{
    [CreateAssetMenu(fileName ="NewEquipableItem", menuName = "LittleSimPrototype/Inventory/New Equipable Item")]
    public class EquipableItem : Item
    {
        [SerializeField] private string _assetLibraryLabel;
        public string AssetLibraryLabel { get => _assetLibraryLabel; }

        [SerializeField] private bool _isEquiped;
        public bool IsEquiped { get => _isEquiped; }

        public override void UseItem()
        {
            _isEquiped = !_isEquiped;
            InventoryEvents.NotifyItemEquiped(_assetLibraryLabel);
        }
    }
}
