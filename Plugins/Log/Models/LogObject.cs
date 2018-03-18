using System;

namespace HZBot
{
    public class LogObject : ViewModelBase
    {
        #region Properties

        public string Text { get; set; }
        public DateTime Time { get; set; }

        public object Tooltip
        {
            get => tooltip;
            set { tooltip = value; RaisePropertyChanged(); }
        }

        public RequestState RequestState
        {
            get => requestState;
            set { requestState = value; RaisePropertyChanged(); }
        }

        public override string ToString()
        {
            return $"{DateTime.Now.Hour:00}:{DateTime.Now.Minute:00}:{DateTime.Now.Second:00} - {Text}";
        }
        #endregion Properties

        #region Fields

        private RequestState requestState;
        private object tooltip;

        #endregion Fields
    }
}