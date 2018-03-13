using Newtonsoft.Json.Linq;

namespace HZBot
{
    public class HideOutRoom
    {
        #region Properties

        public int id { get; set; }
        public int hideout_id { get; set; }
        public int ts_creation { get; set; }
        public string identifier { get; set; }
        public HideoutRoomStatus status { get; set; }
        public int level { get; set; }
        public int current_resource_amount { get; set; }
        public int max_resource_amount { get; set; }
        public int ts_last_resource_change { get; set; }
        public int ts_activity_end { get; set; }
        public int current_generator_level { get; set; }
        public int additional_value_1 { get; set; }
        public string additional_value_2 { get; set; }
        public string ImageUrl => "http://hz-static-2.akamaized.net/assets/hideout_rooms/" + identifier + "_i.png";

        public bool isAutoProductionRoom => identifier == HideoutRoomTypes.MainBuilding || identifier == HideoutRoomTypes.GlueProduction || identifier == HideoutRoomTypes.StoneProduction || identifier == HideoutRoomTypes.XpProduction;

        public bool isManuallyProductionRoom => identifier == HideoutRoomTypes.AttackerProduction || identifier == HideoutRoomTypes.DefenderProduction || identifier == HideoutRoomTypes.GemProduction || identifier == HideoutRoomTypes.ExchangeRoom;

        public bool isProductionRoom => isAutoProductionRoom || isManuallyProductionRoom;

        public int size => HzConstants.Default.Constants["hideout_rooms"][identifier]["size"].Value<int>();

        public string type => HzConstants.Default.Constants["hideout_rooms"][identifier]["type"].Value<string>();

        public string itemId => "hr_" + identifier + "_" + id;

        #endregion Properties

        #region Methods

        public int index() => HzConstants.Default.Constants["hideout_rooms"][identifier]["index"].Value<int>();

        #endregion Methods
    }
}