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

        #region Methods

        public override string ToString()
        {
            return $"{Time.Hour:00}:{Time.Minute:00}:{Time.Second:00} - {Text}";
        }

        #endregion Methods

        #region Fields

        private RequestState requestState;
        private object tooltip;

        #endregion Fields
    }
}