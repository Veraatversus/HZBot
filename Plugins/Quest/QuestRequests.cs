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
        public static async Task<string> CheckForWorkerCompleteAsync(this HzPluginBase plugin, WorkType workType)
        {
            var content = new PostContent();
            if (workType == WorkType.Quest)
            {
                content = plugin.Account.DefaultRequestContent("checkForQuestComplete")
                    .AddLog($"[Quest] END: ID:{plugin.Account.Data.ActiveQuest.id} Duration:{plugin.Account.Data.ActiveQuest.duration / 60}");
            }
            else if (workType == WorkType.Training)
            {
                content = plugin.Account.DefaultRequestContent("checkForTrainingComplete")
                    .AddLog($"[Train] END: TrainStat:{plugin.Account.Data.ActiveTraining.StatType}");
            }
            var error = await content.PostToHzAsync();
            return error;
        }

        /// <summary>Claims the worker reward asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="workType">Type of the work.</param>
        /// <returns></returns>
        public static async Task<string> ClaimWorkerRewardAsync(this HzPluginBase plugin, WorkType workType)
        {
            var content = new PostContent();
            if (workType == WorkType.Quest)
            {
                var rewards = plugin.Account.Data.ActiveQuest.GetRewards;
                content = plugin.Account.DefaultRequestContent("claimQuestRewards")
                   .AddKeyValue("discard_item", "false")
                   .AddKeyValue("create_new", "true")
                   .AddLog($"[Quest] Claim: XP:{rewards.xp} Coins:{rewards.coins} Premium:{rewards.premium} Honor:{rewards.honor} Item:{rewards.item}");
            }
            else if (workType == WorkType.Training)
            {
                content = plugin.Account.DefaultRequestContent("claimTrainingRewards")
                    .AddLog($"[Train] Claim Point:{plugin.Account.Data.ActiveTraining.StatType}");
            }
            content.AddKeyValue("rct", "2");

            var error = await content.PostToHzAsync();
            return error;
        }

        /// <summary>Buys the quest energy asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="usePremiumCurrency">if set to <c>true</c> [use premium currency].</param>
        /// <returns></returns>
        public static async Task<string> BuyQuestEnergyAsync(this HzPluginBase plugin, bool usePremiumCurrency)
        {
            var error = await plugin.Account.DefaultRequestContent("buyQuestEnergy")
                .AddKeyValue("use_premium", usePremiumCurrency.ToString().ToLower())
                .AddKeyValue("rct", "1")
                .AddLog($"[Quest] BuyQuestEnergy")
                .PostToHzAsync();
            return error;
        }

        /// <summary>Aborts the worker asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public static async Task<string> AbortWorkerAsync(this HzPluginBase plugin)
        {
            var content = new PostContent();
            if (plugin.Account.ActiveWorker?.WorkerType == WorkType.Quest)
            {
                content = plugin.Account.DefaultRequestContent("abortQuest")
                    .AddLog($"[Train] Abbort Training");
            }
            else if (plugin.Account.ActiveWorker?.WorkerType == WorkType.Training)
            {
                content = plugin.Account.DefaultRequestContent("abortTraining")
                    .AddLog($"[Train] Abbort Training");
            }

            return await content.AddKeyValue("rct", "2")
                .PostToHzAsync();
        }

        /// <summary>Starts the quest asynchronous.</summary>
        /// <param name="plugin">The plugin.</param>
        /// <param name="quest">The quest.</param>
        /// <returns></returns>
        public static async Task<string> StartQuestAsync(this HzPluginBase plugin, Quest quest)
        {
            var error = await plugin.Account.DefaultRequestContent("startQuest")
                .AddKeyValue("quest_id", quest.id.ToString())
                .AddKeyValue("rct", "1")
                .AddLog($"[Quest] StartQuest: {quest.id}")
                .PostToHzAsync();
            return error;
        }

        #endregion Methods
    }
}