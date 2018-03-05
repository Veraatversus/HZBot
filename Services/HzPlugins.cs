using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HZBot
{
    public class HzPlugins : ViewModelBase
    {
        #region Constructors

        public HzPlugins(HzAccount account)
        {
            hzAccount = account;
            Account = RegisterPlugin(new AccountPlugin(hzAccount));
            CharacterStat = RegisterPlugin(new CharacterStatPlugin(hzAccount));
            Quest = RegisterPlugin(new QuestPlugin(hzAccount));
            //Duel = RegisterPlugin(new DuelPlugin(hzAccount));
            HideOut = RegisterPlugin(new HideOutPlugin(hzAccount));
        }

        #endregion Constructors

        #region Properties

        public CharacterStatPlugin CharacterStat { get; set; }
        public QuestPlugin Quest { get; set; }
        public DuelPlugin Duel { get; private set; }
        public HideOutPlugin HideOut { get; private set; }

        public bool IsExecuteRunning { get; private set; }

        public AccountPlugin Account { get; private set; }

        #endregion Properties

        #region Methods

        public T RegisterPlugin<T>(T plugin) where T : HzPluginBase
        {
            // ExecuteEvent += plugin.OnExcecuteAsync;
            registeredPlugins.Add(plugin.OnExcecuteAsync);
            return plugin;
        }

        public async Task RaiseExcecuteEvent()
        {
            IsExecuteRunning = true;
            //Check for Data
            if (hzAccount.Data == null)
            {
                hzAccount.Bot.IsBotEnabled = false;
                IsExecuteRunning = false;
                return;
            }
            //Trigger Plugins
            foreach (var item in registeredPlugins)
            {
                await item();
            }

            // Check for work complete
            if (hzAccount.Data.ActiveWorker == null)
            {
                hzAccount.Bot.IsBotEnabled = false;
            }
            IsExecuteRunning = false;
        }

        #endregion Methods

        #region Fields

        private List<Func<Task>> registeredPlugins = new List<Func<Task>>();
        private HzAccount hzAccount;

        #endregion Fields
    }
}