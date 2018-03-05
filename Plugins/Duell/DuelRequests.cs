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
        public static async Task<JObject> StartDuellAsync(this HzPluginBase plugin, string charID, bool usePremiumCurrency = false)
        {
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
        public static async Task<JObject> CheckForDuelCompleteAsync(this HzPluginBase plugin)
        {
            var error = await plugin.Account.DefaultRequestContent("checkForDuelComplete")
                .AddKeyValue("rct", "1")
                .PostToHzAsync();
            plugin.Account.Log.Add($"[DUELL]END: Gegner:{plugin.Account.Data.BestDuel.name} Gewonnen:{plugin.Account.Data.battle.winner}");
            return error;
        }

        /// <summary>Claims the duel rewards asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<JObject> ClaimDuelRewardsAsync(this HzPluginBase plugin)
        {
            var error = await plugin.Account.DefaultRequestContent("claimDuelRewards")
                .AddKeyValue("rct", "2")
                .PostToHzAsync();
            plugin.Account.Log.Add($"[DUELL]END: Gegner:{plugin.Account.Data.BestDuel.name} Gewonnen:{plugin.Account.Data.battle.winner}");
            return error;
        }

        /// <summary>Gets the duel opponents asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<JObject> GetDuelOpponentsAsync(this HzPluginBase plugin)
        {
            var error = await plugin.Account.DefaultRequestContent("getDuelOpponents")
                .AddKeyValue("rct", "1")
                .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}