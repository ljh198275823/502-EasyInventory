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
using LJH.Inventory.UI.View;

namespace LJH.Inventory.UI.Forms.Sale
{
    public partial class FrmOrderItemRecordMaster : FrmMasterBase
    {
        public FrmOrderItemRecordMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<OrderItemRecord> _Sheets = null;
        #endregion

        #region 私有方法
        private void SelectNode(TreeNode node)
        {
            List<object> items = GetSelectedNodeItems();
            ShowItemsOnGrid(items);
        }

        private List<object> GetSelectedNodeItems()
        {
            List<OrderItemRecord> items = _Sheets;
            CompanyInfo pc = null;
            if (this.customerTree1.SelectedNode != null) pc = this.customerTree1.SelectedNode.Tag as CompanyInfo;
            if (pc != null) items = _Sheets.Where(it => it.CustomerID == pc.ID).ToList();

            return (from p in items
                    orderby p.OrderDate descending
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
            return new FrmOrderDetail();
        }

        protected override List<object> GetDataSource()
        {
            _Sheets = (new OrderBLL(AppSettings.Current.ConnStr)).GetRecords(SearchCondition).QueryObjects;
            return GetSelectedNodeItems();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            OrderItemRecord info = item as OrderItemRecord;
            row.Tag = info;
            row.Cells["colOrderID"].Value = info.OrderID;
            row.Cells["colOrderDate"].Value = info.OrderDate;
            row.Cells["colCustomer"].Value = info.Customer.Name;
            row.Cells["colProduct"].Value = info.Product != null ? info.Product.Name : info.ProductID;
            row.Cells["colUnit"].Value = info.Unit;
            row.Cells["colSales"].Value = info.SalesPerson;
            row.Cells["colDemandDate"].Value = info.DemandDate;
            row.Cells["colCount"].Value = info.Count.Trim();
            row.Cells["colState"].Value = row.Cells["colState"].Value = SheetStateDescription.GetDescription(info.State);
            row.Cells["colOnWay"].Value = info.OnWay.Trim();
            row.Cells["colInventory"].Value = info.Inventory .Trim();
            row.Cells["colShipped"].Value =info.Shipped .Trim();
            row.Cells["colNotPurchased"].Value = info.NotPurchased.Trim();
            row.Cells["colMemo"].Value = info.Memo;
            if (info.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (!_Sheets.Exists(it => it.ID == info.ID)) _Sheets.Add(info);
        }
        #endregion

        #region 事件处理程序
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "colReceivable")
            {
                Order order = dataGridView1.Rows[e.RowIndex].Tag as Order;
                DeliveryRecordSearchCondition con = new DeliveryRecordSearchCondition();
                con.OrderID = order.ID;
                FrmDeliveryRecordView frm = new FrmDeliveryRecordView();
                frm.SearchCondition = con;
                frm.ShowDialog();
            }
        }

        private void customerTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectNode(e.Node);
        }
        #endregion
    }
}
