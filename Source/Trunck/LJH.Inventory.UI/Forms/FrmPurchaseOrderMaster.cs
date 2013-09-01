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

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            btnAll.BackColor = SystemColors.ControlDark;
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            dataGridView1.Columns["colAmount"].Visible = OperatorInfo.CurrentOperator.Permit(Permission.ReadPrice);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmPurchaseOrderDetail frm = new FrmPurchaseOrderDetail();
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            List<PurchaseOrder> items = (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(null).QueryObjects;
            List<PurchaseOrder> temp = new List<PurchaseOrder>();
            List<object> records = null;
            temp.AddRange(items);

            records = (from o in temp
                       where o.State == SheetState.Canceled
                       select (object)o).ToList();
            btnCanceled.Tag = records;
            btnCanceled.Text = string.Format("作废 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.State == SheetState.Canceled);

            records = (from o in temp
                       where o.State == SheetState.Closed
                       select (object)o).ToList();
            btnClosed.Tag = records;
            btnClosed.Text = string.Format("关闭 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.State == SheetState.Closed);

            records = (from o in temp
                       where o.IsCompleteAll
                       select (object)o).ToList();
            btnCompleteAll.Tag = records;
            btnCompleteAll.Text = string.Format("全部交货 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.IsCompleteAll);

            records = (from o in temp
                       where o.IsOverDate
                       select (object)o).ToList();
            btnOverDate.Tag = records;
            btnOverDate.Text = string.Format("逾期未交 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.IsOverDate);

            records = (from o in temp
                       where o.IsEmergency
                       select (object)o).ToList();
            btnEmergency.Tag = records;
            btnEmergency.Text = string.Format("即将交货 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.IsEmergency);

            records = (from o in temp
                       where !o.IsEmergency
                       select (object)o).ToList();
            btnNonEmergency.Tag = records;
            btnNonEmergency.Text = string.Format("非紧急 ({0})", records == null ? 0 : records.Count);
            temp.RemoveAll(o => o.IsEmergency);

            records = (from o in items
                       select (object)o).ToList();
            btnAll.Tag = records;
            btnAll.Text = string.Format("全部 ({0})", records == null ? 0 : records.Count);
            return records;
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
            CommandResult ret = (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnectString)).Delete(sheet);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
