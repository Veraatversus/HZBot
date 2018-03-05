using System.Threading.Tasks;

namespace HZBot
{
    public class DuelPlugin : HzPluginBase
    {
        #region Constructors

        public DuelPlugin(HzAccount account) : base(account)
        {
            StartBestDuel = new AsyncRelayCommand(
                async () => await this.StartDuellAsync(Account.Data.BestDuel.id.ToString()));

            CheckForDuelComplete = new AsyncRelayCommand(
                async () => await this.CheckForDuelCompleteAsync());

            ClaimDuelReward = new AsyncRelayCommand(
                async () => await this.ClaimDuelRewardsAsync());
        }

        #endregion Constructors

        #region Properties

        public AsyncRelayCommand StartBestDuel { get; private set; }
        public AsyncRelayCommand CheckForDuelComplete { get; private set; }
        public AsyncRelayCommand ClaimDuelReward { get; private set; }
        public bool IsAutoDuel { get; set; }

        #endregion Properties

        #region Methods

        public async override Task OnPrimaryWorkerComplete()
        {
            if (IsAutoDuel)
            {
                if (Account.Character.duel_stamina >= 20)
                {
                    await this.GetDuelOpponentsAsync();
                    await StartBestDuel.TryExecuteAsync();
                    Account.Log.Add($"[Duell]Start: Gegner-{Account.Data.BestDuel.name} Stats:{Account.Data.BestDuel.fightStat - Account.Character.FightStat}");
                    await CheckForDuelComplete.TryExecuteAsync();
                    await ClaimDuelReward.TryExecuteAsync();
                }
            }
        }

        #endregion Methods
    }
}