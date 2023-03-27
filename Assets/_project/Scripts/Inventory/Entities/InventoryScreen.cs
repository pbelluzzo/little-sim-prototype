using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using LittleSimPrototype.UI;

namespace LittleSimPrototype.Inventory
{
    public class InventoryScreen : UIScreen
    {
        [SerializeField] private InventorySlot _inventorySlotPrefab;
        [SerializeField] private GameObject _itemSlotsContainer;
        [SerializeField] private PlayerInventory _playerInventory;

        private List<InventorySlot> _inventorySlots = new();
        private List<InventorySlot> _freeSlots = new();

        private void Start()
        {
            for (int i = 0; i < _playerInventory.Configs.InventorySlots; i++)
            {
                InventorySlot slot = Instantiate(_inventorySlotPrefab, _itemSlotsContainer.transform);
                _inventorySlots.Add(slot);
                _freeSlots.Add(slot);
                slot.gameObject.SetActive(false);
            }
        }

        private void OnEnable()
        {
            InventoryEvents.OnItemUpdateEvent += HandleItemUpdate;
            SetInventorySlots();
        }

        private void OnDisable()
        {
            InventoryEvents.OnItemUpdateEvent -= HandleItemUpdate;
        }

        private void SetInventorySlots()
        {
            _freeSlots = _inventorySlots;

            int slotIndex = 0;

            foreach (KeyValuePair<Item, int> playerItem in _playerInventory.InventoryItems)
            {
                _inventorySlots[slotIndex].SetupSlot(playerItem.Key, playerItem.Value);
                _freeSlots.Remove(_inventorySlots[slotIndex]);
                slotIndex++;
            }
        }

        private void AddItem(Item item, int quantity, InventorySlot slotWithItem)
        {
            if (slotWithItem != null)
            {
                slotWithItem.QuantityText = quantity.ToString();
                return;
            }

            InventorySlot slot = _freeSlots[0];
            slot.gameObject.SetActive(true);
            _freeSlots.Remove(slot);
            slot.SetupSlot(item, quantity);
        }

        private void RemoveItem(InventorySlot slot)
        {
            if (slot == null)
            {
                Debug.LogWarning("Attempt to remove inventory item failed. No slots containing the item were found.");
                return;
            }

            slot.RemoveItem();
            _freeSlots.Insert(0, slot);
            slot.gameObject.SetActive(false);
        }
        private void HandleItemUpdate(Item item, int quantity)
        {
            InventorySlot slotWithItem = _inventorySlots.Where(s => s.EquipedItem == item).FirstOrDefault();

            if (quantity <= 0)
            {
                RemoveItem(slotWithItem);
                return;
            }

            AddItem(item, quantity, slotWithItem);
        }
    }
}
