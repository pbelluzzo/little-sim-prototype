using System;

namespace LittleSimPrototype.Inventory
{
    public static class InventoryEvents
    {
        public static event Action<string, bool> OnItemEquipedEvent;
        public static void NotifyItemEquiped(string itemLabel, bool isEquipped) => OnItemEquipedEvent?.Invoke(itemLabel, isEquipped);

        public static event Action<Item, int> OnItemUpdateEvent;
        public static void NotifyItemUpdate(Item item, int quantity) => OnItemUpdateEvent?.Invoke(item, quantity);

        public static event Action OnRequestPlayerItemDataEvent;
        public static void RequestPlayerItemData() => OnRequestPlayerItemDataEvent?.Invoke();

        public static event Action<PlayerItemData> OnPlayerItemDataResponseEvent;
        public static void NotifyPlayerDataResponse(PlayerItemData playerItemData) => OnPlayerItemDataResponseEvent?.Invoke(playerItemData);
    }
}
