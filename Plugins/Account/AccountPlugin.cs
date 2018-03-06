using System;

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

        public bool IsAutoReconnect { get; set; }

        public bool IsBotEnabled
        {
            get
            {
                return _isBotEnabled;
            }

            set
            {
                _isBotEnabled = value;
                RaisePropertyChanged();
                if (IsBotEnabled)
                {
                    //Action onstartet = async () => await Account.Plugins.RaiseOnBotStarted();
                    //onstartet();
                    Account.Plugins.RaiseOnBotStarted();
                    if (Account.ActiveWorker == null)
                    {
                        Account.Plugins.RaiseOnPrimaryWorkerComplete();
                        //Action workerComplete = async () => await Account.Plugins.RaiseOnPrimaryWorkerComplete();
                        //workerComplete();
                    }
                }
                else
                {
                    Account.Plugins.RaiseOnBotStoped();
                    //Action botstopped = async () => await Account.Plugins.RaiseOnBotStoped();
                    //botstopped();
                }
            }
        }

        #endregion Properties

        #region Fields

        private bool _isBotEnabled;

        #endregion Fields
    }
}