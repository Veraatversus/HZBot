﻿using System.Collections.Generic;

namespace HZBot
{
    public class PostContent
    {
        #region Properties

        public List<KeyValuePair<string, string>> Content { get; set; }
        public HzAccount Account { get; set; }

        #endregion Properties
    }
}