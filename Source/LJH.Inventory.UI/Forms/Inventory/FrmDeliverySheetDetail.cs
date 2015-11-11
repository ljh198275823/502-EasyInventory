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
    public partial class FrmDeliverySheetDetail : FrmSheetDetailBase
    {
        #region 构造函数
        public FrmDeliverySheetDetail()
        {
            InitializeComponent();
        }

        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置要发货的客户
        /// </summary>
        public CompanyInfo Customer { get; set; }
        /// <summary>
        /// 获取或设置发货的订单,用于增加送货单时指定要发货的订单
        /// </summary>
        public Order Order { get; set; }
        /// <summary>
        /// 获取或设置仓库
        /// </summary>
        public WareHouse WareHouse { get; set; }
        #endregion

        #region 私有方法
        private void ShowDeliveryItemsOnGrid(IEnumerable<StackOutItem> items)
        {
            ItemsGrid.Rows.Clear();
            if (items != null)
            {
                List<string> pids = items.Select(it => it.ProductID).ToList();
                List<Product> ps = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(new ProductSearchCondition() { ProductIDS = pids }).QueryObjects;
                foreach (StackOutItem item in items)
                {
                    int row = ItemsGrid.Rows.Add();
                    Product p = ps.SingleOrDefault(it => it.ID == item.ProductID);
                    ShowDeliveryItemOnRow(ItemsGrid.Rows[row], item, p);
                }
                int r = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[r].Cells["colCount"].Value = "合计";
                ItemsGrid.Rows[r].Cells["colTotal"].Value = items.Sum(it => it.Amount);
            }
        }

        private void ShowDeliveryItemOnRow(DataGridViewRow row, StackOutItem item, Product p)
        {
            row.Tag = item;
            row.Cells["colHeader"].Value = this.ItemsGrid.Rows.Count;
            row.Cells["colProductID"].Value = item.ProductID;
            row.Cells["colProductName"].Value = p != null ? p.Name : string.Empty;
            row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
            row.Cells["colCategory"].Value = p != null && p.Category != null ? p.Category.Name : string.Empty;
            row.Cells["colUnit"].Value = item.Unit;
            row.Cells["colPrice"].Value = item.Price;
            row.Cells["colCount"].Value = item.Count;
            row.Cells["colTotal"].Value = item.Amount;
            row.Cells["colOrderID"].Value = item.OrderID;
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
                if (row.Tag != null) sum += (row.Tag as StackOutItem).Amount;
            }
            return sum;
        }

        private void ShowSheet(StackOutSheet item)
        {
            if (!string.IsNullOrEmpty(item.ID))
            {
                this.txtSheetNo.Text = item.ID;
                this.txtSheetNo.Enabled = false;
            }
            Customer = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.CustomerID).QueryObject;
            this.txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            if (item.ClassID == StackOutSheetType.DeliverySheet) this.cmbSheetType.SelectedIndex = 0;
            if (item.ClassID == StackOutSheetType.CustomerBorrow) this.cmbSheetType.SelectedIndex = 1;
            this.cmbSheetType.Enabled = false;
            WareHouse = (new WareHouseBLL(AppSettings.Current.ConnStr)).GetByID(item.WareHouseID).QueryObject;
            this.txtWareHouse.Text = WareHouse != null ? WareHouse.Name : string.Empty;
            dtSheetDate.Value = item.SheetDate;
            this.txtLinker.Text = item.Linker;
            this.txtLinkerPhone.Text = item.LinkerPhoneCall;
            this.txtAddress.Text = item.Address;
            this.txtMemo.Text = item.Memo;
            ShowDeliveryItemsOnGrid(item.Items);
            ShowOperations(item.ID, item.DocumentType, dataGridView1);
            ShowAttachmentHeaders(item.ID, item.DocumentType, this.gridAttachment);
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
            if (Customer == null)
            {
                MessageBox.Show("没有选择客户");
                txtCustomer.Focus();
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
            txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
            txtWareHouse.Text = WareHouse != null ? WareHouse.Name : string.Empty;
            cmbSheetType.SelectedIndex = 0;
            btn_AddItem.Visible = !UserSettings.Current.ForbidWhenNoOrderID;
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
            if (sheet == null)
            {
                sheet = new StackOutSheet();
                sheet.ID = txtSheetNo.Text == "自动创建" ? string.Empty : this.txtSheetNo.Text;
                sheet.ClassID = StackOutSheetType.DeliverySheet;
            }
            else
            {
                sheet = UpdatingItem as StackOutSheet;
            }
            sheet.CustomerID = Customer != null ? Customer.ID : null;
            if (cmbSheetType.SelectedIndex == 0) sheet.ClassID = StackOutSheetType.DeliverySheet;
            if (cmbSheetType.SelectedIndex == 1) sheet.ClassID = StackOutSheetType.CustomerBorrow;
            sheet.WareHouseID = WareHouse != null ? WareHouse.ID : null;
            sheet.SheetDate = dtSheetDate.Value;
            sheet.Linker = txtLinker.Text.Trim();
            sheet.LinkerPhoneCall = txtLinkerPhone.Text.Trim();
            sheet.Address = txtAddress.Text.Trim();
            sheet.Memo = txtMemo.Text;
            sheet.Items = new List<StackOutItem>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null)
                {
                    StackOutItem item = row.Tag as StackOutItem;
                    item.SheetNo = sheet.ID;
                    sheet.Items.Add(item);
                }
            }
            return sheet;
        }

        protected override CommandResult AddItem(object item)
        {
            return (new StackOutSheetBLL(AppSettings.Current.ConnStr)).ProcessSheet(item as StackOutSheet, SheetOperation.Create, Operator.Current.Name, Operator.Current.ID);
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new StackOutSheetBLL(AppSettings.Current.ConnStr)).ProcessSheet(item as StackOutSheet, SheetOperation.Modify, Operator.Current.Name, Operator.Current.ID);
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

        #region 公共方法
        public void AddDeliveryItem(SteelRollSlice p)
        {
            List<StackOutItem> sources = GetDeliveryItemsFromGrid();
            if (!sources.Exists(it => it.ProductID == p.ProductID))
            {
                StackOutItem item = new StackOutItem();
                item.ID = Guid.NewGuid();
                item.ProductID = p.ProductID;
                item.Unit = p.Unit;
                item.Price = p.Product != null ? p.Product.Price : 0;
                item.Count = 0;
                item.Amount = item.Price * item.Count;
                sources.Add(item);
            }
            ShowDeliveryItemsOnGrid(sources);
        }

        public void AddDeliveryItem(OrderItemRecord oi)
        {
            List<StackOutItem> sources = GetDeliveryItemsFromGrid();
            if (!sources.Exists(it => it.OrderItem != null && it.OrderItem.Value == oi.ID))
            {
                StackOutItem item = new StackOutItem();
                item.ID = Guid.NewGuid();
                item.ProductID = oi.ProductID;
                item.Unit = oi.Unit;
                item.Price = oi.Price;
                item.Count = oi.NotShipped;
                item.Amount = item.Price * item.Count;
                item.OrderItem = oi.ID;
                item.OrderID = oi.SheetNo;
                sources.Add(item);
            }
            ShowDeliveryItemsOnGrid(sources);
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
                txtAddress.Text = Customer != null ? Customer.Address : string.Empty;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            Customer = null;
            txtCustomer.Text = Customer != null ? Customer.Name : string.Empty;
        }

        private void lnkWareHouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmWareHouseMaster frm = new FrmWareHouseMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                WareHouse = frm.SelectedItem as WareHouse;
                txtWareHouse.Text = WareHouse != null ? WareHouse.Name : string.Empty;
            }
        }

        private void txtWareHouse_DoubleClick(object sender, EventArgs e)
        {
            WareHouse = null;
            txtWareHouse.Text = WareHouse != null ? WareHouse.Name : string.Empty;
        }

        private void ItemsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn col = ItemsGrid.Columns[e.ColumnIndex];
            DataGridViewRow row = ItemsGrid.Rows[e.RowIndex];
            if (row.Tag != null)
            {
                StackOutItem item = row.Tag as StackOutItem;
                if (col.Name == "colPrice")
                {
                    decimal price;
                    if (decimal.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out price))
                    {
                        if (price < 0) price = 0;
                        item.Price = price;
                        item.Amount = price * item.Count;
                        row.Cells[e.ColumnIndex].Value = price;
                    }
                }
                if (col.Name == "colTotal")
                {
                    decimal amount;
                    if (decimal.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out amount))
                    {
                        if (amount < 0) amount = 0;
                        item.Amount = amount;
                        row.Cells[e.ColumnIndex].Value = amount;
                    }
                }
                else if (col.Name == "colCount")
                {
                    int count;
                    if (int.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out count))
                    {
                        if (count < 0) count = 0;
                        item.Count = count;
                        item.Amount = count * item.Price;
                        row.Cells[e.ColumnIndex].Value = count;
                    }
                }
                row.Cells["colTotal"].Value = item.Amount;
                ItemsGrid.Rows[ItemsGrid.Rows.Count - 1].Cells["colTotal"].Value = GetTotalAmount();
            }
        }

        private void mnu_AddOrderItem_Click(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                FrmOrderRecordView frm = new FrmOrderRecordView();
                frm.ForSelect = true;
                OrderItemRecordSearchCondition con = new OrderItemRecordSearchCondition();
                con.CustomerID = Customer.ID;
                con.States = new List<SheetState>();
                con.States.Add(SheetState.Approved);
                con.HasToDelivery = true;
                frm.SearchCondition = con;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    OrderItemRecord oi = frm.SelectedItem as OrderItemRecord;
                    AddDeliveryItem(oi);
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmSteelRollSliceMaster frm = new FrmSteelRollSliceMaster();
            frm.ForSelect = true;
            ProductInventorySearchCondition con = new ProductInventorySearchCondition();
            con.WareHouseID = txtWareHouse.Tag != null ? (txtWareHouse.Tag as WareHouse).ID : null;
            frm.SearchCondition = con;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SteelRollSlice p = frm.SelectedItem as SteelRollSlice;
                AddDeliveryItem(p);
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
                ShowDeliveryItemsOnGrid(items);
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
            if (Customer != null)
            {
                FrmContactMaster frm = new FrmContactMaster();
                ContactSearchCondition con = new ContactSearchCondition();
                con.CompanyID = Customer.ID;
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

        private void cmbSheetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSheetType.SelectedIndex == 1)
            {
                btn_AddItem.Visible = true;
                mnu_AddOrderItem.Visible = false;
            }
            else
            {
                btn_AddItem.Visible = !UserSettings.Current.ForbidWhenNoOrderID;
                mnu_AddOrderItem.Visible = true;
            }
        }
        #endregion
    }
}
