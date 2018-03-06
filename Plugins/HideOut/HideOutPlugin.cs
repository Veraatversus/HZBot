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

        #region Properties

        public bool IsAutoHideOutCollect { get; set; }
        public bool IsAutoHideOutBuild { get; set; }

        #endregion Properties

        #region Methods

        public async override Task OnPrimaryWorkerDoWork()
        {
            // AutoHideOutCollect
            if (IsAutoHideOutCollect)
            {
            }

            // IsAutoHideOutBuild
            if (IsAutoHideOutBuild)
            {
            }
            return;
        }

        #endregion Methods
    }
}