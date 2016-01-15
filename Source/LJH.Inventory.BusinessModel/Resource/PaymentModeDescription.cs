using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel.Resource
{
    public class PaymentModeDescription
    {
        /// <summary>
        /// 获取或设置收费类型的文字描述
        /// </summary>
        /// <param name="pm"></param>
        /// <returns></returns>
        public static string GetDescription(PaymentMode pm)
        {
            switch (pm)
            {
                case PaymentMode.None:
                    return "未付款";
                case PaymentMode.Cash:
                    return "现金";
                case PaymentMode.Transfer:
                    return "转账";
                case PaymentMode.Check:
                    return "支票";
                case PaymentMode.Prepay:
                    return "预付款";
                default:
                    return pm.ToString();
            }
        }
    }
}
