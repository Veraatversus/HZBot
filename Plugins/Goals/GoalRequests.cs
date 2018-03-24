using System.Threading.Tasks;

namespace HZBot
{
    public static class GoalRequests
    {
        #region Methods

        /// <summary>Collects the goal reward asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="goalValue">The goal.</param>
        /// <param name="discard_item">if set to <c>true</c> [discard item].</param>
        /// <returns></returns>
        public static async Task<string> CollectGoalRewardAsync(this HzPluginBase plugin, GoalValue goalValue, bool discard_item = false)
        {
            var error = await plugin.Account.DefaultRequestContent("collectGoalReward")
                 .AddKeyValue("identifier", goalValue.Goal.Name)
                 .AddKeyValue("discard_item", discard_item.ToString().ToLower())
                 .AddKeyValue("value", goalValue.Id)
                 .AddKeyValue("rct", "2")
                 .AddLog($"[Goal] Collect Goal {goalValue.Goal.Name}, Value {goalValue.Id}")
                 .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}