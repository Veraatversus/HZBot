using System;
using System.Collections.Generic;

namespace HZBot
{
    public class HZLog : HzUserControl
    {
        List<string> logList = new List<string>();


        public string GetLogs
        {
            get
            {
                return String.Join("\n", logList);
            }
        }

        public HZLog()
        {
        }


        public void Add(string text)
        {
            logList.Add(text);
            RaisePropertyChanged(nameof(GetLogs));
        }
    }
}