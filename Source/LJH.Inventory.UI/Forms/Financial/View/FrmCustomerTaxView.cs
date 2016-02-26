using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BusinessModel.Resource;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial.View
{
    public partial class FrmCustomerTaxView : Form
    {
        public FrmCustomerTaxView()
        {
            InitializeComponent();
        }

        #region 公共属性
        public CompanyInfo Customer { get; set; }

        public CustomerReceivableType ReceivableType { get; set; }
        #endregion

        #region 私有方法
        private void FreshData()
        {
            var con = new CustomerReceivableSearchCondition();
            con.CustomerID = Customer != null ? Customer.ID : null;
            con.ReceivableTypes = new List<CustomerReceivableType>();
            con.ReceivableTypes.Add(CustomerReceivableType.CustomerTax);
            con.Settled = false;
            if (!chkShowAll.Checked)
            {
                con.States = new List<SheetState>();
                con.States.Add(SheetState.Add);
                con.Settled = false;
            }
            else
            {
                con.States = null;
                con.Settled = null;
            }
            var items = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            items = (from item in items orderby item.CreateDate ascending, item.SheetID ascending select item).ToList();
            ShowItemsOnGrid(items);
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, CustomerReceivable cr)
        {
            row.Tag = cr;
            row.Cells["colSheetID"].Value = cr.SheetID;
            row.Cells["colCreateDate"].Value = cr.CreateDate.ToString("yyyy-MM-dd");
            row.Cells["colAmount"].Value = cr.Amount.Trim();
            if (cr.Haspaid != 0) row.Cells["colHaspaid"].Value = cr.Haspaid.Trim();
            if (cr.Remain != 0)
            {
                row.Cells["colNotpaid"].Value = cr.Remain.Trim();
            }
            row.Cells["colMemo"].Value = cr.Memo;
            if (cr.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }

        private void ShowItemsOnGrid(List<CustomerReceivable> items)
        {
            GridView.Rows.Clear();
            if (items != null && items.Count > 0)
            {
                foreach (var cr in items)
                {
                    int row = GridView.Rows.Add();
                    ShowItemInGridViewRow(GridView.Rows[row], cr);
                }
                int rowTotal = GridView.Rows.Add();
                GridView.Rows[rowTotal].Cells["colCreateDate"].Value = "合计";
                GridView.Rows[rowTotal].Cells["colAmount"].Value = items.Sum(item => (item as CustomerReceivable).Amount).Trim();
                GridView.Rows[rowTotal].Cells["colHaspaid"].Value = items.Sum(item => (item as CustomerReceivable).Haspaid).Trim();
                GridView.Rows[rowTotal].Cells["colNotpaid"].Value = items.Sum(item => (item as CustomerReceivable).Remain).Trim();
            }
            lblMSG.Text = string.Format("共 {0} 项", items != null ? items.Count : 0);
        }
        #endregion

        #region 事件处理程序
        private void FrmCustomerTaxView_Load(object sender, EventArgs e)
        {
            FreshData();
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_AddTax_Click(object sender, EventArgs e)
        {
            CompanyInfo customer = Customer;
            FrmCustomerReceivableAdd frm = new FrmCustomerReceivableAdd();
            frm.Customer = customer;
            frm.ReceivableType = ReceivableType;
            if (frm.ShowDialog() == DialogResult.OK) FreshData();
        }

        private void cMnu_Export_Click(object sender, EventArgs e)
        {
            NPOIExcelHelper.Export(GridView);
        }

        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var cell = GridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value == null) return;
                if (GridView.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    var sheet = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetByID(cell.Value.ToString()).QueryObject;
                    if (sheet != null)
                    {
                        Inventory.FrmStackOutSheetDetail frm = new Inventory.FrmStackOutSheetDetail();
                        frm.IsAdding = false;
                        frm.IsForView = true;
                        frm.UpdatingItem = sheet;
                        frm.ShowDialog();
                    }
                }
            }
        }
        #endregion
    }
}
