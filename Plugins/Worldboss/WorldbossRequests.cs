using System.Threading.Tasks;

namespace HZBot
{
    public static class WorldbossRequests
    {
        #region Methods

        public static async Task<string> StartWorldbossAttackAsync(this HzPluginBase plugin, int worldboss_event_id)
        {
            var error = await plugin.Account.DefaultRequestContent("startWorldbossAttack")
                .AddKeyValue("rct", "2")
                .AddKeyValue("worldboss_event_id", worldboss_event_id)
                .AddLog($"[WORLDBOSS] Start Attack!")
                .PostToHzAsync();
            return error;
        }

        public static async Task<string> CheckForWorldbossAttackCompleteAsync(this HzPluginBase plugin)
        {
            var error = await plugin.Account.DefaultRequestContent("checkForWorldbossAttackComplete")
                .AddKeyValue("rct", "2")
                .AddLog($"[WORLDBOSS] Check Complete!")
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

        #endregion Methods
    }
}