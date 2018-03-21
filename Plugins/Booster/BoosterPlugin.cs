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
            BuyBoosterCommand = new AsyncRelayCommand(
                async () => await this.BuyBoosterAsync(boosterID),
                () => Account.IsLogined);

        }

        #endregion Constructors

        #region Properties

        public AsyncRelayCommand BuyBoosterCommand { get; private set; }
        string boosterID = "";
        #endregion Properties

        #region Methods

        public override async Task OnBotStarted()
        {
            if (Account.Data.character.active_work_booster_id == null)
            {
                switch (Account.Config.WorkBooster)
                {
                    case "10%":
                        boosterID = "booster_work1";
                        break;
                    case "25%":
                        boosterID = "booster_work2";
                        break;
                    case "50%":
                        boosterID = "booster_work3";
                        break;
                        //    }
                }
            }

            if (boosterID != "")
                await BuyBoosterCommand.TryExecuteAsync();
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