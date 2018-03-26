using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace HZBot
{
    public class CHideOutRoom 
    {
        #region Properties

        public HideOut HideOut { get; set; }
        public string identifier { get; set; }
        public int limit { get; set; }
        public int unlock_with_mainbuilding_1 { get; set; }
        public int unlock_with_mainbuilding_2 { get; set; }
        public int unlock_with_mainbuilding_3 { get; set; }
        public int unlock_with_mainbuilding_4 { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public HideoutRoomType Type { get { Enum.TryParse<HideoutRoomType>(identifier, out HideoutRoomType result); return result; } }
        public int index { get; set; }

        public string RessourceIcon
        {
            get
            {
                switch (Type)
                {
                    case HideoutRoomType.glue_production:
                        return $"/HZBot;component/Assets/HideOut/glue.png";
                    case HideoutRoomType.stone_production:
                        return $"/HZBot;component/Assets/HideOut/stone.png";
                    case HideoutRoomType.main_building:
                        return $"/HZBot;component/Assets/HideOut/gold.png";
                    default:
                        return "";
                }
            }
        }
        public string Icon => "http://hz-static-2.akamaized.net/assets/hideout_rooms/" + identifier + "_i.png";

        public bool IsAutoProductionRoom => Type == HideoutRoomType.main_building || Type == HideoutRoomType.glue_production || Type == HideoutRoomType.stone_production || Type == HideoutRoomType.xp_production;

        public bool IsManuallyProductionRoom => Type == HideoutRoomType.attacker_production || Type == HideoutRoomType.defender_production || Type == HideoutRoomType.gem_production || Type == HideoutRoomType.exchange_room;

        public bool IsProductionRoom => IsAutoProductionRoom || IsManuallyProductionRoom;


        public IEnumerable<CHideOutRoomLevel> Levels => HzConstants.Default.Constants["hideout_rooms"]
            .OfType<JProperty>()
            .FirstOrDefault(p=> p.Name == identifier)?
            .Value["levels"]
            .OfType<JProperty>()
            .Select(prop =>
            {
                var oput = prop.Value.ToObject<CHideOutRoomLevel>();
                oput.HideOut = HideOut;
                oput.Level = Convert.ToInt32(prop.Name);
                return oput;
            });

        #endregion Properties
    }
}