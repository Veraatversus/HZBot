namespace HZBot
{
    public class SlotUnlockCost : IHideOutCost
    {
        #region Properties

        public int price_gold { get; set; }
        public int price_glue { get; set; }
        public int price_stone { get; set; }
        public int duration { get; set; }

        #endregion Properties
    }
}