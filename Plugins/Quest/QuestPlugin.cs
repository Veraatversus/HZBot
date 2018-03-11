using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
                quest => Account.ActiveWorker == null && Account.IsLogined && quest?.energy_cost <= Account.Character?.quest_energy);

            ClaimWorkerReward = new AsyncRelayCommand(
                async () => await this.ClaimWorkerRewardAsync(Account.ActiveWorker.WorkerType),
                () => Account.ActiveWorker?.status == WorkStatus.Finished);

            //Buy Quest Energy Commands
            ShowBuyQuestEnergyWindow = new RelayCommand(
                () => new ChooseCurrencyWindow(Account).ShowDialog(),
                () => Account.Character?.quest_energy < 50 && Account.Character?.quest_energy_refill_amount_today < 200);

            BuyEnergyFromGold = new AsyncRelayCommand(
              async () => await this.BuyQuestEnergyAsync(false),
              () => Account.Character?.quest_energy < 50 && Account.ActiveWorker == null && Account.Character?.game_currency >= Account.Character?.CurrentGameCurrencyCostEnergyRefill);

            BuyEnergyFromPremium = new AsyncRelayCommand(
                async () => await this.BuyQuestEnergyAsync(true),
                () => Account.Character?.quest_energy < 50 && Account.ActiveWorker == null && Account.User?.premium_currency >= 2);
        }

        #endregion Constructors

        #region Properties

        public ObservableCollection<Tuple<DateTime, Quest>> QuestLog { get; } = new ObservableCollection<Tuple<DateTime, Quest>>();

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

        public async override Task OnPrimaryWorkerDoWork()
        {
            if (Account.Data.ActiveWorldBoss != null)
            {
                MessageBox.Show("WorldBoss ist da ruf Vera an!!!");
            }
            //IsAutoBuyEnergyFromGold
            if (Account.Config.BuyEnergyMode.HasFlag(BuyEnergyMode.BuyForGold) && BuyEnergyFromGold.CanExecute)
            {
                await BuyEnergyFromGold.TryExecuteAsync();
            }

            // IsAutoBuyEnergyFromPremium
            if (Account.Config.BuyEnergyMode.HasFlag(BuyEnergyMode.BuyForPremium) && BuyEnergyFromPremium.CanExecute)
            {
                await BuyEnergyFromPremium.TryExecuteAsync();
            }

            // IsAutoQuest
            if (Account.Config.IsAutoQuest && StartBestQuest.CanExecute)
            {
                //Enough Energie?
                var quests = Account.Quests.Where(q => q.energy_cost <= Account.Character.quest_energy);

                //QuestMode
                switch (Account.Config.QuestMode)
                {
                    case QuestMode.MostGold:
                        quests = quests.OrderBy(q => q.CurrencyPerEnergy);
                        break;

                    case QuestMode.MostXP:
                        quests = quests.OrderBy(q => q.XPPerEnergy);
                        break;

                    case QuestMode.Balanced:
                        quests = quests.OrderBy(q => q.XPCurrencyPerEneryAverage);
                        break;
                }

                //Quest Difficulty
                switch (Account.Config.QuestDifficulty)
                {
                    case FightQuestDifficulty.Easy:
                        quests = quests.SkipWhile(q => q.fight_difficulty > FightQuestDifficulty.Easy);
                        break;

                    case FightQuestDifficulty.Medium:
                        quests = quests.SkipWhile(q => q.fight_difficulty > FightQuestDifficulty.Medium);
                        break;

                    case FightQuestDifficulty.Hard:
                        quests = quests.SkipWhile(q => q.fight_difficulty > FightQuestDifficulty.Hard);
                        break;
                }

                //Premium Or Statpoint Quest
                var PremiumOrStatpoint = quests.FirstOrDefault(q => q.GetRewards.premium > 0) ?? quests.FirstOrDefault(q => q.GetRewards.statPoints > 0);

                var quest = PremiumOrStatpoint ?? quests.FirstOrDefault();
                if (quest != null)
                {
                    QuestLog.Add(new Tuple<DateTime, Quest>(DateTime.Now, quest));
                    await StartQuest.TryExecuteAsync(quest);
                    // Account.Log.Add($"[Quest] START: ID:{quest.id} Duration:{quest.duration / 60}");
                }
            }
        }

        #endregion Methods
    }
}