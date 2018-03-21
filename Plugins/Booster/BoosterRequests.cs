using System.Threading.Tasks;

namespace HZBot
{
    public static class BoosterRequests
    {
        #region Methods

        public static async Task<string> BuyBoosterAsync(this HzPluginBase plugin, string booster)
        {
            var error = await plugin.Account.DefaultRequestContent("buyBooster")
                 .AddKeyValue("rct", "1")
                 .AddKeyValue("id", booster)
                 .AddLog("Folgender Booster wurde gekauft: " + booster)
                 .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}