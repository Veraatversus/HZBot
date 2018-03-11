using System.Threading.Tasks;

namespace HZBot
{
    public abstract class HzPluginBase : HzServiceBase, IHzPlugin
    {
        #region Methods

        public async virtual Task AfterPrimaryWorkerWork()
        {
            return;
        }

        public async virtual Task BeforPrimaryWorkerWork()
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

        public async virtual Task OnLogined()
        {
            return;
        }

        public async virtual Task OnLogoffed()
        {
            return;
        }

        public async virtual Task OnPrimaryWorkerDoWork()
        {
            return;
        }

        #endregion Methods

        #region Constructors

        private protected HzPluginBase(HzAccount account) : base(account)
        {
        }

        #endregion Constructors
    }
}