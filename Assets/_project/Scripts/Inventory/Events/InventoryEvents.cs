using System;

namespace LittleSimPrototype.Inventory
{
    public static class InventoryEvents
    {
        public static event Action<string> OnItemEquipedEvent;
        public static void NotifyItemEquiped(string itemLabel) => OnItemEquipedEvent?.Invoke(itemLabel);

        public static event Action<Item, int> OnItemUpdateEvent;
        public static void NotifyItemUpdate(Item item, int quantity) => OnItemUpdateEvent?.Invoke(item, quantity);
    }
}
