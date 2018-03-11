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
        }

        #endregion Constructors
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
            }
        }
        #region Properties
        //Command for Login into Account
        public AsyncRelayCommand LoginCommand { get; private set; }

        #endregion Properties
    }
}