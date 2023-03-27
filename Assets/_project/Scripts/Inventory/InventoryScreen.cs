using UnityEngine;
using LittleSimPrototype.UI;
using Screen = LittleSimPrototype.UI.Screen;
using System.Collections.Generic;
using Unity.VisualScripting;

namespace LittleSimPrototype.Inventory
{
    public class InventoryScreen : Screen
    {
        [SerializeField] private InventorySlot _inventorySlotPrefab;
        [SerializeField] private GameObject _itemSlotsContainer;
        [SerializeField] private Inventory _playerInventory;
        
        private List<InventorySlot> _inventorySlots = new();

        private void Start()
        {
            for (int i = 0; i < _playerInventory.Configs.InventorySlots; i++)
            {
                InventorySlot slot = Instantiate(_inventorySlotPrefab, _itemSlotsContainer.transform);
                _inventorySlots.Add(slot);
                slot.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            SetInventorySlots();
        }

        private void SetInventorySlots()
        {
            int slotIndex = 0;

            foreach (KeyValuePair<Item,int> playerItem in _playerInventory.InventoryItems)
            {
                _inventorySlots[slotIndex].SetupSlot(playerItem.Key, playerItem.Value);
                slotIndex++;
            }
        }
    }
}
