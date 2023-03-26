using System.Collections.Generic;
using UnityEngine;

namespace LittleSimPrototype.Inventory
{
    public class Inventory : MonoBehaviour
    {
        private Dictionary<Item, int> _inventoryItems = new();

        public ItemRequestResponse AddItem(Item item, int quantity)
        {
            if (quantity <= 0)
            {
                Debug.LogWarning("Couldn't add item. Invalid quantity :: " + quantity);
                return null;
            }

            if (!_inventoryItems.ContainsKey(item))
            {
                _inventoryItems.Add(item, 0);
            }

            _inventoryItems[item] += quantity;

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

            return new ItemRequestResponse(ItemRequestStatus.Success, item, _inventoryItems[item]);
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
