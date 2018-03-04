using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HZBot
{
    public class HzAccount : ViewModelBase
    {
        #region Constructors

        public HzAccount()
        {
            AccountManger.Accounts.Add(this);
            Plugins = new HzPlugins(this);
            Requests = new HzRequests(this);
            Bot = new HzBot(this);
            logs = new HZLog();
            OnDataChanged += HzAccount_OnDataChanged;
        }

        #endregion Constructors

        #region Events

        public event Action OnDataChanged;

        #endregion Events

        #region Properties

        //Commands
        public HzPlugins Plugins { get; }

        //Personal data
        public string Username { get => _username; set { _username = value; RaisePropertyChanged(); } }

        public string Password { get => _password; set { _password = value; RaisePropertyChanged(); } }

        //Bot data
        public bool IsLogined { get => _isLogined; set { _isLogined = value; RaisePropertyChanged(); } }

        public Data Data => MainData?.data;

        public User User => MainData?.data.user;

        public Character Character => MainData?.data.character;

        public List<Quest> Quests => MainData?.data.quests;

        public HzRequests Requests { get; }

        public HzBot Bot { get; }

        public IWorkItem ActiveWorker => Data?.ActiveWorker;

        public HZLog logs { get; }

        #endregion Properties

        #region Methods

        /// <summary>Merges the new data into the Accout</summary>
        /// <param name="jobj">The new JObject to merge.</param>
        public void MergeNewData(JObject jobj)
        {
            var updateQuest = jobj.SelectToken("data.quest");
            if (updateQuest != null)
            {
                var questToUpdate = JsonData["data"]?["quests"]?.OfType<JContainer>().FirstOrDefault(quest => quest["id"]?.Value<int>() == updateQuest["id"]?.Value<int>());
                if (questToUpdate != null)
                {
                    questToUpdate.Merge(updateQuest);
                }
            }
            if (jobj.SelectToken("data.quests")?.HasValues ?? false)
            {
                var quests = JsonData.Descendants().OfType<JProperty>().FirstOrDefault(prop => prop.Name == "quests");
                if (quests != null)
                {
                    quests.Remove();
                }
            }
            if (jobj.SelectToken("data.opponents")?.HasValues ?? false)
            {
                var opponents = JsonData.Descendants().OfType<JProperty>().FirstOrDefault(prop => prop.Name == "opponents");
                if (opponents != null)
                {
                    opponents.Remove();
                }
            }

            JsonData.Merge(jobj);
            MainData = JsonData.ToObject<JsonRoot>();
        }

        #endregion Methods

        #region Fields

        private JsonRoot _mainData;
        private bool _isLogined;
        private string _username;
        private string _password;

        #endregion Fields

        #region Destructors

        ~HzAccount()
        {
            AccountManger.Accounts.Remove(this);
        }

        #endregion Destructors

        private JObject JsonData { get; } = new JObject();

        private JsonRoot MainData
        {
            get => _mainData;
            set { _mainData = value; RaisePropertyChanged(); OnDataChanged?.Invoke(); }
        }

        private void HzAccount_OnDataChanged()
        {
            RaisePropertyChanged(nameof(Data));
            RaisePropertyChanged(nameof(User));
            RaisePropertyChanged(nameof(Character));
            RaisePropertyChanged(nameof(Quests));
            RaisePropertyChanged(nameof(ActiveWorker));
        }
    }
}