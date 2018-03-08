namespace HZBot
{
    public class WorldbossEvent
    {
        #region Properties

        public int id { get; set; }
        public int ts_finished { get; set; }
        public string identifier { get; set; }
        public WorldbossEventStatus status { get; set; }
        public int ts_start { get; set; }
        public int ts_end { get; set; }
        public int min_level { get; set; }
        public int max_level { get; set; }
        public int stage { get; set; }
        public int reward_multiplier { get; set; }
        public string reward_top_rank_item_identifier { get; set; }
        public int reward_top_rank_item_level_bonus { get; set; }
        public string reward_top_pool_item_identifier { get; set; }
        public int reward_top_pool_item_level_bonus { get; set; }
        public string npc_identifier { get; set; }
        public int npc_hitpoints_current { get; set; }
        public int npc_hitpoints_total { get; set; }
        public int attack_count { get; set; }
        public int top_attacker_count { get; set; }
        public int top_attacker_id { get; set; }
        public string top_attacker_name { get; set; }
        public int winning_attacker_id { get; set; }
        public string winning_attacker_name { get; set; }
        public int difficulty_factor { get; set; }

        #endregion Properties
    }
}