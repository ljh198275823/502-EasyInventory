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
    public partial class FrmPurchaseOrderDetail : FrmSheetDetailBase 
    {
        public FrmPurchaseOrderDetail()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ShowDeliveryItemsOnGrid(IEnumerable<PurchaseItem> items)
        {
            ItemsGrid.Rows.Clear();
            if (items != null)
            {
                List<string> pids = items.Select(it => it.ProductID).ToList();
                List<Product> ps = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(new ProductSearchCondition() { ProductIDS = pids }).QueryObjects;
                foreach (PurchaseItem item in items)
                {
                    int row = ItemsGrid.Rows.Add();
                    Product p = ps.SingleOrDefault(it => it.ID == item.ProductID);
                    ShowDeliveryItemOnRow(ItemsGrid.Rows[row], item, p);
                }
                int r = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[r].Cells["colCount"].Value = "合计";
                ItemsGrid.Rows[r].Cells["colTotal"].Value = items.Sum(it => it.Amount).Trim();
            }
        }

        private void ShowDeliveryItemOnRow(DataGridViewRow row, PurchaseItem item,Product p)
        {
            row.Tag = item;
            row.Cells["colHeader"].Value = this.ItemsGrid.Rows.Count;
            row.Cells["colProductID"].Value = item.ProductID;
            row.Cells["colProductName"].Value = p != null ? p.Name : string.Empty;
            row.Cells["colCategory"].Value = p != null && p.Category != null ? p.Category.Name : string.Empty;
            row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
            row.Cells["colUnit"].Value = item.Unit;
            row.Cells["colPrice"].Value = item.Price.Trim();
            row.Cells["colCount"].Value = item.Count.Trim();
            row.Cells["colTotal"].Value = item.Amount.Trim();
            row.Cells["colOrderID"].Value = item.OrderID;
            row.Cells["colMemo"].Value = item.Memo;
        }

        private List<PurchaseItem> GetPurchaseSheetItemsFromGrid()
        {
            List<PurchaseItem> items = new List<PurchaseItem>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null)
                {
                    items.Add(row.Tag as PurchaseItem);
                }
            }
            return items;
        }

        private decimal GetTotalAmount()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) sum += (row.Tag as PurchaseItem).Amount;
            }
            return sum.Trim();
        }

        #endregion

        #region 公共方法
        /// <summary>
        /// 获取或设置采购单的供应商信息
        /// </summary>
        public CompanyInfo Supplier { get; set; }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtSheetNo.Text) && UpdatingItem != null)
            {
                MessageBox.Show("采购单号不能为空");
                txtSheetNo.Focus();
                return false;
            }
            if (Supplier == null)
            {
                MessageBox.Show("没有选择供应商");
                txtSupplier.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtBuyer.Text))
            {
                MessageBox.Show("采购人员不能为空");
                txtBuyer.Focus();
                return false;
            }
            if (!rdWithTax.Checked && !rdWithoutTax.Checked)
            {
                MessageBox.Show("没有选择订单的含税情况");
                rdWithTax.Focus();
                return false;
            }
            if (ItemsGrid.Rows.Count == 0)
            {
                MessageBox.Show("采购没有填写订货项");
                return false;
            }
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                PurchaseItem item = row.Tag as PurchaseItem;
                if (item != null && item.Count == 0)
                {
                    MessageBox.Show(string.Format("采购单第 {0} 项数量为零", row.Index + 1));
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
            this.dtDemandDate.Value = DateTime.Today.AddDays(1);
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
            PurchaseOrder item = UpdatingItem as PurchaseOrder;
            if (item != null)
            {
                this.txtSheetNo.Text = item.ID;
                this.txtSheetNo.Enabled = false;
                Supplier = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(item.SupplierID).QueryObject;
                this.txtSupplier.Text = Supplier != null ? Supplier.Name : string.Empty;
                this.dtOrderDate.Value = item.OrderDate;
                this.txtBuyer.Text = item.Buyer;
                this.rdWithTax.Checked = item.WithTax;
                this.rdWithoutTax.Checked = !item.WithTax;
                this.dtDemandDate.Value = item.DemandDate;
                ShowDeliveryItemsOnGrid(item.Items);
                List<DocumentOperation> items = (new DocumentOperationBLL(AppSettings.Current.ConnStr)).GetHisOperations(item.ID, item.DocumentType).QueryObjects;
                ShowOperations(items, dataGridView1);
                List<AttachmentHeader> headers = (new AttachmentBLL(AppSettings.Current.ConnStr)).GetHeaders(item.ID, item.DocumentType).QueryObjects;
                ShowAttachmentHeaders(headers, this.gridAttachment);
                ShowButtonState();
            }
        }

        protected override object GetItemFromInput()
        {
            PurchaseOrder PurchaseSheet = UpdatingItem as PurchaseOrder;
            if (PurchaseSheet == null)
            {
                PurchaseSheet = new PurchaseOrder();
                PurchaseSheet.OrderDate = DateTime.Now;
                PurchaseSheet.ID = txtSheetNo.Text == "自动创建" ? string.Empty : this.txtSheetNo.Text;
            }
            else
            {
                PurchaseSheet = UpdatingItem as PurchaseOrder;
            }
            PurchaseSheet.OrderDate = this.dtOrderDate.Value;
            PurchaseSheet.SupplierID =Supplier.ID;
            PurchaseSheet.Buyer = this.txtBuyer.Text;
            PurchaseSheet.DemandDate = this.dtDemandDate.Value;
            PurchaseSheet.WithTax = rdWithTax.Checked;
            PurchaseSheet.Items = GetPurchaseSheetItemsFromGrid();
            PurchaseSheet.Items.ForEach(item => { item.DemandDate = PurchaseSheet.DemandDate; item.PurchaseID = PurchaseSheet.ID; });
            return PurchaseSheet;
        }

        protected override void ShowButtonState()
        {
            if (UpdatingItem == null)
            {
                this.btnSave.Enabled = true;
                this.btnPrint.Enabled = false;
                this.btnApprove.Enabled = false;
            }
            else
            {
                PurchaseOrder sheet = UpdatingItem as PurchaseOrder;
                this.btnSave.Enabled = sheet.CanEdit;
                this.btnPrint.Enabled = true;
                this.btnApprove.Enabled = sheet.CanApprove;
            }
        }

        protected override CommandResult AddItem(object item)
        {
            return (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).Add(item as PurchaseOrder,Operator .Current.Name );
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).Update(item as PurchaseOrder,Operator .Current .Name );
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            PurchaseOrder item = UpdatingItem as PurchaseOrder;
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
        public void AddPurchaseSheettem(Product product)
        {
            List<PurchaseItem> sources = GetPurchaseSheetItemsFromGrid();
            if (!sources.Exists(it => it.ProductID == product.ID))
            {
                PurchaseItem item = new PurchaseItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = product.ID,
                    Unit = product.Unit,
                    Price = product.Price,
                    Count = 0
                };
                sources.Add(item);
            }
            ShowDeliveryItemsOnGrid(sources);
        }

        public void AddPurchaseSheettem(OrderItemRecord oi)
        {
            List<PurchaseItem> sources = GetPurchaseSheetItemsFromGrid();
            if (!sources.Exists(it => it.OrderItem == oi.ID))
            {
                PurchaseItem item = new PurchaseItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = oi.ProductID,
                    OrderID = oi.OrderID,
                    OrderItem = oi.ID,
                    Unit = oi.Unit,
                    Count = oi.NotPurchased,
                };
                sources.Add(item);
            }
            ShowDeliveryItemsOnGrid(sources);
        }
        #endregion

        #region 事件处理程序
        private void btnSave_Click(object sender, EventArgs e)
        {
            this.btnOk.PerformClick();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                if (MessageBox.Show("是否要审核此采购单?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    PurchaseOrder sheet = UpdatingItem as PurchaseOrder;
                    CommandResult ret = (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).Approve(sheet.ID, Operator.Current.Name);
                    if (ret.Result == ResultCode.Successful)
                    {
                        PurchaseOrder sheet1 = (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).GetByID(sheet.ID).QueryObject;
                        this.UpdatingItem = sheet1;
                        ItemShowing();
                        this.OnItemUpdated(new ItemUpdatedEventArgs(sheet1));
                    }
                    else
                    {
                        MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                if (MessageBox.Show("是否将此采购单作废?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    PurchaseOrder sheet = UpdatingItem as PurchaseOrder;
                    CommandResult ret = (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).Nullify(sheet.ID, Operator.Current.Name);
                    if (ret.Result == ResultCode.Successful)
                    {
                        PurchaseOrder sheet1 = (new PurchaseOrderBLL(AppSettings.Current.ConnStr)).GetByID(sheet.ID).QueryObject;
                        this.UpdatingItem = sheet1;
                        ItemShowing();
                        this.OnItemUpdated(new ItemUpdatedEventArgs(sheet1));
                    }
                    else
                    {
                        MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ItemsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn col = ItemsGrid.Columns[e.ColumnIndex];
            DataGridViewRow row = ItemsGrid.Rows[e.RowIndex];
            if (row.Tag != null)
            {
                PurchaseItem item = row.Tag as PurchaseItem;
                if (col.Name == "colPrice")
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
                    int count;
                    if (int.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out count))
                    {
                        if (count < 0) count = 0;
                        item.Count = count;
                        row.Cells[e.ColumnIndex].Value = count;
                    }
                }
                else if (col.Name == "colMemo")
                {
                    item.Memo = row.Cells[e.ColumnIndex].Value.ToString();
                }
                row.Cells["colTotal"].Value = item.Amount.Trim(); ;
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
                AddPurchaseSheettem(p);
            }
        }

        private void btn_AddOrderRecord_Click(object sender, EventArgs e)
        {
            LJH.Inventory.UI.Forms.Sale.FrmOrderItemRecordMaster frm = new Sale.FrmOrderItemRecordMaster();
            frm.ForSelect = true;
            OrderItemRecordSearchCondition con = new OrderItemRecordSearchCondition();
            con.States = new List<SheetState>();
            con.States.Add(SheetState.Add);
            con.States.Add(SheetState.Approved);
            con.HasToPurchase = true;
            frm.SearchCondition = con;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                OrderItemRecord oi = frm.SelectedItem as OrderItemRecord;
                AddPurchaseSheettem(oi);
            }
        }

        private void mnu_Remove_Click(object sender, EventArgs e)
        {
            if (ItemsGrid.SelectedRows.Count > 0)
            {
                List<PurchaseItem> items = GetPurchaseSheetItemsFromGrid();
                foreach (DataGridViewRow row in ItemsGrid.SelectedRows)
                {
                    if (row.Tag != null) items.Remove(row.Tag as PurchaseItem);
                }
                ShowDeliveryItemsOnGrid(items);
            }
        }

        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSupplierMaster frm = new FrmSupplierMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Supplier  = frm.SelectedItem as CompanyInfo;
                txtSupplier.Text = Supplier != null ? Supplier.Name : string.Empty;
            }
        }

        private void lnkBuyer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOperatorMaster frm = new FrmOperatorMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Operator item = frm.SelectedItem as Operator;
                txtBuyer.Text = item.Name;
            }
        }
        #endregion

        private void ItemsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (ItemsGrid.Columns[e.ColumnIndex].Name == "colOrderID")
                {
                    string orderID = ItemsGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    Order item = (new OrderBLL(AppSettings.Current.ConnStr)).GetByID(orderID).QueryObject;
                    if (item != null)
                    {
                        FrmOrderDetail frm = new FrmOrderDetail();
                        frm.IsForView = true;
                        frm.UpdatingItem = item;
                        frm.ShowDialog();
                    }
                }
                else if (ItemsGrid.Columns[e.ColumnIndex].Name == "colReceived")
                {
                    PurchaseItem pi = ItemsGrid.Rows[e.RowIndex].Tag as PurchaseItem;
                    InventoryRecordSearchCondition con = new InventoryRecordSearchCondition();
                    con.PurchaseItem = pi.ID;
                    LJH.Inventory.UI.View.FrmInventoryRecordView frm = new View.FrmInventoryRecordView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
            }
        }
    }
}

