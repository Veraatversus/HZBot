using System.Linq;

namespace HZBot
{
    public class HideOutRoomSlot
    {
        #region Properties

        public int Level { get; internal set; }
        public int Slot { get; internal set; }
        public string SlotId => $"room_slot_{Level}_{Slot}";

        public int SlotValue { get; internal set; }
        public HideOut HideOut { get; internal set; }
        public SlotUnlockCost SlotUnlockCost => HzConstants.Default.Constants["hideout_expansion"][((Level * HideoutUtil.MAX_SLOTS) + Slot + 1).ToString()].ToObject<SlotUnlockCost>();

        public HideOutRoom Room
        {
            get
            {
                if (SlotValue > 0)
                {
                    return HideOut.Rooms.FirstOrDefault(r => r.id == SlotValue);
                }
                return null;
            }
        }

        public string ImageUrl
        {
            get
            {
                switch (State)
                {
                    case HideOutRoomSlotState.Locked:
                        return $"/HZBot;component/Assets/HideOut/Locked.png";
                    case HideOutRoomSlotState.CanUnlock:
                        return $"/HZBot;component/Assets/HideOut/CanUnlock.png";

                    case HideOutRoomSlotState.UnLocking:
                        return $"/HZBot;component/Assets/HideOut/UnLocking.png";
                    case HideOutRoomSlotState.UnLocked:
                        return $"/HZBot;component/Assets/HideOut/UnLocked.png";
                    case HideOutRoomSlotState.IsBuilding:
                        return Room.LevelImage;

                    case HideOutRoomSlotState.Builded:
                        return Room.LevelImage;
                }
                return null;
            }
        }

        public bool IsUnlocked { get; set; }

        public HideOutRoomSlotState State
        {
            get
            {
                if (Room != null)
                {
                    return Room.status == HideoutRoomStatus.Building ? HideOutRoomSlotState.IsBuilding : HideOutRoomSlotState.Builded;
                }
                if (SlotValue == 0) return HideOutRoomSlotState.UnLocked;
                if (SlotValue == -1)
                {
                    return HideOut.Slots.SkipWhile(s => s.SlotValue >= 0).FirstOrDefault().SlotId == this.SlotId ? HideOutRoomSlotState.CanUnlock : HideOutRoomSlotState.Locked;
                }
                if (SlotValue < -1) return HideOutRoomSlotState.UnLocking;
                return default;
            }
        }

        public int RoomStartSlot
        {
            get
            {
                return HzAccountManger.GetAccByHideOutID(HideOut.id).Data.hideout.Slots
                    .Where(s => s.Level == Level).Reverse().SkipWhile(s => s?.Slot != Slot)
                    ?.TakeWhile(s => s.Room != null && s.Room?.id == Room?.id)
                    .LastOrDefault()?.Slot ?? Slot;
            }
        }

        #endregion Properties
    }
}