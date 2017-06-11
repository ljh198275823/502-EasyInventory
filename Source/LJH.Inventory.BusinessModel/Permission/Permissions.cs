using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace LJH.Inventory.BusinessModel
{
    /// <summary>
    /// 操作员的权限枚举
    /// </summary>
    public enum Permission
    {
        #region 基本资料
        /// <summary>
        /// 查看系统选项
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "系统选项")]
        SystemOptions = 1,
        /// <summary>
        /// 客户资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.导出, Description = "客户资料")]
        Customer,
        /// <summary>
        /// 供应商资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.导出, Description = "供应商资料")]
        Supplier,
        /// <summary>
        /// 厂家资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "厂家资料")]
        Manufacturer,
        /// <summary>
        /// 产品类别
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "产品类别")]
        ProductCategory,
        /// <summary>
        /// 部门资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "部门资料")]
        Department,
        /// <summary>
        /// 人员资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "人员资料")]
        Staff,
        /// <summary>
        /// 操作员资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "操作员资料")]
        Operator,
        /// <summary>
        /// 查看角色资料
        /// </summary>
        [OperatorRight(Catalog = "基本资料", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "角色资料")]
        Role,
        #endregion

        #region 仓库
        /// <summary>
        /// 原材料
        /// </summary>
        [OperatorRight(Catalog = "仓库", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Inventory | PermissionActions .导出  | PermissionActions.Check | PermissionActions.Slice | PermissionActions.Nullify | PermissionActions.ShowPrice | PermissionActions.设置结算单价, Description = "原材料")]
        SteelRoll = 101,
        /// <summary>
        /// 小件
        /// </summary>
        [OperatorRight(Catalog = "仓库", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Inventory | PermissionActions.导出 | PermissionActions.Check | PermissionActions.Nullify | PermissionActions.ShowPrice | PermissionActions.设置结算单价, Description = "小件")]
        SteelRollSlice,
        /// <summary>
        /// 仓库资料
        /// </summary>
        [OperatorRight(Catalog = "仓库", Actions = PermissionActions.Read | PermissionActions.Edit, Description = "仓库资料")]
        WareHouse,
        /// <summary>
        /// 送货单资料
        /// </summary>
        [OperatorRight(Catalog = "仓库", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.导出 | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify | PermissionActions.Ship | PermissionActions.Print | PermissionActions.查看成本, Description = "送货单资料")]
        DeliverySheet,

        /// <summary>
        /// 其它产品
        /// </summary>
        [OperatorRight(Catalog = "仓库", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Inventory | PermissionActions.导出 | PermissionActions.Check | PermissionActions.Slice | PermissionActions.Nullify | PermissionActions.ShowPrice | PermissionActions.设置结算单价, Description = "其它产品")]
        其它产品,
        #endregion

        #region 财务
        /// <summary>
        /// 客户应收管理
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.导出 , Description = "客户财务管理")]
        CustomerState = 201,
        /// <summary>
        /// 客户收款流水
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "客户收款流水")]
        CustomerPayment,
        /// <summary>
        /// 客户应收款
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "客户应收款")]
        CustomerReceivable,
        /// <summary>
        /// 客户增值税发票
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "客户增值税发票")]
        CustomerTaxBill,
        /// <summary>
        /// 客户应开发票
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.导出 | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "客户应开发票")]
        CustomerTax,
        /// <summary>
        /// 供应商应付管理
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.导出, Description = "供应商财务管理")]
        SupplierState,
        /// <summary>
        /// 供应商付款流水
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "供应商付款流水")]
        SupplierPayment,
        /// <summary>
        /// 客户其它应收款
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "供应商应付款")]
        SupplierReceivable,
        /// <summary>
        /// 供应商增值税发票
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "供应商增值税发票")]
        SupplierTaxBill,
        /// <summary>
        /// 供应商应开发票
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "供应商应开发票")]
        SupplierTax,
        /// <summary>
        /// 公司管理费用
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "公司管理费用")]
        ExpenditureRecord,
        /// <summary>
        /// 账号管理
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.导出, Description = "账号管理")]
        Account,
        /// <summary>
        /// 其它收款
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "其它收款")]
        其它收款,
        /// <summary>
        /// 其它收款
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "转账")]
        转账,
        /// <summary>
        ///退款
        /// </summary>
        [OperatorRight(Catalog = "财务", Actions = PermissionActions.Read | PermissionActions.Edit | PermissionActions.Approve | PermissionActions.UndoApprove | PermissionActions.Nullify, Description = "退款")]
        退款,
        #endregion

        #region 查询与报表
        /// <summary>
        /// 出货记录报表
        /// </summary>
        [OperatorRight(Catalog = "报表", Actions = PermissionActions.Read | PermissionActions.导出, Description = "出货记录报表")]
        DeliveryRecordReport = 501,
        /// <summary>
        /// 出货统计报表
        /// </summary>
        [OperatorRight(Catalog = "报表", Actions = PermissionActions.Read | PermissionActions.导出, Description = "出货利润统计报表")]
        DeliveryStatistics,
        /// <summary>
        /// 入库记录报表
        /// </summary>
        [OperatorRight(Catalog = "报表", Actions = PermissionActions.Read | PermissionActions.导出, Description = "入库记录报表")]
        InventoryRecordReport,
        /// <summary>
        /// 原材料加工记录报表
        /// </summary>
        [OperatorRight(Catalog = "报表", Actions = PermissionActions.Read | PermissionActions.导出, Description = "原材料加工记录报表")]
        SliceRecordReport,
        /// <summary>
        /// 收付款流水报表
        /// </summary>
        [OperatorRight(Catalog = "报表", Actions = PermissionActions.Read | PermissionActions.导出, Description = "收付款流水报表")]
        PaymentReport,
        /// <summary>
        /// 增值税发票报表
        /// </summary>
        [OperatorRight(Catalog = "报表", Actions = PermissionActions.Read | PermissionActions.导出, Description = "增值税发票报表")]
        TaxBillReport,
        /// <summary>
        /// 客户往来报表
        /// </summary>
        [OperatorRight(Catalog = "报表", Actions = PermissionActions.Read | PermissionActions.导出, Description = "客户往来报表")]
        客户往来报表,
        /// <summary>
        /// 供应商往来报表
        /// </summary>
        [OperatorRight(Catalog = "报表", Actions = PermissionActions.Read | PermissionActions.导出, Description = "供应商往来报表")]
        供应商往来报表,
        /// <summary>
        /// 原材料盘点报表
        /// </summary>
        [OperatorRight(Catalog = "报表", Actions = PermissionActions.Read | PermissionActions.导出, Description = "原材料盘点报表")]
        原材料盘点报表,
        /// <summary>
        /// 小件盘点报表
        /// </summary>
        [OperatorRight(Catalog = "报表", Actions = PermissionActions.Read | PermissionActions.导出, Description = "小件盘点报表")]
        小件盘点报表,
        #endregion
    }
}
