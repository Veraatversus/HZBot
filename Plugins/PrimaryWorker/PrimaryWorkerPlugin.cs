namespace HZBot
{
    public class PrimaryWorkerPlugin : HzPluginBase
    {
        #region Constructors

        public PrimaryWorkerPlugin(HzAccount account) : base(account)
        {
            Timer = new PrimaryWorkerTimer(Account);
        }

        #endregion Constructors

        #region Properties

        public PrimaryWorkerTimer Timer { get; set; }

        #endregion Properties
    }
}