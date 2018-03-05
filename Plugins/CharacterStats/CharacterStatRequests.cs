﻿using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HZBot
{
    public static class CharacterStatRequests
    {
        #region Methods

        /// <summary>Improves the character stat.</summary>
        /// <param name="statType">Type of the stat.</param>
        /// <param name="skillAmount">The skill amount.</param>
        /// <param name="plugin">The HzPlugin.</param>
        /// <returns></returns>
        public static async Task<JObject> ImproveCharacterStatAsync(this HzPluginBase plugin, StatType statType, int skillAmount = 1)
        {
            plugin.Account.Log.Add($"[Skill] Start Skill:{statType}");
            return await plugin.Account.DefaultRequestContent("improveCharacterStat")
             .AddKeyValue("skill_value", skillAmount)
             .AddKeyValue("stat_type", (int)statType)
             .AddKeyValue("rct", "2")
             .PostToHzAsync();
        }

        /// <summary>Starts the training asynchronous.</summary>
        /// <param name="statType">Type of the stat.</param>
        /// <param name="iterations">The iterations.</param>
        /// <param name="plugin">The HzPlugin.</param>
        /// <returns></returns>
        public static async Task<JObject> StartTrainingAsync(this HzPluginBase plugin, StatType statType, int iterations = 1)
        {
            plugin.Account.Log.Add($"[Training] Start Training:{statType}");
            return await plugin.Account.DefaultRequestContent("startTraining")
           .AddKeyValue("iterations", iterations)
           .AddKeyValue("stat_type", (int)statType)
           .AddKeyValue("rct", "2")
           .PostToHzAsync();
        }

        #endregion Methods
    }
}