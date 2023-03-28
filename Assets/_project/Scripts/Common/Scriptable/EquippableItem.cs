using UnityEngine;
using LittleSimPrototype.Inventory;
using System.Collections.Generic;

namespace LittleSimPrototype
{
    [CreateAssetMenu(fileName ="NewEquippableItem", menuName = "LittleSimPrototype/New Equippable Item", order = 100)]
    public class EquippableItem : Item
    {
        [SerializeField] private List<EquipableSprite> _equipableSpriteList = new();
        public List<EquipableSprite> EquipableSpriteList { get => _equipableSpriteList; }

        private bool _isEquipped;
        public bool IsEquipped { get => _isEquipped; set => _isEquipped = value; }

        public override void UseItem()
        {
            InventoryEvents.NotifyItemEquiped(this);
        }
    }
}
