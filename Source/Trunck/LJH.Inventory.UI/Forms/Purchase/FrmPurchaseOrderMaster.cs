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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmPurchaseOrderMaster : FrmMasterBase
    {
        public FrmPurchaseOrderMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<PurchaseOrder> _Sheets = null;
        #endregion

        #region 私有方法
        private void SelectNode(TreeNode node)
        {
            List<object> items = GetSelectedNodeItems();
            ShowItemsOnGrid(items);
        }

        private List<object> GetSelectedNodeItems()
        {
            List<PurchaseOrder> items = _Sheets;
            CompanyInfo pc = null;
            if (this.supplierTree1.SelectedNode != null) pc = this.supplierTree1.SelectedNode.Tag as CompanyInfo;
            if (pc != null) items = _Sheets.Where(it => it.SupplierID == pc.ID).ToList();

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
            _Sheets = (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            return GetSelectedNodeItems();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            PurchaseOrder info = item as PurchaseOrder;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colOrderDate"].Value = info.OrderDate;
            row.Cells["colSupplier"].Value = info.Supplier.Name;
            row.Cells["colBuyer"].Value = info.Buyer;
            row.Cells["colDeliveryDate"].Value = info.DemandDate;
            row.Cells["colWithTax"].Value = info.WithTax;
            row.Cells["colAmount"].Value = info.CalAmount().Trim();
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
        private void supplierTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectNode(e.Node);
        }
        #endregion

    }
}
