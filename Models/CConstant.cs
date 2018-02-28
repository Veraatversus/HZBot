using System;

namespace HZBot
{
    public static class CConstant
    {
        #region Fields

        public const double coins_per_time_base = 0.02f;
        public const double coins_per_time_scale = 0.01f;
        public const double coins_per_time_level_scale = 0.35f;
        public const double coins_per_time_level_exp = 1.55f;
        public const int quest_energy_refill_amount = 50;
        public const int quest_energy_refill1_cost_factor = 1800;
        public const int quest_energy_refill2_cost_factor = 6300;
        public const int quest_energy_refill3_cost_factor = 10800;
        public const int quest_energy_refill4_cost_factor = 15300;
        public const int quest_energy_refill5_cost_factor = 30600;
        public const int quest_energy_refill6_cost_factor = 45900;
        public const int quest_energy_refill7_cost_factor = 61200;
        public const int quest_energy_refill8_cost_factor = 76500;

        #endregion Fields

        #region Methods

        public static int GameCurrencyCostEnergyRefill(int level, int refillToday)
        {
            var loc5 = refillToday / quest_energy_refill_amount;
            var loc4 = 0;
            switch ((loc5))
            {
                case 0:
                    loc4 = quest_energy_refill1_cost_factor;
                    break;

                case 1:
                    loc4 = quest_energy_refill2_cost_factor;
                    break;

                case 2:
                    loc4 = quest_energy_refill3_cost_factor;
                    break;

                case 3:
                    loc4 = quest_energy_refill4_cost_factor;
                    break;

                case 4:
                    loc4 = quest_energy_refill5_cost_factor;
                    break;

                case 5:
                    loc4 = quest_energy_refill6_cost_factor;
                    break;

                case 6:
                    loc4 = quest_energy_refill7_cost_factor;
                    break;

                case 7:
                    loc4 = quest_energy_refill8_cost_factor;
                    break;
            }
            var loc3 = loc4 * GameCurrencyPerTime(level);
            return (int)Math.Round(loc3);
        }

        public static double GameCurrencyPerTime(int level)
        {
            const double loc6 = coins_per_time_base;
            const double loc3 = coins_per_time_scale;
            const double loc4 = coins_per_time_level_scale;
            const double loc5 = coins_per_time_level_exp;
            var loc2 = loc6 + (loc3 * Math.Pow(loc4 * level, loc5));
            return RoundDecimal(loc2, 3);
        }

        private static double RoundDecimal(double param1, int param2)
        {
            var _loc4_ = Math.Pow(10, param2);
            var _loc3_ = Math.Round(param1 * _loc4_) / _loc4_;
            return _loc3_;
        }

        #endregion Methods
    }
}