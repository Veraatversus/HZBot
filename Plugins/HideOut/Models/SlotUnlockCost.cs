namespace HZBot
{
    public class SlotUnlockCost : IHideOutCost
    {
        #region Properties

        public HideOut HideOut { get; set; }
        public int price_gold { get; set; }
        public double? current_price_gold => HideoutUtil.GetReducedGameCurrencyValue(HideOut, price_gold);
        public int price_glue { get; set; }
        public int price_stone { get; set; }
        public int duration { get; set; }

        #endregion Properties
    }
}