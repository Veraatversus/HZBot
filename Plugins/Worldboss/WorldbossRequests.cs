using System.Threading.Tasks;

namespace HZBot
{
    public static class WorldbossRequests
    {
        #region Methods

        public static async Task<string> StartWorldbossAttackAsync(this HzPluginBase plugin, int worldboss_event_id)
        {
            plugin.Account.Log.Add($"[WORLDBOSS]Start Attack!");
            var error = await plugin.Account.DefaultRequestContent("startWorldbossAttack")
                .AddKeyValue("rct", "2")
                .AddKeyValue("worldboss_event_id", worldboss_event_id)
                .PostToHzAsync();
            return error;
        }

        public static async Task<string> CheckForWorldbossAttackCompleteAsync(this HzPluginBase plugin)
        {
            plugin.Account.Log.Add($"[WORLDBOSS]Check Complete!");
            var error = await plugin.Account.DefaultRequestContent("checkForWorldbossAttackComplete")
                .AddKeyValue("rct", "2")
                .PostToHzAsync();
            return error;
        }

        public static async Task<string> FinishWorldbossAttackAsync(this HzPluginBase plugin, int worldboss_event_id)
        {
            plugin.Account.Log.Add($"[WORLDBOSS]Finish Attack!");
            var error = await plugin.Account.DefaultRequestContent("finishWorldbossAttack")
                .AddKeyValue("rct", "2")
                .AddKeyValue("worldboss_event_id", worldboss_event_id)
                .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}