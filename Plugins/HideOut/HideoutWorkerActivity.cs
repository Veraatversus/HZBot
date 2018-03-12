namespace HZBot
{
    public class HideoutWorkerActivity
    {
        #region Fields

        public HideOutRoom Room;

        public int Level = -1;

        public int Slot = -1;

        #endregion Fields

        #region Constructors

        public HideoutWorkerActivity(HideOutRoom room, int level, int slot)
        {
            this.Room = room;
            this.Level = level;
            this.Slot = slot;
        }

        #endregion Constructors
    }
}