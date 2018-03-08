using System.ComponentModel;

namespace HZBot
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum FightQuestDifficulty
    {
        //Unknown = 0,

        [Description("Easy")]
        Easy = 1,

        [Description("Medium")]
        Medium = 2,

        [Description("Hard")]
        Hard = 3
    }
}