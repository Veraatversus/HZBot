namespace HZBot
{
    public class Item
    {
        #region Properties

        public int id { get; set; }
        public int character_id { get; set; }
        public string identifier { get; set; }
        public int type { get; set; }
        public int quality { get; set; }
        public int required_level { get; set; }
        public int charges { get; set; }
        public int item_level { get; set; }
        public int ts_availability_start { get; set; }
        public int ts_availability_end { get; set; }
        public bool premium_item { get; set; }
        public int buy_price { get; set; }
        public int sell_price { get; set; }
        public int stat_stamina { get; set; }
        public int stat_strength { get; set; }
        public int stat_critical_rating { get; set; }
        public int stat_dodge_rating { get; set; }
        public int stat_weapon_damage { get; set; }

        #endregion Properties
    }
}