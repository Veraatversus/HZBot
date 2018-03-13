﻿using System;
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
    }
}