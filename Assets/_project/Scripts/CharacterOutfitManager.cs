using LittleSimPrototype.Inventory;
using UnityEngine;
using UnityEngine.U2D.Animation;
using System.Collections.Generic;

namespace LittleSimPrototype
{
    public class CharacterOutfitManager : MonoBehaviour
    {
        [SerializeField] private EquippableItem _defaultBodyItem;
        [SerializeField] private SpriteResolver _bodySpriteResolver;
        [SerializeField] private SpriteResolver _armLSpriteResolver;
        [SerializeField] private SpriteResolver _armRSpriteResolver;

        private void Start()
        {
            InventoryEvents.NotifyItemEquiped(_defaultBodyItem);
        }
        private void OnEnable()
        {
            InventoryEvents.OnItemEquippedEvent += HandleItemEquiped;
        }

        private void OnDisable()
        {
            InventoryEvents.OnItemEquippedEvent -= HandleItemEquiped;
        }

        private void EquipItem(EquipmentCategory category, string label)
        {
            string categoryString;
            SpriteResolver resolver = GetResolver(category, out categoryString);
            resolver.SetCategoryAndLabel(categoryString, label);
            resolver.ResolveSpriteToSpriteRenderer();
        }

        private SpriteResolver GetResolver(EquipmentCategory category, out string categoryString)
        {
            switch (category)
            {
                case EquipmentCategory.body:
                    categoryString = "body";
                    return _bodySpriteResolver;
                case EquipmentCategory.armL:
                    categoryString = "armL";
                    return _armLSpriteResolver;
                case EquipmentCategory.armR:
                    categoryString = "armR";
                    return _armRSpriteResolver;
                default:
                    categoryString = "";
                    return null;
            }
        }

        private void HandleItemEquiped(EquippableItem equippableItem)
        {
            foreach(EquipableSprite equipableSprite in equippableItem.EquipableSpriteList)
            {
                EquipItem(equipableSprite.EquipmentCategory, equipableSprite.AssetLibraryLabel);
            }
        }
    }
}
