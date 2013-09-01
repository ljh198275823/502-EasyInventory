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

namespace LJH.Inventory.UI.Forms.Report
{
    public partial class FrmReceivablePaymentAssigns : Form
    {
        public FrmReceivablePaymentAssigns()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ShowDelivery(string receivableID)
        {
            this.Text = string.Format("{0} 的付款项", receivableID);
            GridView.Rows.Clear();
            List<CustomerPaymentAssign> assigns = (new DeliverySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetAssigns(receivableID).QueryObjects;
            if (assigns != null && assigns.Count > 0)
            {
                foreach (CustomerPaymentAssign assign in assigns)
                {
                    int row = GridView.Rows.Add();
                    GridView.Rows[row].Cells["colPaidDate"].Value = assign.PaidDate;
                    GridView.Rows[row].Cells["colCustomerPaymentID"].Value = assign.PaymentID;
                    GridView.Rows[row].Cells["colAssign"].Value = assign.Assign;
                    GridView.Rows[row].Cells["colAmount"].Value = assign.Amount;
                }
                int rowTotal = GridView.Rows.Add();
                GridView.Rows[rowTotal].Cells["colCustomerPaymentID"].Value = "合计";
                GridView.Rows[rowTotal].Cells["colAssign"].Value = assigns.Sum(item => item.Assign);
                GridView.Rows[rowTotal].Cells["colAmount"].Value = assigns.Sum(item => item.Amount);

                this.toolStripStatusLabel1.Text = string.Format("总共 {0} 项", assigns.Count);
            }
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置要显示的送货单
        /// </summary>
        public string ReceivableID { get; set; }
        #endregion

        private void FrmCustomerPaymentAssignView_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty (ReceivableID))
            {
                ShowDelivery(ReceivableID);
            }
        }

        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (GridView.Columns[e.ColumnIndex].Name == "colCustomerPaymentID")
                {
                    string paymentID = GridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    CustomerPayment cp = (new CustomerPaymentBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(paymentID).QueryObject;
                    if (cp != null)
                    {
                        FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
                        frm.IsAdding = false;
                        frm.IsForView = true;
                        frm.UpdatingItem = cp;
                        frm.ShowDialog();
                    }
                }
            }
        }
    }
}
