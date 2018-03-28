using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZBot
{
    public class VoucherPlugin : HzPluginBase
    {
        public VoucherPlugin(HzAccount account) : base(account)
        {
        }

        public List<int> voucherids;


        public async override Task OnBotStarted()
        {
            if (string.IsNullOrWhiteSpace(Account.Character.new_user_voucher_ids))
                return;
            else
            {
                voucherids = JArray.Parse(Account.Character.new_user_voucher_ids).ToObject<List<int>>();

                foreach(int value in voucherids)
                {
                    var vid = value;
                    if (await this.GetUserVoucherAsync(vid) == null)
                    {
                        await this.redeemVoucherAsync();
                    }
                }
            }
        }

        //public async override Task AfterPrimaryWorkerWork()
        //{
        //    if (string.IsNullOrWhiteSpace(Account.Character.new_user_voucher_ids))
        //        return;
        //    else
        //    {
        //        voucherids = JArray.Parse(Account.Character.new_user_voucher_ids).ToObject<List<int>>();
        //    }
        //}
    }
}
