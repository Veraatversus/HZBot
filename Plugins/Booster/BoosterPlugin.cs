using System;
using System.Linq;
using System.Threading.Tasks;

namespace HZBot
{
    public class BoosterPlugin : HzPluginBase
    {
        #region Constructors

        public BoosterPlugin(HzAccount account) : base(account)
        {
            BuyBoosterCommand = new AsyncRelayCommand<Booster>(
                async (booster) => await this.BuyBoosterAsync(booster), CanBuyBooster);

        }

        #endregion Constructors

        #region Properties

        public AsyncRelayCommand<Booster> BuyBoosterCommand { get; private set; }
        #endregion Properties

        #region Methods

        public override async Task BeforPrimaryWorkerWork()
        {
            if (!Account.Config.IsAutoABooster)
                return;

            if (string.IsNullOrWhiteSpace(Account.Data.character.active_work_booster_id))
            {
                var workBooster = Account.Character.Boosters.FirstOrDefault(b => b.Constants.type == CBoosterType.Work && b.Constants.amount == Account.Config.WorkBooster);

                if (workBooster != null)
                    await BuyBoosterCommand.TryExecuteAsync(workBooster);
            }

            if (string.IsNullOrWhiteSpace(Account.Data.character.active_stats_booster_id))
            {
                var statsBooster = Account.Character.Boosters.FirstOrDefault(b => b.Constants.type == CBoosterType.Stats && b.Constants.amount == Account.Config.StatsBooster);

                if (statsBooster != null)
                    await BuyBoosterCommand.TryExecuteAsync(statsBooster);
            }

            if (string.IsNullOrWhiteSpace(Account.Data.character.active_quest_booster_id))
            {
                var questBooster = Account.Character.Boosters.FirstOrDefault(b => b.Constants.type == CBoosterType.Quest && b.Constants.amount == Account.Config.MissionBooster);

                if (questBooster != null)
                    await BuyBoosterCommand.TryExecuteAsync(questBooster);
            }
        }

        private bool CanBuyBooster(Booster booster)
        {
            if (booster.Constants.premium_item)
            {
                return Account.User.premium_currency >= booster.Cost;
            }
            else
            {
                return Account.Character.game_currency >= booster.Cost;
            }
        }

        #endregion Methods
    }
}