using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class Frm成本明细 : FrmMasterBase
    {
        public Frm成本明细()
        {
            InitializeComponent();
        }

        public ProductInventoryItem ProductInventoryItem { get; set; }

        #region 重写基类方法
        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            if (ProductInventoryItem.Model == ProductModel.原材料)
            {
                btn设置入库单价.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.设置成本);
                btn设置其它成本.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.设置成本);
            }
            else if (ProductInventoryItem.Model == ProductModel.其它产品)
            {
                btn设置入库单价.Enabled = Operator.Current.Permit(Permission.其它产品, PermissionActions.设置成本);
                btn设置其它成本.Enabled = Operator.Current.Permit(Permission.其它产品, PermissionActions.设置成本);
            }
            else
            {
                btn设置入库单价.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.设置成本);
                btn设置其它成本.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.设置成本);
            }
        }

        protected override List<object> GetDataSource()
        {
            var records = ProductInventoryItem.GetAllCosts();
            if (records != null && records.Count > 0)
            {
                return (from item in records
                        where item.Price > 0
                        where item.Name != "结算成本"
                        orderby item.Price descending
                        select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CostItem record = item as CostItem;
            row.Tag = record;
            row.Cells["colName"].Value = record.Name;
            row.Cells["colPrice"].Value = record.Price;
            row.Cells["colWithTax"].Value = record.WithTax;
        }
        #endregion

        private void btn设置入库单价_Click(object sender, EventArgs e)
        {
            Frm设置单价 frm = new Frm设置单价();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var pi = ProductInventoryItem;
                var ci = new CostItem() { Name = CostItem.入库单价, Price = frm.入库单价, WithTax = frm.WithTax, SupllierID = string.IsNullOrEmpty(frm.SupplierID) ? pi.Supplier : frm.SupplierID };
                var ret = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).设置成本(pi, ci, Operator.Current.Name, Operator.Current.ID, frm.Memo);
                if (ret.Result == ResultCode.Successful)
                {
                    ReFreshData();
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void btn设置其它成本_Click(object sender, EventArgs e)
        {
            FrmChangeCosts frm = new FrmChangeCosts();
            frm.chk总金额.Enabled = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ci = frm.Cost;
                decimal? 总额 = null;
                var pi = ProductInventoryItem;

                if (frm.chk总金额.Checked && pi.CostID.HasValue)
                {
                    总额 = ci.Price;
                    var f = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetByID(pi.CostID.Value).QueryObject;
                    if (pi.OriginalWeight > 0) ci.Price = Math.Round(ci.Price / pi.OriginalWeight.Value, 2); //如果是总额，则换算成吨价
                }
                var ret = new SteelRollBLL(AppSettings.Current.ConnStr).设置成本(pi, ci, Operator.Current.Name, Operator.Current.ID, frm.Memo, 总额, frm.CarPlate);
                if (ret.Result == ResultCode.Successful)
                {
                    ReFreshData();
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }
    }
}
