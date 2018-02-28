using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace HZBot
{
    public class UserManager : ViewModelBase
    {
        #region Properties

        public static UserManager Instance { get; set; } = new UserManager();
        public AsyncRelayCommand LoginCommand { get; private set; }
        public AsyncRelayCommand StartBestQuestCommand { get; private set; }
        public AsyncRelayCommand<Quest> StartQuestCommand { get; private set; }
        public AsyncRelayCommand ClaimWorkerRewardCommand { get; private set; }
        public AsyncRelayCommand ImproveStrengthCommand { get; private set; }
        public AsyncRelayCommand ImproveStaminaCommand { get; private set; }
        public AsyncRelayCommand ImproveDodgeRatingCommand { get; private set; }
        public RelayCommand BuyQuestEnergyCommand { get; private set; }
        public AsyncRelayCommand TrainCritRatingCommand { get; private set; }
        public AsyncRelayCommand TrainStaminaCommand { get; private set; }
        public AsyncRelayCommand TrainStrengthCommand { get; private set; }
        public AsyncRelayCommand TrainDodgeRatingCommand { get; private set; }
        public AsyncRelayCommand BuyEnergyFromGoldCommand { get; private set; }
        public AsyncRelayCommand BuyEnergyFromPremiumCommand { get; private set; }
        public AsyncRelayCommand ImproveCritRatingCommand { get; private set; }
        public Data HZData => HzRequests.MainClass?.data;
        public bool IsLogined { get { return _isLogined; } set { _isLogined = value; RaisePropertyChanged(); } }
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

        public IEnumerable<Tuple<string, object>> HideOutProps => HZData?.hideout.GetType().GetProperties().Select(prop => new Tuple<string, object>(prop.Name, prop.GetValue(HZData?.hideout)));

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
            if (IsAutoSkill && CanImproveCharacterStat())
            {
                for (int i = 0; i < HZData.character.stat_points_available; i++)
                {
                    await HzRequests.ImproveCharacterStatAsync(GetNextImroveStat().StatType);
                }
            }

            //IsAutoBuyEnergyFromGold
            if (IsAutoBuyEnergyFromGold && BuyEnergyFromGoldCommand.CanExecute)
            {
                await BuyEnergyFromGoldCommand.TryExecuteAsync();
            }

            // IsAutoBuyEnergyFromPremium
            if (IsAutoBuyEnergyFromPremium && BuyEnergyFromPremiumCommand.CanExecute)
            {
                await BuyEnergyFromPremiumCommand.TryExecuteAsync();
            }

            // IsAutoTrain
            if (IsAutoTrain && CanTrain())
            {
                var trainstat = HZData.character.Stats.FirstOrDefault(stat => stat.TrainingValue > 0) ?? GetNextImroveStat();
                if (trainstat != null)
                {
                    await HzRequests.StartTrainingAsync(trainstat.StatType);
                }
            }

            // IsAutoQuest
            if (IsAutoQuest && StartBestQuestCommand.CanExecute)
            {
                var quest = HZData.quests.Where(q1 => q1.energy_cost <= HZData.character.quest_energy).OrderByDescending(q1 => q1.XPCurrencyPerEneryAverage).FirstOrDefault();
                if (quest != null)
                {
                    await StartQuestCommand.TryExecuteAsync(quest);
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
        private bool _isLogined;
        private string _timerText;

        #endregion Fields

        #region Constructors

        private UserManager()
        {
            //Initialize
            ActiveWorkerTimer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, ActiveWorkerTimer_TickAsync, Application.Current.Dispatcher);
            HzRequests.OnDataChanged += OnDataChanged;

            //Commands
            LoginCommand = new AsyncRelayCommand(async () => IsLogined = await HzRequests.LoginRequestAsync(UserName, Password), () => !IsLogined);
            StartBestQuestCommand = new AsyncRelayCommand(async () => await HzRequests.StartQuestAsync(HZData.BestQuest), () => HZData?.ActiveWorker == null && IsLogined);
            StartQuestCommand = new AsyncRelayCommand<Quest>(async (quest) => await HzRequests.StartQuestAsync(quest), (quest) => HZData?.ActiveWorker == null && IsLogined && quest.energy_cost <= HZData?.character.quest_energy);
            ClaimWorkerRewardCommand = new AsyncRelayCommand(async () => await HzRequests.ClaimWorkerRewardAsync(HZData.ActiveWorker.WorkerType), () => HZData?.ActiveWorker?.status == 4);
            ImproveCritRatingCommand = new AsyncRelayCommand(async () => await HzRequests.ImproveCharacterStatAsync(StatType.CriticalRating), CanImproveCharacterStat);
            ImproveStaminaCommand = new AsyncRelayCommand(async () => await HzRequests.ImproveCharacterStatAsync(StatType.Stamina), CanImproveCharacterStat);
            ImproveStrengthCommand = new AsyncRelayCommand(async () => await HzRequests.ImproveCharacterStatAsync(StatType.Strength), CanImproveCharacterStat);
            ImproveDodgeRatingCommand = new AsyncRelayCommand(async () => await HzRequests.ImproveCharacterStatAsync(StatType.DodgeRating), CanImproveCharacterStat);
            BuyQuestEnergyCommand = new RelayCommand(() => new ChooseCurrencyWindow(HZData).ShowDialog(), () => HZData?.character.quest_energy < 50 && HZData?.character.quest_energy_refill_amount_today < 200);
            TrainCritRatingCommand = new AsyncRelayCommand(async () => await HzRequests.StartTrainingAsync(StatType.CriticalRating), CanTrain);
            TrainStaminaCommand = new AsyncRelayCommand(async () => await HzRequests.StartTrainingAsync(StatType.Stamina), CanTrain);
            TrainStrengthCommand = new AsyncRelayCommand(async () => await HzRequests.StartTrainingAsync(StatType.Strength), CanTrain);
            TrainDodgeRatingCommand = new AsyncRelayCommand(async () => await HzRequests.StartTrainingAsync(StatType.DodgeRating), CanTrain);
            BuyEnergyFromGoldCommand = new AsyncRelayCommand(async () => await HzRequests.BuyQuestEnergyAsync(false), () => HZData?.ActiveWorker == null && HZData.character.game_currency >= HZData.character.CurrentGameCurrencyCostEnergyRefill);
            BuyEnergyFromPremiumCommand = new AsyncRelayCommand(async () => await HzRequests.BuyQuestEnergyAsync(true), () => HZData?.ActiveWorker == null && HZData.user.premium_currency >= 2);
        }

        #endregion Constructors

        /// <summary>Determines whether this Character [can improve character stat].</summary>
        /// <returns>
        ///   <c>true</c> if this instance [can improve character stat]; otherwise, <c>false</c>.</returns>
        private bool CanImproveCharacterStat()
        {
            return HZData?.character.stat_points_available > 0;
        }

        /// <summary>Determines whether this Character can train.</summary>
        /// <returns>
        ///   <c>true</c> if this instance can train; otherwise, <c>false</c>.</returns>
        private bool CanTrain()
        {
            return HZData?.character.training_count > 0 && HZData?.ActiveWorker == null;
        }

        private void OnDataChanged()
        {
            // SetActiveQuestTime();
            RaisePropertyChanged(nameof(HZData));
            RaisePropertyChanged(nameof(HideOutProps));
            if (!ActiveWorkerTimer.IsEnabled && HZData?.ActiveWorker != null)
            {
                ActiveWorkerTimer.Start();
            }
        }

        /// <summary>Gets the next Character Stat to Improve.</summary>
        /// <returns></returns>
        private CharacterStat GetNextImroveStat()
        {
            return HZData.character.Stats.OrderBy(stat => stat.BaseValue).FirstOrDefault();
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
                        await HzRequests.CheckForWorkerCompleteAsync(HZData.ActiveWorker.WorkerType);
                    }
                    //when satus == complete then start new Bot Action
                    if (HZData?.ActiveWorker.status == 4)
                    {
                        await ClaimWorkerRewardCommand.TryExecuteAsync();
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