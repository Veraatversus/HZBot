using Newtonsoft.Json.Linq;
using System;
using System.Linq;
using System.Security.Principal;

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

        public string LevelImage => $"http://hz-static-2.akamaized.net/assets/hideout_rooms/{identifier}_{level}.png";
        public bool IsFull => CurrentCalculatedResourceAmount >= MaxResourceAmount;
        public bool CanUpgrade => this.CanRoomUpdate();
        public string ItemId => "hr_" + identifier + "_" + id;

        public double SecondsTillActivityFinished => this.SecondsTillActivityFinished();
        public double CurrentCalculatedResourceAmount => this.CurrentCalculatedResourceAmount();
        public double MaxResourceAmount => this.MaxResourceAmount();
        public bool IsInStore => this.IsRoomInStore();
        public CHideOutRoom CRoom
        {
            get
            {
                var o = HzConstants.Default.Constants["hideout_rooms"][identifier]?.ToObject<CHideOutRoom>();
                if (o != null)
                {
                    o.identifier = identifier;
                }
                return o;
            }
        }
        public CHideOutRoomLevel CLevel => CRoom.Levels.FirstOrDefault(l => l.Level == level);
        public CHideOutRoomLevel CNextLevel => CRoom.Levels.FirstOrDefault(l => l.Level == level + 1);
        public CHideOutRoomLevel CGeneratator => HzConstants.Default.Constants["hideout_rooms"]["generator"]["levels"]
            .OfType<JProperty>()
            .FirstOrDefault(tok => tok.Name == current_generator_level.ToString())?
            .OfType<JProperty>()
            ?.Select(prop => { var oput = prop.ToObject<CHideOutRoomLevel>(); oput.Level = Convert.ToInt32(prop.Name); return oput; })
            .FirstOrDefault();

        #endregion Properties

        #region Methods

        //public int Index() => HzConstants.Default.Constants["hideout_rooms"][identifier]["index"].Value<int>();

        #endregion Methods
    }
}