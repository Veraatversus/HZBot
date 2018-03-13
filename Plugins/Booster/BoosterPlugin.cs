using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZBot
{
    public class BoosterPlugin : HzPluginBase
    { 
        public BoosterPlugin(HzAccount account) : base(account)
        { }

        public async override Task OnLogined()
        {
            var MBTime = Account.Data.character.ts_active_quest_boost_expires - Account.Data.server_time;
            var MBType = Account.Data.character.active_quest_booster_id;
            MBTime = (MBTime / 60) / 60;
            Account.Log.Add($"MissionsBooster ID: {MBType} verbleibend: {MBTime}");

            return;
        }
    }
}
