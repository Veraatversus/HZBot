using System.Linq;
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
            var error = await plugin.Account.DefaultRequestContent("startDuel")
                 .AddKeyValue("character_id", charID)
                 .AddKeyValue("use_premium", usePremiumCurrency.ToString().ToLower())
                 .AddKeyValue("rct", "2")
                 .AddLog("StartDuel...")
                 .PostToHzAsync();
            return error;
        }

        /// <summary>Checks for duel complete asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<string> CheckForDuelCompleteAsync(this DuelPlugin plugin)
        {
            var error = await plugin.Account.DefaultRequestContent("checkForDuelComplete")
                .AddKeyValue("rct", "2")
                .AddLog($"CheckDuelComplete...")
                .PostToHzAsync();

            return error;
        }

        /// <summary>Claims the duel rewards asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<string> ClaimDuelRewardsAsync(this DuelPlugin plugin)
        {
            // Editiere DuelHistory ob Gewonnen
            if (plugin.DuelList != null)
            {
                var index = plugin.DuelList.FirstOrDefault(c => c.id == plugin.Account.Data.ActiveDuel.character_b_id);
                if (index != null)
                    index.Status = (plugin.Account.Data.duel.character_a_status == 2 ? 1 : 0);
            }
            var error = await plugin.Account.DefaultRequestContent("claimDuelRewards")
                .AddKeyValue("rct", "2")
                .AddKeyValue("discard_item", "false")
                .AddLog($"ClaimDuelReward: Status={(plugin.Account.Data.duel.character_a_status == 2 ? "Gewonnen" : "Verloren!")}")
                .PostToHzAsync();

            return error;
        }

        /// <summary>Gets the duel opponents asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<string> GetDuelOpponentsAsync(this HzPluginBase plugin)
        {
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
            var error = await plugin.Account.DefaultRequestContent("retrieveLeaderboard")
                .AddKeyValue("rct", "2")
                .AddKeyValue("level_sort", "true")
                .AddKeyValue("character_name", plugin.Account.Character.name.ToString())
                .AddKeyValue("same_locale", "false")
                .PostToHzAsync();
            return error;
        }

        /// <summary>
        /// Gets the character asynchronous.
        /// </summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="CharID">The character identifier.</param>
        /// <returns></returns>
        public static async Task<string> GetCharacterAsync(this HzPluginBase plugin, string CharID)
        {
            var error = await plugin.Account.DefaultRequestContent("getCharacter")
                .AddKeyValue("rct", "2")
                .AddKeyValue("character_id", CharID)
                .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}