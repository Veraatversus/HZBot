using System;
using System.Collections.Generic;

namespace HZBot
{
    public class HZLog : ViewModelBase
    {
        #region Constructors

        public HZLog()
        {
        }

        #endregion Constructors

        #region Properties

        public List<string> LogList { get; } = new List<string>();

        public string GetLogsAsString
        {
            get
            {
                return String.Join("\n", LogList);
            }
        }

        #endregion Properties

        #region Methods

        public void Add(string text)
        {
            LogList.Add(text);
            RaisePropertyChanged(nameof(GetLogsAsString));
            RaisePropertyChanged(nameof(LogList));
        }

        #endregion Methods
    }
}