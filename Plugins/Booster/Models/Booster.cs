using System;

namespace HZBot
{
    public class Booster
    {
        #region Properties

        public Character character { get; set; }
        public CBooster Constants { get; internal set; }
        public string Id { get; internal set; }
        public int Expires { get; internal set; }
        public TimeSpan RemainingTime => TimeSpan.FromSeconds(Expires - HzAccountManger.GetAccByCharacterID(character.id).ServerTime);
        public DateTimeOffset EndTime => DateTimeOffset.FromUnixTimeSeconds(Expires);
        public bool IsActive => Expires > 0;
        public int DurationInDays => TimeSpan.FromSeconds(Constants.duration).Days;
        public string Icon => $"/HZBot;component/Assets/Booster/{Id}.png";

        public string Effect
        {
            get
            {
                if (Constants.type == CBoosterType.Quest)
                {
                    return "-" + Constants.amount;
                }
                else
                {
                    return "+" + Constants.amount;
                }
            }
        }

        public int Cost
        {
            get
            {
                if (Constants.premium_item == true)
                {
                    return 10;
                }
                else
                {
                    return GameUtil.BoosterCost(character.level, Id.Contains("1"));
                }
            }
        }

        #endregion Properties
    }
}