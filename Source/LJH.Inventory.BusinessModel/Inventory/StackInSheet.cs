using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示入库单
    /// </summary>
    public class StackInSheet : ISheet<string>
    {
        #region 构造函数
        public StackInSheet()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置入库单单号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置入库单类型
        /// </summary>
        public StackInSheetType ClassID { get; set; }
        /// <summary>
        /// 获取或设置单据日期
        /// </summary>
        public DateTime SheetDate { get; set; }
        /// <summary>
        /// 获取或设置单据创建日期
        /// </summary>
        public DateTime LastActiveDate { get; set; }
        /// <summary>
        /// 获取或设置仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 获取或设置供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 获取或设置是否含税
        /// </summary>
        public bool WithTax { get; set; }
        /// <summary>
        /// 获取或设置送货单的折扣额
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// 获取或设置采购人员
        /// </summary>
        public string Buyer { get; set; }
        /// <summary>
        /// 获取或设置送货单状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置收货单的备注
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 获取或设置所有入库单项
        /// </summary>
        public List<StackInItem> Items { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 获取送货单的总货款
        /// </summary>
        public decimal Amount
        {
            get
            {
                return Items.Sum(item => item.Amount);
            }
        }
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
                    return State != SheetState.作废 && State != SheetState.已入库;
                case SheetOperation.StackIn:
                    return (State == SheetState.新增 || State == SheetState.已审批);
                case SheetOperation.StackOut :
                    return (State == SheetState.新增 || State == SheetState.已审批);
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
                    case StackInSheetType.InventorySheet:
                        return "采购入库单";
                    default:
                        throw new Exception("入库单的类型没有指定");
                }

            }
        }

        public ISheet<string> Clone()
        {
            return MemberwiseClone() as ISheet<string>;
        }
        #endregion
    }
}
