using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示收货单
    /// </summary>
    public class InventorySheet : LJH.GeneralLibrary.Core.DAL.IEntity<string>
    {
        #region 构造函数
        public InventorySheet()
        {
        }
        #endregion

        #region 只读变量
        public readonly string DocumentType = "InventorySheet";
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置收货单号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置单据创建日期
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 获取或设置仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 获取或设置供应商ID
        /// </summary>
        public string SupplierID { get; set; }
        /// <summary>
        /// 获取或设置送货单状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置入库日期
        /// </summary>
        public DateTime? InventoryDate { get; set; }
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
        /// <summary>
        /// 获取收货单是否可以收货
        /// </summary>
        public bool CanInventory
        {
            get { return State == SheetState.Add || State == SheetState.Approved; }
        }

        /// <summary>
        /// 获取送货单是否可以审批
        /// </summary>
        public bool CanApprove
        {
            get
            {
                return (State == SheetState.Add);
            }
        }
        /// <summary>
        /// 获取是否可以将送货单作废
        /// </summary>
        public bool CanCancel
        {
            get
            {
                return State != SheetState.Canceled;
            }
        }
        #endregion

        #region 公共方法
        public InventorySheet Clone()
        {
            return MemberwiseClone() as InventorySheet;
        }
        #endregion

    }
}
