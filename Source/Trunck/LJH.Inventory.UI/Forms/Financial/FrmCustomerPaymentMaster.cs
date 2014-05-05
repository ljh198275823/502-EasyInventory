using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmCustomerPaymentMaster : FrmMasterBase
    {
        public FrmCustomerPaymentMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<CustomerPayment> _Sheets = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> objs = FilterData();
            ShowItemsOnGrid(objs);
        }

        private List<object> FilterData()
        {
            List<CustomerPayment> items = _Sheets;
            if (this.customerTree1.SelectedNode != null)
            {
                List<CompanyInfo> pcs = null;
                pcs = this.customerTree1.GetCompanyofNode(this.customerTree1.SelectedNode);
                if (pcs != null && pcs.Count > 0)
                {
                    items = items.Where(it => pcs.Exists(c => c.ID == it.CustomerID)).ToList();
                }
                else
                {
                    items = null;
                }
            }
            if (items != null && items.Count > 0)
            {
                items = items.Where(item => ((item.State == SheetState.Add && chkAdded.Checked) ||
                                        (item.State == SheetState.Approved && chkApproved.Checked) ||
                                        (item.State == SheetState.Canceled && chkNullify.Checked))).ToList();
            }
            List<object> objs = null;
            if (items != null && items.Count > 0) objs = (from item in items orderby item.ID descending select (object)item).ToList();
            return objs;
        }
        #endregion

        #region 重写基类方法和处理事件
        protected override void ReFreshData()
        {
            customerTree1.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Edit);
            mnu_Add.Enabled = Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmCustomerPaymentDetail frm = new FrmCustomerPaymentDetail();
            if (customerTree1.SelectedNode != null) frm.Customer = customerTree1.SelectedNode.Tag as CompanyInfo;
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            _Sheets = (new CustomerPaymentBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            return FilterData();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerPayment info = item as CustomerPayment;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colPaidDate"].Value = info.LastActiveDate.ToString("yyyy-MM-dd");
            CompanyInfo customer = customerTree1.GetCustomer(info.CustomerID);
            row.Cells["colCustomer"].Value = customer != null ? customer.Name : info.CustomerID;
            row.Cells["colPaymentMode"].Value = PaymentModeDescription.GetDescription(info.PaymentMode);
            row.Cells["colAmount"].Value = info.Amount.Trim();
            row.Cells["colCheckNum"].Value = info.CheckNum;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(info.State);
            row.Cells["colMemo"].Value = info.Memo;
            if (info.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (!_Sheets.Exists(it => it.ID == info.ID)) _Sheets.Add(info);
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
        }
        #endregion

        #region 事件处理程序
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "colReceivable")
            //{
            //    Order order = dataGridView1.Rows[e.RowIndex].Tag as Order;
            //    DeliveryRecordSearchCondition con = new DeliveryRecordSearchCondition();
            //    con.OrderID = order.ID;
            //    FrmDeliveryRecordView frm = new FrmDeliveryRecordView();
            //    frm.SearchCondition = con;
            //    frm.ShowDialog();
            //}
        }

        private void customerTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void chkState_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_Add_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }
        #endregion
    }
}
