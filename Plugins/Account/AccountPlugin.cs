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

        #region Properties

        //Command for Login into Account
        public AsyncRelayCommand LoginCommand { get; private set; }

        #endregion Properties
    }
}