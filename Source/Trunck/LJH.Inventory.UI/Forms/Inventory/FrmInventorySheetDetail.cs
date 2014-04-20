using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.DAL;
using LJH.GeneralLibrary.UI;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmInventorySheetDetail :FrmSheetDetailBase 
    {
        public FrmInventorySheetDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        public CompanyInfo Supplier { get; set; }
        #endregion

        #region 私有方法
        private void ShowSheetItemsOnGrid(IEnumerable<InventoryItem> items)
        {
            ItemsGrid.Rows.Clear();
            if (items != null)
            {
                List<string> pids = items.Select(it => it.ProductID).ToList();
                List<Product> ps = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(new ProductSearchCondition() { ProductIDS = pids }).QueryObjects;
                foreach (InventoryItem item in items)
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

        private decimal GetTotalAmount()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) sum += (row.Tag as InventoryItem).Amount;
            }
            return sum;
        }

        private void ShowDeliveryItemOnRow(DataGridViewRow row, InventoryItem item,Product p)
        {
            row.Tag = item;
            row.Cells["colHeader"].Value = this.ItemsGrid.Rows.Count;
            row.Cells["colProductID"].Value = item.ProductID;
            row.Cells["colProductName"].Value = p != null ? p.Name : string.Empty;
            row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
            row.Cells["colCategory"].Value = p != null && p.Category != null ? p.Category.Name : string.Empty;
            row.Cells["colUnit"].Value = item.Unit;
            row.Cells["colPrice"].Value = item.Price;
            row.Cells["colCount"].Value = item.Count.Trim();
            row.Cells["colOrderID"].Value = item.OrderID;
            row.Cells["colPurchaseOrder"].Value = item.PurchaseOrder;
            row.Cells["colTotal"].Value = item.Amount;
        }

        private List<InventoryItem> GetDeliveryItemsFromGrid()
        {
            List<InventoryItem> items = new List<InventoryItem>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) items.Add(row.Tag as InventoryItem);
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
            if (txtWareHouse.Tag == null)
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
                DeliveryItem item = row.Tag as DeliveryItem;
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
            ShowButtonState();
            Operator opt = Operator.Current;
            ItemsGrid.Columns["colPrice"].Visible = Operator.Current.Permit(Permission.ReadPrice);
            ItemsGrid.Columns["colTotal"].Visible = Operator.Current.Permit(Permission.ReadPrice);
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
            InventorySheet item = UpdatingItem as InventorySheet;
            if (item != null)
            {
                this.txtSheetNo.Text = item.ID;
                this.txtSheetNo.Enabled = false;
                Supplier = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.SupplierID).QueryObject;
                this.txtSupplier.Text = Supplier != null ? Supplier.Name : string.Empty;
                WareHouse ws = (new WareHouseBLL(AppSettings.Current.ConnStr)).GetByID(item.WareHouseID).QueryObject;
                this.txtWareHouse.Text = ws != null ? ws.Name : string.Empty;
                this.txtWareHouse.Tag = ws;
                this.txtMemo.Text = item.Memo;
                ShowSheetItemsOnGrid(item.Items);
                ShowButtonState();
                if (item.State != SheetState.Add)
                {
                    this.ItemsGrid.ReadOnly = true;
                    this.ItemsGrid.ContextMenuStrip = null;
                    this.ItemsGrid.ContextMenu = null;
                }
                List<DocumentOperation> items = (new DocumentOperationBLL(AppSettings.Current.ConnStr)).GetHisOperations(item.ID, item.DocumentType).QueryObjects;
                ShowOperations(items, dataGridView1);

                List<AttachmentHeader> headers = (new AttachmentBLL(AppSettings.Current.ConnStr)).GetHeaders(item.ID, item.DocumentType).QueryObjects;
                ShowAttachmentHeaders(headers, this.gridAttachment);
            }
        }

        protected override object GetItemFromInput()
        {
            InventorySheet sheet = UpdatingItem as InventorySheet;
            if (sheet == null)
            {
                sheet = new InventorySheet();
                if (txtSheetNo.Text == "自动创建") sheet.ID = string.Empty;
                sheet.CreateDate = DateTime.Now;
            }
            else
            {
                sheet.ID = this.txtSheetNo.Text;
            }
            if (!string.IsNullOrEmpty(this.txtWareHouse.Text) && this.txtWareHouse.Tag != null)
            {
                sheet.WareHouseID = (txtWareHouse.Tag as WareHouse).ID;
            }
            else
            {
                sheet.WareHouseID = null;
            }
            sheet.SupplierID = Supplier != null ? Supplier.ID : null;
            sheet.Memo = txtMemo.Text;
            sheet.Items = new List<InventoryItem>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null)
                {
                    InventoryItem item = row.Tag as InventoryItem;
                    item.SheetNo = sheet.ID;
                    sheet.Items.Add(item);
                }
            }
            return sheet;
        }

        protected override CommandResult AddItem(object item)
        {
            return (new InventorySheetBLL(AppSettings.Current.ConnStr)).Add(item as InventorySheet,Operator .Current .Name );
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new InventorySheetBLL(AppSettings.Current.ConnStr)).Update(item as InventorySheet,Operator .Current .Name);
        }

        protected override void ShowButtonState()
        {
            if (UpdatingItem == null)
            {
                this.btnOk.Enabled = true;
                this.btnPrint.Enabled = false;
                this.btnApprove.Enabled = false;
                this.btnInventory.Enabled = false;
            }
            else
            {
                InventorySheet sheet = UpdatingItem as InventorySheet;
                this.btnOk.Enabled = sheet.State == SheetState.Add;
                this.btnPrint.Enabled = true;
                this.btnApprove.Enabled = sheet.CanApprove;
                this.btnInventory.Enabled = sheet.CanInventory;
            }
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            InventorySheet item = UpdatingItem as InventorySheet;
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

        #region 公共方法
        public void AddInventoryItem(Product product)
        {
            List<InventoryItem> sources = GetDeliveryItemsFromGrid();
            if (!sources.Exists(it => it.ProductID == product.ID && it.PurchaseItem == null))
            {
                InventoryItem item = new InventoryItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = product.ID,
                    Unit = product.Unit,
                    Price = product.Cost,
                    Count = 0
                };
                sources.Add(item);
            }
            ShowSheetItemsOnGrid(sources);
        }

        public void AddInventoryItem(PurchaseItemRecord pi)
        {
            List<InventoryItem> sources = GetDeliveryItemsFromGrid();
            if (!sources.Exists(it => it.ProductID == pi.ProductID && it.PurchaseItem == pi.ID))
            {
                InventoryItem item = new InventoryItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = pi.ProductID,
                    PurchaseItem = pi.ID,
                    PurchaseOrder = pi.PurchaseID,
                    OrderItem = pi.OrderItem,
                    OrderID = pi.OrderID,
                    Unit = pi.Unit,
                    Price = pi.Price,
                    Count = pi.OnWay,
                };
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

        private void lnkWareHouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmWareHouseMaster frm = new FrmWareHouseMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                WareHouse item = frm.SelectedItem as WareHouse;
                txtWareHouse.Text = item.Name;
                txtWareHouse.Tag = item;
            }
        }

        private void ItemsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn col = ItemsGrid.Columns[e.ColumnIndex];
            DataGridViewRow row = ItemsGrid.Rows[e.RowIndex];
            if (row.Tag != null)
            {
                InventoryItem item = row.Tag as InventoryItem;
                if (col.Name == "colPrice" && row.Tag != null)
                {
                    decimal price;
                    if (decimal.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out price))
                    {
                        if (price < 0) price = 0;
                        item.Price = price;
                        row.Cells[e.ColumnIndex].Value = price;
                    }
                }
                else if (col.Name == "colCount")
                {
                    decimal count;
                    if (decimal.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out count))
                    {
                        if (count < 0) count = 0;
                        item.Count = count;
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
                List<InventoryItem> items = GetDeliveryItemsFromGrid();
                foreach (DataGridViewRow row in ItemsGrid.SelectedRows)
                {
                    if (row.Tag != null) items.Remove(row.Tag as InventoryItem);
                }
                ShowSheetItemsOnGrid(items);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                if (MessageBox.Show("是否要审核此收货单?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    InventorySheet sheet = UpdatingItem as InventorySheet;
                    CommandResult ret = (new InventorySheetBLL(AppSettings.Current.ConnStr)).Approve(sheet.ID, Operator.Current.Name);
                    if (ret.Result == ResultCode.Successful)
                    {
                        InventorySheet sheet1 = (new InventorySheetBLL(AppSettings.Current.ConnStr)).GetByID(sheet.ID).QueryObject;
                        this.UpdatingItem = sheet1;
                        ItemShowing();
                        ShowButtonState();
                        this.OnItemUpdated(new ItemUpdatedEventArgs(sheet1));
                    }
                    else
                    {
                        MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                if (MessageBox.Show("是否要将此收货单收货?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    InventorySheet sheet = UpdatingItem as InventorySheet;
                    CommandResult ret = (new InventorySheetBLL(AppSettings.Current.ConnStr)).Inventory(sheet.ID, Operator.Current.Name);
                    if (ret.Result == ResultCode.Successful)
                    {
                        InventorySheet sheet1 = (new InventorySheetBLL(AppSettings.Current.ConnStr)).GetByID(sheet.ID).QueryObject;
                        this.UpdatingItem = sheet1;
                        ItemShowing();
                        ShowButtonState();
                        this.OnItemUpdated(new ItemUpdatedEventArgs(sheet1));
                    }
                    else
                    {
                        MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.btnOk.PerformClick();
        }

        private void btn_PurchaseItemSelect_Click(object sender, EventArgs e)
        {
            if (txtSupplier.Tag != null)
            {
                PurchaseItemRecordSearchCondition con = new PurchaseItemRecordSearchCondition();
                con.SupplierID = (txtSupplier.Tag as CompanyInfo).ID;
                con.States = new List<SheetState>();
                con.States.Add(SheetState.Add);
                con.States.Add(SheetState.Approved);
                con.HasOnway = true;
                FrmPurchaseRecordSelection frm = new FrmPurchaseRecordSelection();
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
