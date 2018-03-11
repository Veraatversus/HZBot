using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading;

namespace HZBot
{
    public static class HzAccountManger
    {
        #region Constructors

        static HzAccountManger()
        {
            SynContext = System.Threading.SynchronizationContext.Current;
            AddAccountCommand = new RelayCommand(() => new HzAccount());
            RemoveAccountCommand = new RelayCommand<HzAccount>(RemoveAccount);
        }

        #endregion Constructors

        #region Properties

        public static RelayCommand<HzAccount> RemoveAccountCommand { get; set; }
        public static RelayCommand AddAccountCommand { get; set; }
        public static ObservableCollection<HzAccount> Accounts { get; } = new ObservableCollection<HzAccount>();

        #endregion Properties

        #region Methods

        /// <summary>Adds the account.</summary>
        /// <param name="account">The account.</param>
        public static void AddAccount(HzAccount account)
        {
            SynContext.Send((o) => Accounts.Add(account), null);
        }

        /// <summary>Removes the account.</summary>
        /// <param name="account">The account.</param>
        public static void RemoveAccount(HzAccount account)
        {
            if (account != null && RemoveAccountCommand.CanExecute(account))
            {
                account.IsLogined = false;
                SynContext.Send((o) => Accounts.Remove(account), null);
            }
        }

        /// <summary>Gets the account by character identifier.</summary>
        /// <param name="characterId">The character identifier.</param>
        /// <returns></returns>
        public static HzAccount GetAccountByCharacterID(int characterId)
        {
            return Accounts.FirstOrDefault(acc => acc.Character?.id == characterId);
        }

        /// <summary>Gets the item by item id.</summary>
        /// <param name="itemId">The item id.</param>
        /// <param name="characterId">The character id.</param>
        /// <returns></returns>
        public static Item GetItemById(int itemId, int characterId = 0)
        {
            IEnumerable<Item> itemsList;
            if (characterId == 0) itemsList = Accounts.SelectMany(acc => acc.Data.items);
            else itemsList = Accounts.SingleOrDefault(acc => acc.Character?.id == characterId).Data.items;

            return itemsList?.FirstOrDefault(item => item.id == itemId);
        }

        /// <summary>Loads this instance.</summary>
        public static void Load()
        {
            if (File.Exists(HzConfig.FilePath))
            {
                var config = JArray.Parse(File.ReadAllText(HzConfig.FilePath));
                foreach (var item in config.Children())
                {
                    new HzAccount(item.ToObject<HzConfig>());
                }
            }
            if (Accounts.FirstOrDefault() == null)
            {
                new HzAccount();
            }
        }

        /// <summary>Saves this instance.</summary>
        public static void Save()
        {
            var Jobj = new JArray();
            foreach (var acc in Accounts)
            {
                Jobj.Add(JToken.FromObject(acc.Config));
            }

            File.WriteAllText(HzConfig.FilePath, Jobj.ToString());
        }

        #endregion Methods

        #region Fields

        private static readonly SynchronizationContext SynContext;

        #endregion Fields
    }
}