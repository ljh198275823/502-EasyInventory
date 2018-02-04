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
            btn设置结算单价.Enabled = Operator.Current.Permit(Permission.结算单价, PermissionActions.Edit);
            btn设置其它成本.Enabled = Operator.Current.Permit(Permission.其它成本, PermissionActions.Edit);
        }

        protected override List<object> GetDataSource()
        {
            var records = ProductInventoryItem.GetAllCosts();
            if (records != null && records.Count > 0)
            {
                return (from item in records
                        where item.Price > 0
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
            if (record.Name == CostItem.结算单价 && !Operator.Current.Permit(Permission.结算单价, PermissionActions.Read)) row.Visible = false;
            else if (!Operator.Current.Permit(Permission.其它成本, PermissionActions.Read)) row.Visible = false;
        }
        #endregion

        private void btn设置入库单价_Click(object sender, EventArgs e)
        {
            Frm设置结算单价 frm = new Frm设置结算单价();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var pi = ProductInventoryItem;
                var ci = new CostItem() { Name = CostItem.结算单价, Price = frm.单价, WithTax = frm.WithTax, SupllierID = string.IsNullOrEmpty(frm.SupplierID) ? pi.Supplier : frm.SupplierID };
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
            Frm设置其它成本 frm = new Frm设置其它成本();
            frm.chk总金额.Enabled = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ci = frm.Cost;
                decimal? 总额 = null;
                var pi = ProductInventoryItem;

                if (frm.chk总金额.Checked) 总额 = ci.Price;
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
