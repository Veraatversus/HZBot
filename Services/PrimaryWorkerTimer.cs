using System;
using System.Threading;

namespace HZBot
{
    public class PrimaryWorkerTimer : HzServiceBase
    {
        #region Constructors

        public PrimaryWorkerTimer(HzAccount account) : base(account)
        {
            workerTimer = new Timer(onTimerTick, null, Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            Account.OnDataChanged += Account_OnDataChanged;
            UIContext = System.Threading.SynchronizationContext.Current;
        }

        #endregion Constructors

        #region Properties

        public TimeSpan TimerText
        {
            get { return _timerText; }
            set { _timerText = value; RaisePropertyChanged(); }
        }

        public bool IsTimerEnabled
        {
            get
            {
                return _isTimerEnabled;
            }
            private set
            {
                _isTimerEnabled = value;
                if (!_isTimerEnabled)
                {
                    //workerTimer.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
                    TimerText = TimeSpan.FromSeconds(0);
                }
            }
        }

        #endregion Properties

        #region Fields

        private Timer workerTimer;

        private bool _isTimerEnabled;

        private TimeSpan _timerText = TimeSpan.FromSeconds(0);
        private SynchronizationContext UIContext;

        #endregion Fields

        #region Methods

        private void Account_OnDataChanged()
        {
            if (!IsTimerEnabled && Account.ActiveWorker != null)
            {
                IsTimerEnabled = true;
                workerTimer.Change(TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);
            }
        }

        private async void onTimerTick(object state)
        { //No data stop Timer
            if (Account.Data == null)
            {
                IsTimerEnabled = false;
                return;
            }
            if (Account.ActiveWorker != null)
            {
                //Worker Remaining Time Left
                if (Account.ActiveWorker.RemainingTime <= -3)
                {
                    //check for status complete
                    if (Account.ActiveWorker.status == 2)
                    {
                        await Account.Plugins.Quest.CheckForWorkerCompleteAsync(Account.ActiveWorker.WorkerType);
                    }
                    //when status is complete then start new Bot Action
                    if (Account.ActiveWorker?.status == 4)
                    {
                        await Account.Plugins.Quest.ClaimWorkerReward.TryExecuteAsync();
                        if (Account.Data != null)
                        {
                            if (Account.ActiveWorker == null)
                            {
                                if (Account.Plugins.Account.IsBotEnabled)
                                {
                                    await Account.Plugins.RaiseOnPrimaryWorkerComplete();
                                }

                            }
                        }
                    }
                }
                //Worker is working, update Timer Text
                else
                {
                    TimerText = TimeSpan.FromSeconds(Account.ActiveWorker.RemainingTime);
                }
            }
            //No Active Worker so Stop Timer and start new Bot Action
            else
            {
                IsTimerEnabled = false;
                return;
            }
            //If Timer enabled start new timer tick
            if (IsTimerEnabled)
            {
                workerTimer.Change(TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);
            }
        }

        #endregion Methods
    }
}