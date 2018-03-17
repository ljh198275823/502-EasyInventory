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
using LJH.Inventory.UI.Forms.Inventory;

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
            con.ReceivableTypes.Add(ReceivableType);
            if (!chkSheetDate.Checked) con.Settled = false;
            else con.CreateDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            var items = (new CustomerReceivableBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            items = (from item in items orderby item.CreateDate ascending, item.SheetID ascending select item).ToList();
            ShowItemsOnGrid(items);
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, CustomerReceivable cr)
        {
            row.Tag = cr;
            row.Cells["colSheetID"].Value = cr.SheetID;
            var gg = cr.GetProperty("规格");
            if (!string.IsNullOrEmpty(gg)) row.Cells["colSheetID"].Value = gg;
            row.Cells["colOrderID"].Value = cr.OrderID;
            row.Cells["colCreateDate"].Value = cr.CreateDate.ToString("yyyy-MM-dd");
            row.Cells["colAmount"].Value = cr.Amount.Trim();
            if (cr.Haspaid != 0) row.Cells["colHaspaid"].Value = cr.Haspaid.Trim();
            if (cr.Remain != 0)
            {
                row.Cells["colNotpaid"].Value = cr.Remain.Trim();
            }
            row.Cells["col购货单位"].Value = cr.GetProperty("购货单位");
            row.Cells["colMemo"].Value = cr.Memo;
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

        private void ShowOperatorRights()
        {
            if (ReceivableType == CustomerReceivableType.CustomerTax)
            {
                mnu_Add.Enabled = Operator.Current.Permit(Permission.CustomerTax, PermissionActions.Edit);
            }
            else if (ReceivableType == CustomerReceivableType.SupplierTax)
            {
                mnu_Add.Enabled = Operator.Current.Permit(Permission.SupplierTax, PermissionActions.Edit);
            }
            else
            {
                mnu_Add.Enabled = false;
            }
        }
        #endregion

        #region 事件处理程序
        private void FrmCustomerTaxView_Load(object sender, EventArgs e)
        {
            ShowOperatorRights();
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            FreshData();
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_AddTax_Click(object sender, EventArgs e)
        {
            CompanyInfo customer = Customer;
            Frm其它应收明细 frm = new Frm其它应收明细();
            frm.IsAdding = true;
            frm.Customer = customer;
            frm.ReceivableType = ReceivableType;
            FreshData();
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
                CustomerReceivable cr = GridView.Rows[e.RowIndex].Tag as CustomerReceivable;
                if (cr == null) return;
                if (GridView.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    if (ReceivableType == CustomerReceivableType.CustomerTax)
                    {
                        var sheet = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetByID(cr.SheetID).QueryObject;
                        if (sheet != null)
                        {
                            Inventory.FrmStackOutSheetDetail frm = new Inventory.FrmStackOutSheetDetail();
                            frm.IsAdding = false;
                            frm.IsForView = true;
                            frm.UpdatingItem = sheet;
                            frm.ShowDialog();
                        }
                        else
                        {
                            var osheet = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr).GetByID(cr.SheetID).QueryObject;
                            if (osheet != null)
                            {
                                Frm其它应收明细 frm = new Frm其它应收明细();
                                frm.UpdatingItem = osheet;
                                frm.ReceivableType = osheet.ClassID;
                                frm.ShowDialog();
                                FreshData();
                            }
                        }
                    }
                    else if (ReceivableType == CustomerReceivableType.SupplierTax)
                    {
                        Guid gid;
                        if (Guid.TryParse(cr.SheetID, out gid))
                        {
                            var pi = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetByID(gid).QueryObject;
                            if (pi != null)
                            {
                                if (pi.Product.Model == ProductModel.原材料)
                                {
                                    FrmSteelRollDetail frm = new FrmSteelRollDetail();
                                    frm.UpdatingItem = pi;
                                    frm.IsForView = true;
                                    frm.ShowDialog();
                                }
                                else if (pi.Product.Model == ProductModel.其它产品)
                                {
                                    Frm其它产品入库 frm = new Frm其它产品入库();
                                    frm.SteelRollSlice = pi;
                                    frm.IsForView = true;
                                    frm.ShowDialog();
                                }
                                else
                                {
                                    FrmSteelRollSliceStackIn frm = new FrmSteelRollSliceStackIn();
                                    frm.SteelRollSlice = pi;
                                    frm.IsForView = true;
                                    frm.ShowDialog();
                                }
                            }
                        }
                        else
                        {
                            var osheet = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr).GetByID(cr.SheetID).QueryObject;
                            if (osheet != null)
                            {
                                Frm其它应收明细 frm = new Frm其它应收明细();
                                frm.ReceivableType = osheet.ClassID;
                                frm.UpdatingItem = osheet;
                                frm.ShowDialog();
                                FreshData();
                            }
                        }
                    }
                }
                else if (GridView.Columns[e.ColumnIndex].Name == "colHaspaid")
                {
                    FrmReceivablePaymentAssigns frm = new FrmReceivablePaymentAssigns();
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowAssigns(cr);
                    frm.ShowDialog();
                    FreshData();
                }
            }
        }

        private void chkSheetDate_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void btnLast3Month_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            ucDateTimeInterval1.StartDateTime = today.AddMonths(-3);
            ucDateTimeInterval1.EndDateTime = today.AddDays(1).AddSeconds(-1);
        }

        private void ucDateTimeInterval1_ValueChanged(object sender, EventArgs e)
        {
            if (chkSheetDate.Checked) FreshData();
        }
        #endregion
    }
}
