using System.ComponentModel;

namespace HZBot
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum SellMode
    {
        [Description("Sell Nothing")]
        None,

        [Description("Prevent Full Inventory")]
        KeepSpace,

        [Description("Sell Everything")]
        SellAll
    }
}