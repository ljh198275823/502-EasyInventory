using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示公司的资金支出记录
    /// </summary>
    public class ExpenditureRecord : ISheet<string>
    {
        #region 构造函数
        public ExpenditureRecord()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置最近一次活动日期
        /// </summary>
        public DateTime LastActiveDate { get; set; }
        /// <summary>
        /// 获取或设置支出类别
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 获取或设置支出的销售订单号(用于统计订单的管理费用)
        /// </summary>
        public string OrderID { get; set; }
        /// <summary>
        /// 获取或设置支付金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置支付方式
        /// </summary>
        public PaymentMode PaymentMode { get; set; }
        /// <summary>
        /// 获取或设置请款人
        /// </summary>
        public string Request { get; set; }
        /// <summary>
        /// 获取或设置受款人或单位
        /// </summary>
        public string Payee { get; set; }
        /// <summary>
        /// 获取或设置支票号
        /// </summary>
        public string CheckNum { get; set; }
        /// <summary>
        /// 获取或设置当前状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置支付备注
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region ISheet 接口
        public bool CanDo(SheetOperation operation)
        {
            switch (operation)
            {
                case SheetOperation.Modify:
                    return State == SheetState.Add;
                case SheetOperation.Approve:
                    return State == SheetState.Add;
                case SheetOperation.UndoApprove:
                    return State == SheetState.Approved;
                case SheetOperation.Nullify:
                    return State != SheetState.Canceled;
                default:
                    return false;
            }
        }

        public string DocumentType
        {
            get
            {
                return "ExpenditureRecord";
            }
        }

        public ISheet<string> Clone()
        {
            return this.MemberwiseClone() as Order;
        }
        #endregion
    }
}
