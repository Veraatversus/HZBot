using System.ComponentModel;

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