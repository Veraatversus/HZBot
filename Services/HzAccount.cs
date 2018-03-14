using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading;

namespace HZBot
{
    public class HzAccount : ViewModelBase, IDisposable
    {
        #region Fields

        public long ServerTimeOffset;

        public Timer IdleTimer;

        #endregion Fields

        #region Constructors

        public HzAccount()
        {
            HzAccountManger.AddAccount(this);
            Plugins = new HzPlugins(this);
            IdleTimer = new Timer(OnIdleTimerTick, null, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            OnDataChanged += HzAccount_OnDataChanged;
        }

        public HzAccount(HzConfig config) : this()
        {
            Config = config;
            Plugins.RaiseOnAccountLoaded();
        }

        #endregion Constructors

        #region Events

        public event Action OnDataChanged;

        #endregion Events

        #region Properties

        public long ServerTime => DateTimeOffset.Now.ToUnixTimeSeconds() + ServerTimeOffset;

        public HzPlugins Plugins { get; }
        public HzConfig Config { get; set; } = new HzConfig();
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
                if (Config.IsAutoStartBot)
                {
                    IsBotEnabled = true;
                }
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
                    {
                        IdleTimer.Change(TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10));
                        Plugins.RaiseOnPrimaryWorkerComplete();
                    }
                }
                else
                {
                    IdleTimer.Change(Timeout.Infinite, Timeout.Infinite);
                    Plugins.RaiseOnBotStoped();
                }
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

        #region Methods

        public void Dispose()
        {
            IdleTimer.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion Methods

        private JsonRoot _mainData;
        private bool isBotEnabled;
        private bool isLogined;

        ~HzAccount()
        {
            HzAccountManger.RemoveAccount(this);
        }

        private void OnIdleTimerTick(object state)
        {

            if (IsBotEnabled)
            {
                var task = Plugins.Account.SyncGameAsync().Result;
                Plugins.RaiseOnPrimaryWorkerComplete();
            }
        }

        private void HzAccount_OnDataChanged()
        {
            RaisePropertyChanged(nameof(Data));
            RaisePropertyChanged(nameof(User));
            RaisePropertyChanged(nameof(Character));
            RaisePropertyChanged(nameof(Quests));
            RaisePropertyChanged(nameof(ActiveWorker));
            if (ActiveWorker == null)
            {
                IdleTimer.Change(TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(10));
            }
            else
            {
                IdleTimer.Change(Timeout.Infinite, Timeout.Infinite);
            }
        }
    }
}