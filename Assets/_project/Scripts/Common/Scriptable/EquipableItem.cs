using UnityEngine;
using LittleSimPrototype.Inventory;
using UnityEngine.UIElements;
using System.Collections.Generic;

namespace LittleSimPrototype
{
    [CreateAssetMenu(fileName ="NewEquippableItem", menuName = "LittleSimPrototype/New Equippable Item", order = 100)]
    public class EquipableItem : Item
    {
        [SerializeField] private List<EquipableSprite> _equipableSpriteList = new();
        public List<EquipableSprite> EquipableSpriteList { get => _equipableSpriteList; }

        private bool _isEquipped;
        public bool IsEquipped { get => _isEquipped; }

        public override void UseItem()
        {
            _isEquipped = !_isEquipped;
            InventoryEvents.NotifyItemEquiped(_equipableSpriteList);
        }
    }
}
