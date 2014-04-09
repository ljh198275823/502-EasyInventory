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
    public partial class FrmPurchaseItemRecordMaster : FrmMasterBase
    {
        public FrmPurchaseItemRecordMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            btnAll.BackColor = SystemColors.ControlDark;
            Operator opt = Operator.Current;
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return null;
        }

        protected override List<object> GetDataSource()
        {
            PurchaseOrderBLL bll = new PurchaseOrderBLL(AppSettings.Current.ConnStr);
            List<PurchaseItemRecord> items = bll.GetRecords(SearchCondition).QueryObjects;
            List<object> records = null;

            records = (from item in items
                       where item.Count > item.Received && DateTime.Today.AddDays(7) < item.DemandDate
                       orderby item.DemandDate ascending, item.OrderID ascending
                       select (object)item).ToList();
            btnNormal.Tag = records;
            btnNormal.Text = string.Format("非紧急采购项 ({0})", records == null ? 0 : records.Count);

            records = (from item in items
                       where item.Count > item.Received && DateTime.Today <= item.DemandDate && DateTime.Today.AddDays(7) >= item.DemandDate
                       orderby item.DemandDate ascending, item.OrderID ascending
                       select (object)item).ToList();
            btnAlert.Tag = records;
            btnAlert.Text = string.Format("即将交货采购项 ({0})", records == null ? 0 : records.Count);

            records = (from item in items
                       where item.Count > item.Received && item.DemandDate < DateTime.Today
                       orderby item.DemandDate ascending, item.OrderID ascending
                       select (object)item).ToList();
            btnOverDate.Tag = records;
            btnOverDate.Text = string.Format("逾期未到货项 ({0})", records == null ? 0 : records.Count);

            records = (from item in items
                       where item.Count <= item.Received
                       orderby item.DemandDate ascending, item.OrderID ascending
                       select (object)item).ToList();
            btnReceivedAll.Tag = records;
            btnReceivedAll.Text = string.Format("已全部到货项 ({0})", records == null ? 0 : records.Count);

            records = (from item in items
                       orderby item.DemandDate ascending, item.OrderID ascending
                       select (object)item).ToList();
            btnAll.Tag = records;
            btnAll.Text = string.Format("全部 ({0})", records == null ? 0 : records.Count);

            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            PurchaseItemRecord c = item as PurchaseItemRecord;
            row.Tag = c;
            row.Cells["colSheetNo"].Value = c.PurchaseID;
            row.Cells["colProduct"].Value = c.Product.Name;
            row.Cells["colSpecification"].Value = c.Product.Specification;
            row.Cells["colCount"].Value = c.Count.Trim();
            row.Cells["colDemandDate"].Value = c.DemandDate.ToLongDateString();
            row.Cells["colReceived"].Value = c.Received.Trim();
            row.Cells["colMissing"].Value = c.OnWay.Trim();
            row.Cells["colBuyer"].Value = c.Buyer;
            row.Cells["colMemo"].Value = c.Memo;
        }
        #endregion

        #region 事件处理方法
        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FrmPurchaseOrderDetail detailForm = new FrmPurchaseOrderDetail();
                detailForm.IsAdding = true;
                detailForm.ItemAdded += new EventHandler<ItemAddedEventArgs>(frmPurchaseSheetDetail_ItemAdded);
                detailForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PurchaseItemRecord record = dataGridView1.Rows[e.RowIndex].Tag as PurchaseItemRecord;
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colSheetNo")
                {
                    PurchaseOrder sheet = (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).GetByID(record.PurchaseID).QueryObject;
                    if (sheet != null)
                    {
                        FrmPurchaseOrderDetail frm = new FrmPurchaseOrderDetail();
                        frm.IsAdding = false;
                        frm.UpdatingItem = sheet;
                        frm.ItemUpdated += new EventHandler<ItemUpdatedEventArgs>(frmPurchaseSheetDetail_ItemUpdated);
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void frmPurchaseSheetDetail_ItemAdded(object sender, ItemAddedEventArgs e)
        {
            btn_Fresh.PerformClick();
        }

        private void frmPurchaseSheetDetail_ItemUpdated(object sender, ItemUpdatedEventArgs e)
        {
            btn_Fresh.PerformClick();
        }
        #endregion

        private void btn_WaitPurchase_Click(object sender, EventArgs e)
        {
            //if (this.Tag  != null && this.Tag is IMyMDIForm)
            //{
            //    (this.Tag as IMyMDIForm).ShowSingleForm(typeof(FrmOrderItemSelection));
            //}
            //else
            //{
                FrmOrderRecordSelection frm = new FrmOrderRecordSelection();
                frm.Show();
            //}
        }
    }
}

