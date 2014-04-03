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
using LJH.Inventory.UI.ExcelExporter;
using LJH.Inventory.UI.Report;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmDeliverySheetMaster : FrmMasterBase
    {
        public FrmDeliverySheetMaster()
        {
            InitializeComponent();
        }

        #region 私有方法
        
        #endregion

        #region 重写基类方法和处理事件
        protected override void Init()
        {
            base.Init();
            btnAll.BackColor = SystemColors.ControlDark;

            menu.Items["btn_Add"].Enabled = OperatorInfo.CurrentOperator.Permit(Permission.EditDeliverySheet);
            dataGridView1.Columns["colAmount"].Visible = OperatorInfo.CurrentOperator.Permit(Permission.ReadPrice);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmDetailBase frm= new FrmDeliverySheetDetail();
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            List<DeliverySheet> items = (new DeliverySheetBLL(AppSettings.CurrentSetting.ConnStr)).GetItems(null).QueryObjects;
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
                       where o.State == SheetState.Shipped 
                       select (object)o).ToList();
            btnDelivery.Tag = records;
            btnDelivery.Text = string.Format("发货 ({0})", records == null ? 0 : records.Count);

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
            DeliverySheet sheet = item as DeliverySheet;
            row.Tag = sheet;
            row.Cells["colSheetNo"].Value = sheet.ID;
            row.Cells["colCustomer"].Value = sheet.Customer.Name ;
            row.Cells["colWareHouse"].Value = sheet.WareHouse != null ? sheet.WareHouse.Name : string.Empty;
            row.Cells["colAmount"].Value = sheet.Amount;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(sheet.State);
            row.Cells["colLinker"].Value = sheet.Linker;
            row.Cells["colTelphone"].Value = sheet.LinkerPhoneCall;
            row.Cells["colAddress"].Value = sheet.Address;
            row.Cells["colWithTax"].Value = sheet.IsWithTax;
            row.Cells["colMemo"].Value = sheet.Memo;
            if (sheet.State == SheetState.Canceled)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }

        protected override bool DeletingItem(object item)
        {
            MessageBox.Show("不能删除送货单,可以将送货单作废", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }
        #endregion

        #region 事件处理程序
        private void chkSheetState_CheckedChanged(object sender, EventArgs e)
        {
            //if (!chkShipWait.Checked && !chkApproved.Checked && !chkShipped.Checked && !chkCancel.Checked)
            //{
            //    MessageBox.Show("请至少指定一种送货单状态");
            //    (sender as CheckBox).Checked = true;
            //}
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DeliverySheet sheet = dataGridView1.Rows[e.RowIndex].Tag as DeliverySheet;
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colPaid")
                {
                    FrmReceivablePaymentAssigns frm = new FrmReceivablePaymentAssigns();
                    frm.ReceivableID = sheet.ID;
                    frm.ShowDialog();
                }
                else if (dataGridView1.Columns[e.ColumnIndex].Name == "colOrder")
                {
                    //if (!string.IsNullOrEmpty(sheet.OrderID))
                    //{
                    //    Order order = (new OrderBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheet.OrderID).QueryObject;
                    //    if (order != null)
                    //    {
                    //        FrmOrderDetail frm = new FrmOrderDetail();
                    //        frm.IsAdding = false;
                    //        frm.IsForView = true;
                    //        frm.UpdatingItem = order;
                    //        frm.ShowDialog();
                    //    }
                    //}
                }
            }
        }
        #endregion
    }
}
