using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms;
using LJH.Inventory.UI.Forms.Financial;

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
            GridView.Rows.Clear();
            GridView.CellClick -= StackoutSheetID_Click;
            GridView.CellClick -= PaymentID_Click;
            GridView.CellClick += PaymentID_Click;
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
                        int row = GridView.Rows.Add();
                        GridView.Rows[row].Tag = assign;
                        GridView.Rows[row].Cells["colSheetID"].Value = cr.SheetID;
                        GridView.Rows[row].Cells["colAssign"].Value = assign.Amount;
                    }
                }
                int rowTotal = GridView.Rows.Add();
                GridView.Rows[rowTotal].Cells["colSheetID"].Value = "合计";
                GridView.Rows[rowTotal].Cells["colAssign"].Value = assigns.Sum(it => it.Amount);
                this.toolStripStatusLabel1.Text = string.Format("总共 {0} 项", assigns.Count);
            }
        }

        public void ShowAssigns(AccountRecord item)
        {
            GridView.Rows.Clear();
            GridView.CellClick -= StackoutSheetID_Click;
            GridView.CellClick -= PaymentID_Click;
            GridView.CellClick += StackoutSheetID_Click;
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
                        int row = GridView.Rows.Add();
                        GridView.Rows[row].Tag = assign;
                        GridView.Rows[row].Cells["colSheetID"].Value = cr.SheetID;
                        GridView.Rows[row].Cells["colAssign"].Value = assign.Amount;
                    }
                }
                int rowTotal = GridView.Rows.Add();
                GridView.Rows[rowTotal].Cells["colSheetID"].Value = "合计";
                GridView.Rows[rowTotal].Cells["colAssign"].Value = assigns.Sum(it => it.Amount);
                this.toolStripStatusLabel1.Text = string.Format("总共 {0} 项", assigns.Count);
            }
        }
        #endregion

        #region 事件处理程序
        private void StackoutSheetID_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >=0)
            {
                if (GridView.Rows[e.RowIndex].Tag == null) return;
                if (GridView.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    string sheetID = GridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    var sheet = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetByID(sheetID).QueryObject;
                    if (sheet != null)
                    {
                        Inventory.FrmStackOutSheetDetail frm = new Inventory.FrmStackOutSheetDetail();
                        frm.IsAdding = false;
                        frm.IsForView = true;
                        frm.UpdatingItem = sheet;
                        frm.ShowDialog();
                        return;
                    }
                    var osheet = new OtherReceivableSheetBLL(AppSettings.Current.ConnStr).GetByID(sheetID).QueryObject;
                    if (osheet != null)
                    {
                        FrmOhterReceivableSheetDetail frm = new FrmOhterReceivableSheetDetail();
                        frm.ReceivableType = osheet.ClassID;
                        frm.IsForView = true;
                        frm.UpdatingItem = osheet;
                        frm.ShowDialog();
                        return;
                    }
                }
            }
        }

        private void PaymentID_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (GridView.Rows[e.RowIndex].Tag == null) return;
                if (GridView.Columns[e.ColumnIndex].Name == "colSheetID")
                {
                    string paymentID = GridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    CustomerPayment cp = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetByID(paymentID).QueryObject;
                    if (cp != null)
                    {
                        if (cp.ClassID == CustomerPaymentType.Customer || cp.ClassID == CustomerPaymentType.Supplier)
                        {
                            FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                            frm.IsAdding = false;
                            frm.IsForView = true;
                            frm.UpdatingItem = cp;
                            frm.PaymentType = cp.ClassID;
                            frm.ShowDialog();
                        }
                        else if (cp.ClassID == CustomerPaymentType.CustomerTax || cp.ClassID == CustomerPaymentType.SupplierTax)
                        {
                            FrmCustomerTaxBillDetail frm = new FrmCustomerTaxBillDetail();
                            frm.IsAdding = false;
                            frm.IsForView = true;
                            frm.UpdatingItem = cp;
                            frm.TaxType = cp.ClassID;
                            frm.ShowDialog();
                        }
                    }
                }
            }
        }
        #endregion
    }
}
