using System.Threading.Tasks;

namespace HZBot
{
    public class HideOutPlugin : HzPluginBase
    {
        #region Constructors

        public HideOutPlugin(HzAccount account) : base(account)
        {


            BuildRoomCommand = new RelayCommand(() => System.Console.WriteLine(""));
            UnlockSlotCommand = new AsyncRelayCommand<HideOutRoomSlot>(
                slot => this.UnlockHideoutRoomSlotAsync(slot),
                slot => slot.State == HideOutRoomSlotState.CanUnlock && 
                slot.SlotUnlockCost.price_glue <= Account.Data.hideout.current_resource_glue &&
                slot.SlotUnlockCost.price_stone <= Account.Data.hideout.current_resource_stone &&
                slot.SlotUnlockCost.price_gold <= Account.Character.game_currency);
        }

        public RelayCommand BuildRoomCommand { get; private set; }
        public AsyncRelayCommand<HideOutRoomSlot> UnlockSlotCommand { get; private set; }

        #endregion Constructors

        #region Methods
        public async override Task OnLogined()
        {
        }

        public async override Task AfterPrimaryWorkerWork()
        {
            // AutoHideOutCollect
            if (Account.Config.IsAutoHideOutCollect)
            {
                foreach (var room in Account.Data.hideout.RoomsToRewardCollect(25))
                {
                    switch (room.identifier)
                    {
                        case HideoutRoomTypes.StoneProduction:
                            if (Account.Data.hideout.current_resource_stone == Account.Data.hideout.max_resource_stone)
                                continue;
                            break;

                        case HideoutRoomTypes.GlueProduction:
                            if (Account.Data.hideout.current_resource_glue == Account.Data.hideout.max_resource_glue)
                                continue;
                            break;
                    }
                    await this.CollectHideoutRoomActivityResultAsync(room);
                }
            }

            // IsAutoHideOutBuild
            if (Account.Config.IsAutoHideOutBuild)
            {

            }
            return;
        }

        #endregion Methods
    }
}