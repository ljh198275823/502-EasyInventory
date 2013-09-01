using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 操作员的权限枚举
    /// </summary>
    public enum Permission
    {
        #region 数据管理
        /// <summary>
        /// 查看系统选项
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看系统选项")]
        ReadSystemOptions = 1,
        /// <summary>
        /// 编辑系统选项
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "编辑系统选项")]
        EditSystemOptions = 2,
        /// <summary>
        /// 查看商品类别
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看商品类别")]
        ReadProductCategory = 3,
        /// <summary>
        /// 编辑商品类别
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "编辑商品类别")]
        EditProductCategory = 4,
        /// <summary>
        /// 查看商品
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看商品")]
        ReadProduct = 5,
        /// <summary>
        /// 编辑商品
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "编辑商品")]
        EditProduct = 6,
        /// <summary>
        /// 编辑系统选项
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看仓库信息")]
        ReadWareHouse = 7,
        /// <summary>
        /// 查看价格
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "编辑仓库信息")]
        EditWareHouse = 8,
        /// <summary>
        /// 新建商品库存
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "新建商品库存")]
        CreateInventory = 9,
        /// <summary>
        /// 库存盘点
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "库存盘点")]
        InventoryCheck = 10,
        /// <summary>
        /// 查看客户资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看客户资料")]
        ReadCustomer = 11,
        /// <summary>
        /// 编辑客户资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "编辑客户资料")]
        EditCustomer = 12,
        /// <summary>
        /// 查看订单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看订单")]
        ReadOrder = 13,
        /// <summary>
        /// 编辑订单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "编辑订单")]
        EditOrder = 14,
        /// <summary>
        /// 打印订单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "打印订单")]
        PrintOrder = 15,
        /// <summary>
        /// 审核订单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "审核订单")]
        ApproveOrder = 16,
        /// <summary>
        /// 取消订单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "取消订单")]
        CancelOrder = 17,
        /// <summary>
        /// 查看送货单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看送货单")]
        ReadDeliverySheet = 18,
        /// <summary>
        /// 编辑送货单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "编辑送货单")]
        EditDeliverySheet = 19,
        /// <summary>
        /// 查看价格
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "打印送货单")]
        PrintDeliverySheet = 20,
        /// <summary>
        /// 审批送货单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "审核送货单")]
        ApproveDeliverySheet = 21,
        /// <summary>
        /// 出货
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "出货")]
        Shipping = 22,
        /// <summary>
        /// 取消送货单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "取消送货单")]
        CancelDeliverySheet = 23,
        /// <summary>
        /// 查看供应商资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看供应商资料")]
        ReadSupplier = 24,
        /// <summary>
        /// 编辑供应商资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "编辑供应商资料")]
        EditSupplier = 25,
        /// <summary>
        /// 查看收货单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看收货单")]
        ReadInventorySheet = 26,
        /// <summary>
        /// 编辑订单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "编辑收货单")]
        EditInventorySheet = 27,
        /// <summary>
        /// 打印收货单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "打印收货单")]
        PrintInventorySheet = 28,
        /// <summary>
        /// 审核收货单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "审核收货单")]
        ApproveInventorySheet = 29,
        /// <summary>
        /// 收货
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "收货")]
        Inventory = 30,
        /// <summary>
        /// 取消收货单
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "取消收货单")]
        CancelInventorySheet = 31,
        /// <summary>
        /// 查看客户还款资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看客户还款资料")]
        ReadCustomerPayment = 32,
        /// <summary>
        /// 编辑客户还款资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "编辑客户还款资料")]
        EditCustomerPayment = 33,
        /// <summary>
        /// 查看资金支出资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看资金支出资料")]
        ReadExpenditureRecord = 34,
        /// <summary>
        /// 编辑资金支出资料
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "编辑资金支出资料")]
        EditExpenditureRecord = 35,
        /// <summary>
        /// 查看价格
        /// </summary>
        [OperatorRight(Catalog = "数据管理", Description = "查看价格")]
        ReadPrice = 36,
        #endregion

        #region 安全
        /// <summary>
        /// 查看操作员信息
        /// </summary>
        [OperatorRight(Catalog = "安全", Description = "查看操作员信息")]
        ReadOperaotor = 50,
        /// <summary>
        /// 编辑操作员信息
        /// </summary>
        [OperatorRight(Catalog = "安全", Description = "编辑操作员信息")]
        EditOperator = 51,
        /// <summary>
        /// 查看角色信息
        /// </summary>
        [OperatorRight(Catalog = "安全", Description = "查看角色信息")]
        ReadRole = 52,
        /// <summary>
        /// 编辑角色信息
        /// </summary>
        [OperatorRight(Catalog = "安全", Description = "编辑角色信息")]
        EditRole = 53,

        #endregion

        #region 查询与报表
        /// <summary>
        /// 出货记录查询
        /// </summary>
        [OperatorRight(Catalog = "查询与报表", Description = "出货记录查询")]
        DeliveryRecordReport = 60,
        /// <summary>
        /// 商品出货统计
        /// </summary>
        [OperatorRight(Catalog = "查询与报表", Description = "商品出货统计")]
        DeliveryStatistics = 61,
        /// <summary>
        /// 原材料收货查询
        /// </summary>
        [OperatorRight(Catalog = "查询与报表", Description = "业务员业绩统计")]
        PerformanceStatistics = 62,
        /// <summary>
        /// 原材料库存统计
        /// </summary>
        [OperatorRight(Catalog = "查询与报表", Description = "原材料库存统计")]
        _InventoryRecordReport = 63,
        #endregion
    }

    public class OperatorRightAttribute : Attribute
    {
        /// <summary>
        /// 权限的类别
        /// </summary>
        public string Catalog { get; set; }
        /// <summary>
        /// 权限的备注
        /// </summary>
        public string Description { get; set; }

        public OperatorRightAttribute()
        {
        }
    }
}
