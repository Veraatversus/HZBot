using System;
using System.Linq;
using System.Threading.Tasks;
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
        public HzCommands HzCommandBase => Account.Commands;
        public string TimerText { get { return this._timerText; } set { this._timerText = value; RaisePropertyChanged(); } }
        public string UserName { get; set; } = "koernerbrot1@gmx.de";
        public string Password { get; set; } = "test1234";
        public bool IsAutoTrain { get; set; }
        public bool IsAutoQuest { get; set; }
        public bool IsAutoSkill { get; set; }
        public bool IsAutoHideOutCollect { get; set; }
        public bool IsAutoHideOutBuild { get; set; }
        public bool IsAutoBuyEnergyFromGold { get; set; }
        public bool IsAutoBuyEnergyFromPremium { get; set; }
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
                    //Task.Run(async () => await StartBotActionAsync());
                }
            }
        }

        public HzAccount Account { get; }
        public HzRequests Requests => Account.Requests;

        #endregion Properties

        #region Methods

        public async Task StartBotActionAsync()
        {
            // Check for Data
            if (HZData == null)
            {
                IsBotEnabled = false;
                return;
            }

            // Do Work

            // AutoHideOutCollect
            if (IsAutoHideOutCollect)
            {
            }

            // IsAutoHideOutBuild
            if (IsAutoHideOutBuild)
            {
            }

            // IsAutoSkill
            if (IsAutoSkill && HZData.character.CanImproveCharacterStat())
            {
                var trainCount = HZData.character.stat_points_available;
                for (int i = 0; i < trainCount; i++)
                {
                    await Requests.ImproveCharacterStatAsync(HZData.character.GetNextImroveStat().StatType);
                }
            }

            //IsAutoBuyEnergyFromGold
            if (IsAutoBuyEnergyFromGold && HzCommandBase.BuyEnergyFromGold.CanExecute)
            {
                await HzCommandBase.BuyEnergyFromGold.TryExecuteAsync();
            }

            // IsAutoBuyEnergyFromPremium
            if (IsAutoBuyEnergyFromPremium && HzCommandBase.BuyEnergyFromPremium.CanExecute)
            {
                await HzCommandBase.BuyEnergyFromPremium.TryExecuteAsync();
            }

            // IsAutoTrain
            if (IsAutoTrain && HZData.character.CanTrain())
            {
                var trainStat = HZData.character.Stats.FirstOrDefault(stat => stat.TrainingValue > 0) ?? HZData.character.GetNextImroveStat();
                if (trainStat != null)
                {
                    await Requests.StartTrainingAsync(trainStat.StatType);
                }
            }

            // IsAutoQuest
            if (IsAutoQuest && HzCommandBase.StartBestQuest.CanExecute)
            {
                //Enough Energie?
                var quests = HZData.quests.Where(q => q.energy_cost <= HZData.character.quest_energy);
                //Sort By Max Value Quest
                quests = quests.OrderByDescending(q => q.XPCurrencyPerEneryAverage);
                //Skip when Battle is to hart
                quests = quests.SkipWhile(q => q.fight_difficulty > 2);

                if (quests?.FirstOrDefault() != null)
                {
                    await HzCommandBase.StartQuest.TryExecuteAsync(quests.FirstOrDefault());
                }
            }

            // Check for work complete
            if (HZData.ActiveWorker == null)
            {
                IsBotEnabled = false;
                return;
            }
        }

        #endregion Methods

        #region Fields

        private readonly DispatcherTimer ActiveWorkerTimer;
        private bool _isBotEnabled;
        private string _timerText;

        #endregion Fields

        private void OnDataChanged()
        {
            // SetActiveQuestTime();
            //RaisePropertyChanged(nameof(HZData));
            if (!ActiveWorkerTimer.IsEnabled && HZData?.ActiveWorker != null)
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
                        await Requests.CheckForWorkerCompleteAsync(HZData.ActiveWorker.WorkerType);
                    }
                    //when status is complete then start new Bot Action
                    if (HZData?.ActiveWorker.status == 4)
                    {
                        await HzCommandBase.ClaimWorkerReward.TryExecuteAsync();
                    }
                    else
                    {
                        IsBotEnabled = false;
                    }
                    if (IsBotEnabled)
                        await StartBotActionAsync();
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
                    await StartBotActionAsync();
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
    }
}