using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace HZBot
{
    public class HzPlugins
    {
        #region Constructors

        public HzPlugins(HzAccount account)
        {
            hzAccount = account;
            LogPlugin = RegisterPlugin(new LogPlugin(hzAccount));
            Account = RegisterPlugin(new AccountPlugin(hzAccount));
            CharacterStat = RegisterPlugin(new CharacterStatPlugin(hzAccount));
            Quest = RegisterPlugin(new QuestPlugin(hzAccount));
            Duel = RegisterPlugin(new DuelPlugin(hzAccount));
            HideOut = RegisterPlugin(new HideOutPlugin(hzAccount));
            DefaultContext = System.Threading.SynchronizationContext.Current;
        }

        #endregion Constructors

        #region Properties

        public CharacterStatPlugin CharacterStat { get; private set; }
        public QuestPlugin Quest { get; private set; }
        public DuelPlugin Duel { get; private set; }
        public HideOutPlugin HideOut { get; private set; }

        private SynchronizationContext DefaultContext;

        public AccountPlugin Account { get; private set; }

        public LogPlugin LogPlugin { get; }

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
        public async Task RaiseOnLogined()
        {
            DefaultContext.Send(async (o) =>
            {
                foreach (var item in AllPlugins)
                {
                    await item.OnLogined();
                }
            }, null);
        }

        public async Task RaiseOnlogoffed()
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
        public async Task RaiseOnPrimaryWorkerComplete()
        {
            DefaultContext.Send(async (o) =>
            {
                foreach (var item in AllPlugins)
                {
                    await item.OnPrimaryWorkerComplete();
                }
            }, null);
            //if (hzAccount.Data.ActiveWorker == null)
            //{
            //    hzAccount.ActiveWorkerTimer.IsBotEnabled = false;
            //}
        }

        /// <summary>Raises the on bot started.</summary>
        /// <returns></returns>
        public async Task RaiseOnBotStarted()
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
        public async Task RaiseOnBotStoped()
        {
            DefaultContext.Send(async (o) =>
            {
                foreach (var item in AllPlugins)
                {
                    await item.OnBotStoped();
                }
            }, null);
        }

        #endregion Methods

        #region Fields

        private List<IHzPlugin> AllPlugins = new List<IHzPlugin>();
        private HzAccount hzAccount;

        #endregion Fields
    }
}