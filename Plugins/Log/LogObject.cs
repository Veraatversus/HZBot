using System;

namespace HZBot
{
    public class LogObject : ViewModelBase
    {
        #region Properties

        public string Text { get; set; }
        public DateTime Time { get; set; }

        public string Tooltip
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
        private string tooltip;

        #endregion Fields
    }
}