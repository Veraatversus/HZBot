using System;
using System.Threading.Tasks;

namespace HZBot
{
    public class PrimaryWorkerPlugin : HzPluginBase
    {
        #region Constructors

        public PrimaryWorkerPlugin(HzAccount account) : base(account)
        {
            //Timer = new PrimaryWorkerTimer(Account);
            TimerTask = Timer();
        }

        #endregion Constructors

        #region Properties

        public TimeSpan TimerText
        {
            get { return timerText; }
            set { timerText = value; RaisePropertyChanged(); }
        }

        //public PrimaryWorkerTimer Timer { get; set; }
        public Task TimerTask { get; }

        #endregion Properties

        #region Fields

        private bool taskRun = true;
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
                            if (Account.IsBotEnabled == false) Account.IsBotEnabled = true;

                            if (TimeSpan.FromSeconds(Account.ServerTime - Account.Data.server_time) >= TimeSpan.FromMinutes(10))
                            {
                                await Account.Plugins.Account.SyncGameAsync();
                            }
                            Account.Plugins.RaiseOnPrimaryWorkerComplete();
                        }
                    }
                }
                catch (Exception e)
                {
                    Account.Plugins.Log.Add(e.ToString());
                }
                await Task.Delay(1000);
            }
        }

        #endregion Methods
    }
}