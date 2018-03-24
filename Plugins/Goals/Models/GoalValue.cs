using Newtonsoft.Json.Linq;
using System.Linq;

namespace HZBot
{
    public class GoalValue
    {
        #region Properties

        public Goal Goal { get; set; }
        public int Id { get; set; }
        public GoalRewardType reward_type { get; set; }
        public int reward_factor { get; set; }
        public string reward_identifier { get; set; }
        public int estimated_level { get; set; }
        public string text { get; set; }

        //public bool CurrentTarget => Goal.Values.SkipWhile(val => val.IsCollected).FirstOrDefault()?.Id == Id;
        public bool IsCollected
        {
            get
            {
                var goals = HzAccountManger.GetAccByCharacterID(Goal.Charcater.id).JsonData["data"]["collected_goals"] as JArray;
                return goals.Values().OfType<JProperty>().FirstOrDefault(prop =>
                 prop.Name == Goal.Name &&
                 prop.Value["value"].Value<int>() == Id &&
                 !string.IsNullOrEmpty(prop.Value["date"]?.ToString())) != null;
            }
        }

        public bool IsCollectable => Id <= Goal.CurrentValue;
        public bool IsAvailable => Goal.IsAvailable && Goal.CurrentTargetValue?.Id == Id;

        #endregion Properties
    }
}