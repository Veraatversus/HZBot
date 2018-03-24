using System;
using System.Threading.Tasks;

namespace HZBot
{
    public class PrimaryWorkerPlugin : HzPluginBase
    {
        #region Constructors

        public PrimaryWorkerPlugin(HzAccount account) : base(account)
        {
            Task.Run(Timer);
            //timer = new Timer(Timer, null, TimeSpan.FromSeconds(1), Timeout.InfiniteTimeSpan);
        }

        #endregion Constructors

        #region Properties

        public TimeSpan TimerText
        {
            get { return timerText; }
            set { timerText = value; RaisePropertyChanged(); }
        }

        public Task TimerTask { get; }

        #endregion Properties

        //public Timer timer;

        #region Fields

        private volatile bool taskRun = true;
        private TimeSpan timerText;

        #endregion Fields

        #region Destructors

        ~PrimaryWorkerPlugin()
        {
            taskRun = false;
        }

        #endregion Destructors

        #region Methods

        private async Task Timer()
        {
            while (taskRun)
            {
                if (Account.Data != null)
                {
                    try
                    {
                        if (Account.ActiveWorker != null)
                        {
                            //Worker Remaining Time Left
                            if (Account.ActiveWorker.RemainingTime <= -2)
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
                                }
                            }
                            //Worker is working, update Timer Text
                            else
                            {
                                TimerText = TimeSpan.FromSeconds(Account.ActiveWorker.RemainingTime);
                            }
                        }
                        if (Account.ActiveWorker == null)
                        {
                            if (Account.IsBotEnabled || Account.Config.IsAutoStartBot)
                            {
                                if (!Account.IsBotEnabled) Account.IsBotEnabled = true;

                                if (TimeSpan.FromSeconds(Account.ServerTime - Account.Data.server_time) >= TimeSpan.FromMinutes(10))
                                {
                                    await Account.Plugins.Account.SyncGameAsync();
                                }
                                await Account.Plugins.RaiseOnPrimaryWorkerComplete();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Account.Plugins.Log.Add(e.ToString());
                    }
                }
                // timer.Change(TimeSpan.FromSeconds(10), Timeout.InfiniteTimeSpan);
                await Task.Delay(1000);
            }
        }

        #endregion Methods
    }
}