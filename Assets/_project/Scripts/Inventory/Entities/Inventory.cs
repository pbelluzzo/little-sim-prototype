using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private InventoryConfigs _configs;
        public InventoryConfigs Configs { get => _configs; }

        private Dictionary<Item, int> _inventoryItems = new();
        public Dictionary<Item, int> InventoryItems { get => _inventoryItems;  }

        public ItemRequestResponse AddItem(Item item, int quantity)
        {
            if (quantity <= 0)
            {
                Debug.LogWarning("Couldn't add item. Invalid quantity :: " + quantity);
                return null;
            }

            bool inventoryHasItem = _inventoryItems.ContainsKey(item);

            if (_configs.InventorySlots <= _inventoryItems.Count && inventoryHasItem == false)
            {
                return new ItemRequestResponse(ItemRequestStatus.InventoryIsFull);
            }

            if (!inventoryHasItem)
            {
                _inventoryItems.Add(item, 0);
            }

            _inventoryItems[item] += quantity;

            InventoryEvents.NotifyItemUpdate(item, _inventoryItems[item]);

            return new ItemRequestResponse(ItemRequestStatus.Success, item, _inventoryItems[item]);
        }

        public ItemRequestResponse RemoveItem(Item item, int quantity)
        {
            if (quantity <= 0)
            {
                Debug.LogWarning("Couldn't remove item. Invalid quantity :: " + quantity);
                return null;
            }

            ItemRequestResponse response;

            if (!_inventoryItems.ContainsKey(item) || _inventoryItems[item] < quantity)
            {
                response = new(ItemRequestStatus.DoesNotContain);
                return response;
            }

            _inventoryItems[item] -= quantity;

            InventoryEvents.NotifyItemUpdate(item, _inventoryItems[item]);

            response =  new ItemRequestResponse(ItemRequestStatus.Success, item, _inventoryItems[item]);

            if (quantity > 0)
            {
                return response;
            }

            _inventoryItems.Remove(item);
            return response;
        }

        public ItemRequestResponse GetItem(Item item)
        {
            ItemRequestResponse response;

            if (!_inventoryItems.ContainsKey(item) || _inventoryItems[item] <= 0)
            {
                response = new(ItemRequestStatus.DoesNotContain);
                return response;
            }

            response = new(ItemRequestStatus.Success, item, _inventoryItems[item]);
            return response;
        }


    }
}
