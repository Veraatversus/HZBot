using System.ComponentModel;

namespace HZBot
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum QuestDifficulty
    {
        [Description("Easy")]
        Easy = 1,

        [Description("Medium")]
        Medium,

        [Description("TryHard")]
        Hard
    }
}