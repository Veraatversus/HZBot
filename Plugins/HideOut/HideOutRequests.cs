using System.Threading.Tasks;

namespace HZBot
{
    public static class HideOutRequests
    {
        #region Methods

        /// <summary>Collects the hideout room activity result asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="hideOurRoom">The hide our room.</param>
        /// <returns></returns>
        public static async Task<string> CollectHideoutRoomActivityResultAsync(this HzPluginBase plugin, HideOutRoom hideOurRoom)
        {
            return await plugin.Account.DefaultRequestContent("collectHideoutRoomActivityResult")
             .AddKeyValue("hideout_room_id", hideOurRoom.id)
             .AddKeyValue("rct", "1")
             .AddLog($"[HideOut] Claim Reward:{hideOurRoom.id}")
             .PostToHzAsync();
        }

        /// <summary>Gets the hideout opponent asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<string> GetHideoutOpponentAsync(this HzPluginBase plugin)
        {
            return await plugin.Account.DefaultRequestContent("getHideoutOpponent")
             .AddKeyValue("rct", "2")
             .AddLog($"[HideOut] Get Opponent")
             .PostToHzAsync();
        }

        /// <summary>Checks the hideout room activity finished asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="room">The room.</param>
        /// <returns></returns>
        public static async Task<string> CheckHideoutRoomActivityFinishedAsync(this HzPluginBase plugin, HideOutRoom room)
        {
            return await plugin.Account.DefaultRequestContent("checkHideoutRoomActivityFinished")
             .AddKeyValue("hideout_room_id", room.id)
             .AddKeyValue("rct", "2")
             .AddLog($"[HideOut] Check For Complete")
             .PostToHzAsync();
        }

        /// <summary>Upgrades the hideout room asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="room">The room.</param>
        /// <param name="ignoreResource">if set to <c>true</c> [ignore resource].</param>
        /// <returns></returns>
        public static async Task<string> UpgradeHideoutRoomAsync(this HzPluginBase plugin, HideOutRoom room, bool ignoreResource = false)
        {
            return await plugin.Account.DefaultRequestContent("upgradeHideoutRoom")
             .AddKeyValue("hideoutRoomId", room.id)
             .AddKeyValue("ignoreResource", ignoreResource.ToString().ToLower())
             .AddKeyValue("rct", "2")
             .AddLog($"[HideOut] Check For Complete")
             .PostToHzAsync();
        }

        /// <summary>Builds the hideout room asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="slot">The slot.</param>
        /// <param name="identifier">The identifier.</param>
        /// <returns></returns>
        public static async Task<string> BuildHideoutRoomAsync(this HzPluginBase plugin, HideOutRoomSlot slot, string identifier)
        {
            return await plugin.Account.DefaultRequestContent("buildHideoutRoom")
             .AddKeyValue("identifier", identifier)
             .AddKeyValue("slot", slot.Slot)
             .AddKeyValue("level", slot.Level)
             .AddKeyValue("rct", "2")
             .AddLog($"[HideOut] Build Room")
             .PostToHzAsync();
        }

        /// <summary>Unlocks the hideout room slot asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="slot">The slot.</param>
        /// <param name="identifier">The identifier.</param>
        /// <returns></returns>
        public static async Task<string> UnlockHideoutRoomSlotAsync(this HzPluginBase plugin, HideOutRoomSlot slot)
        {
            return await plugin.Account.DefaultRequestContent("unlockHideoutRoomSlot")
             .AddKeyValue("slot", slot.Slot)
             .AddKeyValue("level", slot.Level)
             .AddKeyValue("rct", "2")
             .AddLog($"[HideOut] Unlock Slot")
             .PostToHzAsync();
        }

        public static async Task<string> UnlockHideoutAsync(this HzPluginBase plugin)
        {
            return await plugin.Account.DefaultRequestContent("unlockHideout")
             .AddKeyValue("rct", "2")
             .AddLog($"[HideOut] Unlock Hideout")
             .PostToHzAsync();
        }

        #endregion Methods
    }
}