using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 表示出库单
    /// </summary>
    public class StackOutSheet : ISheet<string>
    {
        #region 工厂方法
        public static StackOutSheet Create(CompanyInfo customer, WareHouse wareHouse)
        {
            return new StackOutSheet()
            {
                ClassID = StackOutSheetType.DeliverySheet,
                SheetDate = DateTime.Now,
                LastActiveDate = DateTime.Now,
                CustomerID = customer != null ? customer.ID : null,
                WareHouseID = wareHouse != null ? wareHouse.ID : null,
                State = SheetState.Add,
                Items = new List<StackOutItem>()
            };
        }
        #endregion

        #region 构造函数
        public StackOutSheet()
        {
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置出库单编号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置出库单类型
        /// </summary>
        public StackOutSheetType ClassID { get; set; }
        /// <summary>
        /// 获取或设置单据日期
        /// </summary>
        public DateTime SheetDate { get; set; }
        /// <summary>
        /// 获取或设置单据最后一次操作时间
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
        public string LinkerCall { get; set; }
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
        public string DriverCall { get; set; }
        /// <summary>
        /// 获取或设置送货车牌号
        /// </summary>
        public string CarPlate { get; set; }
        /// <summary>
        /// 获取或设置是否含税
        /// </summary>
        public bool WithTax { get; set; }
        /// <summary>
        /// 获取或设置送货单的折扣额
        /// </summary>
        public decimal Discount { get; set; }
        /// <summary>
        /// 获取或设置送货单最迟付款期限
        /// </summary>
        public DateTime? DeadlineDate { get; set; }
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
        public List<StackOutItem> Items { get; set; }
        #endregion

        #region 只读属性
        /// <summary>
        /// 获取送货单的总货款
        /// </summary>
        public decimal Amount
        {
            get
            {
                var items = GetSummaryItems();
                if (items == null || items.Count == 0) return 0;
                return items.Sum(item => item.Amount);
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
                    return State != SheetState.Canceled;
                case SheetOperation.StackOut:
                    return (State == SheetState.Add || State == SheetState.Approved);
                case SheetOperation.StackIn:
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
            get
            {
                switch (ClassID)
                {
                    case StackOutSheetType.DeliverySheet:
                        return "送货单";
                    case StackOutSheetType.CustomerBorrow:
                        return "客户借用单";
                    case StackOutSheetType.Production:
                        return "生产领用单";
                    default:
                        throw new Exception("出库单的类型没有指定");
                }
            }
        }

        public ISheet<string> Clone()
        {
            return MemberwiseClone() as ISheet<string>;
        }
        #endregion

        #region 公共方法
        public void AddItems(ProductInventoryItem inventory, decimal count)
        {
            if (count <= 0) return;
            if (Items == null) Items = new List<StackOutItem>();
            var si = Items.SingleOrDefault(it => it.InventoryItem == inventory.ID);
            if (si != null)
            {
                si.Count += count;
            }
            else
            {
                si = new StackOutItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = inventory.ProductID,
                    Unit = inventory.Unit,
                    InventoryItem = inventory.ID,
                    Length = inventory.Length,
                    SheetNo = this.ID,
                    Price = 0,
                    Count = count,
                    AddDate = DateTime.Now,
                    Memo = inventory.Carplate
                };
                if (inventory.Weight.HasValue && inventory.Model != "开平")
                {
                    if (si.TotalWeight == null) si.TotalWeight = 0;
                    si.TotalWeight += (inventory.Product != null ? inventory.Product.Weight : inventory.Weight) * count;
                }
                Items.Add(si);
            }
        }
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        public List<StackOutItem> GetSummaryItems()
        {
            if (Items == null) return null;
            List<StackOutItem> ret = new List<StackOutItem>();

            var groups = from it in Items
                         orderby it.AddDate ascending
                         group it by it.ProductID;
            foreach (var g in groups)
            {
                var si = new StackOutItem()
                {
                    ID = Guid.Empty,
                    ProductID = g.First().ProductID,
                    Length = g.First().Length,
                    TotalWeight = g.First().TotalWeight,
                    Unit = g.First().Unit,
                    Count = g.Sum(it => it.Count),
                    SheetNo = this.ID,
                    Price = g.First().Price,
                    InventoryItem = g.First().InventoryItem,
                    AddDate = g.First().AddDate,
                    Memo = g.First().Memo
                };
                ret.Add(si);
            }
            return ret;
        }
        #endregion
    }

    public class StackOutSheetFinancialState
    {
        public string ID { get; set; }
        /// <summary>
        /// 获取或设置已收款金额
        /// </summary>
        public decimal Paid { get; set; }

        public decimal NotPaid { get; set; }

        public string FirstPaymentMode { get; set; }
    }
}