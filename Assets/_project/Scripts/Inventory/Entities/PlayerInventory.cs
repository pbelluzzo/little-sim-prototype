using LittleSimPrototype.ShopSystem;
using UnityEngine;

namespace LittleSimPrototype.Inventory
{
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] private InventoryConfigs _configs;
        public InventoryConfigs Configs { get => _configs; }

        [SerializeField] private PlayerItemData _playerItemData;
        public PlayerItemData PlayerItemData { get => _playerItemData; }

        private void Start()
        {
            _playerItemData.Money = _configs.StartingMoney;
            _playerItemData.InventoryItems.Clear();

            foreach(Item item in _configs.StartingItems)
            {
                AddItem(item, 1);
            }
        }

        private void OnEnable()
        {
            InventoryEvents.OnRequestPlayerItemDataEvent += HandleRequestPlayerItemData;

            ShopEvents.OnItemBoughtEvent += HandleItemBought;
            ShopEvents.OnItemSoldEvent += HandleItemSold;
        }

        private void OnDisable()
        {
            InventoryEvents.OnRequestPlayerItemDataEvent -= HandleRequestPlayerItemData;

            ShopEvents.OnItemBoughtEvent -= HandleItemBought;
            ShopEvents.OnItemSoldEvent -= HandleItemSold;
        }

        public ItemRequestResponse AddItem(Item item, int quantity = 1)
        {
            if (quantity <= 0)
            {
                Debug.LogWarning("Couldn't add item. Invalid quantity :: " + quantity);
                return new ItemRequestResponse(ItemRequestStatus.InvalidQuantity);
            }

            bool inventoryHasItem = _playerItemData.InventoryItems.ContainsKey(item);

            if (_configs.InventorySlots <= _playerItemData.InventoryItems.Count && inventoryHasItem == false)
            {
                return new ItemRequestResponse(ItemRequestStatus.InventoryIsFull);
            }

            if (!inventoryHasItem)
            {
                _playerItemData.InventoryItems.Add(item, 0);
            }

            _playerItemData.InventoryItems[item] += quantity;

            InventoryEvents.NotifyItemUpdate(item, _playerItemData.InventoryItems[item]);

            return new ItemRequestResponse(ItemRequestStatus.Success, item, _playerItemData.InventoryItems[item]);
        }

        public ItemRequestResponse RemoveItem(Item item, int quantity)
        {
            if (quantity <= 0)
            {
                Debug.LogWarning("Couldn't remove item. Invalid quantity :: " + quantity);
                return null;
            }

            ItemRequestResponse response;

            if (!_playerItemData.InventoryItems.ContainsKey(item) || _playerItemData.InventoryItems[item] < quantity)
            {
                response = new(ItemRequestStatus.DoesNotContain);
                return response;
            }

            _playerItemData.InventoryItems[item] -= quantity;

            InventoryEvents.NotifyItemUpdate(item, _playerItemData.InventoryItems[item]);

            response =  new ItemRequestResponse(ItemRequestStatus.Success, item, _playerItemData.InventoryItems[item]);

            if (_playerItemData.InventoryItems[item] > 0)
            {
                return response;
            }

            _playerItemData.InventoryItems.Remove(item);
            return response;
        }

        public ItemRequestResponse GetItem(Item item)
        {
            ItemRequestResponse response;

            if (!_playerItemData.InventoryItems.ContainsKey(item) || _playerItemData.InventoryItems[item] <= 0)
            {
                response = new(ItemRequestStatus.DoesNotContain);
                return response;
            }

            response = new(ItemRequestStatus.Success, item, _playerItemData.InventoryItems[item]);
            return response;
        }

        private void HandleRequestPlayerItemData()
        {
            InventoryEvents.NotifyPlayerDataResponse(_playerItemData);
        }

        private void HandleItemBought(ShopItem shopItem)
        {
            if (_playerItemData.Money < shopItem.Price)
            {
                Debug.LogWarning("Not Enought Money");
                return;
            }

            ItemRequestResponse response = AddItem(shopItem.Item);

            if (response.RequestStatus != ItemRequestStatus.Success)
            {
                Debug.LogWarning("Item buy failed with request status : " + response.RequestStatus);
                return;
            }
            
            _playerItemData.Money -= shopItem.Price;
        }

        private void HandleItemSold(ShopItem shopItem, int price)
        {
            ItemRequestResponse response = RemoveItem(shopItem.Item, 1);

            if (response.RequestStatus != ItemRequestStatus.Success)
            {
                Debug.LogWarning("Item sell failed with request status : " + response.RequestStatus);
                return;
            }

            _playerItemData.Money += price;
        }

    }
}
