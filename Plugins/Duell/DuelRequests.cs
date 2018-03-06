using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HZBot
{
    public static class DuelRequests
    {
        #region Methods

        /// <summary>Starts the duell asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="charID">The character identifier.</param>
        /// <param name="usePremiumCurrency">if set to <c>true</c> [use premium currency].</param>
        /// <returns></returns>
        public static async Task<JObject> StartDuellAsync(this DuelPlugin plugin, string charID, bool usePremiumCurrency = false)
        {
            plugin.Account.Log.Add($"[DUEL]Start Duel!");
            var error = await plugin.Account.DefaultRequestContent("startDuel")
                 .AddKeyValue("character_id", charID)
                 .AddKeyValue("use_premium", usePremiumCurrency.ToString().ToLower())
                 .AddKeyValue("rct", "2")
                 .PostToHzAsync();
            return error;
        }

        /// <summary>Checks for duel complete asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<JObject> CheckForDuelCompleteAsync(this DuelPlugin plugin)
        {
            plugin.Account.Log.Add($"[DUEL]CheckForComplete");
            var error = await plugin.Account.DefaultRequestContent("checkForDuelComplete")
                .AddKeyValue("rct", "2")
                .PostToHzAsync();
            
            return error;
        }

        /// <summary>Claims the duel rewards asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<JObject> ClaimDuelRewardsAsync(this DuelPlugin plugin)
        {
            plugin.Account.Log.Add($"[DUEL]Claim Rewards!");
            var error = await plugin.Account.DefaultRequestContent("claimDuelRewards")
                .AddKeyValue("rct", "2")
                .AddKeyValue("discard_item", "false")
                .PostToHzAsync();
            
            return error;
        }

        /// <summary>Gets the duel opponents asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<JObject> GetDuelOpponentsAsync(this HzPluginBase plugin)
        {
            plugin.Account.Log.Add($"[DUEL]GET OPPONENTS ");
            var error = await plugin.Account.DefaultRequestContent("getDuelOpponents")
                .AddKeyValue("rct", "1")

                .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}