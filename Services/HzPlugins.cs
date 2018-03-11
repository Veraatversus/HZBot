using System.Collections.Generic;
using System.Threading;

namespace HZBot
{
    public class HzPlugins
    {
        #region Constructors

        public HzPlugins(HzAccount account)
        {
            hzAccount = account;
            Log = RegisterPlugin(new LogPlugin(hzAccount));
            Account = RegisterPlugin(new AccountPlugin(hzAccount));
            Worldboss = RegisterPlugin(new WorldbossPlugin(hzAccount));
            CharacterStat = RegisterPlugin(new CharacterStatPlugin(hzAccount));
            Quest = RegisterPlugin(new QuestPlugin(hzAccount));
            Duel = RegisterPlugin(new DuelPlugin(hzAccount));
            HideOut = RegisterPlugin(new HideOutPlugin(hzAccount));
            Item = RegisterPlugin(new ItemPlugin(hzAccount));
            PrimaryWorker = RegisterPlugin(new PrimaryWorkerPlugin(hzAccount));
            DefaultContext = System.Threading.SynchronizationContext.Current;
        }

        #endregion Constructors

        #region Properties

        public CharacterStatPlugin CharacterStat { get; private set; }
        public QuestPlugin Quest { get; private set; }
        public DuelPlugin Duel { get; private set; }
        public HideOutPlugin HideOut { get; private set; }
        public ItemPlugin Item { get; private set; }
        public PrimaryWorkerPlugin PrimaryWorker { get; private set; }

        private readonly SynchronizationContext DefaultContext;

        public AccountPlugin Account { get; private set; }
        public WorldbossPlugin Worldboss { get; private set; }
        public LogPlugin Log { get; }

        #endregion Properties

        #region Methods

        /// <summary>Registers the plugin.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="plugin">The plugin.</param>
        /// <returns></returns>
        public T RegisterPlugin<T>(T plugin) where T : IHzPlugin
        {
            // ExecuteEvent += plugin.OnExcecuteAsync;
            AllPlugins.Add(plugin);
            return plugin;
        }

        /// <summary>Raises the on plugin loaded.</summary>
        /// <returns></returns>
        public void RaiseOnLogined()
        {
            DefaultContext.Send(async (o) =>
            {
                foreach (var item in AllPlugins)
                {
                    await item.OnLogined();
                }
            }, null);
        }

        public void RaiseOnlogoffed()
        {
            DefaultContext.Send(async (o) =>
            {
                foreach (var item in AllPlugins)
                {
                    await item.OnLogoffed();
                }
            }, null);
        }

        /// <summary>Raises the on primary worker complete.</summary>
        /// <returns></returns>
        public void RaiseOnPrimaryWorkerComplete()
        {
            DefaultContext.Send(async (o) =>
            {
                foreach (var item in AllPlugins)
                {
                    await item.BeforPrimaryWorkerWork();
                }
                foreach (var item in AllPlugins)
                {
                    await item.OnPrimaryWorkerDoWork();
                }
                foreach (var item in AllPlugins)
                {
                    await item.AfterPrimaryWorkerWork();
                }
            }, null);
            //if (hzAccount.Data.ActiveWorker == null)
            //{
            //    hzAccount.ActiveWorkerTimer.IsBotEnabled = false;
            //}
        }

        /// <summary>Raises the on bot started.</summary>
        /// <returns></returns>
        public void RaiseOnBotStarted()
        {
            DefaultContext.Send(async (o) =>
            {
                foreach (var item in AllPlugins)
                {
                    await item.OnBotStarted();
                }
            }, null);
        }

        /// <summary>Raises the on bot stoped.</summary>
        /// <returns></returns>
        public void RaiseOnBotStoped()
        {
            DefaultContext.Send(async (o) =>
            {
                foreach (var item in AllPlugins)
                {
                    await item.OnBotStoped();
                }
            }, null);
        }

        /// <summary>Raises the account loaded.</summary>
        public void RaiseOnAccountLoaded()
        {
            DefaultContext.Send(async (o) =>
            {
                foreach (var item in AllPlugins)
                {
                    await item.OnAccountLoaded();
                }
            }, null);
        }

        public void RaiseOnHandleError(string error)
        {
            DefaultContext.Send(async (o) =>
            {
                foreach (var item in AllPlugins)
                {
                    await item.OnHandleError(error);
                }
            }, null);
        }





        #endregion Methods

        #region Fields

        private readonly List<IHzPlugin> AllPlugins = new List<IHzPlugin>();
        private readonly HzAccount hzAccount;

        #endregion Fields
    }
}