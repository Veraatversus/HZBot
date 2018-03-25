namespace HZBot
{
    public class HideoutWorkerActivity
    {
        #region Fields

        public HideOutRoom Room;

        public int Level = -1;

        public int Slot = -1;

        public long Ts_activity_end = -1;

        #endregion Fields

        #region Constructors

        public HideoutWorkerActivity(HideOutRoom room, int level, int slot, int ts_complete)
        {
            this.Room = room;
            this.Level = level;
            this.Slot = slot;
            this.Ts_activity_end = ts_complete;
        }

        #endregion Constructors
    }
}