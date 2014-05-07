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
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmPurchaseItemRecordMaster : FrmMasterBase
    {
        public FrmPurchaseItemRecordMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<PurchaseItemRecord> _Records = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> objs = FilterData();
            ShowItemsOnGrid(objs);
        }

        private List<object> FilterData()
        {
            List<PurchaseItemRecord> items = _Records;
            if (this.supplierTree1.SelectedNode != null)
            {
                List<CompanyInfo> pcs = null;
                pcs = this.supplierTree1.GetCompanyofNode(this.supplierTree1.SelectedNode);
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
            if (items != null && items.Count > 0)
            {
                items = items.Where(item => ((item.Received == 0 && chkNoneShipped.Checked) ||
                                             (item.Received > 0 && item.OnWay > 0 && item.Received < item.Count && chkPatialShipped.Checked) ||
                                             ((item.OnWay == 0) && chkAllShipped.Checked))).ToList();
            }
            List<object> objs = null;
            if (items != null && items.Count > 0) objs = (from item in items orderby item.OrderID descending select (object)item).ToList();
            return objs;
        }
        #endregion

        #region 重写基类方法和处理事件
        protected override void ReFreshData()
        {
            this.supplierTree1.Init();
            base.ReFreshData();
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return null;
        }

        protected override List<object> GetDataSource()
        {
            if (SearchCondition == null)
            {
                PurchaseItemRecordSearchCondition con = new PurchaseItemRecordSearchCondition();
                con.OrderDate = new DateTimeRange(DateTime.Today.AddYears(-1), DateTime.Now); //获取最后一年产生的订单
                _Records = (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).GetRecords(con).QueryObjects;
            }
            else
            {
                _Records = (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).GetRecords(SearchCondition).QueryObjects;
            }
            return FilterData();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            PurchaseItemRecord info = item as PurchaseItemRecord;
            row.Tag = info;
            row.Cells["colSheetNo"].Value = info.SheetNo;
            row.Cells["colSupplier"].Value = info.Supplier != null ? info.Supplier.Name : string.Empty;
            row.Cells["colProduct"].Value =info.Product !=null? info.Product.Name:string.Empty ;
            row.Cells["colSpecification"].Value = info.Product.Specification;
            row.Cells["colUnit"].Value = info.Unit;
            row.Cells["colCount"].Value = info.Count.Trim();
            row.Cells["colReceived"].Value = info.Received.Trim();
            row.Cells["colOnway"].Value = info.OnWay.Trim();
            row.Cells["colDemandDate"].Value = info.DemandDate.ToLongDateString();
            row.Cells["colOrderID"].Value = info.OrderID;
            row.Cells["colBuyer"].Value = info.Buyer;
            row.Cells["colMemo"].Value = info.Memo;
            if (info.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (!_Records.Exists(it => it.ID == info.ID)) _Records.Add(info);
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
        }
        #endregion

        #region 事件处理方法
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PurchaseItemRecord record = dataGridView1.Rows[e.RowIndex].Tag as PurchaseItemRecord;
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colSheetNo")
                {
                    PurchaseOrder sheet = (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).GetByID(record.SheetNo).QueryObject;
                    if (sheet != null)
                    {
                        FrmPurchaseOrderDetail frm = new FrmPurchaseOrderDetail();
                        frm.IsAdding = false;
                        frm.UpdatingItem = sheet;
                        frm.IsForView = true;
                        frm.ShowDialog();
                    }
                }
            }
        }

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

