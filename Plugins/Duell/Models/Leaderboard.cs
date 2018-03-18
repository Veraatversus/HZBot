namespace HZBot
{
    public class LeaderChars
    {
        #region Properties

        public int rank { get; set; }
        public int id { get; set; }
        public object character_id { get; set; }
        public string name { get; set; }
        public string locale { get; set; }
        public int guild_id { get; set; }
        public string guild_name { get; set; }
        public string emblem_background_shape { get; set; }
        public string emblem_background_color { get; set; }
        public string emblem_background_border_color { get; set; }
        public string emblem_icon_shape { get; set; }
        public string emblem_icon_color { get; set; }
        public string emblem_icon_size { get; set; }
        public string gender { get; set; }
        public object hideout_level { get; set; }
        public object hideout_points { get; set; }
        public int level { get; set; }
        public int league_points { get; set; }
        public int league_group_id { get; set; }
        public int honor { get; set; }
        public object value { get; set; }
        public int online_status { get; set; }

        #endregion Properties
    }
}