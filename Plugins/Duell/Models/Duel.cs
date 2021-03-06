﻿using Newtonsoft.Json.Linq;

namespace HZBot
{
    public class Duel
    {
        #region Properties

        public int id { get; set; }
        public int ts_creation { get; set; }
        public int battle_id { get; set; }
        public int character_a_id { get; set; }
        public int character_b_id { get; set; }
        public int character_a_status { get; set; }
        public int character_b_status { get; set; }
        public string character_a_rewards { get; set; }
        public string character_b_rewards { get; set; }
        public Rewards Rewards_A => JObject.Parse(character_a_rewards).ToObject<Rewards>();
        public Rewards Rewards_B => JObject.Parse(character_b_rewards).ToObject<Rewards>();

        #endregion Properties
    }

    public class DuelHistory : ViewModelBase
    {
        #region Properties

        public int id { get; set; }
        public string name { get; set; }
        public int Status { get => _status; set { _status = value; RaisePropertyChanged(); } }

        #endregion Properties

        #region Fields

        private int _status;

        #endregion Fields

        // Gewonnen Ja=1 Nein=0
    }
}