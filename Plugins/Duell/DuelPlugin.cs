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
                async () => await Account.Requests.StartDuellAsync(Account.Data.GetOpponent.id.ToString()),
                () => Account.IsLogined);

            CheckForDuelComplete = new AsyncRelayCommand(
                async () => await Account.Requests.CheckForDuelCompleteAsync());

            claimDuelReward = new AsyncRelayCommand(
                async () => await Account.Requests.claimDuelRewardseAsync());
        }

        public opponents FindOpponent()
        {
            // Find all Opponents where MyStats > OpStats
            var fo = Account.Data.opponents.Where(g1 => Account.Data.character.FightStat > g1.fightStat);
            // Find Opponent where lower Crit rating as my
            fo = fo.SkipWhile(o => o.stat_total_critical_rating <= Account.Data.character.stat_total_critical_rating);
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
        
        #endregion

        public async override Task OnExcecuteAsync()
        {
            if (Account.Character.duel_stamina >= 20)
            {
                await Account.Requests.GetDuelOpponentsAsync();
                Account.Data.GetOpponent = FindOpponent();
                if (Account.Data.GetOpponent != null)
                {
                    await StartBestDuel.TryExecuteAsync();
                    Account.logs.Add($"[Duel]Start: Gegner-{Account.Data.GetOpponent.name} Stats:{Account.Data.GetOpponent.fightStat - Account.Character.FightStat}");
                }
                else
                {
                    Account.logs.Add($"[Duel] KEIN PASSENDER GEGNER GEFUNDEN!");
                }
                await CheckForDuelComplete.TryExecuteAsync();
                await claimDuelReward.TryExecuteAsync();
            }
        }
    }
}
