using System;
using System.Windows;
using System.Windows.Threading;

namespace HZBot
{
    // HZBot Class
    public class HzBot : ViewModelBase
    {
        #region Constructors

        public HzBot(HzAccount account)
        {
            //Initialize
            ActiveWorkerTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, ActiveWorkerTimer_TickAsync, Application.Current.Dispatcher);

            Account = account;
            Account.OnDataChanged += OnDataChanged;
        }

        #endregion Constructors

        #region Properties

        public Data HZData => Account.Data;

        public string TimerText { get { return this._timerText; } set { this._timerText = value; RaisePropertyChanged(); } }

        public bool IsAutoReconnect { get; set; }

        public bool IsBotEnabled
        {
            get
            {
                return _isBotEnabled;
            }

            set
            {
                _isBotEnabled = value;
                RaisePropertyChanged();
                if (value && !ActiveWorkerTimer.IsEnabled)
                {
                    ActiveWorkerTimer.Start();
                }
            }
        }

        public HzAccount Account { get; }

        #endregion Properties

        #region Fields

        private readonly DispatcherTimer ActiveWorkerTimer;
        private bool _isBotEnabled;
        private string _timerText;

        #endregion Fields

        #region Methods

        private void OnDataChanged()
        {
            if (!ActiveWorkerTimer.IsEnabled && Account.ActiveWorker != null)
            {
                ActiveWorkerTimer.Start();
            }
        }

        private async void ActiveWorkerTimer_TickAsync(object sender, EventArgs e)
        {
            //No data stop Timer
            if (HZData == null)
            {
                StopActiveWorkTimer();
                return;
            }
            if (HZData.ActiveWorker != null)
            {
                //Worker Remaining Time Left
                if (HZData.ActiveWorker.RemainingTime <= -2)
                {
                    //Work seems complete stop timer
                    StopActiveWorkTimer();

                    //check for status complete
                    if (HZData.ActiveWorker.status != 4)
                    {
                        await Account.Requests.CheckForWorkerCompleteAsync(HZData.ActiveWorker.WorkerType);
                    }
                    //when status is complete then start new Bot Action
                    if (HZData?.ActiveWorker.status == 4)
                    {
                        await Account.Plugins.Quest.ClaimWorkerReward.TryExecuteAsync();
                    }
                    else
                    {
                        IsBotEnabled = false;
                    }

                    if (IsBotEnabled)
                    {
                        StopActiveWorkTimer();
                        await Account.Plugins.RaiseExcecuteEvent();
                    }
                }
                //Worker is working, update Timer Text
                else
                {
                    TimerText = TimeSpan.FromSeconds(HZData.ActiveWorker.RemainingTime).ToString();
                }
            }
            //No Active Worker so Stop Timer and start new Bot Action
            else
            {
                StopActiveWorkTimer();
                if (IsBotEnabled)
                {
                    await Account.Plugins.RaiseExcecuteEvent();
                }
            }
        }

        private void StopActiveWorkTimer()
        {
            if (ActiveWorkerTimer.IsEnabled)
            {
                TimerText = TimeSpan.FromSeconds(0).ToString();
                ActiveWorkerTimer.Stop();
            }
        }

        #endregion Methods
    }
}