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
        public static async Task<string> ImproveCharacterStatAsync(this HzPluginBase plugin, StatType statType, int skillAmount = 1)
        {
            return await plugin.Account.DefaultRequestContent("improveCharacterStat")
             .AddKeyValue("skill_value", skillAmount)
             .AddKeyValue("stat_type", (int)statType)
             .AddKeyValue("rct", "2")
             .AddLog($"[Skill] Start Skill:{statType.ToString()}")
             .PostToHzAsync();
        }

        /// <summary>Starts the training asynchronous.</summary>
        /// <param name="statType">Type of the stat.</param>
        /// <param name="iterations">The iterations.</param>
        /// <param name="plugin">The HzPlugin.</param>
        /// <returns></returns>
        public static async Task<string> StartTrainingAsync(this HzPluginBase plugin, StatType statType, int iterations = 1)
        {
            return await plugin.Account.DefaultRequestContent("startTraining")
           .AddKeyValue("iterations", iterations)
           .AddKeyValue("stat_type", (int)statType)
           .AddKeyValue("rct", "2")
           .AddLog($"[Train] Start Training:{statType.ToString()}")
           .PostToHzAsync();
        }

        #endregion Methods
    }
}