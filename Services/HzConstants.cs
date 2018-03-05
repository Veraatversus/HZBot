using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace HZBot
{
    public class HzConstants
    {
        #region Properties

        public static HzConstants Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new HzConstants();
                }
                return _default;
            }
        }

        public JObject Constants { get; set; }
        public double coins_per_time_base => Constants["coins_per_time_base"].Value<double>();

        public double coins_per_time_scale => Constants["coins_per_time_scale"].Value<double>();

        public double coins_per_time_level_scale => Constants["coins_per_time_level_scale"].Value<double>();

        public double coins_per_time_level_exp => Constants["coins_per_time_level_exp"].Value<double>();

        public int quest_energy_refill_amount => Constants["quest_energy_refill_amount"].Value<int>();

        public int quest_energy_refill1_cost_factor => Constants["quest_energy_refill1_cost_factor"].Value<int>();

        public int quest_energy_refill2_cost_factor => Constants["quest_energy_refill2_cost_factor"].Value<int>();

        public int quest_energy_refill3_cost_factor => Constants["quest_energy_refill3_cost_factor"].Value<int>();

        public int quest_energy_refill4_cost_factor => Constants["quest_energy_refill4_cost_factor"].Value<int>();

        public int quest_energy_refill5_cost_factor => Constants["quest_energy_refill5_cost_factor"].Value<int>();

        public int quest_energy_refill6_cost_factor => Constants["quest_energy_refill6_cost_factor"].Value<int>();

        public int quest_energy_refill7_cost_factor => Constants["quest_energy_refill7_cost_factor"].Value<int>();

        public int quest_energy_refill8_cost_factor => Constants["quest_energy_refill8_cost_factor"].Value<int>();

        #endregion Properties

        #region Methods

        /// <summary>Generate MD5 Hash from the request action and the userid</summary>
        /// <param name="action">The action.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public static string MD5Hash(string action, string userId)
        {
            var hash = new StringBuilder();
            using (var md5provider = new MD5CryptoServiceProvider())
            {
                var bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes($"{action}bpHgj5214{userId}"));

                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }
                return hash.ToString();
            }
        }

        public int GameCurrencyCostEnergyRefill(int level, int refillToday)
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

        //public double coins_per_time_base = 0.02f;
        //public double coins_per_time_scale = 0.01f;
        //public double coins_per_time_level_scale = 0.35f;
        //public double coins_per_time_level_exp = 1.55f;
        //public int quest_energy_refill_amount = 50;
        //public int quest_energy_refill1_cost_factor = 1800;
        //public int quest_energy_refill2_cost_factor = 6300;
        //public int quest_energy_refill3_cost_factor = 10800;
        //public int quest_energy_refill4_cost_factor = 15300;
        //public int quest_energy_refill5_cost_factor = 30600;
        //public int quest_energy_refill6_cost_factor = 45900;
        //public int quest_energy_refill7_cost_factor = 61200;
        //public int quest_energy_refill8_cost_factor = 76500;
        public double GameCurrencyPerTime(int level)
        {
            var loc6 = coins_per_time_base;
            var loc3 = coins_per_time_scale;
            var loc4 = coins_per_time_level_scale;
            var loc5 = coins_per_time_level_exp;
            var loc2 = loc6 + (loc3 * Math.Pow(loc4 * level, loc5));
            return RoundDecimal(loc2, 3);
        }

        #endregion Methods

        #region Fields

        private static HzConstants _default;

        #endregion Fields

        #region Constructors

        private HzConstants()
        {
            var resourceName = "HZBot.Assets.constantsReadable.json";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                var result = reader.ReadToEnd();
                Constants = JObject.Parse(result);
            }
        }

        #endregion Constructors

        private static double RoundDecimal(double param1, int param2)
        {
            var _loc4_ = Math.Pow(10, param2);
            var _loc3_ = Math.Round(param1 * _loc4_) / _loc4_;
            return _loc3_;
        }
    }
}