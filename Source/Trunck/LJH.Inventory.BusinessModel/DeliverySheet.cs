using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示送货单
    /// </summary>
    public class DeliverySheet : ISheet<string>
    {
        #region 构造函数
        public DeliverySheet()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置送货单据编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置单据创建日期
        /// </summary>
        public DateTime LastActiveDate { get; set; }
        /// <summary>
        /// 获取或设置客户ID
        /// </summary>
        public string CustomerID { get; set; }
        /// <summary>
        /// 获取或设置出库仓库ID
        /// </summary>
        public string WareHouseID { get; set; }
        /// <summary>
        /// 获取或设置联系人
        /// </summary>
        public string Linker { get; set; }
        /// <summary>
        /// 获取或设置联系人手机号
        /// </summary>
        public string LinkerPhoneCall { get; set; }
        /// <summary>
        /// 获取或设置送货地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 获取或设置送货人
        /// </summary>
        public string Driver { get; set; }
        /// <summary>
        /// 获取或设置送货人电话
        /// </summary>
        public string DriverMobile { get; set; }
        /// <summary>
        /// 获取或设置送货车牌号
        /// </summary>
        public string CarPlate { get; set; }
        /// <summary>
        /// 获取或设置是否含税
        /// </summary>
        public bool IsWithTax { get; set; }
        /// <summary>
        /// 获取或设置送货单的折扣额
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// 获取或设置销售人员
        /// </summary>
        public string SalesPerson { get; set; }
        /// <summary>
        /// 获取或设置送货单的状态
        /// </summary>
        public SheetState State { get; set; }
        /// <summary>
        /// 获取或设置备注描述
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// 获取或设置出货商品项(如果要在列表中增删改项，请不要直接在此对象中操作，而是调用DeliverySheet类的方法)
        /// </summary>
        public List<DeliveryItem> Items { get; set; }
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
                    return State != SheetState.Canceled && State != SheetState.Shipped;
                case SheetOperation.Ship:
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
            get { return "DeliverySheet"; }
        }

        public ISheet<string> Clone()
        {
            return MemberwiseClone() as ISheet<string>;
        }
        #endregion
    }
}