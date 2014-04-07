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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmPurchaseOrderMaster : FrmMasterBase
    {
        public FrmPurchaseOrderMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<PurchaseOrder> _Orders = null;
        #endregion

        #region 私有方法
        private void SelectNode(TreeNode node)
        {
            List<object> items = GetSelectedNodeItems();
            ShowItemsOnGrid(items);
        }

        private List<object> GetSelectedNodeItems()
        {
            List<PurchaseOrder> items = _Orders;
            CompanyInfo pc = null;
            if (this.supplierTree1.SelectedNode != null) pc = this.supplierTree1.SelectedNode.Tag as CompanyInfo;
            if (pc != null) items = _Orders.Where(it => it.SupplierID == pc.ID).ToList();

            return (from p in items
                    orderby p.OrderDate descending
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            supplierTree1.Init();
            Operator opt = Operator.Current;
            dataGridView1.Columns["colAmount"].Visible = Operator.Current.Permit(Permission.ReadPrice);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmPurchaseOrderDetail frm = new FrmPurchaseOrderDetail();
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            _Orders = (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            return GetSelectedNodeItems();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            PurchaseOrder PurchaseSheet = item as PurchaseOrder;
            row.Cells["colID"].Value = PurchaseSheet.ID;
            row.Cells["colOrderDate"].Value = PurchaseSheet.OrderDate;
            row.Cells["colSupplier"].Value = PurchaseSheet.Supplier.Name;
            row.Cells["colBuyer"].Value = PurchaseSheet.Buyer;
            row.Cells["colDeliveryDate"].Value = PurchaseSheet.DemandDate;
            row.Cells["colWithTax"].Value = PurchaseSheet.WithTax;
            row.Cells["colAmount"].Value = PurchaseSheet.CalAmount().Trim();
            row.Cells["colMemo"].Value = PurchaseSheet.Memo;
            if (PurchaseSheet.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }

        protected override bool DeletingItem(object item)
        {
            PurchaseOrder sheet = item as PurchaseOrder;
            CommandResult ret = (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).Delete(sheet);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion

        #region 事件处理程序
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "colReceivable")
            {
            }
        }

        private void supplierTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectNode(e.Node);
        }
        #endregion

    }
}
