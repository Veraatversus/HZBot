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
        public static async Task<string> StartDuellAsync(this DuelPlugin plugin, string charID, bool usePremiumCurrency = false)
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
        public static async Task<string> CheckForDuelCompleteAsync(this DuelPlugin plugin)
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
        public static async Task<string> ClaimDuelRewardsAsync(this DuelPlugin plugin)
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
        public static async Task<string> GetDuelOpponentsAsync(this HzPluginBase plugin)
        {
            plugin.Account.Log.Add($"[DUEL]GET OPPONENTS ");
            var error = await plugin.Account.DefaultRequestContent("getDuelOpponents")
                .AddKeyValue("rct", "1")

                .PostToHzAsync();
            return error;
        }

        /// <summary>Gets Leaderboard asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<string> GetLeaderboardAsync(this HzPluginBase plugin)
        {
            plugin.Account.Log.Add($"[DUEL]GET Leaderboard!");
            var error = await plugin.Account.DefaultRequestContent("retrieveLeaderboard")
                .AddKeyValue("rct", "2")
                .AddKeyValue("level_sort", "true")
                .AddKeyValue("character_name", plugin.Account.Character.name.ToString())
                .AddKeyValue("same_locale", "false")
                .PostToHzAsync();
            return error;
        }

        /// <summary>Get Character asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<string> GetCharacterAsync(this HzPluginBase plugin, string CharID)
        {
            plugin.Account.Log.Add($"[DUEL]GET Leaderboard!");
            var error = await plugin.Account.DefaultRequestContent("getCharacter")
                .AddKeyValue("rct", "2")
                .AddKeyValue("character_id", CharID)
                .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}