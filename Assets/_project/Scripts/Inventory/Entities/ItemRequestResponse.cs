namespace LittleSimPrototype.Inventory
{
    public class ItemRequestResponse
    {
        public ItemRequestStatus RequestStatus;

        public Item InventoryItem;
        public float ItemQuantity;

        public ItemRequestResponse(ItemRequestStatus requestStatus, Item inventoryItem, int itemQuantity)
        {
            RequestStatus = requestStatus;
            InventoryItem = inventoryItem;
            ItemQuantity = itemQuantity;
        }
        public ItemRequestResponse(ItemRequestStatus requestStatus)
        {
            RequestStatus = requestStatus;
        }
    }

    public enum ItemRequestStatus
    {
        Success,
        DoesNotContain,
        InventoryIsFull,
    }

}
