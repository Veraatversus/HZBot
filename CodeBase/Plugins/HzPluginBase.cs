using System.Threading.Tasks;

namespace HZBot
{
    public abstract class HzPluginBase : ViewModelBase, IHzPlugin
    {
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

        #region Methods

        public async virtual Task OnLogined()
        {
            return;
        }

        public async virtual Task OnPrimaryWorkerDoWork()
        {
            return;
        }

        public async virtual Task OnBotStarted()
        {
            return;
        }

        public async virtual Task OnBotStoped()
        {
            return;
        }

        public async virtual Task OnLogoffed()
        {
            return;
        }

        public async virtual Task AfterPrimaryWorkerWork()
        {
            return;
        }

        public async virtual Task BeforPrimaryWorkerWork()
        {
            return;
        }

        #endregion Methods

        #region Constructors

        protected private HzPluginBase(HzAccount account)
        {
            Account = account;
        }

        #endregion Constructors

        #region Fields

        private HzAccount _account;

        #endregion Fields
    }
}