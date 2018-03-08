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

        public ObservableCollection<LogObject> LogList { get; } = new ObservableCollection<LogObject>();

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
            Add(new LogObject() { Text = text, Time = DateTime.Now });
            //LogList.Add(text);
            RaisePropertyChanged(nameof(GetLogsAsString));
        }

        public void Add(LogObject logObject)
        {
            Context.Send(o => LogList.Add(logObject), null);
        }

        #endregion Methods

        #region Fields

        private SynchronizationContext Context;

        #endregion Fields
    }
}