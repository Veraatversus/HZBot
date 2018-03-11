
using System.Threading.Tasks;

namespace HZBot
{
    public class WorldbossPlugin : HzPluginBase
    {
        public WorldbossPlugin(HzAccount account) : base(account)
        {
        }
        public async override Task OnPrimaryWorkerDoWork()
        {
            if (Account.Data.ActiveWorldBoss != null && Account.ActiveWorker == null)
            {

            }
        }
    }
}
