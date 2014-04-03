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
    public partial class FrmPurchaseOrderDetail : FrmDetailBase
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
                foreach (PurchaseItem item in items)
                {
                    int row = ItemsGrid.Rows.Add();
                    ShowDeliveryItemOnRow(ItemsGrid.Rows[row], item);
                }
                int r = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[r].Cells["colCount"].Value = "合计";
                ItemsGrid.Rows[r].Cells["colTotal"].Value = items.Sum(it => it.Amount).Trim();
            }
        }

        private void ShowDeliveryItemOnRow(DataGridViewRow row, PurchaseItem item)
        {
            row.Tag = item;
            row.Cells["colProductID"].Value = item.Product != null ? item.Product.ID : string.Empty;
            row.Cells["colProductName"].Value = item.Product != null ? item.Product.Name : string.Empty;
            row.Cells["colSpecification"].Value = item.Product != null ? item.Product.Specification : string.Empty;
            row.Cells["colPrice"].Value = item.Price.Trim();
            row.Cells["colCount"].Value = item.Count.Trim();
            row.Cells["colTotal"].Value = item.Amount.Trim();
            row.Cells["colOrderID"].Value = item.OrderID;
            row.Cells["colReceived"].Value = item.Received.Trim();
            row.Cells["colOnWay"].Value = item.OnWay.Trim();
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

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtSheetNo.Text) && UpdatingItem != null)
            {
                MessageBox.Show("采购单号不能为空");
                txtSheetNo.Focus();
                return false;
            }
            if (txtSupplier.Tag == null)
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
            this.dtDeliveryDate.Value = DateTime.Today.AddDays(1);
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
            PurchaseOrder item = UpdatingItem as PurchaseOrder;
            if (item != null)
            {
                this.txtSheetNo.Text = item.ID;
                this.txtSheetNo.Enabled = false;
                this.txtSupplier.Text = item.Supplier.Name;
                this.txtSupplier.Tag = item.Supplier;
                this.dtOrderDate.Value = item.OrderDate;
                this.txtCurrencyType.Text = item.CurrencyType;
                this.txtBuyer.Text = item.Buyer;
                this.dtDeliveryDate.Value = item.DemandDate;
                ShowDeliveryItemsOnGrid(item.Items);
                List<DocumentOperation> items = (new DocumentOperationBLL(AppSettings.CurrentSetting.ConnStr)).GetHisOperations(item.ID, item.DocumentType).QueryObjects;
                ShowOperations(items, dataGridView1);
                List<AttachmentHeader> headers = (new AttachmentBLL(AppSettings.CurrentSetting.ConnStr)).GetHeaders(item.ID, item.DocumentType).QueryObjects;
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
            PurchaseSheet.SupplierID = (this.txtSupplier.Tag as Customer).ID;
            PurchaseSheet.Supplier = this.txtSupplier.Tag as Customer;
            PurchaseSheet.CurrencyType = this.txtCurrencyType.Text;
            PurchaseSheet.Buyer = this.txtBuyer.Text;
            PurchaseSheet.DemandDate = this.dtDeliveryDate.Value;
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
            return (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnStr)).Add(item as PurchaseOrder,OperatorInfo .CurrentOperator.OperatorName );
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnStr)).Update(item as PurchaseOrder,OperatorInfo .CurrentOperator .OperatorName );
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            PurchaseOrder item = UpdatingItem as PurchaseOrder;
            if (item != null)
            {
                OpenFileDialog dig = new OpenFileDialog();
                if (dig.ShowDialog() == DialogResult.OK)
                {
                    AttachmentHeader header = new AttachmentHeader();
                    header.ID = Guid.NewGuid();
                    header.DocumentID = item.ID;
                    header.DocumentType = item.DocumentType;
                    header.Owner = OperatorInfo.CurrentOperator.OperatorName;
                    header.FileName = System.IO.Path.GetFileName(dig.FileName);
                    header.UploadDateTime = DateTime.Now;
                    CommandResult ret = (new AttachmentBLL(AppSettings.CurrentSetting.ConnStr)).Upload(header, dig.FileName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        int row = gridAttachment.Rows.Add();
                        ShowAttachmentHeaderOnRow(header, gridAttachment.Rows[row]);
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }

        private void mnu_AttachmentOpen_Click(object sender, EventArgs e)
        {
            if (this.gridAttachment.SelectedRows.Count == 1)
            {
                AttachmentHeader header = this.gridAttachment.SelectedRows[0].Tag as AttachmentHeader;
                string dir = LJH.GeneralLibrary.TempFolderManager.GetCurrentFolder();
                string path = System.IO.Path.Combine(dir, header.FileName);
                CommandResult ret = (new AttachmentBLL(AppSettings.CurrentSetting.ConnStr)).Download(header, path);
                if (ret.Result == ResultCode.Successful)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(path);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void mnu_AttachmentSaveAs_Click(object sender, EventArgs e)
        {
            if (this.gridAttachment.SelectedRows.Count == 1)
            {
                AttachmentHeader header = this.gridAttachment.SelectedRows[0].Tag as AttachmentHeader;
                SaveFileDialog dig = new SaveFileDialog();
                dig.FileName = header.FileName;
                dig.Filter = "所有文件(*.*)|*.*";
                if (dig.ShowDialog() == DialogResult.OK)
                {
                    CommandResult ret = (new AttachmentBLL(AppSettings.CurrentSetting.ConnStr)).Download(header, dig.FileName);
                    if (ret.Result == ResultCode.Successful)
                    {
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }

        private void mnu_AttachmentDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确实要删除所选项?", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                List<DataGridViewRow> deletingRows = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in this.gridAttachment.SelectedRows)
                {
                    AttachmentHeader header = row.Tag as AttachmentHeader;
                    CommandResult ret = (new AttachmentBLL(AppSettings.CurrentSetting.ConnStr)).Delete(header);
                    if (ret.Result == ResultCode.Successful)
                    {
                        deletingRows.Add(row);
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
                if (deletingRows != null && deletingRows.Count > 0)
                {
                    foreach (DataGridViewRow row in deletingRows)
                    {
                        this.gridAttachment.Rows.Remove(row);
                    }
                }
            }
        }

        #endregion

        #region 公共方法
        public void AddPurchaseSheettem(Product product)
        {
            List<PurchaseItem> sources = GetPurchaseSheetItemsFromGrid();
            if (!sources.Exists(it => it.ProductID == product.ID))
            {
                if (sources.Count < DeliverySheet.MaxItemCount)
                {
                    PurchaseItem item = new PurchaseItem()
                    {
                        ID=Guid.NewGuid (),
                        ProductID = product.ID,
                        Product = product,
                        Unit = product.Unit,
                        Price = product.Price,
                        Count = 0
                    };
                    sources.Add(item);
                }
            }
            ShowDeliveryItemsOnGrid(sources);
        }

        public void AddPurchaseSheettem(OrderRecord oi)
        {
            List<PurchaseItem> sources = GetPurchaseSheetItemsFromGrid();
            if (!sources.Exists(it => it.OrderItem == oi.ID))
            {
                PurchaseItem item = new PurchaseItem()
                {
                    ID = Guid.NewGuid(),
                    ProductID = oi.ProductID,
                    Product = oi.Product,
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
                    CommandResult ret = (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnStr)).Approve(sheet.ID, OperatorInfo.CurrentOperator.OperatorName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        PurchaseOrder sheet1 = (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnStr)).GetByID(sheet.ID).QueryObject;
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
                    CommandResult ret = (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnStr)).Nullify(sheet.ID, OperatorInfo.CurrentOperator.OperatorName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        PurchaseOrder sheet1 = (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnStr)).GetByID(sheet.ID).QueryObject;
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
            FrmOrderRecordSelection frm = new FrmOrderRecordSelection();
            frm.ForSelect = true;
            OrderRecordSearchCondition con = new OrderRecordSearchCondition();
            con.States = new List<SheetState>();
            con.States.Add(SheetState.Add);
            con.States.Add(SheetState.Approved);
            con.HasToPurchase = true;
            frm.SearchCondition = con;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                OrderRecord oi = frm.SelectedItem as OrderRecord;
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
                Customer item = frm.SelectedItem as Customer;
                txtSupplier.Text = item.Name;
                txtSupplier.Tag = item;
            }
        }

        private void lnkCurrencyType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCurrencyTypeMaster frm = new FrmCurrencyTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CurrencyType item = frm.SelectedItem as CurrencyType;
                txtCurrencyType.Text = item.ID;
            }
        }

        private void lnkBuyer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOperatorMaster frm = new FrmOperatorMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                OperatorInfo item = frm.SelectedItem as OperatorInfo;
                txtBuyer.Text = item.OperatorName;
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
                    Order item = (new OrderBLL(AppSettings.CurrentSetting.ConnStr)).GetByID(orderID).QueryObject;
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

