namespace HZBot
{
    public class HzCommands
    {
        #region Constructors

        public HzCommands(HzAccount account)
        {
            Account = account;
            InitializeCommands();
        }

        #endregion Constructors

        #region Properties

        //Command for Login into Account
        public AsyncRelayCommand Login { get; private set; }

        //Quest Commands
        public AsyncRelayCommand StartBestQuest { get; private set; }

        public AsyncRelayCommand<Quest> StartQuest { get; private set; }
        public AsyncRelayCommand ClaimWorkerReward { get; private set; }

        //Buy Quest Energy Commands
        public AsyncRelayCommand BuyEnergyFromGold { get; private set; }

        public AsyncRelayCommand BuyEnergyFromPremium { get; private set; }
        public RelayCommand ShowBuyQuestEnergyWindow { get; private set; }

        //Imrpove CharacterStat Commands
        public AsyncRelayCommand ImproveStrength { get; private set; }

        public AsyncRelayCommand ImproveStamina { get; private set; }
        public AsyncRelayCommand ImproveDodgeRating { get; private set; }
        public AsyncRelayCommand ImproveCritRating { get; private set; }
        public AsyncRelayCommand<CharacterStat> ImproveCharacterStat { get; private set; }

        //Train Stats Commands
        public AsyncRelayCommand TrainCritRating { get; private set; }

        public AsyncRelayCommand TrainStamina { get; private set; }
        public AsyncRelayCommand TrainStrength { get; private set; }
        public AsyncRelayCommand TrainDodgeRating { get; private set; }

        #endregion Properties

        #region Fields

        private static HzAccount Account;

        #endregion Fields

        #region Methods

        private void InitializeCommands()
        {
            //Command for Login into Account
            Login = new AsyncRelayCommand(
                async () => Account.IsLogined = await Account.Requests.LoginRequestAsync(),
                () => !Account.IsLogined);

            //Quest Commands
            StartBestQuest = new AsyncRelayCommand(
                async () => await Account.Requests.StartQuestAsync(Account.Data.BestQuest),
                () => Account.ActiveWorker == null && Account.IsLogined);

            StartQuest = new AsyncRelayCommand<Quest>(
                async quest => await Account.Requests.StartQuestAsync(quest),
                quest => Account.ActiveWorker == null && Account.IsLogined && quest.energy_cost <= Account.Character?.quest_energy);

            ClaimWorkerReward = new AsyncRelayCommand(
                async () => await Account.Requests.ClaimWorkerRewardAsync(Account.ActiveWorker.WorkerType),
                () => Account.ActiveWorker?.status == 4);

            //Buy Quest Energy Commands
            ShowBuyQuestEnergyWindow = new RelayCommand(
                () => new ChooseCurrencyWindow(Account).ShowDialog(),
                () => Account.Character?.quest_energy < 50 && Account.Character?.quest_energy_refill_amount_today < 200);

            BuyEnergyFromGold = new AsyncRelayCommand(
              async () => await Account.Requests.BuyQuestEnergyAsync(false),
              () => Account.ActiveWorker == null && Account.Character?.game_currency >= Account.Character?.CurrentGameCurrencyCostEnergyRefill);

            BuyEnergyFromPremium = new AsyncRelayCommand(
                async () => await Account.Requests.BuyQuestEnergyAsync(true),
                () => Account.ActiveWorker == null && Account.User?.premium_currency >= 2);

            //Imrpove CharacterStat Commands
            ImproveCritRating = new AsyncRelayCommand(
                async () => await Account.Requests.ImproveCharacterStatAsync(StatType.CriticalRating),
                () => Account.Character?.CanImproveCharacterStat() ?? false);

            ImproveStamina = new AsyncRelayCommand(
                async () => await Account.Requests.ImproveCharacterStatAsync(StatType.Stamina),
                () => Account.Character?.CanImproveCharacterStat() ?? false);

            ImproveStrength = new AsyncRelayCommand(
                async () => await Account.Requests.ImproveCharacterStatAsync(StatType.Strength),
                () => Account.Character?.CanImproveCharacterStat() ?? false);

            ImproveDodgeRating = new AsyncRelayCommand(
                async () => await Account.Requests.ImproveCharacterStatAsync(StatType.DodgeRating),
                () => Account.Character?.CanImproveCharacterStat() ?? false);

            ImproveCharacterStat = new AsyncRelayCommand<CharacterStat>(
                async stat => await Account.Requests.ImproveCharacterStatAsync(stat.StatType),
                stat => Account.Character?.CanImproveCharacterStat() ?? false);

            //Train Stats Commands
            TrainCritRating = new AsyncRelayCommand(
                async () => await Account.Requests.StartTrainingAsync(StatType.CriticalRating),
                () => Account.ActiveWorker == null && (Account.Character?.CanTrain() ?? false));

            TrainStamina = new AsyncRelayCommand(
                async () => await Account.Requests.StartTrainingAsync(StatType.Stamina),
              () => Account.ActiveWorker == null && (Account.Character?.CanTrain() ?? false));

            TrainStrength = new AsyncRelayCommand(
                async () => await Account.Requests.StartTrainingAsync(StatType.Strength),
                () => Account.ActiveWorker == null && (Account.Character?.CanTrain() ?? false));

            TrainDodgeRating = new AsyncRelayCommand(
                async () => await Account.Requests.StartTrainingAsync(StatType.DodgeRating),
                () => Account.ActiveWorker == null && (Account.Character?.CanTrain() ?? false));
        }

        #endregion Methods
    }
}