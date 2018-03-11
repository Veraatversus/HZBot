using System.Linq;
using System.Threading.Tasks;

namespace HZBot
{
    public class ItemPlugin : HzPluginBase
    {
        #region Constructors

        public ItemPlugin(HzAccount account) : base(account)
        {
            EquipItemCommand = new AsyncRelayCommand<Item>(async item => await EquipItemAsync(item));
            UnEquipItemCommand = new AsyncRelayCommand<Item>(async item => await UnEquipItemAsync(item), item => Account.Data.HzInventory.FreeBagSpace > 0);
            SellItemCommand = new AsyncRelayCommand<Item>(async item => await this.SellInventoryItemAsync(item.id));
        }

        #endregion Constructors

        #region Properties

        public AsyncRelayCommand<Item> EquipItemCommand { get; set; }
        public AsyncRelayCommand<Item> UnEquipItemCommand { get; set; }
        public AsyncRelayCommand<Item> SellItemCommand { get; set; }

        #endregion Properties

        #region Methods

        public async override Task BeforPrimaryWorkerWork()
        {
            //AutoEquip
            if (Account.Config.IsAutoEquip)
            {
                var items = Account.Data.HzInventory.BagItems;
                foreach (var item in items)
                {
                    var t = Account.Data.HzInventory.CompareToEquip(item);
                    if (t > 0)
                    {
                        await EquipItemAsync(item);
                    }
                }
            }
            //AutoSell
            switch (Account.Config.SellMode)
            {
                case SellMode.KeepSpace:
                    while (Account.Data.HzInventory.FreeBagSpace < 2)
                    {
                        var worstItem = Account.Data.HzInventory.BagItems.OrderBy(item => item.GearScore()).FirstOrDefault();
                        await SellItemCommand.TryExecuteAsync(worstItem);
                    }
                    break;

                case SellMode.SellAll:
                    var items = Account.Data.HzInventory.BagItems;
                    foreach (var item in items)
                    {
                        await SellItemCommand.TryExecuteAsync(item);
                    }
                    break;
            }
        }

        private async Task EquipItemAsync(Item item)
        {
            if (item.type > 0 && item.type < ItemType.Missiles)
            {
                if (item.required_level <= Account.Character?.level && item.EquipSlot() != HzInventoryId.Unknown)
                {
                    await this.MoveInventoryItemAsync(item.id, InventoryAction.EquipItem, item.EquipSlot());
                }
            }
        }

        private async Task UnEquipItemAsync(Item item)
        {
            var slot = Account.Data.HzInventory.GetFreeBagSlot();
            if (slot != null)
            {
                await this.MoveInventoryItemAsync(item.id, InventoryAction.UnequipItem, slot.Id);
            }
        }

        #endregion Methods
    }
}