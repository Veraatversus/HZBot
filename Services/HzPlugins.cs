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
            DefaultContext = SynchronizationContext.Current;
            Log = RegisterPlugin(new LogPlugin(hzAccount));
            Account = RegisterPlugin(new AccountPlugin(hzAccount));
            Worldboss = RegisterPlugin(new WorldbossPlugin(hzAccount));
            CharacterStat = RegisterPlugin(new CharacterStatPlugin(hzAccount));
            Quest = RegisterPlugin(new QuestPlugin(hzAccount));
            Duel = RegisterPlugin(new DuelPlugin(hzAccount));
            HideOut = RegisterPlugin(new HideOutPlugin(hzAccount));
            Item = RegisterPlugin(new ItemPlugin(hzAccount));
            PrimaryWorker = RegisterPlugin(new PrimaryWorkerPlugin(hzAccount));
            Booster = RegisterPlugin(new BoosterPlugin(hzAccount));
            Goal = RegisterPlugin(new GoalPlugin(hzAccount));
        }

        #endregion Constructors

        #region Properties

        public BoosterPlugin Booster { get; set; }
        public GoalPlugin Goal { get; private set; }
        public CharacterStatPlugin CharacterStat { get; private set; }
        public QuestPlugin Quest { get; private set; }
        public DuelPlugin Duel { get; private set; }
        public HideOutPlugin HideOut { get; private set; }
        public ItemPlugin Item { get; private set; }
        public PrimaryWorkerPlugin PrimaryWorker { get; private set; }

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
        public async Task RaiseOnLogined()
        {
            foreach (var item in AllPlugins)
            {
                await item.OnLogined();
            }
        }

        public async Task RaiseOnlogoffed()
        {
            foreach (var item in AllPlugins)
            {
                await item.OnLogoffed();
            }
        }

        /// <summary>Raises the on primary worker complete.</summary>
        /// <returns></returns>
        public async Task RaiseOnPrimaryWorkerComplete()
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
        }

        /// <summary>Raises the on bot started.</summary>
        /// <returns></returns>
        public async Task RaiseOnBotStarted()
        {
            foreach (var item in AllPlugins)
            {
                await item.OnBotStarted();
            }
        }

        /// <summary>Raises the on bot stoped.</summary>
        /// <returns></returns>
        public async Task RaiseOnBotStoped()
        {
            foreach (var item in AllPlugins)
            {
                await item.OnBotStoped();
            }
        }

        /// <summary>Raises the account loaded.</summary>
        public async Task RaiseOnAccountLoaded()
        {
            foreach (var item in AllPlugins)
            {
                await item.OnAccountLoaded();
            }
        }

        public async Task RaiseOnHandleError(string error)
        {
            foreach (var item in AllPlugins)
            {
                await item.OnHandleError(error);
            }
        }

        #endregion Methods

        #region Fields

        private readonly SynchronizationContext DefaultContext;
        private readonly List<IHzPlugin> AllPlugins = new List<IHzPlugin>();
        private readonly HzAccount hzAccount;

        #endregion Fields
    }
}