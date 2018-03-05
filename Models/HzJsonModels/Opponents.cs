namespace HZBot
{
    public class Opponents
    {
        #region Properties

        public int id { get; set; }
        public string name { get; set; }
        public int level { get; set; }
        public int honor { get; set; }
        public string gender { get; set; }
        public int stat_total_stamina { get; set; }
        public int stat_total_strength { get; set; }
        public int stat_total_critical_rating { get; set; }
        public int stat_total_dodge_rating { get; set; }
        public int stat_weapon_damage { get; set; }
        public int online_status { get; set; }
        public int total_stats { get; set; }
        public int fightStat => total_stats - stat_weapon_damage;

        #endregion Properties
    }
}