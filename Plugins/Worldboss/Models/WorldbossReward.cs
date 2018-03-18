namespace HZBot
{
    public class WorldbossReward
    {
        #region Properties

        public int id { get; set; }
        public int worldboss_event_id { get; set; }
        public int character_id { get; set; }
        public int xp { get; set; }
        public int game_currency { get; set; }
        public int item_id { get; set; }
        public int sidekick_item_id { get; set; }
        public string rewards { get; set; }
        public int status { get; set; }

        #endregion Properties
    }
}