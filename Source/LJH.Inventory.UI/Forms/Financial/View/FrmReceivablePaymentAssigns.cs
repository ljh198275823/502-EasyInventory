using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms.Inventory;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Financial.View
{
    public partial class FrmReceivablePaymentAssigns : Form
    {
        public FrmReceivablePaymentAssigns()
        {
            InitializeComponent();
        }

        #region 私有方法
        public void ShowAssigns(CustomerReceivable item)
        {
            ItemsGrid.Rows.Clear();
            ItemsGrid.CellClick -= StackoutSheetID_Click;
            ItemsGrid.CellClick -= PaymentID_Click;
            ItemsGrid.CellClick += PaymentID_Click;
            AccountRecordAssignSearchCondition con = new AccountRecordAssignSearchCondition();
            con.ReceivableID = item.ID;
            var assigns = new AccountRecordAssignBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                foreach (AccountRecordAssign assign in assigns)
                {
                    var cr = new AccountRecordBLL(AppSettings.Current.ConnStr).GetByID(assign.PaymentID).QueryObject;
                    if (cr != null)
                    {
                        int row = ItemsGrid.Rows.Add();
                        ItemsGrid.Rows[row].Tag = assign;
                        ItemsGrid.Rows[row].Cells["colSheetID"].Value = cr.SheetID;
                        ItemsGrid.Rows[row].Cells["colAssign"].Value = assign.Amount;
                    }
                }
                int rowTotal = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[rowTotal].Cells["colSheetID"].Value = "合计";
                ItemsGrid.Rows[rowTotal].Cells["colAssign"].Value = assigns.Sum(it => it.Amount);
                this.toolStripStatusLabel1.Text = string.Format("总共 {0} 项", assigns.Count);
            }
        }

        public void ShowAssigns(AccountRecord item)
        {
            ItemsGrid.Rows.Clear();
            ItemsGrid.CellClick -= StackoutSheetID_Click;
            ItemsGrid.CellClick -= PaymentID_Click;
            ItemsGrid.CellClick += StackoutSheetID_Click;
            AccountRecordAssignSearchCondition con = new AccountRecordAssignSearchCondition();
            con.PaymentID = item.ID;
            var assigns = new AccountRecordAssignBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                foreach (AccountRecordAssign assign in assigns)
                {
                    var cr = new CustomerReceivableBLL(AppSettings.Current.ConnStr).GetByID(assign.ReceivableID).QueryObject;
                    if (cr != null)
                    {
                        int row = ItemsGrid.Rows.Add();
                        ItemsGrid.Rows[row].Tag = assign;
                        ItemsGrid.Rows[row].Cells["colSheetID"].Value = cr.SheetID;
                        ItemsGrid.Rows[row].Cells["colSheetID"].Tag = cr;
                        if (cr.ClassID == CustomerReceivableType.SupplierReceivable)
                        {
                            var gg = cr.GetProperty("规格");
                            if (!string.IsNullOrEmpty(gg)) ItemsGrid.Rows[row].Cells["colSheetID"].Value = gg;
                        }
                        ItemsGrid.Rows[row].Cells["colAssign"].Value = assign.Amount;
                    }
                }
                int rowTotal = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[rowTotal].Cells["colSheetID"].Value = "合计";
                ItemsGrid.Rows[rowTotal].Cells["colAssign"].Value = assigns.Sum(it => it.Amount);
                this.toolStripStatusLabel1.Text = string.Format("总共 {0} 项", assigns.Count);
            }
        }
        #endregion

        #region 事件处理程序
        private void StackoutSheetID_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (ItemsGrid.Rows[e.RowIndex].Tag == null) return;
                if (ItemsGrid.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    CustomerReceivable cr = ItemsGrid.Rows[e.RowIndex].Cells["colSheetID"].Tag as CustomerReceivable;
                    if (cr.ClassID  == CustomerReceivableType.CustomerReceivable)
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
                                frm.ReceivableType = osheet.ClassID;
                                frm.UpdatingItem = osheet;
                                frm.ShowDialog();
                            }
                            else
                            {
                                var tui = new CustomerPaymentBLL(AppSettings.Current.ConnStr).GetByID(cr.SheetID).QueryObject;
                                if (tui != null)
                                {
                                    Frm退款 frm = new Frm退款();
                                    frm.IsAdding = false;
                                    frm.UpdatingItem = tui;
                                    frm.ShowDialog();
                                }
                            }
                        }
                    }
                    else if (cr.ClassID  == CustomerReceivableType.SupplierReceivable)
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
                            }
                        }
                    }
                }
            }
        }

        private void PaymentID_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (ItemsGrid.Rows[e.RowIndex].Tag == null) return;
                if (ItemsGrid.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    string paymentID = ItemsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    CustomerPayment cp = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetByID(paymentID).QueryObject;
                    if (cp != null)
                    {
                        if (cp.ClassID == CustomerPaymentType.客户收款 || cp.ClassID == CustomerPaymentType.供应商付款)
                        {
                            FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                            frm.IsAdding = false;
                            frm.UpdatingItem = cp;
                            frm.PaymentType = cp.ClassID;
                            frm.ShowDialog();
                        }
                        else if (cp.ClassID == CustomerPaymentType.客户增值税发票 || cp.ClassID == CustomerPaymentType.供应商增值税发票)
                        {
                            FrmCustomerTaxBillDetail frm = new FrmCustomerTaxBillDetail();
                            frm.IsAdding = false;
                            frm.UpdatingItem = cp;
                            frm.TaxType = cp.ClassID;
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }

        private void mnu_UndoAssign_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> delRows = new List<DataGridViewRow>();
            if (ItemsGrid.SelectedRows != null && ItemsGrid.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("是否要取消此核销项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in ItemsGrid.SelectedRows)
                    {
                        AccountRecordAssign assign = row.Tag as AccountRecordAssign;
                        CommandResult ret = (new AccountRecordAssignBLL(AppSettings.Current.ConnStr)).UndoAssign(assign);
                        if (ret.Result == ResultCode.Successful) delRows.Add(row);
                    }
                }
            }
            delRows.ForEach(it => ItemsGrid.Rows.Remove(it));
        }
        #endregion
    }
}
