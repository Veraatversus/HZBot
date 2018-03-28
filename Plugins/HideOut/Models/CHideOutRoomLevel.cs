namespace HZBot
{
    public class CHideOutRoomLevel : IHideOutCost
    {
        #region Properties
        public HideOut HideOut { get; set; }
        public int Level { get; set; }
        public int price_gold { get; set; }
        public double? current_price_gold => this.GetReducedGameCurrencyValue();
        public int price_glue { get; set; }
        public int price_stone { get; set; }
        public int build_time { get; set; }
        public int passiv_bonus_amount_1 { get; set; }
        public int passiv_bonus_amount_2 { get; set; }
        public int min_till_max_resource { get; set; }
        public int resource_production_max { get; set; }
        public int image_level { get; set; }



        #endregion Properties
    }
}