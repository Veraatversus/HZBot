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

        #endregion Properties

        #region Fields

        private RequestState requestState;
        private object tooltip;

        #endregion Fields
    }
}