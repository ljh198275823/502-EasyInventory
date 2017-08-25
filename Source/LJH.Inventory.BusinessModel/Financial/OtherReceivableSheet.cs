using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    public class OtherReceivableSheet : ISheet<string>
    {
        #region 构造函数
        public OtherReceivableSheet()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置付款记录ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置单据类型
        /// </summary>
        public CustomerReceivableType ClassID { get; set; }
        /// <summary>
        /// 获取或设置单据日期
        /// </summary>
        public DateTime SheetDate { get; set; }
        /// <summary>
        /// 获取或设置最近活动日期
        /// </summary>
        public DateTime LastActiveDate { get; set; }
        /// <summary>
        /// 获取或设置付款客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置付款金额
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 获取或设置付款流水的收发货单据号
        /// </summary>
        public string StackinSheetID { get; set; }
        /// <summary>
        /// 获取或设置当前状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置备注信息
        /// </summary>
        public string Memo { get; set; }
        #endregion

        #region ISheet接口
        public bool CanDo(SheetOperation operation)
        {
            switch (operation)
            {
                case SheetOperation.Modify:
                    return State == SheetState.新增;
                case SheetOperation.Approve:
                    return State == SheetState.新增;
                case SheetOperation.UndoApprove:
                    return State == SheetState.已审批;
                case SheetOperation.Nullify:
                    return State != SheetState.作废;
                default:
                    return false;
            }
        }
        /// <summary>
        /// 获取单据类型
        /// </summary>
        public string DocumentType
        {
            get
            {
                switch (ClassID)
                {
                    case CustomerReceivableType.CustomerReceivable:
                        return "客户应收款";
                    case CustomerReceivableType.SupplierReceivable:
                        return "供应商应付款";
                    case CustomerReceivableType.CustomerTax:
                        return "客户应开增值税";
                    case CustomerReceivableType.SupplierTax:
                        return "供应商应开增值税";
                    default:
                        throw new Exception("客户应收款单没有指定类型");
                }
            }
        }

        public ISheet<string> Clone()
        {
            return MemberwiseClone() as OtherReceivableSheet;
        }
        #endregion
    }
}
