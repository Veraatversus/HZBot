namespace HZBot
{
    public class HzGear
    {
        #region Constructors

        public HzGear(HzInventory hzInventory)
        {
            this.hzInventory = hzInventory;
        }

        #endregion Constructors

        #region Fields

        private readonly HzInventory hzInventory;

        #endregion Fields
    }
}