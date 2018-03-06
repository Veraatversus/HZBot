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
            AccountManger.Accounts.Add(this);
            Plugins = new HzPlugins(this);
            PrimaryWorkerTimer = new PrimaryWorkerTimer(this);
            OnDataChanged += HzAccount_OnDataChanged;
        }

        #endregion Constructors

        #region Events

        public event Action OnDataChanged;

        #endregion Events

        #region Properties

        public long ServerTime => DateTimeOffset.Now.ToUnixTimeSeconds() + ServerTimeOffset;

        //Commands
        public HzPlugins Plugins { get; }

        //Personal data
        public string Username { get => _username; set { _username = value; RaisePropertyChanged(); } }

        public string Password { get => _password; set { _password = value; RaisePropertyChanged(); } }
        public LogPlugin Log => Plugins.LogPlugin;

        //Bot data
        public bool IsLogined
        {
            get => _isLogined;
            set
            {
                _isLogined = value;
                RaisePropertyChanged();
                if (IsLogined)
                {
                    Plugins.RaiseOnLogined();
                    //Action onlogin = async () => await Plugins.RaiseOnLogined();
                    //onlogin();
                }
                else
                {
                    Plugins.RaiseOnlogoffed();
                    //Action onlogoff = async () => await Plugins.RaiseOnlogoffed();
                    //onlogoff();
                    Plugins.Account.IsBotEnabled = false;
                }
            }
        }

        public Data Data => MainData?.data;

        public User User => MainData?.data.user;

        public Character Character => MainData?.data.character;

        public List<Quest> Quests => MainData?.data.quests;

        public PrimaryWorkerTimer PrimaryWorkerTimer { get; }

        public JObject JsonData { get; } = new JObject();

        public JsonRoot MainData
        {
            get => _mainData;
            set { _mainData = value; RaisePropertyChanged(); OnDataChanged?.Invoke(); }
        }

        public IWorkItem ActiveWorker => Data?.ActiveWorker;

        #endregion Properties

        private JsonRoot _mainData;
        private bool _isLogined;
        private string _username;
        private string _password;
        private bool IsRunning;

        ~HzAccount()
        {
            AccountManger.Accounts.Remove(this);
        }

        private async void HzAccount_OnDataChanged()
        {
            RaisePropertyChanged(nameof(Data));
            RaisePropertyChanged(nameof(User));
            RaisePropertyChanged(nameof(Character));
            RaisePropertyChanged(nameof(Quests));
            RaisePropertyChanged(nameof(ActiveWorker));

        }
    }
}