using System.Linq;
using System.Threading.Tasks;

namespace HZBot
{
    public class DuelPlugin : HzPluginBase
    {
        #region Fields

        public string GegnerID = "";

        #endregion Fields

        #region Constructors

        public DuelPlugin(HzAccount account) : base(account)
        {
            StartBestDuel = new AsyncRelayCommand(
                async () => await this.StartDuellAsync(GegnerID),
                () => Account.IsLogined);

            CheckForDuelComplete = new AsyncRelayCommand(
                async () => await this.CheckForDuelCompleteAsync());

            claimDuelReward = new AsyncRelayCommand(
                async () => await this.ClaimDuelRewardsAsync());
        }

        #endregion Constructors

        #region Properties

        public AsyncRelayCommand StartBestDuel { get; private set; }
        public AsyncRelayCommand CheckForDuelComplete { get; private set; }
        public AsyncRelayCommand claimDuelReward { get; private set; }
        public Opponents GetOpponent { get; set; }
        public AsyncObservableCollection<DuelHistory> DuelList { get; set; } = new AsyncObservableCollection<DuelHistory>();

        #endregion Properties

        #region Methods

        public async override Task AfterPrimaryWorkerWork()
        {
            if (!Account.Config.IsAutoDuel)
                return;

            if (Account.Data.ActiveDuel != null)
            {
                await CheckForComplete();
            }

            var DuelStamina = (Account.Character.duel_stamina >= Account.Character.duel_stamina_cost ? 1 : 0);
            switch (DuelStamina)
            {
                case 1:
                    if (await this.GetDuelOpponentsAsync() != null) return;
                    if (Account.Data.opponents != null)
                        GetOpponent = FindOpponent();
                    if (GetOpponent != null)
                    {
                        DuelList.Add(new DuelHistory { id = GetOpponent.id, name = GetOpponent.name });
                        GegnerID = GetOpponent.id.ToString();
                        await StartBestDuel.TryExecuteAsync();
                    }
                    else
                    {
                        goto case 2;
                    }
                    await CheckForComplete();

                    if (Account.Character.duel_stamina >= Account.Character.duel_stamina_cost)
                        goto case 1;
                    break;

                case 2:
                    Account.Log.Add("Duel wird Deaktiviert Arbeite an deinen Stats du NOOB!");
                    Account.Config.IsAutoDuel = false;

                    break;
            }

            //while (Account.Character.duel_stamina >= Account.Character.duel_stamina_cost)
            //{
            //    if (Account.Data.ActiveDuel == null)
            //    {
            //        await this.GetDuelOpponentsAsync();
            //        GetOpponent = FindOpponent(false);
            //        if (GetOpponent != null)
            //        {
            //            // Add to Duel History
            //            DuelList.Add(new DuelHistory { id = GetOpponent.id, name = GetOpponent.name });

            //            GegnerID = GetOpponent.id.ToString();
            //            await StartBestDuel.TryExecuteAsync();
            //        }
            //        else
            //        {
            //            await this.GetLeaderboardAsync();

            //            var MyRank = Account.Data.centered_rank;
            //            var AktRank = Account.Data.centered_rank;
            //            var DiffRank = 0;
            //            var OpponentFound = false;
            //            var goBetterRank = true;

            //            while (!OpponentFound)
            //            {
            //                if (goBetterRank)
            //                {
            //                    AktRank--;
            //                    DiffRank = MyRank - AktRank;

            //                    var LCharID = Account.Data.leaderboard_characters.FirstOrDefault(ch => ch.rank == AktRank).id.ToString();

            //                    await this.GetCharacterAsync(LCharID);
            //                    OpponentFound = await CheckForOpponent(OpponentFound);

            //                    if (DiffRank >= 20)
            //                    {
            //                        goBetterRank = false;
            //                        AktRank = MyRank;
            //                    }
            //                }
            //                else
            //                {
            //                    AktRank++;
            //                    DiffRank = AktRank - MyRank;

            //                    var LCharID = Account.Data.leaderboard_characters.FirstOrDefault(ch => ch.rank == AktRank).id.ToString();

            //                    await this.GetCharacterAsync(LCharID);

            //                    OpponentFound = await CheckForOpponent(OpponentFound);

            //                    if (DiffRank >= 20)
            //                    {
            //                        FindOpponent(false);
            //                        return;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //    await CheckForComplete();
            //}
        }

        //private async Task<bool> CheckForOpponent(bool OpponentFound)
        //{
        //    if (Account.Data.requested_character != null)
        //    {
        //        var StatTotal = Account.Data.requested_character.stat_total_critical_rating +
        //                        Account.Data.requested_character.stat_total_dodge_rating +
        //                        Account.Data.requested_character.stat_total_stamina +
        //                        Account.Data.requested_character.stat_total_strength;
        //        if (StatTotal < Account.Character.FightStat && Account.Data.requested_character.stat_total_critical_rating < Account.Character.stat_total_critical_rating && Account.Data.requested_character.stat_total_dodge_rating < Account.Character.stat_total_dodge_rating)
        //        {
        //            OpponentFound = true;
        //            GegnerID = Account.Data.requested_character.id.ToString();
        //            // Add to Duel History
        //            DuelList.Add(new DuelHistory { id = Account.Data.requested_character.id, name = Account.Data.requested_character.name });
        //            await StartBestDuel.TryExecuteAsync();
        //        }
        //    }

        //    return OpponentFound;
        //}

        public Opponents FindOpponent(bool LookStats = true)
        {
            var fo = Account.Data.opponents.Where(g1 => Account.Data.character.FightStat > g1.fightStat);
            if (LookStats)
                fo.Where(g1 => g1.stat_total_critical_rating <= Account.Data.character.stat_total_critical_rating && g1.stat_total_dodge_rating <= Account.Data.character.stat_total_dodge_rating);

            fo = fo.OrderBy(g => g.fightStat);

            return fo.FirstOrDefault() ?? null;
        }

        private async Task CheckForComplete()
        {
            if (Account.Data.ActiveDuel?.character_a_status == 1 && Account.Data.ActiveDuel?.character_b_status == 1)
            {
                await CheckForDuelComplete.TryExecuteAsync();
            }
            if (Account.Data.ActiveDuel?.character_a_status == 2 || Account.Data.ActiveDuel?.character_b_status == 2)
            {
                await claimDuelReward.TryExecuteAsync();
            }
        }

        #endregion Methods
    }
}