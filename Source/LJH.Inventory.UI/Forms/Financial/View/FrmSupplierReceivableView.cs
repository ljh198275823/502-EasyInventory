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
    public partial class FrmSupplierReceivableView : Form
    {
        public FrmSupplierReceivableView()
        {
            InitializeComponent();
        }

        #region 私有方法
        private int DaysBetween(DateTime endDt, DateTime beginDt)
        {
            TimeSpan ts1 = new TimeSpan(endDt.Date.Ticks - beginDt.Date.Ticks);
            return (int)ts1.TotalDays;
        }
        #endregion

        #region 公共属性
        public CompanyInfo Customer { get; set; }

        public CustomerReceivableType ReceivableType { get; set; }
        #endregion

        #region 重写基类方法
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
            FilterRow(txtKeyword.Text);
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, CustomerReceivable cr)
        {
            row.Tag = cr;
            row.Cells["colSheetID"].Value = cr.SheetID;
            if (cr.ClassID == CustomerReceivableType.SupplierReceivable)
            {
                var gg = cr.GetProperty("规格");
                if (!string.IsNullOrEmpty(gg)) row.Cells["colSheetID"].Value = gg;
            }
            row.Cells["colOrderID"].Value = cr.OrderID;
            row.Cells["colCreateDate"].Value = cr.CreateDate.ToString("yyyy-MM-dd");
            row.Cells["colAmount"].Value = cr.Amount.Trim();
            if (cr.Haspaid != 0) row.Cells["colHaspaid"].Value = cr.Haspaid.Trim();
            if (cr.Remain != 0)
            {
                row.Cells["colNotpaid"].Value = cr.Remain.Trim();
                int days = DaysBetween(DateTime.Today, cr.CreateDate);
                row.Cells["colHowold"].Value = days >= 0 ? string.Format("{0}天", days) : string.Empty;
            }
            row.Cells["col申请人"].Value = cr.GetProperty("申请人");
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

        private void FilterRow(string key)
        {
            var items = new List<CustomerReceivable>();
            for (int i = 0; i < GridView.Rows.Count - 1; i++)
            {
                GridView.Rows[i].Visible = ContainText(GridView.Rows[i], key);
                if (GridView.Rows[i].Visible) items.Add(GridView.Rows[i].Tag as CustomerReceivable);
            }
            lblMSG.Text = string.Format("共 {0} 项", items.Count);
            GridView.Rows[GridView.Rows.Count - 1].Cells["colAmount"].Value = items.Sum(item => (item as CustomerReceivable).Amount).Trim();
            GridView.Rows[GridView.Rows.Count - 1].Cells["colHaspaid"].Value = items.Sum(item => (item as CustomerReceivable).Haspaid).Trim();
            GridView.Rows[GridView.Rows.Count - 1].Cells["colNotpaid"].Value = items.Sum(item => (item as CustomerReceivable).Remain).Trim();
        }

        private bool ContainText(DataGridViewRow row, string key)
        {
            if (string.IsNullOrEmpty(key)) return true;
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Visible && cell.Value != null && cell.Value.ToString().Contains(key)) return true;
            }
            return false;
        }

        private void ShowOperatorRights()
        {
            if (ReceivableType == CustomerReceivableType.CustomerReceivable)
            {
                mnu_Add.Enabled = Operator.Current.Permit(Permission.CustomerReceivable, PermissionActions.Edit);
            }
            else if (ReceivableType == CustomerReceivableType.SupplierReceivable)
            {
                mnu_Add.Enabled = Operator.Current.Permit(Permission.SupplierReceivable, PermissionActions.Edit);
            }
            else
            {
                mnu_Add.Enabled = false;
            }
        }
        #endregion

        #region 事件处理程序
        private void FrmCustomerReceivableView_Load(object sender, EventArgs e)
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

        private void mnu_Add_Click(object sender, EventArgs e)
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
                if (GridView.Rows[e.RowIndex].Tag == null) return;
                CustomerReceivable cr = GridView.Rows[e.RowIndex].Tag as CustomerReceivable;
                if (GridView.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    if (cr.ClassID == CustomerReceivableType.CustomerReceivable)
                    {
                        var sheet = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetByID(cr.SheetID).QueryObject;
                        if (sheet != null)
                        {
                            Inventory.FrmStackOutSheetDetail frm = new Inventory.FrmStackOutSheetDetail();
                            frm.IsAdding = false;
                            frm.IsForView = true;
                            frm.UpdatingItem = sheet;
                            frm.ShowDialog();
                            return;
                        }
                    }
                    else if (cr.ClassID == CustomerReceivableType.SupplierReceivable)
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
                    }
                    var osheet = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr).GetByID(cr.SheetID).QueryObject;
                    if (osheet != null)
                    {
                        Frm其它应收明细 frm = new Frm其它应收明细();
                        frm.ReceivableType = osheet.ClassID;
                        frm.UpdatingItem = osheet;
                        frm.ShowDialog();
                        FreshData();
                    }
                    else
                    {
                        var cp = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cr.SheetID).QueryObject;
                        if (cp != null && (cp.ClassID == CustomerPaymentType.供应商退款 || cp.ClassID == CustomerPaymentType.客户退款))
                        {
                            Frm退款 frm = new Frm退款();
                            frm.IsAdding = false;
                            frm.UpdatingItem = cp;
                            frm.ShowDialog();
                            FreshData();
                        }
                        else if (cp != null && cp.ClassID == CustomerPaymentType.公司管理费用)
                        {
                            Frm管理费用明细 frm = new Frm管理费用明细();
                            frm.IsAdding = false;
                            frm.UpdatingItem = cp;
                            frm.ShowDialog();
                            FreshData();
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

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            FilterRow(txtKeyword.Text);
        }
    }
}
