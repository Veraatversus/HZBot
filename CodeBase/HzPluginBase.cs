using System.Threading.Tasks;

namespace HZBot
{
    public abstract class HzPluginBase : ViewModelBase
    {
        #region Methods

        public abstract Task OnExcecuteAsync();

        #endregion Methods

        #region Properties

        protected internal HzAccount Account { get; }

        #endregion Properties

        #region Constructors

        protected private HzPluginBase(HzAccount account)
        {
            Account = account;
        }

        #endregion Constructors
    }
}