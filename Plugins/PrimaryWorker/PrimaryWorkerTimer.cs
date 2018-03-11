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

        public TimeSpan Text
        {
            get { return _Text; }
            set { _Text = value; RaisePropertyChanged(); }
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
                    Text = TimeSpan.FromSeconds(0);
                }
            }
        }

        #endregion Properties

        #region Fields

        private readonly Timer workerTimer;

        private bool _isTimerEnabled;

        private TimeSpan _Text = TimeSpan.FromSeconds(0);
        private readonly SynchronizationContext UIContext;

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
                if (Account.ActiveWorker.RemainingTime <= -1)
                {
                    //check for status complete
                    if (Account.ActiveWorker.status == WorkStatus.Started)
                    {
                        await Account.Plugins.Quest.CheckForWorkerCompleteAsync(Account.ActiveWorker.WorkerType);
                    }
                    //when status is complete then start new Bot Action
                    if (Account.ActiveWorker?.status == WorkStatus.Finished)
                    {
                        if (Account.ActiveWorker.WorkerType == WorkType.Quest || Account.ActiveWorker.WorkerType == WorkType.Training)
                        {
                            await Account.Plugins.Quest.ClaimWorkerReward.TryExecuteAsync();
                        }
                        else if (Account.ActiveWorker.WorkerType == WorkType.WorldbossAttack)
                        {
                            await Account.Plugins.Worldboss.FinishWorldbossAttackAsync(Account.Data.ActiveWorldbossAttack.worldboss_event_id);
                        }
                        if (Account.Data.ActiveWorldBossEvent?.status == WorldbossEventStatus.Finished)
                        {
                            await Account.Plugins.Worldboss.ClaimWorldbossEventRewardsAsync(Account.Data.ActiveWorldBossEvent.id);
                        }
                        
                        if (Account.Data != null)
                        {
                            if (Account.ActiveWorker == null)
                            {
                                if (Account.IsBotEnabled)
                                {
                                    IsTimerEnabled = false;
                                    Account.Plugins.RaiseOnPrimaryWorkerComplete();
                                }
                            }
                        }
                    }
                }
                //Worker is working, update Timer Text
                else
                {
                    Text = TimeSpan.FromSeconds(Account.ActiveWorker.RemainingTime);
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