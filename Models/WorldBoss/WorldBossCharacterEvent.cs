namespace HZBot
{
    public class WorldbossCharacterEvent
    {
        #region Properties

        public int worldboss_event_id { get; set; }
        public int ranking { get; set; }
        public int coin_reward_total { get; set; }
        public int coin_reward_next_attack { get; set; }
        public int xp_reward_total { get; set; }
        public int xp_reward_next_attack { get; set; }

        #endregion Properties
    }
}