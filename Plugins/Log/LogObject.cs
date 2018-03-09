using System;

namespace HZBot
{
    public class LogObject : ViewModelBase
    {
        #region Properties

        public string Text { get; set; }
        public DateTime Time { get; set; }

        public RequestState RequestState
        {
            get
            {
                return requestState;
            }

            set
            {
                requestState = value;
                RaisePropertyChanged();
            }
        }

        #endregion Properties

        #region Fields

        private RequestState requestState;

        #endregion Fields
    }
}