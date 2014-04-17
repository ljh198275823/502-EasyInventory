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
using LJH.GeneralLibrary.DAL;
using LJH.GeneralLibrary.UI;

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
        private void FreshData()
        {
            List<object> objs = FilterData();
            ShowItemsOnGrid(objs);
        }

        private List<object> FilterData()
        {
            List<PurchaseOrder > items = _Sheets;
            if (this.supplierTree1 .SelectedNode != null)
            {
                List<CompanyInfo> pcs = null;
                pcs = this.supplierTree1 .GetCompanyofNode(this.supplierTree1 .SelectedNode);
                if (pcs != null && pcs.Count > 0)
                {
                    items = items.Where(it => pcs.Exists(c => c.ID == it.SupplierID)).ToList();
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
            return FilterData();
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

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
        }
        #endregion

        #region 事件处理程序
        private void supplierTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
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
        #endregion
    }
}
