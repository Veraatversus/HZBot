using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HZBot
{
    internal static class AccountManger
    {
        #region Properties

        public static ObservableCollection<HzAccount> Accounts { get; } = new ObservableCollection<HzAccount>();

        #endregion Properties

        #region Methods

        /// <summary>Gets the item by item id.</summary>
        /// <param name="itemId">The item id.</param>
        /// <param name="characterId">The character id.</param>
        /// <returns></returns>
        public static Item GetItemById(int itemId, int characterId = 0)
        {
            IEnumerable<Item> itemsList;
            if (characterId == 0) itemsList = Accounts.SelectMany(acc => acc.Data.items);
            else itemsList = Accounts.SingleOrDefault(acc => acc.Character.id == characterId).Data.items;
            return itemsList?.FirstOrDefault(item => item.id == itemId);
        }

        #endregion Methods
    }
}