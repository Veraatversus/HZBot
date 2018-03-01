using Newtonsoft.Json.Linq;

namespace HZBot
{
    public class Quest : IWorkItem
    {
        #region Properties

        public int character_id { get; set; }
        public int duration { get; set; }
        public int duration_raw { get; set; }
        public int duration_type { get; set; }
        public int energy_cost { get; set; }
        public int fight_battle_id { get; set; }
        public int fight_difficulty { get; set; }
        public string fight_npc_identifier { get; set; }
        public int id { get; set; }
        public string identifier { get; set; }
        public int level { get; set; }
        public string rewards { get; set; }
        public int stage { get; set; }
        public int status { get; set; }
        public int ts_complete { get; set; }
        public int type { get; set; }
        public int used_resources { get; set; }

        //Extended Properties

        /// <summary>Gets the get rewards.</summary>
        /// <value>The get rewards.</value>
        public Rewards GetRewards => JObject.Parse(rewards).ToObject<Rewards>();

        public Item GetItem => AccountManger.GetItemById(GetRewards.item, character_id);
        public Item GetEventItem => AccountManger.GetItemById(GetRewards.item, character_id);
        public int CoinsInclItem => GetRewards.coins + (GetItem?.sell_price ?? 0);
        public double XPPerEnergy => GetRewards.xp / energy_cost;
        public double CurrencyPerEnergy => CoinsInclItem / energy_cost;
        public double XPCurrencyPerEneryAverage => (XPPerEnergy + CurrencyPerEnergy) / 2;
        public long RemainingTime => (ts_complete != 0 ? ts_complete : HzRequests.ServerTime) - HzRequests.ServerTime;

        public WorkType WorkerType => WorkType.Quest;

        #endregion Properties
    }
}