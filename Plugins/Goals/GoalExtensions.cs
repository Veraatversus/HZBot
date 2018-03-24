using System.Collections.Generic;
using System.Linq;

namespace HZBot
{
    public static class GoalExtensions
    {
        #region Methods

        public static IEnumerable<GoalValue> CollectableValues(this IEnumerable<Goal> goals)
        {
            return goals.SelectMany(g => g.Steps).Where(g => g.IsCollectable && !g.IsCollected);
        }

        #endregion Methods
    }
}