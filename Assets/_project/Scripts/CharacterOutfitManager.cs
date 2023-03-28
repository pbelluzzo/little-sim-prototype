using LittleSimPrototype.Inventory;
using UnityEngine;
using UnityEngine.U2D.Animation;

namespace LittleSimPrototype
{
    public class CharacterOutfitManager : MonoBehaviour
    {
        [SerializeField] private EquipableItem _defaultBodyItem;
        [SerializeField] private SpriteResolver _bodySpriteResolver;

        private void Start()
        {
            EquipItem(_defaultBodyItem.EquipmentCategory, _defaultBodyItem.AssetLibraryLabel);
        }

        private void EquipItem(string category, string label)
        {
            _bodySpriteResolver.SetCategoryAndLabel(category, label);
            _bodySpriteResolver.ResolveSpriteToSpriteRenderer();
        }

        private void OnEnable()
        {
            InventoryEvents.OnItemEquipedEvent += HandleItemEquiped;
        }

        private void OnDisable()
        {
            InventoryEvents.OnItemEquipedEvent -= HandleItemEquiped;
        }

        private void HandleItemEquiped(string itemLabel, string category, bool isEquipped)
        {
            EquipItem(category, itemLabel);
        }
    }
}
