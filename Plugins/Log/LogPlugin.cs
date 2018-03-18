using System;
using System.Linq;
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

        public AsyncObservableCollection<LogObject> LogList { get; } = new AsyncObservableCollection<LogObject>();
        public AsyncObservableCollection<KeyValue> RequestLog { get; } = new AsyncObservableCollection<KeyValue>();
        public AsyncObservableCollection<KeyValue> ErrorLog { get; } = new AsyncObservableCollection<KeyValue>();

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

        public void AddRequestLog(string action)
        {
            Context.Send(o =>
            {
                var keyvalue = RequestLog.FirstOrDefault(kv => kv.Key == action);
                if (keyvalue != null)
                {
                    keyvalue.Value++;
                }
                else
                {
                    var keyVal = new KeyValue
                    {
                        Key = action,
                        Value = 1
                    };
                    RequestLog.Add(keyVal);
                }
            }, null);
        }

        public void AddErrorLog(string error)
        {
            Context.Send(o =>
            {
                var keyvalue = ErrorLog.FirstOrDefault(kv => kv.Key == error);
                if (keyvalue != null)
                {
                    keyvalue.Value++;
                }
                else
                {
                    var keyVal = new KeyValue
                    {
                        Key = error,
                        Value = 1
                    };
                    ErrorLog.Add(keyVal);
                }
            }, null);
        }

        #endregion Methods

        #region Fields

        private readonly SynchronizationContext Context;

        #endregion Fields
    }
}