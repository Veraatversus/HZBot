using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZBot
{
    public class UserVoucher
    {
        public int id { get; set; }
        public string code { get; set; }
        public string rewards { get; set; }
        public int ts_end { get; set; }
    }
}
