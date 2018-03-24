using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace HZBot
{
    public class Goal
    {
        #region Properties

        public Character Charcater { get; set; }

        public string Name { get; set; }
        public int index { get; set; }
        public bool active { get; set; }
        public GoalType goal_type { get; set; }
        public GoalMechanicType mechanic_type { get; set; }
        public string lookup_column { get; set; }
        public int category { get; set; }
        public string required_goal { get; set; }
        public int required_level { get; set; }
        public IEnumerable<GoalValue> Steps { get; set; }
        public Goal Required_goal => Charcater.Goals.FirstOrDefault(g => g.Name == required_goal);
        public bool IsFinished => Steps.All(val => val.IsCollected);
        public string ImageUrl => "http://hz-static-2.akamaized.net/assets/goals/" + Name + ".png";

        public bool IsAvailable
        {
            get
            {
                if (required_level > 0 && required_level > this.Charcater.level)
                {
                    return false;
                }

                if (Required_goal != null && !Required_goal.IsFinished)
                {
                    return false;
                }

                return true;
            }
        }

        public GoalValue CurrentTargetValue => Steps.SkipWhile(val => val.IsCollected).FirstOrDefault();

        public int CurrentValue
        {
            get
            {
                if (mechanic_type == GoalMechanicType.Daily || mechanic_type == GoalMechanicType.Row)
                {
                    return HzAccountManger.GetAccByCharacterID(this.Charcater.id).JsonData["data"]["current_goal_values"][Name]["current_value"].Value<int>();
                }
                return HzAccountManger.GetAccByCharacterID(this.Charcater.id).JsonData["data"]["current_goal_values"][Name]?["value"]?.Value<int>() ?? 0;
            }
        }

        #endregion Properties
    }
}