using System;

namespace LittleSimPrototype.ShopSystem
{
    public static class ShopEvents 
    {
        public static event Action<ShopItem> OnItemBoughtEvent;
        public static void NotifyItemBought(ShopItem item) => OnItemBoughtEvent?.Invoke(item);

        public static event Action<ShopItem, int> OnItemSoldEvent;
        public static void NotifyItemSold(ShopItem item, int pricePaid) => OnItemSoldEvent?.Invoke(item, pricePaid);
    }
}