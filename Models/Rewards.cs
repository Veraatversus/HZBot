using System.Linq;

namespace HZBot
{
    public class Rewards
    {
        #region Properties

        public int coins { get; set; }
        public int xp { get; set; }
        public int honor { get; set; }
        public int premium { get; set; }
        public int statPoints { get; set; }
        public int item { get; set; }
        public string event_item { get; set; }
        public Item GetItem => HzRequests.MainClass?.data.items.FirstOrDefault(it => it.id == item);
        public Item GetEventItem => HzRequests.MainClass?.data.items.FirstOrDefault(it => it.id == item);
        public int CoinsInclItem => coins + (GetItem?.sell_price ?? 0);

        #endregion Properties
    }
}