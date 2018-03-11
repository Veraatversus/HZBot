namespace HZBot
{
    public class HzBagSlot
    {
        #region Properties

        public Item Item { get; set; }
        public HzInventorySlotType Type { get; set; }
        public HzInventoryId Id { get; set; }
        public bool IsUnlocked { get; set; }

        #endregion Properties
    }
}