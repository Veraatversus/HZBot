using System.Threading.Tasks;

namespace HZBot
{
    public static class ItemRequests
    {
        #region Methods

        public static async Task<string> MoveInventoryItemAsync(this HzPluginBase plugin, int ItemId, InventoryAction moveType, HzInventoryId targetSlot)
        {
            return await plugin.Account.DefaultRequestContent("moveInventoryItem")
             .AddKeyValue("action_type", (int)moveType)
             .AddKeyValue("item_id", ItemId)
             .AddKeyValue("target_slot", (int)targetSlot)
             .AddKeyValue("rct", "2")
             .AddLog($"[Item] {moveType.ToString()}: {ItemId}")
             .PostToHzAsync();
        }

        public static async Task<string> SellInventoryItemAsync(this HzPluginBase plugin, int ItemId)
        {
            return await plugin.Account.DefaultRequestContent("sellInventoryItem")
             .AddKeyValue("item_id", ItemId)
             .AddKeyValue("rct", "2")
             .AddLog($"[Item] Sell: {ItemId}")
             .PostToHzAsync();
        }

        #endregion Methods
    }
}