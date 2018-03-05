using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HZBot
{
    public static class AccountRequests
    {
        #region Methods

        /// <summary>Logins the Account asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<JObject> LoginRequestAsync(this HzPluginBase plugin)
        {
            plugin.Account.Log.Add($"[Loggin] User:{plugin.Account.Username}");
            return await plugin.Account.DefaultRequestContent("loginUser")
             .AddKeyValue("platform_user_id", "0")
             .AddKeyValue("platform", "web")
             .AddKeyValue("device_info", "{\"screenResolutionY\":1200,\"pixelAspectRatio\":1,\"os\":\"Windows 10\",\"touchscreenType\":\"none\",\"screenDPI\":72,\"version\":\"WIN 28,0,0,161\",\"screenResolutionX\":1920,\"language\":\"de\"}")
             .AddKeyValue("email", plugin.Account.Username)
             .AddKeyValue("client_id", "s151518213457")
             .AddKeyValue("app_version", 144)
             .AddKeyValue("password", plugin.Account.Password)
             .AddKeyValue("rct", "1")
             .PostToHzAsync();
        }

        #endregion Methods
    }
}