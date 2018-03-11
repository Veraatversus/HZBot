using System.Threading.Tasks;

namespace HZBot
{
    public class HideOutPlugin : HzPluginBase
    {
        #region Constructors

        public HideOutPlugin(HzAccount account) : base(account)
        {
        }

        #endregion Constructors

        #region Methods

        public async override Task OnPrimaryWorkerDoWork()
        {
            // AutoHideOutCollect
            if (Account.Config.IsAutoHideOutCollect)
            {
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