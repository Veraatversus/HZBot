using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HZBot
{
    public static class HzRequests
    {
        #region Fields

        public const string RequestUrl = "http://s15.herozerogame.com/request.php";
        public static JsonRoot _mainClass;
        public static HttpClient client;

        #endregion Fields

        #region Constructors

        static HzRequests()
        {
            InitHttpClient();
        }

        #endregion Constructors

        #region Events

        public static event Action OnDataChanged;

        #endregion Events

        #region Properties

        public static JsonRoot MainClass
        {
            get
            {
                return _mainClass;
            }

            set
            {
                _mainClass = value;
                OnDataChanged?.Invoke();
            }
        }

        public static JObject MainJObject { get; set; } = new JObject();

        public static long ServerTime => DateTimeOffset.Now.ToUnixTimeSeconds() + ServerTimeOffset;

        #endregion Properties

        #region Methods

        /// <summary>Checks for worker complete.</summary>
        /// <param name="workType">Type of the work.</param>
        /// <returns></returns>
        public static async Task<JObject> CheckForWorkerCompleteAsync(WorkType workType)
        {
            var content = new List<KeyValuePair<string, string>>();
            if (workType == WorkType.Quest)
            {
                content = GetDefaultContent("checkForQuestComplete");
            }
            else if (workType == WorkType.Training)
            {
                content = GetDefaultContent("checkForTrainingComplete");
            }
            else
            {
                return null;
            }

            return await PostAsync(content);
        }

        /// <summary>Claims the worker reward.</summary>
        /// <param name="workType">Type of the work.</param>
        /// <returns></returns>
        public static async Task<JObject> ClaimWorkerRewardAsync(WorkType workType)
        {
            var content = new List<KeyValuePair<string, string>>();
            if (workType == WorkType.Quest)
            {
                content = GetDefaultContent("claimQuestRewards");
                content.Add(new KeyValuePair<string, string>("discard_item", "false"));
                content.Add(new KeyValuePair<string, string>("create_new", "true"));
            }
            else if (workType == WorkType.Training)
            {
                content = GetDefaultContent("claimTrainingRewards");
            }
            content.Add(new KeyValuePair<string, string>("rct", "2"));
            return await PostAsync(content);
        }

        /// <summary>Improves the character stat.</summary>
        /// <param name="statType">Type of the stat.</param>
        /// <param name="skillAmount">The skill amount.</param>
        /// <returns></returns>
        public static async Task<JObject> ImproveCharacterStatAsync(StatType statType, int skillAmount = 1)
        {
            var content = GetDefaultContent("improveCharacterStat");
            content.Add(new KeyValuePair<string, string>("skill_value", skillAmount.ToString()));
            content.Add(new KeyValuePair<string, string>("stat_type", ((int)statType).ToString()));
            content.Add(new KeyValuePair<string, string>("rct", "2"));
            return await PostAsync(content);
        }

        public static async Task<JObject> StartTrainingAsync(StatType statType, int iterations = 1)
        {
            var content = GetDefaultContent("startTraining");
            content.Add(new KeyValuePair<string, string>("iterations", iterations.ToString()));
            content.Add(new KeyValuePair<string, string>("stat_type", ((int)statType).ToString()));
            content.Add(new KeyValuePair<string, string>("rct", "2"));
            return await PostAsync(content);
        }

        /// <summary>Buys the quest energy.</summary>
        /// <param name="usePremiumCurrency">if set to <c>true</c> [use premium currency].</param>
        /// <returns></returns>
        public static async Task<JObject> BuyQuestEnergyAsync(bool usePremiumCurrency)
        {
            var content = GetDefaultContent("buyQuestEnergy");
            content.Add(new KeyValuePair<string, string>("use_premium", usePremiumCurrency.ToString().ToLower()));
            content.Add(new KeyValuePair<string, string>("rct", "1"));
            return await PostAsync(content);
        }

        /// <summary>Login to the server.</summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static async Task<bool> LoginRequestAsync(string username, string password)
        {
            var content = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("platform_user_id", "0"),
                new KeyValuePair<string, string>("platform", "web"),
                new KeyValuePair<string, string>("device_info", "{\"screenResolutionY\":1200,\"pixelAspectRatio\":1,\"os\":\"Windows 10\",\"touchscreenType\":\"none\",\"screenDPI\":72,\"version\":\"WIN 28,0,0,161\",\"screenResolutionX\":1920,\"language\":\"de\"}"),
                new KeyValuePair<string, string>("email", username),
                new KeyValuePair<string, string>("client_id", "s151518213457"),
                new KeyValuePair<string, string>("app_version", "144"),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("rct","1")
            };
            content.AddRange(GetDefaultContent("loginUser"));

            var result = await PostAsync(content);
            return true;
        }

        public static async Task<JObject> StartQuestAsync(Quest quest)
        {
            var content = GetDefaultContent("startQuest");
            content.Add(new KeyValuePair<string, string>("quest_id", quest.id.ToString()));
            content.Add(new KeyValuePair<string, string>("rct", "1"));
            return await PostAsync(content);
        }

        #endregion Methods

        private static long ServerTimeOffset;

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
            client.DefaultRequestHeaders.TryAddWithoutValidation("Origin", "http://hz-static-2.akamaized.net");
            client.DefaultRequestHeaders.TryAddWithoutValidation("X-Requested-With", "ShockwaveFlash/28.0.0.161");
            client.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.167 Safari/537.36");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Referer", "http://hz-static-2.akamaized.net/swf/main_new.swf?664c63b039bf785c18887862aec49a30");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9,de-DE;q=0.8,de;q=0.7");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
        }

        /// <summary>Gets the default HttpRequest content.</summary>
        /// <param name="action">The action.</param>
        /// <returns></returns>
        private static List<KeyValuePair<string, string>> GetDefaultContent(string action)
        {
            var UserId = MainClass?.data?.user?.id ?? 0;
            var UserSessionId = MainClass?.data?.user?.session_id ?? "0";
            return new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("device_type", "web"),
                new KeyValuePair<string, string>("client_version", "flash_145"),
                new KeyValuePair<string, string>("user_id", UserId.ToString()),
                new KeyValuePair<string, string>("user_session_id", UserSessionId),
                new KeyValuePair<string, string>("auth", MD5Hash(action, UserId.ToString())),
                new KeyValuePair<string, string>("action", action)
            };
        }

        /// <summary>Generate MD5 Hash from the request action and the userid</summary>
        /// <param name="action">The action.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        private static string MD5Hash(string action, string userId)
        {
            var hash = new StringBuilder();
            using (var md5provider = new MD5CryptoServiceProvider())
            {
                var bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes($"{action}bpHgj5214{userId}"));

                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }
                return hash.ToString();
            }
        }

        /// <summary>Merges the new data into the database</summary>
        /// <param name="jobj">The new JObject to merge.</param>
        private static void MergeNewData(JObject jobj)
        {
            var updateQuest = jobj.SelectToken("data.quest");
            if (updateQuest != null)
            {
                var questToUpdate = MainJObject["data"]?["quests"]?.OfType<JContainer>().FirstOrDefault(quest => quest["id"]?.Value<int>() == updateQuest["id"]?.Value<int>());
                if (questToUpdate != null)
                {
                    questToUpdate.Merge(updateQuest);
                }
            }
            if (jobj.SelectToken("data.quests")?.HasValues ?? false)
            {
                var quests = MainJObject.Descendants().OfType<JProperty>().FirstOrDefault(prop => prop.Name == "quests");
                if (quests != null)
                {
                    quests.Remove();
                }
            }

            MainJObject.Merge(jobj);
            MainClass = MainJObject.ToObject<JsonRoot>();
            ServerTimeOffset = DateTimeOffset.Now.ToUnixTimeSeconds() - MainClass.data.server_time;
        }

        /// <summary>Posts the specified content to the server.</summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        private static async Task<JObject> PostAsync(List<KeyValuePair<string, string>> content)
        {
            using (var formUrlEncodedContent = new FormUrlEncodedContent(content))
            {
                var response = await client.PostAsync(RequestUrl, formUrlEncodedContent);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var obj = JObject.Parse(json);
                    var error = obj["error"];
                    if (!string.IsNullOrWhiteSpace(error.ToString()))
                    {
                        MessageBox.Show(error.Value<string>());
                        return null;
                    }
                    MergeNewData(obj);
                    return obj;
                }
            }
            return JObject.Parse("{}");
        }
    }
}