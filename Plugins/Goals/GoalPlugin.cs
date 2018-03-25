using System.Linq;
using System.Threading.Tasks;

namespace HZBot
{
    public class GoalPlugin : HzPluginBase
    {
        #region Constructors

        public GoalPlugin(HzAccount account) : base(account)
        {
        }

        #endregion Constructors

        #region Methods

        public async override Task BeforPrimaryWorkerWork()
        {
            if (Account.Config.IsAutoGoal)
            {
                var colectableGoals = Account.Character.Goals.CollectableValues().ToList();
                foreach (var goal in colectableGoals)
                {
                    switch (goal.reward_type)
                    {
                        case GoalRewardType.Item:
                            if (Account.Data.HzInventory.FreeBagSpace <= 0) continue;
                            break;

                        case GoalRewardType.Quest_Energy:
                            if (Account.Character.quest_energy > 10) continue;
                            break;

                        case GoalRewardType.Booster:
                            continue;
                            break;

                        default:
                            break;
                    }
                    var error = await this.CollectGoalRewardAsync(goal);
                }
            }
        }

        #endregion Methods
    }
}