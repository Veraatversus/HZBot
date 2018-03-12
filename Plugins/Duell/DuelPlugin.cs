using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HZBot
{
    public class DuelPlugin : HzPluginBase
    {
        #region Constructors

        public DuelPlugin(HzAccount account) : base(account)
        {
            StartBestDuel = new AsyncRelayCommand(
                async () => await this.StartDuellAsync(GegnerID));

            CheckForDuelComplete = new AsyncRelayCommand(
                async () => await this.CheckForDuelCompleteAsync());

            claimDuelReward = new AsyncRelayCommand(
                async () => await this.ClaimDuelRewardsAsync());

            //Account.OnDataChanged += Account_OnDataChanged;
        }

        #endregion Constructors

        #region Properties
        public AsyncRelayCommand StartBestDuel { get; private set; }
        public AsyncRelayCommand CheckForDuelComplete { get; private set; }
        public AsyncRelayCommand claimDuelReward { get; private set; }
        public Opponents GetOpponent { get; set; }
        public string GegnerID = "";
        public ObservableCollection<DuelHistory> DuelList { get; set; } = new ObservableCollection<DuelHistory>();
        #endregion Properties

        #region Methods

        public async override Task AfterPrimaryWorkerWork()
        {
            if (!Account.Config.IsAutoDuel)
                return;

            if (Account.Data.ActiveDuel != null && Account.Character.duel_stamina < 20)
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

            while (Account.Character.duel_stamina >= Account.Character.duel_stamina_cost)
            {
                if (Account.Data.ActiveDuel == null)
                {
                    await this.GetDuelOpponentsAsync();
                    GetOpponent = FindOpponent();
                    if (GetOpponent != null)
                    {
                        // Add to Duel History
                        DuelList.Add(new DuelHistory() { id = GetOpponent.id, name = GetOpponent.name });

                        GegnerID = GetOpponent.id.ToString();
                        await StartBestDuel.TryExecuteAsync();
                        
                    }
                    else
                    {
                        await this.GetLeaderboardAsync();

                        int MyRank = Account.Data.centered_rank;
                        int AktRank = Account.Data.centered_rank;
                        int DiffRank = 0;
                        bool OpponentFound = false;
                        bool goBetterRank = true;

                        while(!OpponentFound)
                        {
                            
                            if (goBetterRank)
                            {
                                AktRank--;
                                DiffRank = MyRank - AktRank;
                                

                                string LCharID = Account.Data.leaderboard_characters.FirstOrDefault(ch => ch.rank == AktRank).id.ToString();

                                await this.GetCharacterAsync(LCharID);

                                if (Account.Data.requested_character != null)
                                {
                                    int StatTotal = Account.Data.requested_character.stat_total_critical_rating +
                                                    Account.Data.requested_character.stat_total_dodge_rating +
                                                    Account.Data.requested_character.stat_total_stamina +
                                                    Account.Data.requested_character.stat_total_strength;
                                    if (StatTotal < Account.Character.FightStat && Account.Data.requested_character.stat_total_critical_rating < Account.Character.stat_total_critical_rating && Account.Data.requested_character.stat_total_dodge_rating < Account.Character.stat_total_dodge_rating)
                                    {
                                        OpponentFound = true;
                                        GegnerID = Account.Data.requested_character.id.ToString();
                                        // Add to Duel History
                                        DuelList.Add(new DuelHistory() { id = Account.Data.requested_character.id, name = Account.Data.requested_character.name });
                                        await StartBestDuel.TryExecuteAsync();
                                    }
                                }
                                if (DiffRank >= 20)
                                {
                                    goBetterRank = false;
                                    AktRank = MyRank;
                                }
                            } else
                            {
                                AktRank++;
                                DiffRank = AktRank - MyRank;

                                string LCharID = Account.Data.leaderboard_characters.FirstOrDefault(ch => ch.rank == AktRank).id.ToString();

                                await this.GetCharacterAsync(LCharID);

                                if (Account.Data.requested_character != null)
                                {
                                    int StatTotal = Account.Data.requested_character.stat_total_critical_rating +
                                                    Account.Data.requested_character.stat_total_dodge_rating +
                                                    Account.Data.requested_character.stat_total_stamina +
                                                    Account.Data.requested_character.stat_total_strength;
                                    if (StatTotal < Account.Character.FightStat && Account.Data.requested_character.stat_total_critical_rating < Account.Character.stat_total_critical_rating && Account.Data.requested_character.stat_total_dodge_rating < Account.Character.stat_total_dodge_rating)
                                    {
                                        OpponentFound = true;
                                        GegnerID = Account.Data.requested_character.id.ToString();
                                        // Add to Duel History
                                        DuelList.Add(new DuelHistory() { id = Account.Data.requested_character.id, name = Account.Data.requested_character.name });
                                        await StartBestDuel.TryExecuteAsync();
                                    }
                                }

                                if (DiffRank >= 20)
                                {
                                    FindOpponent(false);
                                    return;
                                }
                            }
                        }

                    }
                }
                if (Account.Data.ActiveDuel?.character_a_status == 1 && Account.Data.ActiveDuel?.character_b_status == 1)
                {
                    await CheckForDuelComplete.TryExecuteAsync();
                }
                if (Account.Data.ActiveDuel?.character_a_status == 2 || Account.Data.ActiveDuel?.character_b_status == 2)
                {
                    await claimDuelReward.TryExecuteAsync();
                }
            }
        }

        public Opponents FindOpponent(bool LookStats=true)
        {
            var fo = Account.Data.opponents.Where(g1 => Account.Data.character.FightStat > g1.fightStat);
            if (LookStats)
                fo.Where(g1 => g1.stat_total_critical_rating <= Account.Data.character.stat_total_critical_rating && g1.stat_total_dodge_rating <= Account.Data.character.stat_total_dodge_rating);

            fo = fo.OrderBy(g => g.fightStat);

            if (fo.FirstOrDefault() != null)
            {
                return fo.FirstOrDefault();
            }
            else
                return null;
        }

        #endregion Methods

        #region Fields

        private bool IsRunning = false;

        #endregion Fields
    }
}