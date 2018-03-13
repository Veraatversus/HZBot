using System.Threading.Tasks;

namespace HZBot
{
    public static class BoosterRequests
    {
        #region Methods

        public static async Task<string> BuyBoosterAsync(this HzPluginBase plugin, Booster booster)
        {
            var error = await plugin.Account.DefaultRequestContent("startDuel")
                 .AddKeyValue("rct", "2")
                 .AddLog("StartDuel...")
                 .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}