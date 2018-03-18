using System;
using System.ComponentModel;

namespace HZBot
{
    [Flags]
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum BuyEnergyMode
    {
        [Description("Dont Buy Energy")]
        None,

        [Description("Buy Energy for Gold")]
        BuyForGold,

        [Description("Buy Energy for Premium")]
        BuyForPremium,

        [Description("Buy Energy for Both")]
        All = BuyForGold | BuyForPremium
    }
}