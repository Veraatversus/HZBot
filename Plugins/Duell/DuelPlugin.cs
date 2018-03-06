using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZBot
{
    public class DuelPlugin : HzPluginBase
    {
        public DuelPlugin(HzAccount account) : base(account)
        {
            StartBestDuel = new AsyncRelayCommand(
                async () => await this.StartDuellAsync(GetOpponent.id.ToString()),
                () => Account.ActiveWorker != null);

            CheckForDuelComplete = new AsyncRelayCommand(
                async () => await this.CheckForDuelCompleteAsync());

            claimDuelReward = new AsyncRelayCommand(
                async () => await this.ClaimDuelRewardsAsync());

            Account.OnDataChanged += Account_OnDataChanged;
        }

        bool IsRunning = false;
        private async void Account_OnDataChanged()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                if (Account.Character.active_duel_id == 0)
                {
                    if (Account.Character.duel_stamina > 20)
                    {
                        await this.GetDuelOpponentsAsync();
                        GetOpponent = FindOpponent();
                        if (GetOpponent != null)
                        {
                            await StartBestDuel.TryExecuteAsync();
                            //Account.Log.Add($"[Duel]Start: Gegner-{GetOpponent.name} Stats:{GetOpponent.fightStat - Account.Character.FightStat}");
                        }
                    }
                }
                if (Account.Data.ActiveDuel?.character_a_status == 1 && Account.Data.ActiveDuel?.character_b_status == 1)
                {
                    await CheckForDuelComplete.TryExecuteAsync();
                }
                if (Account.Data.ActiveDuel?.character_a_status == 2 || Account.Data.ActiveDuel?.character_b_status == 2)
                {
                    IsRunning = false;
                    await claimDuelReward.TryExecuteAsync();
                }

                IsRunning = false;
            }
        }

        public Opponents FindOpponent()
        {
            // Find all Opponents where MyStats > OpStats
            var fo = Account.Data.opponents.Where(g1 => Account.Data.character.FightStat > g1.fightStat);
            // Find Opponent where lower Crit rating as my
            //fo = fo.SkipWhile(o => o.stat_total_critical_rating <= Account.Data.character.stat_total_critical_rating);
            fo = fo.OrderBy(g => g.fightStat);

            if (fo.FirstOrDefault() != null)
            {
                return fo.FirstOrDefault();
            }
            else
                return null;
        }

        #region Properties
        public AsyncRelayCommand StartBestDuel { get; private set; }
        public AsyncRelayCommand CheckForDuelComplete { get; private set; }
        public AsyncRelayCommand claimDuelReward { get; private set; }
        public Opponents GetOpponent { get; set; }
        #endregion
    }
}
