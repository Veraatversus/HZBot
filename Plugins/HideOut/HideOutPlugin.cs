using System.Linq;
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
                slot.SlotUnlockCost.HaveEnoughRessources(Account));
        }

        #endregion Constructors

        #region Properties

        public RelayCommand BuildRoomCommand { get; private set; }
        public AsyncRelayCommand<HideOutRoomSlot> UnlockSlotCommand { get; private set; }

        #endregion Properties

        #region Methods

        public async override Task OnLogined()
        {
        }

        public async override Task BeforPrimaryWorkerWork()
        {
            await DoHideOutLogic();
        }
        public async Task DoHideOutLogic()
        {
            //  await this.CollectHideoutRoomActivityResultAsync(Account.Data.hideout_rooms.FirstOrDefault());
            // await this.CheckHideoutRoomActivityFinishedAsync(Account.Data.hideout_rooms.FirstOrDefault());
            //await this.StoreHideoutRoomAsync(Account.Data.hideout_rooms.FirstOrDefault(), true);
            //await this.CheckHideoutRoomActivityFinishedAsync(Account.Data.hideout_rooms.FirstOrDefault());
            if (Account.Data?.hideout == null /*&& Account.Character.level >= 10*/)
            {
                return;
                //await this.UnlockHideoutAsync();
            }

            //var activity = Account.Data.hideout.ActiveActivity;
            //if (activity != null &&
            //   activity.Ts_activity_end < Account.ServerTime)
            //{
            //    if (activity.Room != null)
            //    {
            //        await this.CheckHideoutRoomActivityFinishedAsync(activity.Room);
            //    }
            //}
            if (Account.Config.IsAutoHideOutCollect)
            {
                foreach (var room in Account.Data.hideout.RoomsToRewardCollect(25))
                {
                    switch (room.CRoom.Type)
                    {
                        case HideoutRoomType.stone_production:
                            if (Account.Data.hideout.current_resource_stone == Account.Data.hideout.max_resource_stone)
                                continue;
                            break;

                        case HideoutRoomType.glue_production:
                            if (Account.Data.hideout.current_resource_glue == Account.Data.hideout.max_resource_glue)
                                continue;
                            break;
                    }
                    await this.CollectHideoutRoomActivityResultAsync(room);
                }
            }
            if (Account.Config.IsAutoHideOutUpgrade && Account.Data.hideout.ActiveActivity == null)
            {
                var room = Account.Data.hideout.Rooms.RoomsThatCanUpgrade()
                      .OrderBy(r => r.CNextLevel?.price_gold)
                      .FirstOrDefault();
                if (room != null)
                {
                    await this.CollectHideoutRoomActivityResultAsync(room);
                    await this.UpgradeHideoutRoomAsync(room, true);
                }
            }
            // IsAutoHideOutBuild
            if (Account.Config.IsAutoHideOutBuild && Account.Data.hideout.ActiveActivity == null)
            {

                var rooms = Account.Data.hideout.RoomsThatCanBuilded().HaveEnoughRessources(Account);
                foreach (var room in rooms)
                {
                    HideOutRoomSlot slot = null;
                    if (room.Type == HideoutRoomType.main_building)
                    {
                        slot = Account.Data.hideout.Slots.GetFreeSlotsForRoom(room).LastOrDefault();
                    }
                    else if (room.Type == HideoutRoomType.generator)
                    {
                        slot = Account.Data.hideout.Slots.GetFreeSlotsForRoom(room)
                            .FirstOrDefault(s =>
                            s.PrevSlot?.Level == s.Level &&
                            (s.PrevSlot?.Room == null || s.NextSlot.Room.CRoom.IsAutoProductionRoom) &&
                            s.NextSlot?.Level == s.Level &&
                            (s.NextSlot?.Room == null || s.NextSlot.Room.CRoom.IsAutoProductionRoom)
                            );
                    }
                    else if (room.IsAutoProductionRoom)
                    {
                        var i = Account.Data.hideout.Slots.GetFreeSlotsForRoom(room);
                        slot = i
                             .FirstOrDefault(s =>
                             (s.PrevSlot?.Level == s.Level && s.PrevSlot?.Room?.CRoom.Type == HideoutRoomType.generator) ||
                            (s.GetEndSlotForRoom(room).NextSlot?.Level == s.Level && s.GetEndSlotForRoom(room).NextSlot?.Room?.CRoom.Type == HideoutRoomType.generator)
                            );

                        slot = slot ?? Account.Data.hideout.Slots.GetFreeSlotsForRoom(room)
                             .FirstOrDefault(s =>
                             (s.PrevSlot?.Level == s.Level &&
                            s.PrevSlot?.Room == null)
                            ||
                            (s.GetEndSlotForRoom(room).NextSlot?.Level == s.Level &&
                            s.GetEndSlotForRoom(room).NextSlot?.Room == null)
                            );
                        slot = slot ?? Account.Data.hideout.Slots.GetFreeSlotsForRoom(room).FirstOrDefault();
                    }
                    else
                    {
                        slot = Account.Data.hideout.Slots.GetFreeSlotsForRoom(room).LastOrDefault();
                    }

                    if (slot != null)
                    {
                        var error = await this.BuildHideoutRoomAsync(slot, room);
                        if (error == null)
                        {
                            break;
                        }
                    }
                }

                //AutoUlock
                if (Account.Data.hideout.ActiveActivity == null)
                {
                    var slot = Account.Data.hideout.Slots.GetNextUnlockSlot();
                    if (slot != null && slot.SlotUnlockCost.HaveEnoughRessources(Account))
                    {
                        await this.UnlockSlotCommand.TryExecuteAsync(slot);
                    }
                }
            }
        }
        #endregion Methods
    }
}