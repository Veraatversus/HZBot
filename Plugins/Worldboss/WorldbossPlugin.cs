using System.Threading.Tasks;

namespace HZBot
{
    public class WorldbossPlugin : HzPluginBase
    {
        #region Constructors

        public WorldbossPlugin(HzAccount account) : base(account)
        {
            StartAttackCommand = new AsyncRelayCommand<WorldbossEvent>(async e => await this.StartWorldbossAttackAsync(e.id), e => Account.ActiveWorker == null && e.status == WorldbossEventStatus.Started);
        }

        #endregion Constructors

        #region Properties

        public AsyncRelayCommand<WorldbossEvent> StartAttackCommand { get; set; }

        #endregion Properties

        #region Methods

        public async override Task OnPrimaryWorkerDoWork()
        {
            if (Account.Config.IsAutoAttackWorldboss && Account.Data.ActiveWorldBossEvent != null)
            {
                await StartAttackCommand.TryExecuteAsync(Account.Data.ActiveWorldBossEvent);
            }
        }

        #endregion Methods
    }
}