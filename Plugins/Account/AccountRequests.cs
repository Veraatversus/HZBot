using System.Threading.Tasks;

namespace HZBot
{
    public static class AccountRequests
    {
        #region Methods

        /// <summary>Logins the Account asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<string> LoginRequestAsync(this HzPluginBase plugin)
        {
            return await plugin.Account.DefaultRequestContent("loginUser")
             .AddKeyValue("platform_user_id", "0")
             .AddKeyValue("platform", "web")
             .AddKeyValue("device_info", "{\"screenResolutionY\":1200,\"pixelAspectRatio\":1,\"os\":\"Windows 10\",\"touchscreenType\":\"none\",\"screenDPI\":72,\"version\":\"WIN 28,0,0,161\",\"screenResolutionX\":1920,\"language\":\"de\"}")
             .AddKeyValue("email", plugin.Account.Config.Username)
             .AddKeyValue("client_id", "s151518213457")
             .AddKeyValue("app_version", 144)
             .AddKeyValue("password", plugin.Account.Config.Password)
             .AddKeyValue("rct", "1")
             .AddLog($"[Account] LoginUser:{plugin.Account.Config.Username}")
             .PostToHzAsync();
        }

        #endregion Methods
    }
}