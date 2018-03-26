using System.Threading;
using System.Threading.Tasks;

namespace HZBot
{
    public class AccountPlugin : HzPluginBase
    {
        #region Constructors

        public AccountPlugin(HzAccount account) : base(account)
        {
            //Command for Login into Account
            LoginCommand = new AsyncRelayCommand(
                async () => Account.IsLogined = string.IsNullOrWhiteSpace(await this.LoginRequestAsync()),
                () => !Account.IsLogined);

            UpdateSessionCommand = new AsyncRelayCommand(async () => await this.updateGameSessionAsync(),
                () => Account.IsLogined);
        }

        #endregion Constructors

        #region Properties

        //Command for Login into Account
        public AsyncRelayCommand LoginCommand { get; private set; }

        public AsyncRelayCommand UpdateSessionCommand { get; private set; }

        #endregion Properties

        #region Methods

        public async override Task OnAccountLoaded()
        {
            if (Account.Config.IsAutoLogin)
            {
                await LoginCommand.TryExecuteAsync();
            }
            if (Account.Config.IsAutoLogin && Account.Config.IsAutoStartBot)
            {
                Account.IsBotEnabled = true;
            }
        }

        public async override Task OnHandleError(string error)
        {
            if (error == "errUserNotAuthorized")
            {
                Account.IsLogined = false;
                await LoginCommand.TryExecuteAsync();
                await UpdateSessionCommand.TryExecuteAsync();
                Account.IsBotEnabled = true;
            }
        }

        #endregion Methods
    }
}