namespace HZBot
{
    public class Battle
    {
        #region Properties

        public int id { get; set; }
        public int ts_creation { get; set; }
        public string profile_a_stats { get; set; }
        public string profile_b_stats { get; set; }
        public string winner { get; set; }
        public string rounds { get; set; }

        #endregion Properties
    }
}