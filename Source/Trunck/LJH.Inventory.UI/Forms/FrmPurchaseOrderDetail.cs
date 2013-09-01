using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
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

        private void ShowOperations()
        {
            dataGridView1.Rows.Clear();
            List<DocumentOperation> items = (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnectString)).GetHisOperations((UpdatingItem as PurchaseOrder).ID).QueryObjects;
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
            this.txtSheetNo.Text = _AutoCreate;
            this.dtDeliveryDate.Value = DateTime.Today.AddDays(1);
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            ItemsGrid.Columns["colPrice"].Visible = OperatorInfo.CurrentOperator.Permit(Permission.ReadPrice);
            ItemsGrid.Columns["colTotal"].Visible = OperatorInfo.CurrentOperator.Permit(Permission.ReadPrice);
        }

        protected override void ItemShowing()
        {
            PurchaseOrder PurchaseSheet = UpdatingItem as PurchaseOrder;
            if (PurchaseSheet != null)
            {
                this.txtSheetNo.Text = PurchaseSheet.ID;
                this.txtSheetNo.Enabled = false;
                this.txtSupplier.Text = PurchaseSheet.Supplier.Name;
                this.txtSupplier.Tag = PurchaseSheet.Supplier;
                this.dtOrderDate.Value = PurchaseSheet.OrderDate;
                this.txtCurrencyType.Text = PurchaseSheet.CurrencyType;
                this.txtBuyer.Text = PurchaseSheet.Buyer;
                this.dtDeliveryDate.Value = PurchaseSheet.DemandDate;
                ShowDeliveryItemsOnGrid(PurchaseSheet.Items);
                ShowOperations();
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
            PurchaseSheet.SupplierID = (this.txtSupplier.Tag as Supplier).ID;
            PurchaseSheet.Supplier = this.txtSupplier.Tag as Supplier;
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
            return (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnectString)).Add(item as PurchaseOrder,OperatorInfo .CurrentOperator.OperatorName );
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnectString)).Update(item as PurchaseOrder,OperatorInfo .CurrentOperator .OperatorName );
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

        public void AddPurchaseSheettem(OrderItem oi)
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
                    CommandResult ret = (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnectString)).Approve(sheet.ID, OperatorInfo.CurrentOperator.OperatorName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        PurchaseOrder sheet1 = (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheet.ID).QueryObject;
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
                    CommandResult ret = (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnectString)).Nullify(sheet.ID, OperatorInfo.CurrentOperator.OperatorName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        PurchaseOrder sheet1 = (new PurchaseOrderBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheet.ID).QueryObject;
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
            FrmNotPurchaseItems frm = new FrmNotPurchaseItems();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                OrderItem p = frm.SelectedItem as OrderItem;
                AddPurchaseSheettem(p);
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
                Supplier item = frm.SelectedItem as Supplier;
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
    }
}

