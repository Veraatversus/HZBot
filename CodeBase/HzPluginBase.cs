using System.Threading.Tasks;

namespace HZBot
{
    public abstract class HzPluginBase : ViewModelBase
    {
        #region Methods

        public abstract Task OnExcecuteAsync();

        private HzAccount _account;

        #endregion Methods

        #region Properties

        public HzAccount Account
        {
            get
            {
                return _account;
            }
            set
            {
                _account = value;
                RaisePropertyChanged();
            }
        }

        #endregion Properties

        #region Constructors

        protected private HzPluginBase(HzAccount account)
        {
            Account = account;
        }

        #endregion Constructors
    }
}