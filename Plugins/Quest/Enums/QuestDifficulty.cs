using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZBot
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum QuestDifficulty
    {
        [Description("Easy")]
        Easy,
        [Description("Medium")]
        Medium,
        [Description("TryHard")]
        Hard
    }
}
