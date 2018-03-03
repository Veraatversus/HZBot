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
                async () => await Account.Requests.StartDuellAsync(Account.Data.BestDuel.id.ToString()),
                () => Account.ActiveWorker == null && Account.IsLogined);

            CheckForDuelComplete = new AsyncRelayCommand(
                async () => await Account.Requests.CheckForDuelCompleteAsync());

            claimDuelReward = new AsyncRelayCommand(
                async () => await Account.Requests.claimDuelRewardseAsync());
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
                await StartBestDuel.TryExecuteAsync();
                Account.logs.Add($"[Duell]Start: Gegner-{Account.Data.BestDuel.name} Stats:{Account.Data.BestDuel.fightStat - Account.Character.FightStat}");
                await CheckForDuelComplete.TryExecuteAsync();
                await claimDuelReward.TryExecuteAsync();
            }
        }

        
    }
}
