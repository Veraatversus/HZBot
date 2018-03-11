using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace HZBot
{
    public class HzAccount : ViewModelBase
    {
        #region Fields

        public long ServerTimeOffset;

        #endregion Fields

        #region Constructors

        public HzAccount()
        {
            HzAccountManger.AddAccount(this);
            Plugins = new HzPlugins(this);
            Config = new HzConfig();
            OnDataChanged += HzAccount_OnDataChanged;
        }

        #endregion Constructors

        #region Events

        public event Action OnDataChanged;

        #endregion Events

        #region Properties

        public long ServerTime => DateTimeOffset.Now.ToUnixTimeSeconds() + ServerTimeOffset;

        public HzPlugins Plugins { get; }
        public HzConfig Config { get; set; }
        public Data Data => MainData?.data;
        public User User => MainData?.data.user;
        public Character Character => MainData?.data.character;
        public List<Quest> Quests => MainData?.data.quests;
        public JObject JsonData { get; } = new JObject();

        public bool IsLogined
        {
            get => isLogined;
            set
            {
                isLogined = value;
                RaisePropertyChanged();
                if (IsLogined)
                    Plugins.RaiseOnLogined();
                else
                {
                    Plugins.RaiseOnlogoffed();
                    IsBotEnabled = false;
                }
            }
        }

        public bool IsBotEnabled
        {
            get => isBotEnabled;
            set
            {
                isBotEnabled = value;
                RaisePropertyChanged();
                if (IsBotEnabled)
                {
                    Plugins.RaiseOnBotStarted();
                    if (ActiveWorker == null)
                        Plugins.RaiseOnPrimaryWorkerComplete();
                }
                else
                    Plugins.RaiseOnBotStoped();
            }
        }

        public JsonRoot MainData
        {
            get => _mainData;
            set { _mainData = value; RaisePropertyChanged(); OnDataChanged?.Invoke(); }
        }

        public LogPlugin Log => Plugins.Log;
        public IWorkItem ActiveWorker => Data?.ActiveWorker;

        #endregion Properties

        private JsonRoot _mainData;
        private bool isBotEnabled;
        private bool isLogined;

        ~HzAccount()
        {
            HzAccountManger.RemoveAccount(this);
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