using System.Linq;
using Newtonsoft.Json.Linq;
using System;
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

        public async override Task AfterPrimaryWorkerWork()
        {

            // AutoHideOutCollect
            if (Account.Config.IsAutoHideOutCollect)
            {
                foreach (var room in Account.Data.hideout.hasRewardToCollect(25))
                {
                    switch (room.identifier)
                    {
                        case HideoutRoomTypes.StoneProduction:
                            if (Account.Data.hideout.current_resource_stone == Account.Data.hideout.max_resource_stone)
                                continue;
                            break;
                        case HideoutRoomTypes.GlueProduction:
                            if (Account.Data.hideout.current_resource_glue == Account.Data.hideout.max_resource_glue)
                                continue;
                            break;
                    }
                    await this.CollectHideoutRoomActivityResultAsync(room);

                }
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