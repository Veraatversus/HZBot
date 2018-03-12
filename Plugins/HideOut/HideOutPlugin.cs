using System.Linq;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace HZBot
{
    public class HideOutPlugin : HzPluginBase
    {
        #region Constructors

        public HideOutPlugin(HzAccount account) : base(account)
        {
        }

        #endregion Constructors

        #region Methods

        public async override Task OnPrimaryWorkerDoWork()
        {

            // AutoHideOutCollect
            if (Account.Config.IsAutoHideOutCollect)
            {
                var roomz = Account.Data.hideout_rooms.FirstOrDefault(ro => ro.identifier == HideoutRoomTypes.MainBuilding);
                roomz = roomz ?? Account.Data.hideout_rooms.FirstOrDefault();
                //var t = roomz.currentCalculatedResourceAmount(Account);
                var j = roomz.secondsTillActivityFinished(Account);
                var u = roomz.currentGeneratorFactor();
                var o = roomz.maxResourceAmount();
                var p = roomz.resourceAmountPerMinute();
                var rooms = Account.Data.hideout_rooms;
                foreach (var room in rooms)
                {

                }
            }

            // IsAutoHideOutBuild
            if (Account.Config.IsAutoHideOutBuild)
            {
            }
            return;
        }


        #endregion Methods
    }
}