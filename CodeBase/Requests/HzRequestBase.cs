using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HZBot
{
    public static class HzRequestBase
    {
        #region Fields

        public const string RequestUrl = "http://s15.herozerogame.com/request.php";

        #endregion Fields

        #region Constructors

        static HzRequestBase()
        {
            InitHttpClient();
        }

        #endregion Constructors

        #region Methods

        /// <summary>Adds the key value.</summary>
        /// <param name="content">The content.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static PostContent AddKeyValue(this PostContent content, object key, object value)
        {
            content.Content.Add(new KeyValuePair<string, string>(key.ToString(), value.ToString()));
            return content;
        }

        /// <summary>Adds the log.</summary>
        /// <param name="content">The content.</param>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        public static PostContent AddLog(this PostContent content, string text)
        {
            content.LogObject.Text = text;
            content.LogObject.Time = DateTime.Now;
            content.Account.Plugins.Log.Add(content.LogObject);

            return content;
        }

        /// <summary>Gets the default HttpRequest content.</summary>
        /// <param name="action">The action.</param>
        /// <param name="account">The account.</param>
        /// <returns></returns>
        public static PostContent DefaultRequestContent(this HzAccount account, string action)
        {
            var UserId = account.User?.id ?? 0;
            var UserSessionId = account.User?.session_id ?? "0";
            var content = new PostContent();
            content.Content = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("device_type", "web"),
                new KeyValuePair<string, string>("client_version", "flash_145"),
                new KeyValuePair<string, string>("user_id", UserId.ToString()),
                new KeyValuePair<string, string>("user_session_id", UserSessionId),
                new KeyValuePair<string, string>("auth", HzConstants.MD5Hash(action, UserId.ToString())),
                new KeyValuePair<string, string>("action", action)
            };
            content.Account = account;
            return content;
        }

        /// <summary>Posts the specified content to the server.</summary>
        /// <param name="content">The content.</param>
        /// <returns>The error string or null</returns>
        public static async Task<string> PostToHzAsync(this PostContent content)
        {
            content.Account.Log.AddRequestLog(content.Content.FirstOrDefault(keyval => keyval.Key == "action").Value);
            content.LogObject.RequestState = RequestState.Pending;
            using (var formUrlEncodedContent = new FormUrlEncodedContent(content.Content))
            {
               
                var response = await client.PostAsync(RequestUrl, formUrlEncodedContent);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var obj = JObject.Parse(json);
                    var error = obj["error"];
                    if (!string.IsNullOrWhiteSpace(error.ToString()))
                    {
                        content.LogObject.RequestState = RequestState.Error;
                        content.LogObject.Tooltip = error.Value<string>();
                        content.Account.Log.AddErrorLog(error.Value<string>());
                        content.Account.Plugins.RaiseOnHandleError(error.Value<string>());
                        // MessageBox.Show(error.Value<string>());
                        return error.Value<string>();
                    }
                    content.Account.MergeNewData(obj);
                    content.LogObject.RequestState = RequestState.Success;
                    //content.Account.Log.Add($"Action {content.Content.FirstOrDefault(a => a.Key == "action").Value} Success");

                    //   return obj;
                }
                else
                {
                    content.LogObject.RequestState = RequestState.Error;
                }
            }
            return null;
        }

        /// <summary>Merges the new data into the Accout</summary>
        /// <param name="jobj">The new JObject to merge.</param>
        /// <param name="account">The account.</param>
        public static void MergeNewData(this HzAccount account, JObject jobj)
        {
            account.ServerTimeOffset = jobj["data"]["server_time"].Value<long>() - DateTimeOffset.Now.ToUnixTimeSeconds();
            var updateQuest = jobj.SelectToken("data.quest");
            if (updateQuest != null)
            {
                var questToUpdate = account.JsonData["data"]?["quests"]?.OfType<JContainer>().FirstOrDefault(quest => quest["id"]?.Value<int>() == updateQuest["id"]?.Value<int>());
                if (questToUpdate != null)
                {
                    questToUpdate.Merge(updateQuest);
                }
            }
            var updateRoom = jobj.SelectToken("data.hideout_room");
            if (updateRoom != null)
            {
                var roomToUpdate = account.JsonData["data"]?["hideout_rooms"]?.OfType<JContainer>().FirstOrDefault(room => room["id"]?.Value<int>() == updateRoom["id"]?.Value<int>());
                if (roomToUpdate != null)
                {
                    roomToUpdate.Merge(updateRoom);
                }
            }
            if (jobj.SelectToken("data.quests")?.HasValues ?? false)
            {
                var quests = account.JsonData.Descendants().OfType<JProperty>().FirstOrDefault(prop => prop.Name == "quests");
                if (quests != null)
                {
                    quests.Remove();
                }
            }
            if (jobj.SelectToken("data.opponents")?.HasValues ?? false)
            {
                var opponents = account.JsonData.Descendants().OfType<JProperty>().FirstOrDefault(prop => prop.Name == "opponents");
                if (opponents != null)
                {
                    opponents.Remove();
                }
            }
            if (jobj.SelectToken("data.hideout_rooms")?.HasValues ?? false)
            {
                var hideoutRooms = account.JsonData.Descendants().OfType<JProperty>().FirstOrDefault(prop => prop.Name == "hideout_rooms");
                if (hideoutRooms != null)
                {
                    hideoutRooms.Remove();
                }
            }

            account.JsonData.Merge(jobj);
            account.MainData = account.JsonData.ToObject<JsonRoot>();
        }

        #endregion Methods

        private static HttpClient client;

        /// <summary>Initializes the HTTP client.</summary>
        private static void InitHttpClient()
        {
            var msgHandler = new HttpClientHandler()
            {
                AutomaticDecompression = System.Net.DecompressionMethods.Deflate | System.Net.DecompressionMethods.GZip,
                AllowAutoRedirect = true,
                UseDefaultCredentials = true
            };

            client = new HttpClient(msgHandler);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Host", "s15.herozerogame.com");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Origin", "http://hz--2.akamaized.net");
            client.DefaultRequestHeaders.TryAddWithoutValidation("X-Requested-With", "ShockwaveFlash/28.0.0.161");
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.167 Safari/537.36");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Referer", "http://hz--2.akamaized.net/swf/main_new.swf?664c63b039bf785c18887862aec49a30");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9,de-DE;q=0.8,de;q=0.7");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
        }
    }
}