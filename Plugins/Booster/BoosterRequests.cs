using System.Threading.Tasks;

namespace HZBot
{
    public static class BoosterRequests
    {
        #region Methods

        public static async Task<string> BuyBoosterAsync(this HzPluginBase plugin, Booster booster)
        {
            var error = await plugin.Account.DefaultRequestContent("buyBooster")
                 .AddKeyValue("rct", "2")
                 .AddKeyValue("user_id", plugin.Account.Character.id)
                 .AddKeyValue("id", booster.Id)
                 .AddLog("StartDuel...")
                 .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}