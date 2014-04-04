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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmInventorySheetMaster : FrmMasterBase
    {
        public FrmInventorySheetMaster()
        {
            InitializeComponent();
        }

        #region 私有方法
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            btnAll.BackColor = SystemColors.ControlDark;
            Operator opt = Operator.Current;
        }

        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmInventorySheetDetail();
        }

        protected override List<object> GetDataSource()
        {
            List<InventorySheet> items = (new InventorySheetBLL(AppSettings.CurrentSetting.ConnStr)).GetItems(null).QueryObjects;
            List<object> records = null;

            records = (from o in items
                       where o.State == SheetState.Add
                       select (object)o).ToList();
            btnAdd.Tag = records;
            btnAdd.Text = string.Format("新建 ({0})", records == null ? 0 : records.Count);

            records = (from o in items
                       where o.State == SheetState.Approved
                       select (object)o).ToList();
            btnApprove.Tag = records;
            btnApprove.Text = string.Format("审核 ({0})", records == null ? 0 : records.Count);

            records = (from o in items
                       where o.State == SheetState.Inventory
                       select (object)o).ToList();
            btnInventory.Tag = records;
            btnInventory.Text = string.Format("收货 ({0})", records == null ? 0 : records.Count);

            records = (from o in items
                       where o.State == SheetState.Closed
                       select (object)o).ToList();
            btnClosed.Tag = records;
            btnClosed.Text = string.Format("关闭 ({0})", records == null ? 0 : records.Count);

            records = (from o in items
                       where o.State == SheetState.Canceled
                       select (object)o).ToList();
            btnCanceled.Tag = records;
            btnCanceled.Text = string.Format("作废 ({0})", records == null ? 0 : records.Count);

            records = (from o in items
                       select (object)o).ToList();
            btnAll.Tag = records;
            btnAll.Text = string.Format("全部 ({0})", records == null ? 0 : records.Count);
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            InventorySheet sheet = item as InventorySheet;
            row.Cells["colSheetNo"].Value = sheet.ID;
            row.Cells["colWareHouseName"].Value = sheet.WareHouse.Name;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(sheet.State);
            row.Cells["colSupplier"].Value = sheet.Supplier.Name;
            row.Cells["colAmount"].Value = sheet.Amount.Trim();
            row.Cells["colMemo"].Value = sheet.Memo;
            if (sheet.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //if (UpdatingItem != null)
            //{
            //    if (MessageBox.Show("是否将此收货单作废?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //    {
            //        InventorySheet sheet = UpdatingItem as InventorySheet;
            //        CommandResult ret = (new InventorySheetBLL(AppSettings.CurrentSetting.ConnectString)).Nullify(sheet.ID, OperatorInfo.CurrentOperator.OperatorName);
            //        if (ret.Result == ResultCode.Successful)
            //        {
            //            InventorySheet sheet1 = (new InventorySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheet.ID).QueryObject;
            //            this.UpdatingItem = sheet1;
            //            ItemShowing();
            //            ShowButtonState();
            //            this.OnItemUpdated(new ItemUpdatedEventArgs(sheet1));
            //        }
            //        else
            //        {
            //            MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //}
        }
    }
}
