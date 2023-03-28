using UnityEngine;
using System.Linq;
using System.Collections.Generic;
using LittleSimPrototype.UI;
using TMPro;

namespace LittleSimPrototype.Inventory
{
    public class InventoryScreen : UIScreen
    {
        [SerializeField] private InventorySlot _inventorySlotPrefab;
        [SerializeField] private GameObject _itemSlotsContainer;
        [SerializeField] private PlayerInventory _playerInventory;
        [SerializeField] private TextMeshProUGUI _moneyTMP;

        private List<InventorySlot> _inventorySlots = new();
        private List<InventorySlot> _freeSlots;

        private bool _isInitialized = false;

        private void Start()
        {
            SetupInventorySlots();
        }

        private void OnEnable()
        {
            InventoryEvents.OnItemUpdateEvent += HandleItemUpdate;
            InventoryEvents.OnPlayerMoneyUpdateEvent += HandlePlayerMoneyUpdate;
        }

        private void OnDisable()
        {
            InventoryEvents.OnItemUpdateEvent -= HandleItemUpdate;
            InventoryEvents.OnPlayerMoneyUpdateEvent -= HandlePlayerMoneyUpdate;
        }

        public override void Enable()
        {
            base.Enable();
            SetupInventorySlots();
        }

        private void SetupInventorySlots()
        {
            if (!_isInitialized)
            {
                InitializeInventorySlots();
            }

            _freeSlots = new(_inventorySlots);

            int slotIndex = 0;

            foreach (KeyValuePair<Item, int> playerItem in _playerInventory.PlayerItemData.InventoryItems)
            {
                _inventorySlots[slotIndex].SetupSlot(playerItem.Key, playerItem.Value);
                _freeSlots.Remove(_inventorySlots[slotIndex]);
                slotIndex++;
            }
        }

        private void InitializeInventorySlots()
        {
            for (int i = 0; i < _playerInventory.Configs.InventorySlots; i++)
            {
                InventorySlot slot = Instantiate(_inventorySlotPrefab, _itemSlotsContainer.transform);
                _inventorySlots.Add(slot);
                slot.gameObject.SetActive(false);
            }

            _isInitialized = true;
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
            InventorySlot slotWithItem = _inventorySlots.Where(s => s.SlotItem == item).FirstOrDefault();

            if (quantity <= 0)
            {
                RemoveItem(slotWithItem);
                return;
            }

            AddItem(item, quantity, slotWithItem);
        }

        private void HandlePlayerMoneyUpdate(int money)
        {
            _moneyTMP.text = money.ToString() + ",00";
        }
    }
}
