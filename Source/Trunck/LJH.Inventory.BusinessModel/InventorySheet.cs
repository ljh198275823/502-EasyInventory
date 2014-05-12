using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示收货单
    /// </summary>
    public class InventorySheet : ISheet<string>
    {
        #region 构造函数
        public InventorySheet()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置收货单号
        /// </summary>
        public string ID { get; set; }
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
        /// 获取或设置所有收货单项
        /// </summary>
        public List<InventoryItem> Items { get; set; }
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
                    return State == SheetState.Add;
                case SheetOperation.Approve:
                    return State == SheetState.Add;
                case SheetOperation.UndoApprove:
                    return State == SheetState.Approved;
                case SheetOperation.Nullify:
                    return State != SheetState.Canceled && State != SheetState.Inventory;
                case SheetOperation.Inventory:
                    return (State == SheetState.Add || State == SheetState.Approved);
                default:
                    return false;
            }
        }
        /// <summary>
        /// 获取单据类型
        /// </summary>
        public string DocumentType
        {
            get { return "InventorySheet"; }
        }

        public ISheet<string> Clone()
        {
            return MemberwiseClone() as ISheet<string>;
        }
        #endregion
    }
}
