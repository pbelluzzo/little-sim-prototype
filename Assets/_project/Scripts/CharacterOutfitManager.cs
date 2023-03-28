using LittleSimPrototype.Inventory;
using UnityEngine;
using UnityEngine.U2D.Animation;
using System.Collections.Generic;

namespace LittleSimPrototype
{
    public class CharacterOutfitManager : MonoBehaviour
    {
        [SerializeField] private EquipableItem _defaultBodyItem;
        [SerializeField] private SpriteResolver _bodySpriteResolver;
        [SerializeField] private SpriteResolver _armLSpriteResolver;
        [SerializeField] private SpriteResolver _armRSpriteResolver;

        private void Start()
        {
            HandleItemEquiped(_defaultBodyItem.EquipableSpriteList);
        }
        private void OnEnable()
        {
            InventoryEvents.OnItemEquipedEvent += HandleItemEquiped;
        }

        private void OnDisable()
        {
            InventoryEvents.OnItemEquipedEvent -= HandleItemEquiped;
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

        private void HandleItemEquiped(List<EquipableSprite> equipableSpriteList)
        {
            foreach(EquipableSprite equipableSprite in equipableSpriteList)
            {
                EquipItem(equipableSprite.EquipmentCategory, equipableSprite.AssetLibraryLabel);
            }
        }
    }
}
