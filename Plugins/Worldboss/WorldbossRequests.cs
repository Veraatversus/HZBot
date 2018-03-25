using System.Threading.Tasks;

namespace HZBot
{
    public static class WorldbossRequests
    {
        #region Methods

        /// <summary>Starts the worldboss attack asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="worldboss_event_id">The worldboss event identifier.</param>
        /// <returns></returns>
        public static async Task<string> StartWorldbossAttackAsync(this HzPluginBase plugin, int worldboss_event_id)
        {
            var error = await plugin.Account.DefaultRequestContent("startWorldbossAttack")
                .AddKeyValue("rct", "2")
                .AddKeyValue("worldboss_event_id", worldboss_event_id)
                .AddLog($"[WORLDBOSS] Start Attack!")
                .PostToHzAsync();
            return error;
        }

        //public static async Task<string> CheckForWorldbossAttackCompleteAsync(this HzPluginBase plugin)
        //{
        //    var error = await plugin.Account.DefaultRequestContent("checkForWorldbossAttackComplete")
        //        .AddKeyValue("rct", "2")
        //        .AddLog($"[WORLDBOSS] Check Complete!")
        //        .PostToHzAsync();
        //    return error;
        //}

        /// <summary>Finishes the worldboss attack asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="worldboss_event_id">The worldboss event identifier.</param>
        /// <returns></returns>
        public static async Task<string> AssignWorldbossEventAsync(this HzPluginBase plugin, int worldboss_event_id)
        {
            var error = await plugin.Account.DefaultRequestContent("assignWorldbossEvent")
                .AddKeyValue("rct", "2")
                .AddKeyValue("worldboss_event_id", worldboss_event_id)
                .AddLog($"[WORLDBOSS] Assign Worldboss!")
                .PostToHzAsync();
            return error;
        }

        public static async Task<string> FinishWorldbossAttackAsync(this HzPluginBase plugin, int worldboss_event_id)
        {
            var error = await plugin.Account.DefaultRequestContent("finishWorldbossAttack")
                .AddKeyValue("rct", "2")
                .AddKeyValue("worldboss_event_id", worldboss_event_id)
                .AddLog($"[WORLDBOSS] Finish Attack!")
                .PostToHzAsync();
            return error;
        }

        /// <summary>Claims the worldboss event rewards asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="worldboss_event_id">The worldboss event identifier.</param>
        /// <returns></returns>
        public static async Task<string> ClaimWorldbossEventRewardsAsync(this HzPluginBase plugin, int worldboss_event_id)
        {
            var error = await plugin.Account.DefaultRequestContent("claimWorldbossEventRewards")
                .AddKeyValue("discard_item", "false")
                .AddKeyValue("rct", "2")
                .AddKeyValue("worldboss_event_id", worldboss_event_id)
                .AddLog($"[WORLDBOSS] Claim Rewards")
                .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}