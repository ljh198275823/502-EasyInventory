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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmInventorySheetDetail : FrmDetailBase
    {
        public FrmInventorySheetDetail()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ShowSheetItemsOnGrid(IEnumerable<InventoryItem> items)
        {
            ItemsGrid.Rows.Clear();
            if (items != null)
            {
                foreach (InventoryItem item in items)
                {
                    int row = ItemsGrid.Rows.Add();
                    ShowDeliveryItemOnRow(ItemsGrid.Rows[row], item);
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

        private void ShowDeliveryItemOnRow(DataGridViewRow row, InventoryItem item)
        {
            row.Tag = item;
            row.Cells["colProductID"].Value = item.Product.ID;
            row.Cells["colProductName"].Value = item.Product.Name;
            row.Cells["colSpecification"].Value = item.Product.Specification;
            row.Cells["colUnit"].Value = item.Product.Unit;
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

        private void ShowOperations(string sheetNo)
        {
            dataGridView1.Rows.Clear();
            List<DocumentOperation> items = (new InventorySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetHisOperations(sheetNo).QueryObjects;
            items = (from item in items
                     orderby item.OperatDate ascending
                     select item).ToList();
            foreach (DocumentOperation item in items)
            {
                int row = dataGridView1.Rows.Add();
                dataGridView1.Rows[row].Cells["colOperateDate"].Value = item.OperatDate;
                dataGridView1.Rows[row].Cells["colOperation"].Value = item.Operation;
                dataGridView1.Rows[row].Cells["colOperator"].Value = item.Operator;
            }
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
            ShowButtonState();
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            ItemsGrid.Columns["colPrice"].Visible = OperatorInfo.CurrentOperator.Permit(Permission.ReadPrice);
            ItemsGrid.Columns["colTotal"].Visible = OperatorInfo.CurrentOperator.Permit(Permission.ReadPrice);
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
            InventorySheet sheet = UpdatingItem as InventorySheet;
            if (sheet != null)
            {
                this.txtSheetNo.Text = sheet.ID;
                this.txtSheetNo.Enabled = false;
                this.txtSupplier.Text = sheet.Supplier != null ? sheet.Supplier.Name : string.Empty;
                this.txtSupplier.Tag = sheet.Supplier;
                this.txtWareHouse.Text = sheet.WareHouse != null ? sheet.WareHouse.Name : string.Empty;
                this.txtWareHouse.Tag = sheet.WareHouse;
                this.txtMemo.Text = sheet.Memo;
                ShowSheetItemsOnGrid(sheet.Items);
                ShowButtonState();
                if (sheet.State != SheetState.Add)
                {
                    this.ItemsGrid.ReadOnly = true;
                    this.ItemsGrid.ContextMenuStrip = null;
                    this.ItemsGrid.ContextMenu = null;
                }
                ShowOperations(sheet.ID);
            }
        }

        protected override object GetItemFromInput()
        {
            InventorySheet sheet = UpdatingItem as InventorySheet;
            if (sheet == null) sheet = new InventorySheet();
            if (txtSheetNo.Text == "自动创建")
            {
                sheet.ID = string.Empty;
            }
            else
            {
                sheet.ID = this.txtSheetNo.Text;
            }
            sheet.WareHouseID = (this.txtWareHouse.Tag as WareHouse).ID;
            sheet.WareHouse = this.txtWareHouse.Tag as WareHouse;
            sheet.SupplierID = (this.txtSupplier.Tag as Supplier).ID;
            sheet.Supplier = this.txtSupplier.Tag as Supplier;
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
            return (new InventorySheetBLL(AppSettings.CurrentSetting.ConnectString)).Add(item as InventorySheet,OperatorInfo .CurrentOperator .OperatorName );
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new InventorySheetBLL(AppSettings.CurrentSetting.ConnectString)).Update(item as InventorySheet,OperatorInfo .CurrentOperator .OperatorName);
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
                    Product = product,
                    Unit = product.Unit,
                    Price = product.Cost,
                    Count = 0
                };
                sources.Add(item);
            }
            ShowSheetItemsOnGrid(sources);
        }

        public void AddInventoryItem(PurchaseItem pi)
        {
            List<InventoryItem> sources = GetDeliveryItemsFromGrid();
            if (!sources.Exists(it => it.ProductID == pi.ProductID && it.PurchaseItem == pi.ID))
            {
                InventoryItem item = new InventoryItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = pi.ProductID,
                    Product = pi.Product,
                    PurchaseItem = pi.ID,
                    OrderItem = pi.OrderItem,
                    Unit = pi.Unit,
                    Price = pi.Price,
                    Count = pi.OnWay,
                };
                sources.Add(item);
            }
            ShowSheetItemsOnGrid(sources);
        }

        public void AddInventoryItem(PurchaseRecord pi)
        {
            List<InventoryItem> sources = GetDeliveryItemsFromGrid();
            if (!sources.Exists(it => it.ProductID == pi.ProductID && it.PurchaseItem == pi.ID))
            {
                InventoryItem item = new InventoryItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = pi.ProductID,
                    Product = pi.Product,
                    PurchaseItem = pi.ID,
                    OrderItem = pi.OrderItem,
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
                Supplier item = frm.SelectedItem as Supplier;
                txtSupplier.Text = item.Name;
                txtSupplier.Tag = item;
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
                    CommandResult ret = (new InventorySheetBLL(AppSettings.CurrentSetting.ConnectString)).Approve(sheet.ID, OperatorInfo.CurrentOperator.OperatorName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        InventorySheet sheet1 = (new InventorySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheet.ID).QueryObject;
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
                    CommandResult ret = (new InventorySheetBLL(AppSettings.CurrentSetting.ConnectString)).Inventory(sheet.ID, OperatorInfo.CurrentOperator.OperatorName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        InventorySheet sheet1 = (new InventorySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheet.ID).QueryObject;
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
                PurchaseRecordSearchCondition con = new PurchaseRecordSearchCondition();
                con.SupplierID = (txtSupplier.Tag as Supplier).ID;
                con.States = new List<SheetState>();
                con.States.Add(SheetState.Add);
                con.States.Add(SheetState.Approved);
                con.IsComplete = false;
                FrmPurchaseRecordSelection frm = new FrmPurchaseRecordSelection();
                frm.ForSelect = true;
                frm.SearchCondition = con;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    AddInventoryItem(frm.SelectedItem as PurchaseRecord);
                }
            }
        }
        #endregion
    }
}
