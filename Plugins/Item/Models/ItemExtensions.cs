namespace HZBot
{
    public static class ItemExtensions
    {
        #region Methods

        public static HzInventoryId EquipSlot(this Item item)
        {
            return item.type > 0 && item.type <= ItemType.Missiles ? (HzInventoryId)((int)(item.type)) : HzInventoryId.Unknown;
        }

        #endregion Methods
    }
}