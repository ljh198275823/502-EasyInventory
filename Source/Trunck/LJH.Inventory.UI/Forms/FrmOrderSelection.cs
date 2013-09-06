using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory.BusinessModel.Resource;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmOrderSelection : FrmMasterBase 
    {
        public FrmOrderSelection()
        {
            InitializeComponent();
        }

        #region 公共方法
        public Customer Customer { get; set; }

        public event EventHandler CustomerUpdated;
        #endregion

        private void ShowCustomer(Customer c)
        {
            this.Text = string.Format("{0} 的应收账款", c.Name);

            this.GridView.Rows.Clear();
            List<CustomerReceivable> items = (new CustomerBLL(AppSettings.CurrentSetting.ConnectString)).GetUnSettleReceivables(c.ID);
            if (items != null && items.Count > 0)
            {
                foreach (CustomerReceivable item in items)
                {
                    int row = GridView.Rows.Add();
                    ShowItemInGridViewRow(GridView.Rows[row], item);
                }
                int rowTotal = GridView.Rows.Add();
                GridView.Rows[rowTotal].Cells["colSheetNo"].Value = "合计";
                GridView.Rows[0].Selected = false;
            }
        }

        private void ShowItemInGridViewRow(DataGridViewRow row, CustomerReceivable item)
        {
            row.Tag = item;
            row.Cells["colSheetNo"].Value = item.ID;
            row.Cells["colCreateDate"].Value = item.CreateDate;
            row.Cells["colAmount"].Value = item.Amount;
            //row.Cells["colPaid"].Value = item.Paid;
            //row.Cells["colReceivable"].Value = item.Receivable;
            row.Cells["colMemo"].Value = item.Memo;
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (GridView.Columns[e.ColumnIndex].Name == "colSheetNo")
                {
                    string sheetNo = GridView.Rows[e.RowIndex].Cells["colSheetNo"].Value.ToString();
                    if (!string.IsNullOrEmpty(sheetNo))
                    {
                        DeliverySheet sheet = (new DeliverySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheetNo).QueryObject;
                        if (sheet != null)
                        {
                            FrmDeliverySheetDetail frm = new FrmDeliverySheetDetail();
                            frm.UpdatingItem = sheet;
                            frm.IsForView = true;
                            frm.ShowDialog();
                        }
                    }
                }
                else if (GridView.Columns[e.ColumnIndex].Name == "colPaid")
                {
                //    string sheetNo = GridView.Rows[e.RowIndex].Cells["colSheetNo"].Value.ToString();
                //    FrmReceivablePaymentAssigns frm = new FrmReceivablePaymentAssigns();
                //    frm.ReceivableID = sheetNo;
                //    frm.ShowDialog();
                }
            }
        }

        private void GridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1)
                {
                    if (!GridView.Rows[e.RowIndex].Selected)
                    {
                        foreach (DataGridViewRow row in GridView.Rows)
                        {
                            row.Selected = false;
                        }
                        GridView.Rows[e.RowIndex].Selected = true;
                    }
                }
            }
        }

        private void FrmCustomerReceivables_Load(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                ShowCustomer(Customer);
            }
        }

        private void mnu_Pay_Click(object sender, EventArgs e)
        {
        //    if (this.GridView.SelectedRows.Count == 1)
        //    {
        //        CustomerReceivable cr = this.GridView.SelectedRows[0].Tag as CustomerReceivable;
        //        if (cr != null)
        //        {
        //            FrmPaymentAssign frm = new FrmPaymentAssign();
        //            frm.CustomerID = cr.CustomerID;
        //            frm.ReceivableID = cr.ID;
        //            frm.Receivables = cr.Receivable;
        //            if (frm.ShowDialog() == DialogResult.OK)
        //            {
        //                ShowCustomer(this.Customer);
        //                if (this.CustomerUpdated != null) this.CustomerUpdated(this, EventArgs.Empty);
        //            }
        //        }
        //    }
        }
    }
}
