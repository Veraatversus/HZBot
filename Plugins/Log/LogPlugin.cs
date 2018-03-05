using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace HZBot
{
    public class LogPlugin : HzPluginBase
    {
        #region Constructors

        public LogPlugin(HzAccount account) : base(account)
        {
            Context = System.Threading.SynchronizationContext.Current;
        }

        #endregion Constructors

        #region Properties

        public ObservableCollection<string> LogList { get; } = new ObservableCollection<string>();

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
            Context.Send(o => LogList.Add(text), null);
            //LogList.Add(text);
            RaisePropertyChanged(nameof(GetLogsAsString));
            // RaisePropertyChanged(nameof(LogList));
        }

        #endregion Methods

        #region Fields

        private SynchronizationContext Context;

        #endregion Fields
    }
}