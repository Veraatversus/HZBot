using Newtonsoft.Json;

namespace HZBot
{
    public class HzServiceBase : ViewModelBase
    {
        #region Constructors

        public HzServiceBase(HzAccount account)
        {
            Account = account;
        }

        #endregion Constructors

        #region Properties

        [JsonIgnore]
        public HzAccount Account
        {
            get
            {
                return account;
            }

            set
            {
                account = value;
                RaisePropertyChanged();
            }
        }

        #endregion Properties

        #region Fields

        private HzAccount account;

        #endregion Fields
    }
}