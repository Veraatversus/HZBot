﻿using System;

namespace HZBot
{
    public class AccountPlugin : HzPluginBase
    {
        #region Constructors

        public AccountPlugin(HzAccount account) : base(account)
        {
            //Command for Login into Account
            LoginCommand = new AsyncRelayCommand(
                async () => Account.IsLogined = !(await this.LoginRequestAsync()).HasValues,
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
                    Action onstartet = async () => await Account.Plugins.RaiseOnBotStarted();
                    onstartet();
                    if (Account.ActiveWorker == null)
                    {
                        Action workerComplete = async () => await Account.Plugins.RaiseOnPrimaryWorkerComplete();
                        workerComplete();
                    }
                }
                else
                {
                    Action botstopped = async () => await Account.Plugins.RaiseOnBotStoped();
                    botstopped();
                }
            }
        }

        #endregion Properties

        #region Fields

        private bool _isBotEnabled;

        #endregion Fields
    }
}