using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZBot
{
    public static class VoucherRequest
    {
        public static async Task<string> GetUserVoucherAsync(this VoucherPlugin plugin, int vid)
        {
            var error = await plugin.Account.DefaultRequestContent("getUserVoucher")
                .AddKeyValue("rct", "1")
                .AddKeyValue("id",vid.ToString())
                .AddLog($"[Voucher] getUserVoucher")
                .PostToHzAsync();

            return error;
        }

        public static async Task<string> redeemVoucherAsync(this HzPluginBase plugin)
        {
            var error = await plugin.Account.DefaultRequestContent("redeemVoucher")
                .AddKeyValue("rct", "1")
                .AddKeyValue("code", plugin.Account.Data.voucher.code)
                .AddLog($"[Voucher] Erhalten: {plugin.Account.Data.voucher.code}")
                .PostToHzAsync();

            return error;
        }
    }
}
