namespace HZBot
{
    public class LeaderCharacter
    {
        #region Properties

        public int id { get; set; }
        public int user_id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public int xp { get; set; }
        public int level { get; set; }
        public int honor { get; set; }
        public int league_points { get; set; }
        public int league_group_id { get; set; }
        public string description { get; set; }
        public int stat_total_stamina { get; set; }
        public int stat_total_strength { get; set; }
        public int stat_total_critical_rating { get; set; }
        public int stat_total_dodge_rating { get; set; }
        public int stat_weapon_damage { get; set; }
        public string active_quest_booster_id { get; set; }
        public string active_stats_booster_id { get; set; }
        public string active_work_booster_id { get; set; }
        public int online_status { get; set; }
        public int guild_id { get; set; }
        public bool show_mask { get; set; }
        public int appearance_skin_color { get; set; }
        public int appearance_hair_color { get; set; }
        public int appearance_hair_type { get; set; }
        public int appearance_head_type { get; set; }
        public int appearance_eyes_type { get; set; }
        public int appearance_eyebrows_type { get; set; }
        public int appearance_nose_type { get; set; }
        public int appearance_mouth_type { get; set; }
        public int appearance_facial_hair_type { get; set; }
        public int appearance_decoration_type { get; set; }
        public int hideout_id { get; set; }

        #endregion Properties
    }
}