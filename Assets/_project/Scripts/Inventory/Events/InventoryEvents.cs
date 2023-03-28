using System;
using System.Collections.Generic;

namespace LittleSimPrototype.Inventory
{
    public static class InventoryEvents
    {
        public static event Action<List<EquipableSprite>> OnItemEquipedEvent;
        public static void NotifyItemEquiped(List<EquipableSprite> equipableSpriteList) => OnItemEquipedEvent?.Invoke(equipableSpriteList);

        public static event Action<Item, int> OnItemUpdateEvent;
        public static void NotifyItemUpdate(Item item, int quantity) => OnItemUpdateEvent?.Invoke(item, quantity);

        public static event Action OnRequestPlayerItemDataEvent;
        public static void RequestPlayerItemData() => OnRequestPlayerItemDataEvent?.Invoke();

        public static event Action<PlayerItemData> OnPlayerItemDataResponseEvent;
        public static void NotifyPlayerDataResponse(PlayerItemData playerItemData) => OnPlayerItemDataResponseEvent?.Invoke(playerItemData);

        public static event Action<int> OnPlayerMoneyUpdateEvent;
        public static void NotifyPlayerMoneyUpdate(int money) => OnPlayerMoneyUpdateEvent?.Invoke(money);
    }
}
