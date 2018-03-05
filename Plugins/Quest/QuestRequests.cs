using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace HZBot
{
    public static class QuestRequests
    {
        #region Methods

        /// <summary>Checks for worker complete asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="workType">Type of the work.</param>
        /// <returns></returns>
        public static async Task<JObject> CheckForWorkerCompleteAsync(this HzPluginBase plugin, WorkType workType)
        {
            var content = new PostContent();
            if (workType == WorkType.Quest)
            {
                content = plugin.Account.DefaultRequestContent("checkForQuestComplete");
                plugin.Account.Log.Add($"[QUEST] END: ID:{plugin.Account.Data.ActiveQuest.id} Duration:{plugin.Account.Data.ActiveQuest.duration / 60}");
            }
            else if (workType == WorkType.Training)
            {
                content = plugin.Account.DefaultRequestContent("checkForTrainingComplete");
                plugin.Account.Log.Add($"[TRAINING] END: TrainStat:{plugin.Account.Data.ActiveTraining.StatType}");
            }
            var error = await content.PostToHzAsync();
            return error;
        }

        /// <summary>Claims the worker reward asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="workType">Type of the work.</param>
        /// <returns></returns>
        public static async Task<JObject> ClaimWorkerRewardAsync(this HzPluginBase plugin, WorkType workType)
        {
            var content = new PostContent();
            if (workType == WorkType.Quest)
            {
                content = plugin.Account.DefaultRequestContent("claimQuestRewards")
                   .AddKeyValue("discard_item", "false")
                   .AddKeyValue("create_new", "true");
            }
            else if (workType == WorkType.Training)
            {
                content = plugin.Account.DefaultRequestContent("claimTrainingRewards");
            }
            content.AddKeyValue("rct", "2");
            var error = await content.PostToHzAsync();
            return error;
        }

        /// <summary>Buys the quest energy asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="usePremiumCurrency">if set to <c>true</c> [use premium currency].</param>
        /// <returns></returns>
        public static async Task<JObject> BuyQuestEnergyAsync(this HzPluginBase plugin, bool usePremiumCurrency)
        {
            var error = await plugin.Account.DefaultRequestContent("buyQuestEnergy")
                .AddKeyValue("use_premium", usePremiumCurrency.ToString().ToLower())
                .AddKeyValue("rct", "1")
                .PostToHzAsync();
            return error;
        }

        /// <summary>Starts the quest asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="quest">The quest.</param>
        /// <returns></returns>
        public static async Task<JObject> StartQuestAsync(this HzPluginBase plugin, Quest quest)
        {
            var error = await plugin.Account.DefaultRequestContent("startQuest")
                .AddKeyValue("quest_id", quest.id.ToString())
                .AddKeyValue("rct", "1")
                .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}