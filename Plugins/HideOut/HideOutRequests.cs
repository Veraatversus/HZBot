using System.Threading.Tasks;

namespace HZBot
{
    public static class HideOutRequests
    {
        #region Methods

        public static async Task<string> CollectHideoutRoomActivityResultAsync(this HzPluginBase plugin, HideOutRoom hideOurRoom)
        {
            return await plugin.Account.DefaultRequestContent("collectHideoutRoomActivityResult")
             .AddKeyValue("hideout_room_id", hideOurRoom.id)
             .AddKeyValue("rct", "1")
             .AddLog($"[HideOut] Claim Reward:{hideOurRoom.id}")
             .PostToHzAsync();
        }

        public static async Task<string> GetHideoutOpponentAsync(this HzPluginBase plugin)
        {
            return await plugin.Account.DefaultRequestContent("getHideoutOpponent")
             .AddKeyValue("rct", "2")
             .AddLog($"[HideOut] Get Opponent")
             .PostToHzAsync();
        }

        #endregion Methods
    }
}