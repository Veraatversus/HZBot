using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HZBot
{
    public class QuestPlugin : HzPluginBase
    {
        #region Constructors

        public QuestPlugin(HzAccount account) : base(account)
        {
            //ActiveWorkerTimer = new Timer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, ActiveWorkerTimer_TickAsync, Application.Current.Dispatcher);

            //Quest Commands
            StartBestQuest = new AsyncRelayCommand(
                async () => await this.StartQuestAsync(Account.Data.BestQuest),
                () => Account.ActiveWorker == null && Account.IsLogined);

            StartQuest = new AsyncRelayCommand<Quest>(
                async quest => await this.StartQuestAsync(quest),
                quest => Account.ActiveWorker == null && Account.IsLogined && quest.energy_cost <= Account.Character?.quest_energy);

            ClaimWorkerReward = new AsyncRelayCommand(
                async () => await this.ClaimWorkerRewardAsync(Account.ActiveWorker.WorkerType),
                () => Account.ActiveWorker?.status == 4);

            //Buy Quest Energy Commands
            ShowBuyQuestEnergyWindow = new RelayCommand(
                () => new ChooseCurrencyWindow(Account).ShowDialog(),
                () => Account.Character?.quest_energy < 50 && Account.Character?.quest_energy_refill_amount_today < 200);

            BuyEnergyFromGold = new AsyncRelayCommand(
              async () => await this.BuyQuestEnergyAsync(false),
              () => Account.ActiveWorker == null && Account.Character?.game_currency >= Account.Character?.CurrentGameCurrencyCostEnergyRefill);

            BuyEnergyFromPremium = new AsyncRelayCommand(
                async () => await this.BuyQuestEnergyAsync(true),
                () => Account.ActiveWorker == null && Account.User?.premium_currency >= 2);
        }

        #endregion Constructors

        #region Properties

        public bool IsAutoQuest { get; set; }

        public bool IsAutoBuyEnergyFromGold { get; set; }

        public bool IsAutoBuyEnergyFromPremium { get; set; }

        //Quest Commands
        public AsyncRelayCommand StartBestQuest { get; private set; }

        public AsyncRelayCommand<Quest> StartQuest { get; private set; }

        public AsyncRelayCommand ClaimWorkerReward { get; private set; }

        //Buy Quest Energy Commands
        public AsyncRelayCommand BuyEnergyFromGold { get; private set; }

        public AsyncRelayCommand BuyEnergyFromPremium { get; private set; }

        public RelayCommand ShowBuyQuestEnergyWindow { get; private set; }

        #endregion Properties

        #region Methods

        public override Task OnLogined()
        {
            return base.OnLogined();
        }

        public override Task OnBotStarted()
        {
            return base.OnBotStarted();
        }

        public override Task OnBotStoped()
        {
            return base.OnBotStoped();
        }

        public override Task OnLogoffed()
        {
            return base.OnLogoffed();
        }

        public async override Task OnPrimaryWorkerComplete()
        {
            //IsAutoBuyEnergyFromGold
            if (IsAutoBuyEnergyFromGold && BuyEnergyFromGold.CanExecute)
            {
                await BuyEnergyFromGold.TryExecuteAsync();
            }

            // IsAutoBuyEnergyFromPremium
            if (IsAutoBuyEnergyFromPremium && BuyEnergyFromPremium.CanExecute)
            {
                await BuyEnergyFromPremium.TryExecuteAsync();
            }

            // IsAutoQuest
            if (IsAutoQuest && StartBestQuest.CanExecute)
            {
                //Enough Energie?
                var quests = Account.Quests.Where(q => q.energy_cost <= Account.Character.quest_energy);
                //Sort By Max Value Quest
                quests = quests.OrderByDescending(q => q.XPCurrencyPerEneryAverage);
                //Skip when Battle is to hart
                quests = quests.SkipWhile(q => q.fight_difficulty > 2);

                if (quests?.FirstOrDefault() != null)
                {
                    await StartQuest.TryExecuteAsync(quests.FirstOrDefault());
                    Account.Log.Add($"[QUEST] START: ID:{quests.FirstOrDefault().id} Duration:{quests.FirstOrDefault().duration / 60}");
                }
            }
        }

        #endregion Methods

        #region Fields

        private readonly Timer ActiveWorkerTimer;

        private bool _isTimerEnabled;

        #endregion Fields

        private async void onTimerTick(object state)
        {
        }
    }
}