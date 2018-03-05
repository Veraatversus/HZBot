namespace HZBot
{
    public class HzServiceBase : ViewModelBase
    {
        #region Constructors

        public HzServiceBase(HzAccount account)
        {
            Account = account;
        }

        #endregion Constructors

        #region Properties

        public HzAccount Account { get; }

        #endregion Properties
    }
}