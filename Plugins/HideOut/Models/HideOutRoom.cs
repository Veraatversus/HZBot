using Newtonsoft.Json.Linq;
using System.Linq;

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
        public string Icon => "http://hz-static-2.akamaized.net/assets/hideout_rooms/" + identifier + "_i.png";
        public string LevelImage => $"http://hz-static-2.akamaized.net/assets/hideout_rooms/{identifier}_{level}.png";
        public bool IsFull => CurrentCalculatedResourceAmount >= MaxResourceAmount;

        public string RessourceIcon
        {
            get
            {
                switch (identifier)
                {
                    case HideoutRoomTypes.GlueProduction:
                        return $"/HZBot;component/Assets/HideOut/glue.png";
                    case HideoutRoomTypes.StoneProduction:
                        return $"/HZBot;component/Assets/HideOut/stone.png";
                    case HideoutRoomTypes.MainBuilding:
                        return $"/HZBot;component/Assets/HideOut/gold.png";
                    default:
                        return "";
                }
            }
        }

        public bool CanUpgrade => this.CanRoomUpdate();
        public bool IsAutoProductionRoom => identifier == HideoutRoomTypes.MainBuilding || identifier == HideoutRoomTypes.GlueProduction || identifier == HideoutRoomTypes.StoneProduction || identifier == HideoutRoomTypes.XpProduction;

        public bool IsManuallyProductionRoom => identifier == HideoutRoomTypes.AttackerProduction || identifier == HideoutRoomTypes.DefenderProduction || identifier == HideoutRoomTypes.GemProduction || identifier == HideoutRoomTypes.ExchangeRoom;

        public bool IsProductionRoom => IsAutoProductionRoom || IsManuallyProductionRoom;

        public string ItemId => "hr_" + identifier + "_" + id;

        public CHideOutRoom CRoom => HzConstants.Default.Constants["hideout_rooms"][identifier]?.ToObject<CHideOutRoom>();
        public CHideOutRoomLevel CLevel => HzConstants.Default.Constants["hideout_rooms"][identifier]["levels"][level.ToString()]?.ToObject<CHideOutRoomLevel>();
        public CHideOutRoomLevel CNextLevel => HzConstants.Default.Constants["hideout_rooms"][identifier]["levels"].OfType<JProperty>().FirstOrDefault(tok => tok.Name == (level + 1).ToString())?.Value.ToObject<CHideOutRoomLevel>();
        public CHideOutRoomLevel CGeneratator => HzConstants.Default.Constants["hideout_rooms"]["generator"]["levels"].OfType<JProperty>().FirstOrDefault(tok => tok.Name == current_generator_level.ToString())?.Value.ToObject<CHideOutRoomLevel>();
        public double SecondsTillActivityFinished => this.SecondsTillActivityFinished();
        public double CurrentCalculatedResourceAmount => this.CurrentCalculatedResourceAmount();
        public double MaxResourceAmount => this.MaxResourceAmount();
        public bool IsInStore => this.IsRoomInStore();

        #endregion Properties

        #region Methods

        public int Index() => HzConstants.Default.Constants["hideout_rooms"][identifier]["index"].Value<int>();

        #endregion Methods
    }
}