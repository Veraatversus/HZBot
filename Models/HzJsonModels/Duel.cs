using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZBot
{
    public class Duel
    {
        public int id { get; set; }
        public int ts_creation { get; set; }
        public int battle_id { get; set; }
        public int character_a_id { get; set; }
        public int character_b_id { get; set; }
        public int character_a_status { get; set; }
        public int character_b_status { get; set; }
        public string character_a_rewards { get; set; }
        public string character_b_rewards { get; set; }
    }
}

  
