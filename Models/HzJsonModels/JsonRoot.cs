using System.Collections.Generic;

namespace HZBot
{
    public class JsonRoot
    {
        #region Properties

        public Data data { get; set; }
        public List<string> error { get; set; }

        #endregion Properties
    }
}