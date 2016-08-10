using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Diagnostics;
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
            this.txtCustomer.Tag = Customer;
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
            txtWarehouse.SelectedWareHouseID = item.WareHouseID;
            this.txtMemo.Text = item.Memo;
            ShowDeliveryItemsOnGrid(item);
            ShowOperations(item.ID, item.DocumentType, dataGridView1);
            ShowAttachmentHeaders(item.ID, item.DocumentType, this.gridAttachment);
            ShowPaymentState(item);
        }

        private void ShowPaymentState(StackOutSheet item)
        {
            var finance = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetFinancialStateOf(item.ID).QueryObject;
            if (finance != null) lnkPayment.Text = finance.Paid.ToString("C2");
        }

        private void ShowDeliveryItemsOnGrid(StackOutSheet sheet)
        {
            ItemsGrid.Rows.Clear();
            var items = sheet.GetSummaryItems();
            if (items != null)
            {
                ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                con.IDS = items.Select(it => it.InventoryItem.Value).ToList();
                var pis = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
                foreach (StackOutItem item in items)
                {
                    int row = ItemsGrid.Rows.Add();
                    ShowDeliveryItemOnRow(ItemsGrid.Rows[row], item, pis.SingleOrDefault(it => it.ID == item.InventoryItem));
                }
                int r = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[r].Cells["colCategory"].Value = "合计";
                ItemsGrid.Rows[r].Cells["colWeight"].Value = sheet.TotalWeight;
                ItemsGrid.Rows[r].Cells["colCount"].Value = items.Count;
                ItemsGrid.Rows[r].Cells["colTotal"].Value = sheet.Amount;
            }
        }

        private void ShowDeliveryItemOnRow(DataGridViewRow row, StackOutItem item, ProductInventoryItem pi)
        {
            row.Tag = item;
            if (pi != null)
            {
                Product p = pi.Product;
                row.Cells["colHeader"].Value = this.ItemsGrid.Rows.Count;
                row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
                row.Cells["colCategory"].Value = p != null && p.Category != null ? p.Category.Name : string.Empty;
                row.Cells["colMaterial"].Value = pi != null ? pi.Material : null;
            }
            else
            {
                Product p = new ProductBLL(AppSettings.Current.ConnStr).GetByID(item.ProductID).QueryObject;
                row.Cells["colHeader"].Value = this.ItemsGrid.Rows.Count;
                row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
                row.Cells["colCategory"].Value = p != null && p.Category != null ? p.Category.Name : string.Empty;
            }
            row.Cells["colLength"].Value = item.Length;
            row.Cells["colWeight"].Value = item.TotalWeight;
            row.Cells["colPrice"].Value = item.Price;
            row.Cells["colCount"].Value = item.Count;
            row.Cells["colTotal"].Value = item.Amount;
            row.Cells["colMemo"].Value = item.Memo;
            row.Cells["colCount"].ReadOnly = true;
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
                MessageBox.Show("请选择是否含税");
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
            this.txtWarehouse.Init();
            this.txtSheetNo.Text = _AutoCreate;
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
            sheet.SheetDate = dtSheetDate.Value;
            sheet.Linker = txtLinker.Text.Trim();
            sheet.LinkerCall = txtLinkerPhone.Text.Trim();
            sheet.Address = txtAddress.Text.Trim();
            sheet.DriverCall = txtDriverCall.Text;
            sheet.Driver = txtDriver.Text;
            sheet.CarPlate = txtCarPlate.Text;
            sheet.DeadlineDate = chkDeadline.Checked ? (DateTime?)dtDeadline.Value : null;
            sheet.WareHouseID = txtWarehouse.SelectedWareHouseID;
            if (rdWithTax.Checked) sheet.WithTax = true;
            if (rdWithoutTax.Checked) sheet.WithTax = false;
            sheet.Memo = txtMemo.Text;
            return sheet;
        }

        protected override void ShowButtonState()
        {
            ShowButtonState(this.toolStrip1);
            btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Edit);
            btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Nullify);
            btnPrint.Enabled = btnPrint.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Print);
            btnShip.Enabled = btnShip.Enabled && Operator.Current.Permit(Permission.DeliverySheet, PermissionActions.Ship);
            btnPayment.Enabled = btnPayment.Enabled && Operator.Current.Permit(Permission.CustomerPayment, PermissionActions.Edit);
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

        private void btnPayment_Click(object sender, EventArgs e)
        {
            var sheet = UpdatingItem as StackOutSheet;
            if (sheet == null || sheet.State == SheetState.Canceled) return;
            if (string.IsNullOrEmpty(sheet.ID))
            {
                MessageBox.Show("请先保存送货单后再支付");
                return;
            }
            Financial.FrmCustomerPaymentDetail frm = new Financial.FrmCustomerPaymentDetail();
            frm.PaymentType = CustomerPaymentType.Customer;
            frm.Customer = (txtCustomer.Tag as CompanyInfo);
            frm.StackSheetID = sheet.ID;
            frm.IsAdding = true;
            frm.ShowDialog();
            ShowPaymentState(sheet);
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
                try
                {
                    if (sheet.State == SheetState.Add)
                    {
                        var ret = new StackOutSheetBLL(AppSettings.Current.ConnStr).ProcessSheet(sheet, SheetOperation.Modify, Operator.Current.Name, Operator.Current.ID);
                        if (ret.Result != ResultCode.Successful)
                        {
                            MessageBox.Show(ret.Message);
                            return;
                        }
                        else
                        {
                            this.OnItemUpdated(new LJH.GeneralLibrary.Core.UI.ItemUpdatedEventArgs(sheet));
                        }
                    }
                    string modal = System.IO.Path.Combine(Application.StartupPath, "送货单模板.xls");
                    Print.StackOutSheetExporter exporter = null;
                    if (System.IO.File.Exists(modal))
                    {
                        exporter = new Print.StackOutSheetExporter(modal);
                        var files = exporter.Export(sheet, LJH.GeneralLibrary.TempFolderManager.GetCurrentFolder());
                        foreach (var file in files)
                        {
                            if (System.IO.File.Exists(file))
                            {
                                ProcessStartInfo psi = new ProcessStartInfo(file);
                                psi.Verb = "Print";
                                psi.CreateNoWindow = true;
                                psi.WindowStyle = ProcessWindowStyle.Hidden;
                                psi.UseShellExecute = true;

                                Process prs = new Process();
                                prs.StartInfo = psi;
                                prs.Start();
                                LJH.GeneralLibrary.LOG.FileLog.Log("打印", file);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("未找到送货单导出模板", "打印失败");
                    }
                }
                catch (Exception ex)
                {
                    LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                }
            }
        }

        private void btnShip_Click(object sender, EventArgs e)
        {
            StackOutSheetBLL bll = new StackOutSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackOutSheet>(bll, SheetOperation.StackOut);
            StackOutSheet sheet = UpdatingItem as StackOutSheet;
            if (sheet.State == SheetState.Shipped)
            {
                new StackOutSheetBLL(AppSettings.Current.ConnStr).AssignPayment(sheet);
                ShowPaymentState(sheet);
            }
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
                if (c.DefaultLinker != null)
                {
                    var contact = new ContactBLL(AppSettings.Current.ConnStr).GetByID(c.DefaultLinker.Value).QueryObject;
                    if (contact != null)
                    {
                        txtLinker.Text = contact.Name;
                        txtLinkerPhone.Text = contact.Mobile;
                    }
                }
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Text = string.Empty;
            txtCustomer.Tag = null;
            txtLinker.Text = string.Empty;
            txtLinkerPhone.Text = string.Empty;
        }

        private void ItemsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = ItemsGrid.Rows[e.RowIndex];
            StackOutItem item = row.Tag as StackOutItem;
            if (item == null) return; //表示合计行
            StackOutSheet sheet = UpdatingItem as StackOutSheet;
            DataGridViewColumn col = ItemsGrid.Columns[e.ColumnIndex];
            if (col.Name == "colMemo")
            {
                foreach (var it in sheet.Items)
                {
                    if (it.ProductID == item.ProductID) it.Memo = row.Cells["colMemo"].Value != null ? row.Cells["colMemo"].Value.ToString() : null;
                }
            }
            else
            {
                decimal value;
                if (row.Cells[e.ColumnIndex].Value != null && decimal.TryParse(row.Cells[e.ColumnIndex].Value.ToString().TrimStart('¥'), out value))
                {
                    if (value < 0) value = 0;
                    if (col.Name == "colPrice")
                    {
                        item.Price = value;
                        row.Cells[e.ColumnIndex].Value = value;
                        row.Cells["colTotal"].Value = item.Amount;
                    }
                    else if (col.Name == "colWeight")
                    {
                        item.TotalWeight = value > 0 ? (decimal?)value : null;
                        row.Cells[e.ColumnIndex].Value = value;
                        row.Cells["colTotal"].Value = item.Amount;
                    }
                    ItemsGrid.Rows[ItemsGrid.Rows.Count - 1].Cells["colTotal"].Value = sheet.Amount;
                    ItemsGrid.Rows[ItemsGrid.Rows.Count - 1].Cells["colWeight"].Value = sheet.TotalWeight;
                }
            }
        }

        private void mnu_AddSteelRoll_Click(object sender, EventArgs e)
        {
            FrmSteelRollSelection frm = new FrmSteelRollSelection();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var sheet = UpdatingItem as StackOutSheet;
                List<ProductInventoryItem> srs = frm.SelectedItems;
                if (srs != null && srs.Count > 0)
                {
                    foreach (var sr in srs)
                    {
                        if (sheet.Items != null && sheet.Items.Exists(it => it.InventoryItem == sr.ID)) continue; //原材料只加一次
                        sheet.AddItems(sr, 1);
                    }
                    ShowDeliveryItemsOnGrid(sheet);
                }
            }
        }

        private void mnu_Remove_Click(object sender, EventArgs e)
        {
            if (ItemsGrid.SelectedCells.Count > 0)
            {
                StackOutSheet sheet = UpdatingItem as StackOutSheet;
                foreach (DataGridViewCell cell in ItemsGrid.SelectedCells)
                {
                    var row = ItemsGrid.Rows[cell.RowIndex];
                    if (row.Tag != null)
                    {
                        StackOutItem si = row.Tag as StackOutItem;
                        if (si.ID == Guid.Empty)
                        {
                            sheet.Items.RemoveAll(it => it.ProductID == si.ProductID);
                        }
                        else
                        {
                            sheet.Items.Remove(si);
                        }
                    }
                }
                ShowDeliveryItemsOnGrid(sheet);
            }
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
