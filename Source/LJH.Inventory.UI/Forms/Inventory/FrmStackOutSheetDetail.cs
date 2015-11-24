using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary.Core.DAL;
using LJH.Inventory.UI.Forms.Sale;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Sale.View;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmStackOutSheetDetail : FrmSheetDetailBase
    {
        #region 构造函数
        public FrmStackOutSheetDetail()
        {
            InitializeComponent();
        }

        #endregion

        #region 私有方法
        private void ShowSheet(StackOutSheet item)
        {
            if (!string.IsNullOrEmpty(item.ID))
            {
                this.txtSheetNo.Text = item.ID;
                this.txtSheetNo.Enabled = false;
            }
            var Customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.CustomerID).QueryObject;
            this.txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            var WareHouse = (new WareHouseBLL(AppSettings.Current.ConnStr)).GetByID(item.WareHouseID).QueryObject;
            this.txtWareHouse.Text = WareHouse != null ? WareHouse.Name : string.Empty;
            dtSheetDate.Value = item.SheetDate;
            this.txtLinker.Text = item.Linker;
            this.txtLinkerPhone.Text = item.LinkerCall;
            this.txtAddress.Text = item.Address;
            txtDriver.Text = item.Driver;
            txtDriverCall.Text = item.DriverCall;
            txtCarPlate.Text = item.CarPlate;
            chkDeadline.Checked = item.DeadlineDate.HasValue;
            dtDeadline.Value = item.DeadlineDate.HasValue ? item.DeadlineDate.Value : DateTime.Today;
            rdWithoutTax.Checked = item.WithTax == false;
            rdWithTax.Checked = item.WithTax == true;
            this.txtMemo.Text = item.Memo;
            ShowDeliveryItemsOnGrid(item);
            ShowOperations(item.ID, item.DocumentType, dataGridView1);
            ShowAttachmentHeaders(item.ID, item.DocumentType, this.gridAttachment);
        }

        private void ShowDeliveryItemsOnGrid(StackOutSheet sheet)
        {
            ItemsGrid.Rows.Clear();
            var items = sheet.GetSummaryItems();
            if (items != null)
            {
                foreach (StackOutItem item in items)
                {
                    int row = ItemsGrid.Rows.Add();
                    ShowDeliveryItemOnRow(ItemsGrid.Rows[row], item);
                }
                int r = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[r].Cells["colCount"].Value = "合计";
                ItemsGrid.Rows[r].Cells["colTotal"].Value = sheet.Amount;
            }
        }

        private void ShowDeliveryItemOnRow(DataGridViewRow row, StackOutItem item)
        {
            row.Tag = item;
            Product p = new ProductBLL(AppSettings.Current.ConnStr).GetByID(item.ProductID).QueryObject;
            row.Cells["colHeader"].Value = this.ItemsGrid.Rows.Count;
            row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
            row.Cells["colCategory"].Value = p != null && p.Category != null ? p.Category.Name : string.Empty;
            row.Cells["colModel"].Value = p.Model;
            row.Cells["colLength"].Value = item.Length;
            row.Cells["colWeight"].Value = item.Weight;
            row.Cells["colPrice"].Value = item.Price;
            row.Cells["colCount"].Value = item.Count;
            row.Cells["colTotal"].Value = item.CalAmount();
            row.Cells["colMemo"].Value = item.Memo;
        }

        private List<StackOutItem> GetDeliveryItemsFromGrid()
        {
            List<StackOutItem> items = new List<StackOutItem>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) items.Add(row.Tag as StackOutItem);
            }
            return items;
        }

        private decimal GetTotalAmount()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) sum += (row.Tag as StackOutItem).CalAmount();
            }
            return sum;
        }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtSheetNo.Text) && UpdatingItem != null)
            {
                MessageBox.Show("送货单号不能为空");
                txtSheetNo.Focus();
                return false;
            }
            if (txtCustomer.Tag == null)
            {
                MessageBox.Show("没有选择客户");
                txtCustomer.Focus();
                return false;
            }
            if (!rdWithTax.Checked && !rdWithoutTax.Checked)
            {
                MessageBox.Show("请选择是否是含税价");
                return false;
            }
            if (ItemsGrid.Rows.Count == 0)
            {
                MessageBox.Show("送货单没有填写送货项");
                return false;
            }
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                StackOutItem item = row.Tag as StackOutItem;
                if (item != null && item.Count == 0)
                {
                    MessageBox.Show(string.Format("送货单第 {0} 项送货数量为零", row.Index + 1));
                    row.Selected = true;
                    return false;
                }
            }
            return true;
        }

        protected override void InitControls()
        {
            base.InitControls();
            this.txtSheetNo.Text = _AutoCreate;
            btn_AddSlice.Visible = !UserSettings.Current.ForbidWhenNoOrderID;
            if (IsForView)
            {
                toolStrip1.Enabled = false;
                ItemsGrid.ReadOnly = true;
                ItemsGrid.ContextMenu = null;
                ItemsGrid.ContextMenuStrip = null;
            }
        }

        protected override void ItemShowing()
        {
            StackOutSheet sheet = UpdatingItem as StackOutSheet;
            if (sheet != null) ShowSheet(sheet);
        }

        protected override object GetItemFromInput()
        {
            StackOutSheet sheet = UpdatingItem as StackOutSheet;
            sheet.ID = txtSheetNo.Text == "自动创建" ? string.Empty : this.txtSheetNo.Text;
            sheet.CustomerID = txtCustomer.Tag != null ? (txtCustomer.Tag as CompanyInfo).ID : null;
            sheet.WareHouseID = txtWareHouse.Tag != null ? (txtWareHouse.Tag as WareHouse).ID : null;
            sheet.SheetDate = dtSheetDate.Value;
            sheet.Linker = txtLinker.Text.Trim();
            sheet.LinkerCall = txtLinkerPhone.Text.Trim();
            sheet.Address = txtAddress.Text.Trim();
            sheet.DriverCall = txtDriverCall.Text;
            sheet.Driver = txtDriver.Text;
            sheet.CarPlate = txtCarPlate.Text;
            sheet.DeadlineDate = chkDeadline.Checked ? (DateTime?)dtDeadline.Value : null;
            if (rdWithTax.Checked) sheet.WithTax = true;
            if (rdWithoutTax.Checked) sheet.WithTax = false;
            sheet.Memo = txtMemo.Text;
            return sheet;
        }

        protected override void ShowButtonState()
        {
            ShowButtonState(this.toolStrip1);
            btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Edit);
            btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Approve);
            btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.UndoApprove);
            btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Nullify);
            btnPrint.Enabled = Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Print);
            btnShip.Enabled = btnShip.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Ship);
            ItemsGrid.ContextMenuStrip = btnSave.Enabled ? this.contextMenuStrip1 : null;
            ItemsGrid.ReadOnly = !btnSave.Enabled;
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            StackOutSheet item = UpdatingItem as StackOutSheet;
            if (item != null) PerformAddAttach(item.ID, item.DocumentType, gridAttachment);
        }

        private void mnu_AttachmentDelete_Click(object sender, EventArgs e)
        {
            PerformDelAttach(gridAttachment);
        }

        private void mnu_AttachmentSaveAs_Click(object sender, EventArgs e)
        {
            PerformAttachSaveAs(gridAttachment);
        }

        private void mnu_AttachmentOpen_Click(object sender, EventArgs e)
        {
            PerformAttachOpen(gridAttachment);
        }

        private void gridAttachment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PerformAttachOpen(gridAttachment);
        }
        #endregion

        #region 工具栏事件处理
        private void btnSave_Click(object sender, EventArgs e)
        {
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackOutSheet>(bll, IsAdding ? SheetOperation.Create : SheetOperation.Modify);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackOutSheet>(bll, SheetOperation.Approve);
        }

        private void btnUndoApprove_Click(object sender, EventArgs e)
        {
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackOutSheet>(bll, SheetOperation.UndoApprove);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            StackOutSheet sheet = UpdatingItem as StackOutSheet;
            if (sheet != null)
            {
                Print.FrmDeliverySheetPrint frm = new Print.FrmDeliverySheetPrint();
                frm.Sheet = sheet;
                frm.ShowDialog();
            }
        }

        private void btnShip_Click(object sender, EventArgs e)
        {
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackOutSheet>(bll, SheetOperation.StackOut);
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackOutSheet>(bll, SheetOperation.Nullify);
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var c = frm.SelectedItem as CompanyInfo;
                txtCustomer.Tag = c;
                txtCustomer.Text = c != null ? c.Name : string.Empty;
                txtAddress.Text = c != null ? c.Address : string.Empty;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Text =  string.Empty;
            txtCustomer.Tag = null;
        }

        private void lnkWareHouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmWareHouseMaster frm = new FrmWareHouseMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var w = frm.SelectedItem as WareHouse;
                txtWareHouse.Tag = w;
                txtWareHouse.Text = w != null ? w.Name : string.Empty;
            }
        }

        private void txtWareHouse_DoubleClick(object sender, EventArgs e)
        {
            txtWareHouse.Tag = null;
            txtWareHouse.Text = string.Empty;
        }

        private void ItemsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn col = ItemsGrid.Columns[e.ColumnIndex];
            DataGridViewRow row = ItemsGrid.Rows[e.RowIndex];
            if (row.Tag != null)
            {
                StackOutItem item = row.Tag as StackOutItem;
                decimal value;
                if (decimal.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out value))
                {
                    if (value < 0) value = 0;
                    row.Cells[e.ColumnIndex].Value = value;
                }
                if (col.Name == "colPrice")
                {
                    item.Price = value;
                }
                else if (col.Name == "colCount")
                {
                    item.Count = value;
                }
                else if (col.Name == "colWeight")
                {
                    item.Weight = value > 0 ? (decimal?)value : null;
                }
                row.Cells["colTotal"].Value = item.CalAmount();
            }
            ItemsGrid.Rows[ItemsGrid.Rows.Count - 1].Cells["colTotal"].Value = GetTotalAmount();
        }

        private void btn_AddSlice_Click(object sender, EventArgs e)
        {
            if (txtWareHouse.Tag == null)
            {
                MessageBox.Show("请先选择出货仓库");
                return;
            }
            FrmSteelRollSliceSelection frm = new FrmSteelRollSliceSelection();
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.WareHouseID = txtWareHouse.Tag != null ? (txtWareHouse.Tag as WareHouse).ID : null;
            con.States = (int)ProductInventoryState.Inventory; //只显示在库的
            frm.SearchCondition = con;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                StackOutSheet sheet = UpdatingItem as StackOutSheet;
                var items = frm.SelectedItems;
                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        sheet.AddItems(item.Key, item.Value);
                    }
                    ShowDeliveryItemsOnGrid(sheet);
                }
            }
        }

        private void mnu_AddSteelRoll_Click(object sender, EventArgs e)
        {
            if (txtWareHouse.Tag == null)
            {
                MessageBox.Show("请先选择出货仓库");
                return;
            }
            FrmSteelRollMaster frm = new FrmSteelRollMaster();
            frm.ForSelect = true;
            ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
            con.WareHouseID = txtWareHouse.Tag != null ? (txtWareHouse.Tag as WareHouse).ID : null;
            con.States = (int)ProductInventoryState.Inventory; //只显示在库的原材料
            frm.SearchCondition = con;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ProductInventoryItem sr = frm.SelectedItem as ProductInventoryItem;
                var sheet = UpdatingItem as StackOutSheet;
                sheet.AddItems(sr, 1);
                ShowDeliveryItemsOnGrid(sheet);
            }
        }

        private void mnu_Remove_Click(object sender, EventArgs e)
        {
            if (ItemsGrid.SelectedRows.Count > 0)
            {
                List<StackOutItem> items = GetDeliveryItemsFromGrid();
                foreach (DataGridViewRow row in ItemsGrid.SelectedRows)
                {
                    if (row.Tag != null) items.Remove(row.Tag as StackOutItem);
                }
                ShowDeliveryItemsOnGrid(UpdatingItem as StackOutSheet);
            }
        }

        private void btnPaymentAssign_Click(object sender, EventArgs e)
        {
            //if (UpdatingItem != null)
            //{
            //    DeliverySheet sheet = UpdatingItem as DeliverySheet;
            //    if (sheet.Payable)
            //    {
            //        FrmPaymentAssign frm = new FrmPaymentAssign();
            //        frm.CustomerID = sheet.CustomerID;
            //        frm.ReceivableID = sheet.ID;
            //        frm.Receivables = sheet.Receivables;
            //        if (frm.ShowDialog() == DialogResult.OK)
            //        {
            //            DeliverySheet sheet1 = (new DeliverySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheet.ID).QueryObject;
            //            this.UpdatingItem = sheet1;
            //            ItemShowing();
            //            ShowButtonState();
            //            this.OnItemUpdated(new ItemUpdatedEventArgs(sheet1));
            //        }
            //    }
            //}
        }

        private void lnkLinker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCustomer.Tag != null)
            {
                FrmContactMaster frm = new FrmContactMaster();
                ContactSearchCondition con = new ContactSearchCondition();
                con.CompanyID = (txtCustomer.Tag as CompanyInfo).ID;
                frm.SearchCondition = con;
                frm.ForSelect = true;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Contact c = frm.SelectedItem as Contact;
                    txtLinker.Text = c.Name;
                    txtLinkerPhone.Text = c.Mobile;
                }
            }
            else
            {
                MessageBox.Show("请先选择客户");
            }
        }

        private void lnkDriver_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmStaffMaster frm = new FrmStaffMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Staff s = frm.SelectedItem as Staff;
                txtDriver.Text = s.Name;
                txtDriverCall.Text = s.Phone;
            }
        }
        #endregion
    }
}
