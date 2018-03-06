using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZBot
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum QuestMode
    {
        [Description("Most Gold")]
        MostGold,
        [Description("Most XP")]
        MostXP,
        [Description("Balanced")]
        Balanced
    }
}
