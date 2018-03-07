using Newtonsoft.Json.Linq;
using System;

namespace HZBot
{
    public static class GameUtil
    {
        #region Methods

        public static Double gameCurrencyPerTime(double param1)
        {
            var _loc6_ = HzConstants.Default.Constants["coins_per_time_base"].Value<double>();
            var _loc3_ = HzConstants.Default.Constants["coins_per_time_scale"].Value<double>();
            var _loc4_ = HzConstants.Default.Constants["coins_per_time_level_scale"].Value<double>();
            var _loc5_ = HzConstants.Default.Constants["coins_per_time_level_exp"].Value<double>();
            var _loc2_ = _loc6_ + _loc3_ * Math.Pow(_loc4_ * param1, _loc5_);
            return HzConstants.Default.RoundDecimal(_loc2_, 3);
        }

        public static double calcNeededGameCurrency(double param1)
        {
            var _loc5_ = HzConstants.Default.Constants["cost_stat_base"].Value<double>();
            var _loc3_ = HzConstants.Default.Constants["cost_stat_scale"].Value<double>();
            var _loc6_ = HzConstants.Default.Constants["cost_stat_base_scale"].Value<double>();
            var _loc4_ = HzConstants.Default.Constants["cost_stat_base_exp"].Value<double>();
            var _loc2_ = Math.Round(_loc5_ + _loc3_ * Math.Pow(_loc6_ * param1, _loc4_));
            return _loc2_;
        }

        public static double boosterCost(double param1, bool param2)
        {
            var _loc7_ = Math.Ceiling((param1 + 1) / 10);
            double _loc3_ = 0;
            if (param2)
            {
                _loc3_ = (HzConstants.Default.Constants["booster_small_costs_time"].Value<double>());
            }
            else
            {
                _loc3_ = (HzConstants.Default.Constants["booster_medium_costs_time"].Value<double>());
            }
            var _loc8_ = HzConstants.Default.Constants["booster_costs_coins_step"].Value<double>();
            var _loc5_ = HzConstants.Default.Constants["coins_per_time_base"].Value<double>();
            var _loc9_ = HzConstants.Default.Constants["coins_per_time_scale"].Value<double>();
            var _loc10_ = HzConstants.Default.Constants["coins_per_time_level_scale"].Value<double>();
            var _loc6_ = HzConstants.Default.Constants["coins_per_time_level_exp"].Value<double>();
            var _loc4_ = Math.Ceiling((_loc5_ + _loc9_ * Math.Pow(_loc10_ * (_loc7_ * 10 - 9), _loc6_)) * _loc3_ / _loc8_) * _loc8_;
            return Math.Round(_loc4_);
        }

        public static double getHitPoints(double param1)
        {
            var _loc2_ = HzConstants.Default.Constants["battle_hp_scale"].Value<double>();
            var _loc3_ = _loc2_ * param1;
            return Math.Round(_loc3_);
        }

        public static double getCriticalHitPercentage(double param1, double param2)
        {
            var _loc8_ = HzConstants.Default.Constants["battle_critical_probability_min"].Value<double>();
            var _loc6_ = HzConstants.Default.Constants["battle_critical_probability_base"].Value<double>();
            var _loc3_ = HzConstants.Default.Constants["battle_critical_probability_max"].Value<double>();
            var _loc4_ = HzConstants.Default.Constants["battle_critical_probability_exp_low"].Value<double>();
            var _loc5_ = HzConstants.Default.Constants["battle_critical_probability_exp_high"].Value<double>();
            var _loc9_ = param1 / param2;
            double _loc7_ = 0;
            if (_loc9_ <= 1)
            {
                _loc7_ = Math.Pow(_loc9_, _loc4_) * (_loc6_ - _loc8_) + _loc8_;
            }
            else
            {
                _loc7_ = (1 - Math.Pow(1 / _loc9_, _loc5_)) * (_loc3_ - _loc6_) + _loc6_;
            }
            return HzConstants.Default.RoundDecimal(_loc7_, 3);
        }

        public static double getDodgePercentage(double param1, double param2)
        {
            var _loc5_ = HzConstants.Default.Constants["battle_dodge_probability_min"].Value<double>();
            var _loc6_ = HzConstants.Default.Constants["battle_dodge_probability_base"].Value<double>();
            var _loc4_ = HzConstants.Default.Constants["battle_dodge_probability_max"].Value<double>();
            var _loc7_ = HzConstants.Default.Constants["battle_dodge_probability_exp_low"].Value<double>();
            var _loc8_ = HzConstants.Default.Constants["battle_dodge_probability_exp_high"].Value<double>();
            var _loc9_ = param1 / param2;
            double _loc3_ = 0;
            if (_loc9_ <= 1)
            {
                _loc3_ = Math.Pow(_loc9_, _loc7_) * (_loc6_ - _loc5_) + _loc5_;
            }
            else
            {
                _loc3_ = (1 - Math.Pow(1 / _loc9_, _loc8_)) * (_loc4_ - _loc6_) + _loc6_;
            }
            return HzConstants.Default.RoundDecimal(_loc3_, 3);
        }

        public static double getDamage(double param1, double param2, double param3)
        {
            var _loc4_ = param1 + param2 + param3;
            return Math.Round(_loc4_);
        }

        public static double getQuestInstantFinishCost(double param1)
        {
            if (param1 < HzConstants.Default.Constants["quest_instant_finish_range1_duration"].Value<double>() * 60)
            {
                return HzConstants.Default.Constants["quest_instant_finish_range1_premium_amount"].Value<double>();
            }
            if (param1 < HzConstants.Default.Constants["quest_instant_finish_range2_duration"].Value<double>() * 60)
            {
                return HzConstants.Default.Constants["quest_instant_finish_range2_premium_amount"].Value<double>();
            }
            if (param1 < HzConstants.Default.Constants["quest_instant_finish_range3_duration"].Value<double>() * 60)
            {
                return HzConstants.Default.Constants["quest_instant_finish_range3_premium_amount"].Value<double>();
            }
            return HzConstants.Default.Constants["quest_instant_finish_range4_premium_amount"].Value<double>();
        }

        public static double duelHonorWinReward(double param1, double param2, double param3 = 1, double param4 = 1)
        {
            var _loc7_ = HzConstants.Default.Constants["pvp_honor_win_exp_better"].Value<double>();
            var _loc5_ = HzConstants.Default.Constants["pvp_honor_win_exp_worse"].Value<double>();
            double _loc6_ = 0;
            if (param1 > param2)
            {
                _loc6_ = 1 - Math.Pow(param2 / param1, _loc5_);
            }
            else
            {
                _loc6_ = -1 * (1 - Math.Pow(param1 / param2, _loc7_));
            }
            _loc6_ = 100 - _loc6_ * 100;
            _loc6_ = _loc6_ * param3 * param4;
            return Math.Round(_loc6_);
        }

        public static double duelHonorLostReward(double param1, double param2)
        {
            if (param1 == 0)
            {
                return 0;
            }
            var _loc4_ = HzConstants.Default.Constants["pvp_honor_lose_amount"].Value<double>();
            var _loc6_ = HzConstants.Default.Constants["pvp_honor_lose_max"].Value<double>();
            var _loc5_ = duelHonorWinReward(param1, param2);
            double _loc7_ = 0;
            if (_loc4_ * _loc5_ < _loc6_ * param2)
            {
                _loc7_ = _loc4_ * _loc5_;
            }
            else
            {
                _loc7_ = _loc6_ * param2;
            }
            var _loc3_ = Math.Round(_loc7_);
            _loc3_ = _loc3_ * -1;
            return _loc3_;
        }

        public static double duelGameCurrencyWinReward(double param1, double param2 = 1, double param3 = 1)
        {
            var _loc5_ = HzConstants.Default.Constants["pvp_waiting_time"].Value<double>();
            var _loc4_ = HzConstants.Default.Constants["pvp_effectiveness_won"].Value<double>();
            var _loc6_ = _loc5_ * gameCurrencyPerTime(param1) * _loc4_ * param2 * param3;
            return Math.Round(_loc6_);
        }

        public static double gameCurrencyCostEnergyRefill(double param1, double param2)
        {
            var _loc5_ = param2 / HzConstants.Default.Constants["quest_energy_refill_amount"].Value<double>();
            double _loc4_ = 0;
            switch ((int)(_loc5_))
            {
                case 0:
                    _loc4_ = HzConstants.Default.Constants["quest_energy_refill1_cost_factor"].Value<double>();
                    break;

                case 1:
                    _loc4_ = HzConstants.Default.Constants["quest_energy_refill2_cost_factor"].Value<double>();
                    break;

                case 2:
                    _loc4_ = HzConstants.Default.Constants["quest_energy_refill3_cost_factor"].Value<double>();
                    break;

                case 3:
                    _loc4_ = HzConstants.Default.Constants["quest_energy_refill4_cost_factor"].Value<double>();
                    break;

                case 4:
                    _loc4_ = HzConstants.Default.Constants["quest_energy_refill5_cost_factor"].Value<double>();
                    break;

                case 5:
                    _loc4_ = HzConstants.Default.Constants["quest_energy_refill6_cost_factor"].Value<double>();
                    break;

                case 6:
                    _loc4_ = HzConstants.Default.Constants["quest_energy_refill7_cost_factor"].Value<double>();
                    break;

                case 7:
                    _loc4_ = HzConstants.Default.Constants["quest_energy_refill8_cost_factor"].Value<double>();
                    break;
            }
            var _loc3_ = _loc4_ * gameCurrencyPerTime(param1);
            return Math.Round(_loc3_);
        }

        public static double getGoalRewardAmount(double param1, double param2, double param3)
        {
            var _loc7_ = double.NaN;
            var _loc11_ = double.NaN;
            var _loc5_ = double.NaN;
            var _loc9_ = 0;
            var _loc8_ = 0;
            var _loc10_ = 0;
            var _loc6_ = double.NaN;
            double _loc4_ = 0;
            switch ((int)(param1) - 1)
            {
                case 0:
                    _loc7_ = gameCurrencyPerTime(param3);
                    _loc11_ = HzConstants.Default.Constants["goal_reward_game_currency_time"].Value<double>();
                    _loc5_ = HzConstants.Default.Constants["goal_reward_game_currency_percentage_base"].Value<double>();
                    _loc5_ = _loc5_ * param2;
                    _loc7_ = Math.Round(_loc7_ * _loc5_ * _loc11_);
                    _loc7_ = _loc7_ + Math.Pow(param3, HzConstants.Default.Constants["goal_reward_game_currency_exp"].Value<double>());
                    return Math.Round(_loc7_);

                case 1:
                    _loc4_ = HzConstants.Default.Constants["goal_reward_premium_currency_base"].Value<double>();
                    _loc4_ = _loc4_ * param2;
                    return Math.Round(_loc4_);

                case 2:
                    _loc4_ = HzConstants.Default.Constants["goal_reward_stat_points_base"].Value<double>();
                    _loc4_ = _loc4_ * param2;
                    return Math.Round(_loc4_);

                case 3:
                    if (param3 >= HzConstants.Default.Constants["max_level"].Value<double>())
                    {
                        return 0;
                    }
                    _loc9_ = HzConstants.Default.Constants["levels"][param3]["xp"].Value<int>();  // CLevel.fromId(param3).xp;
                    _loc8_ = HzConstants.Default.Constants["levels"][param3 + 1]["xp"].Value<int>();  //CLevel.fromId(param3 + 1).xp;
                    _loc10_ = _loc8_ - _loc9_;
                    _loc6_ = HzConstants.Default.Constants["goal_reward_xp_percentage_base"].Value<double>();
                    _loc6_ = _loc6_ * param2;
                    return Math.Round(_loc10_ * _loc6_);

                case 4:
                    return 0;

                case 5:
                    _loc4_ = HzConstants.Default.Constants["goal_reward_training_base"].Value<double>();
                    _loc4_ = _loc4_ * param2;
                    return Math.Round(_loc4_);

                case 6:
                case 7:
                case 8:
                    _loc4_ = HzConstants.Default.Constants["goal_reward_energy_base"].Value<double>();
                    _loc4_ = _loc4_ * param2;
                    return Math.Round(_loc4_);

                case 9:
                    _loc4_ = HzConstants.Default.Constants["goal_reward_hideout_glue_base"].Value<double>();
                    _loc4_ = _loc4_ * param2;
                    return Math.Round(_loc4_);

                case 10:
                    _loc4_ = HzConstants.Default.Constants["goal_reward_hideout_stone_base"].Value<double>();
                    _loc4_ = _loc4_ * param2;
                    return Math.Round(_loc4_);
            }
            return 0; //ka
        }

        public static double getItemPatternRewardAmount(double param1, double param2)
        {
            double _loc3_ = 0;
            switch ((int)(param1) - 1)
            {
                case 0:
                    _loc3_ = HzConstants.Default.Constants["item_pattern_reward_stat_points_base"].Value<double>();
                    _loc3_ = _loc3_ * Math.Round(param2);
                    return _loc3_;

                case 1:
                    return 0;

                case 2:
                    _loc3_ = HzConstants.Default.Constants["item_pattern_reward_training_base"].Value<double>();
                    _loc3_ = _loc3_ * Math.Round(param2);
                    return _loc3_;

                case 3:
                    _loc3_ = HzConstants.Default.Constants["item_pattern_reward_energy_base"].Value<double>();
                    _loc3_ = _loc3_ * Math.Round(param2);
                    return _loc3_;
            }
            return 0; // ka
        }

        public static double getOpticalChangeRewardAmount(double param1, double param2)
        {
            double _loc3_ = 0;//int
            switch ((int)(param1) - 1)
            {
                case 0:
                    _loc3_ = HzConstants.Default.Constants["optical_changes_reward_stat_points_base"].Value<double>();
                    _loc3_ = _loc3_ * Math.Round(param2);
                    return _loc3_;

                case 1:
                    return 0;

                case 2:
                    _loc3_ = HzConstants.Default.Constants["optical_changes_reward_training_base"].Value<double>();
                    _loc3_ = _loc3_ * Math.Round(param2);
                    return _loc3_;

                case 3:
                    _loc3_ = HzConstants.Default.Constants["optical_changes_reward_energy_base"].Value<double>();
                    _loc3_ = _loc3_ * Math.Round(param2);
                    return _loc3_;
            }
            return 0; //ka
        }

        public static double getEventQuestObjectiveRewardAmount(double param1, double param2, int param3)
        {
            var _loc5_ = double.NaN;
            var _loc9_ = double.NaN;
            var _loc11_ = double.NaN;
            var _loc7_ = 0;
            var _loc6_ = 0;
            var _loc8_ = 0;
            var _loc10_ = double.NaN;
            double _loc4_ = 0;
            switch ((int)(param1) - 1)
            {
                case 0:
                    _loc5_ = gameCurrencyPerTime(param3);
                    _loc9_ = HzConstants.Default.Constants["event_quest_objective_reward_game_currency_time"].Value<double>();
                    _loc11_ = HzConstants.Default.Constants["event_quest_objective_reward_game_currency_percentage_base"].Value<double>();
                    _loc11_ = _loc11_ * param2;
                    _loc5_ = Math.Round(_loc5_ * _loc11_ * _loc9_);
                    _loc5_ = _loc5_ + Math.Pow(param3, HzConstants.Default.Constants["event_quest_objective_reward_game_currency_exp"].Value<double>());
                    return Math.Round(_loc5_);

                case 1:
                    _loc4_ = HzConstants.Default.Constants["event_quest_objective_reward_premium_currency_base"].Value<double>();
                    _loc4_ = _loc4_ * Math.Round(param2);
                    return _loc4_;

                case 2:
                    _loc4_ = HzConstants.Default.Constants["event_quest_objective_reward_stat_points_base"].Value<double>();
                    _loc4_ = _loc4_ * Math.Round(param2);
                    return _loc4_;

                case 3:
                    if (param3 >= HzConstants.Default.Constants["max_level"].Value<double>())
                    {
                        return 0;
                    }
                    _loc7_ = HzConstants.Default.Constants["levels"][param3]["xp"].Value<int>(); //CLevel.fromId(param3).xp;
                    _loc6_ = HzConstants.Default.Constants["levels"][param3 + 1]["xp"].Value<int>(); // CLevel.fromId(param3 + 1).xp;
                    _loc8_ = _loc6_ - _loc7_;
                    _loc10_ = HzConstants.Default.Constants["event_quest_objective_reward_xp_percentage_base"].Value<double>();
                    _loc10_ = _loc10_ * param2;
                    return Math.Round(_loc8_ * _loc10_);
            }
            return 0; //ka
        }

        public static int getTrainingInstantFinishCost(double param1)
        {
            if (param1 % 2 != 0)
            {
                param1++;
            }
            return (int)(param1 / 2);
        }

        public static int getTrainingStartPremiumCurrencyCost(double param1)
        {
            if (param1 <= 1)
            {
                return 0;
            }
            if (param1 % 2 != 0)
            {
                param1++;
            }
            return (int)(param1 / 2);
        }

        public static int guildBattleCost(double param1)
        {
            var _loc2_ = HzConstants.Default.Constants["guild_battle_attack_cost"][Math.Floor(param1)]["gameCurrencyCost"].Value<int>(); // CGuildBattleAttackCost.fromId(Math.floor(param1)).gameCurrencyCost;
            return _loc2_;
        }

        public static int guildDungeonBattleCost(double param1)
        {
            var _loc2_ = HzConstants.Default.Constants["guild_battle_attack_cost"][Math.Floor(param1)]["gameCurrencyCost"].Value<int>(); //CGuildDungeonAttackCost.fromId(Math.floor(param1)).gameCurrencyCost;
            return _loc2_;
        }

        public static double guildBattleHonorWinReward(double param1, double param2)
        {
            return duelHonorWinReward(param1, param2) * 10;
        }

        public static double guildBattleHonorLostReward(double param1, double param2)
        {
            return duelHonorLostReward(param1, param2) * 10;
        }

        public static double roundDuration(double param1)
        {
            if (param1 < 60)
            {
                return 60;
            }
            var _loc3_ = 60;
            var _loc2_ = param1 % _loc3_;
            if (_loc2_ == 0)
            {
                return param1;
            }
            if (_loc2_ < _loc3_ / 2)
            {
                return param1 - _loc2_;
            }
            return param1 - _loc2_ + _loc3_;
        }

        public static int getWorldbossAttackInstantFinishCost()
        {
            return HzConstants.Default.Constants["worldboss_event_instant_finish_premium_amount"].Value<int>();
        }

        //      public static  void testFormulas()
        //      {
        //         testGetCoinReward(3600);
        //testCalcNeededCoins();
        //      }

        //      public static testGetCoinReward(param1:Number) : void
        //      {
        //         var _loc2_:int = 0;
        //         _loc2_ = 1;
        //         while(_loc2_ <= 300)
        //         {
        //            Logger.debug("-Level " + _loc2_.toString() + ": " + gameCurrencyPerTime(_loc2_).toString() + " Coins");
        //            _loc2_++;
        //         }
        //      }

        //      public static testCalcNeededCoins() : void
        //      {
        //         var _loc1_:int = 0;
        //         _loc1_ = 1;
        //         while(_loc1_ <= 1000)
        //         {
        //            Logger.debug("Stat " + _loc1_.toString() + ": " + calcNeededGameCurrency(_loc1_).toString() + " Coins");
        //            _loc1_++;
        //         }
        //      }

        //      public static string getHint(double param1)
        //      {
        //         var  _loc4_= null;
        //         var _loc2_:Vector.<String> = new Vector.<String>();
        //         var _loc6_:int = 0;
        //         var _loc5_:* = CHint.ids;
        //         for each(var _loc3_ in CHint.ids)
        //{
        //    _loc4_ = CHint.fromId(_loc3_);
        //    if (_loc4_.requiredLevel <= param1 && (_loc4_.maxLevel >= param1 || _loc4_.maxLevel == 0))
        //    {
        //        _loc2_.push(_loc3_);
        //    }
        //}
        //_loc2_.sort(shuffleVector);
        //         return LocText.current.text("hint/" + _loc2_.pop() + "/text");
        //      }

        //private static int shuffleVector(object param1,object param2)
        //{
        //   return Math.Floor(Math..Random() * 3 - 1);
        //}

        public static bool matchesRef(string param1, string param2, char param3)
        {
            return param1.IndexOf(param2) == 0 && param1[param1.Length - 4] == '-' && param1[param1.Length - 3] == param3;
        }

        public static double itemPatternSewPrice(double param1, int param2, int param3)
        {
            var _loc4_ = double.NaN;
            if (param1 == 1)
            {
                _loc4_ = param2 * HzConstants.Default.Constants["sewing_machine_common_game_currency_factor"].Value<double>();
                return Math.Round(_loc4_);
            }
            var _loc5_ = param3;
            if (_loc5_ == 0)
            {
                switch ((int)(param1) - 2)
                {
                    case 0:
                        _loc5_ = (int)(HzConstants.Default.Constants["sewing_machine_rare_premium_currency_amount"].Value<double>());
                        break;

                    case 1:
                        _loc5_ = (int)(HzConstants.Default.Constants["sewing_machine_epic_premium_currency_amount"].Value<double>());
                        break;
                }
            }
            return _loc5_;
        }

        public static double getQuestRefreshCost(bool param1, int param2)
        {
            var _loc4_ = HzConstants.Default.Constants["quest_refresh_single_stage_premium_currency_amount"].Value<int>();
            var _loc3_ = HzConstants.Default.Constants["quest_refresh_all_stages_reduction_factor"].Value<double>();
            if (!param1)
            {
                return _loc4_;
            }
            return Math.Round(_loc4_ + param2 * _loc3_);
        }

        public static double getSidekickStatPlus(double param1, int param2, int param3)
        {
            var _loc7_ = param3;
            var _loc5_ = 0;
            var _loc6_ = GameUtil.getNewSidekickStatValue(param1, param3, param2 - 1);
            var _loc4_ = GameUtil.getNewSidekickStatValue(param1, param3, param2);
            return _loc4_ - _loc6_;
        }

        public static double getNewSidekickStatValue(double param1, int param2, int param3)
        {
            double _loc5_ = 0;
            switch ((int)(param1) - 1)
            {
                case 0:
                    _loc5_ = HzConstants.Default.Constants["sidekick_stat_factor_common"].Value<double>();
                    break;

                case 1:
                    _loc5_ = HzConstants.Default.Constants["sidekick_stat_factor_rare"].Value<double>();
                    break;

                case 2:
                    _loc5_ = HzConstants.Default.Constants["sidekick_stat_factor_epic"].Value<double>();
                    break;
            }
            var _loc4_ = Math.Round(param2 + param2 * _loc5_ * (param3 - 1));
            return _loc4_;
        }

        public static double questCoinReward(double param1, double param2, int param3, double param4 = 1, double param5 = 0)
        {
            if (param2 == 1)
            {
                return 5;
            }
            double _loc7_ = 0;
            switch ((int)(param3) - 1)
            {
                case 0:
                    _loc7_ = HzConstants.Default.Constants["quest_reward_coin_scale_balanced"].Value<double>();
                    break;

                case 1:
                    _loc7_ = HzConstants.Default.Constants["quest_reward_coin_scale_xp_heavy"].Value<double>();
                    break;

                case 2:
                    _loc7_ = HzConstants.Default.Constants["quest_reward_coin_scale_coin_heavy"].Value<double>();
                    break;

                case 3:
                    _loc7_ = HzConstants.Default.Constants["quest_reward_coin_scale_item"].Value<double>();
                    break;
            }
            var _loc6_ = param1 * gameCurrencyPerTime(param2) * _loc7_ * param4;
            return Math.Round(_loc6_ * (1 + param5));
        }

        public static double getCustomBannerRewardAmount(string param1, int param2, double param3)
        {
            var _loc4_ = param1;
            if ("game_currency" != _loc4_)
            {
                return 0;
            }
            return questCoinReward(param2, param3, 1, 1, 0);
        }

        #endregion Methods

        //      public static int getHighestWorldbossRewardValue(double param1)
        //      {
        //         var _loc3_:* = null;
        //         var _loc5_ = 0;
        //         var _loc2_:* = 0;
        //         var _loc7_ = 0;
        //         var _loc6_:* = CWorldbossEventReward.ids;
        //         for each(var _loc4_ in CWorldbossEventReward.ids)
        //{
        //    _loc3_ = CWorldbossEventReward.fromId(_loc4_);
        //    _loc5_ = 0;
        //    switch (int(param1) - 1)
        //    {
        //        case 0:
        //            _loc5_ = _loc3_.reward1Value;
        //            break;
        //        case 1:
        //            _loc5_ = _loc3_.reward2Value;
        //    }
        //    if (_loc5_ > _loc2_)
        //    {
        //        _loc2_ = _loc5_;
        //    }
        //}
        //         return _loc2_;
        //      }

        //      public static getQuestStageUnlockLevel(double param1) : int
        //      {
        //         if(param1 <= 0)
        //         {
        //            return 0;
        //         }
        //         if(param1 > CStage.count)
        //         {
        //            return 0;
        //         }
        //         return CStage.fromId(param1).minLevel;
        //      }
    }
}