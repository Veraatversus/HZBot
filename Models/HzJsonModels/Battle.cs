using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZBot
{
    public class Battle
    {
        public int id { get; set; }
        public int ts_creation { get; set; }
        public string profile_a_stats { get; set; }
        public string profile_b_stats { get; set; }
        public string winner { get; set; }
        public string rounds { get; set; }
    }
}
