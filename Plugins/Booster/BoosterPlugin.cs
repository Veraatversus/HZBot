using System.Threading.Tasks;

namespace HZBot
{
    public class BoosterPlugin : HzPluginBase
    {
        #region Constructors

        public BoosterPlugin(HzAccount account) : base(account)
        {
            BuyBoosterCommand = new AsyncRelayCommand<Booster>(b => this.BuyBoosterAsync(b), CanBuyBooster);
        }

        #endregion Constructors

        #region Properties

        public AsyncRelayCommand<Booster> BuyBoosterCommand { get; private set; }

        #endregion Properties

        #region Methods

        public async override Task OnLogined()
        {
            var MBTime = Account.Data.character.ts_active_quest_boost_expires - Account.Data.server_time;
            var MBType = Account.Data.character.active_quest_booster_id;
            MBTime = (MBTime / 60) / 60;
            if (MBTime <= 6)
            {
                if (Account.User.premium_currency >= 10)
                {
                }
            }

            var SBTime = Account.Data.character.ts_active_stats_boost_expires - Account.Data.server_time;
            var SBType = Account.Data.character.active_stats_booster_id;
            SBTime = (SBTime / 60) / 60;

            var WBTime = Account.Data.character.ts_active_work_boost_expires - Account.Data.server_time;
            var WBType = Account.Data.character.active_work_booster_id;
            WBTime = (WBTime / 60) / 60;

            Account.Log.Add($"MissionsBooster ID: {MBType} verbleibend: {MBTime}");
            Account.Log.Add($"StatsBooster ID: {SBType} verbleibend: {SBTime}");
            Account.Log.Add($"WorkBooster ID: {WBType} verbleibend: {WBTime}");
            return;
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