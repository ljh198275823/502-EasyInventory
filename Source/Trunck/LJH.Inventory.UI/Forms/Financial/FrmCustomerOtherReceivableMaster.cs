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
        #endregion

        #region 私有方法
        private void SelectNode(TreeNode node)
        {
            List<object> items = GetSelectedNodeItems();
            ShowItemsOnGrid(items);
        }

        private List<object> GetSelectedNodeItems()
        {
            List<CustomerOtherReceivable> items = _Sheets;
            CompanyInfo pc = null;
            if (this.customerTree1.SelectedNode != null) pc = this.customerTree1.SelectedNode.Tag as CompanyInfo;
            if (pc != null) items = _Sheets.Where(it => it.CustomerID == pc.ID).ToList();

            return (from p in items
                    orderby p.LastActiveDate descending
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            this.customerTree1.Init();
            Operator opt = Operator.Current;
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmCustomerOtherReceivableDetail();
        }

        protected override List<object> GetDataSource()
        {
            _Sheets  = (new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            return GetSelectedNodeItems();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CustomerOtherReceivable info = item as CustomerOtherReceivable;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colCreateDate"].Value = info.LastActiveDate.ToString("yyyy-MM-dd");
            row.Cells["colCustomer"].Value = info.Customer != null ? info.Customer.Name : info.CustomerID;
            row.Cells["colCurrencyType"].Value = info.CurrencyType;
            row.Cells["colAmount"].Value = info.Amount.Trim();
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
                        FrmReceivablePaymentAssigns frm = new FrmReceivablePaymentAssigns();
                        frm.ReceivableID = daifu.ID;
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void mnu_Pay_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.SelectedRows.Count == 1)
            //{
            //    CustomerOtherReceivable daifu = dataGridView1.SelectedRows[0].Tag as CustomerOtherReceivable;
            //    if (daifu.Payable)
            //    {
            //        FrmReceivablesPaid frm = new FrmReceivablesPaid();
            //        CompanyInfo c = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(daifu.CustomerID).QueryObject;
            //        if (c != null)
            //        {
            //            frm.Customer = c;
            //            frm.ReceivableID = daifu.ID;
            //            frm.MaxAmount = daifu.NotPaid;
            //            if (frm.ShowDialog() == DialogResult.OK)
            //            {
            //                CustomerOtherReceivable sheet1 = (new CustomerOtherReceivableBLL(AppSettings.Current.ConnStr)).GetByID(daifu.ID).QueryObject;
            //                ShowItemInGridViewRow(dataGridView1.SelectedRows[0], sheet1);
            //            }
            //        }
            //    }
            //}
        }

        private void customerTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectNode(e.Node);
        }
        #endregion
    }
}
