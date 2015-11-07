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
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.Report;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmCustomerOtherReceivableMaster : FrmMasterBase
    {
        public FrmCustomerOtherReceivableMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<CustomerOtherReceivable> _Sheets = null;
        private List<CustomerReceivable> _Receivables = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> objs = FilterData();
            ShowItemsOnGrid(objs);
        }

        private List<object> FilterData()
        {
            List<CustomerOtherReceivable> items = _Sheets;
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
            this.customerTree1.Init();
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.CustomerOtherReceivable, PermissionActions.Edit);
            mnu_Add.Enabled = Operator.Current.Permit(Permission.CustomerOtherReceivable, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmCustomerOtherReceivableDetail frm = new FrmCustomerOtherReceivableDetail();
            if (customerTree1.SelectedNode != null) frm.Customer = customerTree1.SelectedNode.Tag as CompanyInfo;
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            CustomerReceivableSearchCondition con1 = new CustomerReceivableSearchCondition();
            con1.ReceivableTypes = new List<CustomerReceivableType>();
            con1.ReceivableTypes.Add(CustomerReceivableType.CustomerOtherReceivable);
            _Receivables = new CustomerReceivableBLL(AppSettings.Current.ConnStr).GetItems(con1).QueryObjects;

            if (SearchCondition == null)
            {
                CustomerOtherReceivableSearchCondition con = new CustomerOtherReceivableSearchCondition();
                con.LastActiveDate = new DateTimeRange(DateTime.Today.AddYears(-1), DateTime.Now);
                _Sheets = (new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            }
            else
            {
                _Sheets = (new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            return FilterData();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerOtherReceivable info = item as CustomerOtherReceivable;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colSheetDate"].Value = info.SheetDate.ToString("yyyy-MM-dd");
            CompanyInfo customer = customerTree1.GetCustomer(info.CustomerID);
            row.Cells["colCustomer"].Value = customer != null ? customer.Name : info.CustomerID;
            row.Cells["colCurrencyType"].Value = info.CurrencyType;
            row.Cells["colAmount"].Value = info.Amount.Trim();
            CustomerReceivable cr = _Receivables.SingleOrDefault(it => it.SheetID == info.ID);
            if (cr != null)
            {
                row.Cells["colPaid"].Value = cr.Haspaid.Trim();
                row.Cells["colNotPaid"].Value = cr.Remain.Trim();
            }
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(info.State);
            row.Cells["colMemo"].Value = info.Memo;
            if (info.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (!_Sheets.Exists(it => it.ID == info.ID)) _Sheets.Add(info);
        }

        protected override bool DeletingItem(object item)
        {
            return false;
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
            if (e.RowIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colPaid")
                {
                    CustomerOtherReceivable daifu = dataGridView1.Rows[e.RowIndex].Tag as CustomerOtherReceivable;
                    if (daifu != null)
                    {
                        View.FrmReceivablePaymentAssigns frm = new View.FrmReceivablePaymentAssigns();
                        frm.ReceivableID = daifu.ID;
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void customerTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void mnu_Add_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }

        private void chkState_CheckedChanged(object sender, EventArgs e)
        {
            FreshData();
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            FreshData();
        }
        #endregion
    }
}
