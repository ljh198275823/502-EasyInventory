using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.DAL;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Purchase;
using LJH.Inventory.UI.Forms.Purchase.View;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmStackInSheetDetail : FrmSheetDetailBase
    {
        public FrmStackInSheetDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        public CompanyInfo Supplier { get; set; }

        public WareHouse WareHouse { get; set; }
        #endregion

        #region 私有方法
        private void ShowSheetItemsOnGrid(IEnumerable<StackInItem> items)
        {
            ItemsGrid.Rows.Clear();
            if (items != null)
            {
                List<string> pids = items.Select(it => it.ProductID).ToList();
                List<Product> ps = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(new ProductSearchCondition() { ProductIDS = pids }).QueryObjects;
                foreach (StackInItem item in items)
                {
                    int row = ItemsGrid.Rows.Add();
                    Product p = ps.SingleOrDefault(it => it.ID == item.ProductID);
                    ShowStackInItemOnRow(ItemsGrid.Rows[row], item, p);
                }
                int r = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[r].Cells["colCount"].Value = "合计";
                ItemsGrid.Rows[r].Cells["colTotal"].Value = items.Sum(it => it.Amount);
            }
        }

        private decimal GetTotalAmount()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) sum += (row.Tag as StackInItem).Amount;
            }
            return sum;
        }

        private void ShowStackInItemOnRow(DataGridViewRow row, StackInItem item, Product p)
        {
            row.Tag = item;
            row.Cells["colHeader"].Value = this.ItemsGrid.Rows.Count;
            row.Cells["colProductID"].Value = item.ProductID;
            row.Cells["colProductName"].Value = p != null ? p.Name : string.Empty;
            row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
            row.Cells["colCategory"].Value = p != null && p.Category != null ? p.Category.Name : string.Empty;
            row.Cells["colPrice"].Value = item.Price;
            row.Cells["colCount"].Value = item.Count.Trim();
            row.Cells["colLength"].Value = item.Length.HasValue ? item.Length : 0;
            row.Cells["colPurchaseOrder"].Value = item.PurchaseOrder;
            row.Cells["colTotal"].Value = item.Amount;
        }

        private List<StackInItem> GetDeliveryItemsFromGrid()
        {
            List<StackInItem> items = new List<StackInItem>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) items.Add(row.Tag as StackInItem);
            }
            return items;
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
            if (WareHouse == null)
            {
                MessageBox.Show("请选择收货的仓库");
                txtWareHouse.Focus();
                return false;
            }
            if (ItemsGrid.Rows.Count == 0)
            {
                MessageBox.Show("收货单没有填写收货项");
                return false;
            }
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                StackOutItem item = row.Tag as StackOutItem;
                if (item != null && item.Count == 0)
                {
                    MessageBox.Show(string.Format("收货单第 {0} 项收货数量为零", row.Index + 1));
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
            this.txtSupplier.Text = Supplier != null ? Supplier.Name : string.Empty;
            this.txtWareHouse.Text = WareHouse != null ? WareHouse.Name : string.Empty;
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
            StackInSheet item = UpdatingItem as StackInSheet;
            if (item != null)
            {
                this.txtSheetNo.Text = item.ID;
                this.txtSheetNo.Enabled = false;
                Supplier = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.SupplierID).QueryObject;
                this.txtSupplier.Text = Supplier != null ? Supplier.Name : string.Empty;
                WareHouse = (new WareHouseBLL(AppSettings.Current.ConnStr)).GetByID(item.WareHouseID).QueryObject;
                this.txtWareHouse.Text = WareHouse != null ? WareHouse.Name : string.Empty;
                dtSheetDate.Value = item.SheetDate;
                this.txtMemo.Text = item.Memo;
                ShowSheetItemsOnGrid(item.Items);
                ShowOperations(item.ID, item.DocumentType, dataGridView1);
                ShowAttachmentHeaders(item.ID, item.DocumentType, this.gridAttachment);
            }
        }

        protected override object GetItemFromInput()
        {
            StackInSheet sheet = UpdatingItem as StackInSheet;
            if (sheet == null)
            {
                sheet = new StackInSheet();
                if (txtSheetNo.Text == "自动创建") sheet.ID = string.Empty;
                sheet.ClassID = StackInSheetType.InventorySheet;
            }
            else
            {
                sheet.ID = this.txtSheetNo.Text;
            }
            sheet.SupplierID = Supplier != null ? Supplier.ID : null;
            sheet.WareHouseID = WareHouse != null ? WareHouse.ID : null;
            sheet.SheetDate = dtSheetDate.Value;
            sheet.Memo = txtMemo.Text;
            sheet.Items = new List<StackInItem>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null)
                {
                    StackInItem item = row.Tag as StackInItem;
                    item.SheetNo = sheet.ID;
                    sheet.Items.Add(item);
                }
            }
            return sheet;
        }

        protected override CommandResult AddItem(object item)
        {
            return (new StackInSheetBLL(AppSettings.Current.ConnStr)).ProcessSheet(item as StackInSheet, SheetOperation.Create, Operator.Current.Name, Operator.Current.ID);
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new StackInSheetBLL(AppSettings.Current.ConnStr)).ProcessSheet(item as StackInSheet, SheetOperation.Modify, Operator.Current.Name, Operator.Current.ID);
        }

        protected override void ShowButtonState()
        {
            ShowButtonState(this.toolStrip1);
            //btnSave.Enabled = btnSave.Enabled && Operator.Current.Permit(Permission.InventorySheet, PermissionActions.Edit);
            //btnApprove.Enabled = btnApprove.Enabled && Operator.Current.Permit(Permission.InventorySheet, PermissionActions.Approve);
            //btnUndoApprove.Enabled = btnUndoApprove.Enabled && Operator.Current.Permit(Permission.InventorySheet, PermissionActions.UndoApprove);
            //btnNullify.Enabled = btnNullify.Enabled && Operator.Current.Permit(Permission.InventorySheet, PermissionActions.Nullify);
            //btnPrint.Enabled = btnPrint.Enabled && Operator.Current.Permit(Permission.InventorySheet, PermissionActions.Print);
            //btnInventory.Enabled = btnInventory.Enabled && Operator.Current.Permit(Permission.InventorySheet, PermissionActions.Inventory);
            ItemsGrid.ContextMenuStrip = btnSave.Enabled ? this.contextMenuStrip1 : null;
            ItemsGrid.ReadOnly = !btnSave.Enabled;
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            StackInSheet item = UpdatingItem as StackInSheet;
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
            StackInSheetBLL bll = new StackInSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackInSheet>(bll, IsAdding ? SheetOperation.Create : SheetOperation.Modify);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            StackInSheetBLL bll = new StackInSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackInSheet>(bll, SheetOperation.Approve);
        }

        private void btnUndoApprove_Click(object sender, EventArgs e)
        {
            StackInSheetBLL bll = new StackInSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackInSheet>(bll, SheetOperation.UndoApprove);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            StackInSheetBLL bll = new StackInSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackInSheet>(bll, SheetOperation.StackIn);
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            StackInSheetBLL bll = new StackInSheetBLL(AppSettings.Current.ConnStr);
            PerformOperation<StackInSheet>(bll, SheetOperation.Nullify);
        }
        #endregion

        #region 公共方法
        public void AddInventoryItem(Product product)
        {
            List<StackInItem> sources = GetDeliveryItemsFromGrid();
            StackInItem item = new StackInItem()
            {
                ID = Guid.NewGuid(),
                ProductID = product.ID,
                Unit = product.Unit,
                Price = product.Cost,
                Count = 0
            };
            sources.Add(item);
            ShowSheetItemsOnGrid(sources);
        }

        public void AddInventoryItem(PurchaseItemRecord pi)
        {
            List<StackInItem> sources = GetDeliveryItemsFromGrid();
            if (!sources.Exists(it => it.ProductID == pi.ProductID && it.PurchaseItem == pi.ID))
            {
                StackInItem item = new StackInItem();
                item.ID = Guid.NewGuid();
                item.ProductID = pi.ProductID;
                item.PurchaseItem = pi.ID;
                item.PurchaseOrder = pi.SheetNo;
                item.OrderItem = pi.OrderItem;
                item.OrderID = pi.OrderID;
                item.Unit = pi.Unit;
                item.Price = pi.Price;
                item.Count = pi.OnWay;
                item.Amount = item.Price * item.Count;
                sources.Add(item);
            }
            ShowSheetItemsOnGrid(sources);
        }
        #endregion

        #region 事件处理程序
        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSupplierMaster frm = new FrmSupplierMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Supplier = frm.SelectedItem as CompanyInfo;
                txtSupplier.Text = Supplier != null ? Supplier.Name : string.Empty;
            }
        }

        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            Supplier = null;
            txtSupplier.Text = Supplier != null ? Supplier.Name : string.Empty;
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
                StackInItem item = row.Tag as StackInItem;
                if (col.Name == "colPrice")
                {
                    decimal price;
                    if (decimal.TryParse(StringHelper.ToDBC(row.Cells[e.ColumnIndex].Value.ToString()).Trim(), out price))
                    {
                        if (price < 0) price = 0;
                        item.Price = price;
                        item.Amount = price * item.Count;
                        row.Cells[e.ColumnIndex].Value = price;
                    }
                }
                else if (col.Name == "colLength")
                {
                    decimal length = 0;
                    if (decimal.TryParse(StringHelper.ToDBC(row.Cells[e.ColumnIndex].Value.ToString()).Trim(), out length))
                    {
                        item.Length = length;
                        row.Cells[e.ColumnIndex].Value = length;
                    }
                }
                else if (col.Name == "colTotal")
                {
                    decimal amount;
                    if (decimal.TryParse(StringHelper.ToDBC(row.Cells[e.ColumnIndex].Value.ToString()).Trim(), out amount))
                    {
                        if (amount < 0) amount = 0;
                        item.Amount = amount;
                        row.Cells[e.ColumnIndex].Value = amount;
                    }
                }
                else if (col.Name == "colCount")
                {
                    decimal count;
                    if (decimal.TryParse(StringHelper.ToDBC(row.Cells[e.ColumnIndex].Value.ToString()).Trim(), out count))
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmProductMaster frm = new FrmProductMaster();
            frm.Models = "原材料";
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Product p = frm.SelectedItem as Product;
                AddInventoryItem(p);
            }
        }

        private void mnu_Remove_Click(object sender, EventArgs e)
        {
            if (ItemsGrid.SelectedRows.Count > 0)
            {
                List<StackInItem> items = GetDeliveryItemsFromGrid();
                foreach (DataGridViewRow row in ItemsGrid.SelectedRows)
                {
                    if (row.Tag != null) items.Remove(row.Tag as StackInItem);
                }
                ShowSheetItemsOnGrid(items);
            }
        }

        private void btn_PurchaseItemSelect_Click(object sender, EventArgs e)
        {
            if (Supplier != null)
            {
                PurchaseItemRecordSearchCondition con = new PurchaseItemRecordSearchCondition();
                con.SupplierID = Supplier.ID;
                con.States = new List<SheetState>();
                con.States.Add(SheetState.Approved);
                con.HasOnway = true;
                FrmPurchaseRecordView frm = new FrmPurchaseRecordView();
                frm.ForSelect = true;
                frm.SearchCondition = con;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    AddInventoryItem(frm.SelectedItem as PurchaseItemRecord);
                }
            }
        }
        #endregion
    }
}
