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
using LJH.Inventory.UI.View;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmOrderDetail : FrmDetailBase
    {
        public FrmOrderDetail()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ShowDeliveryItemsOnGrid(IEnumerable<OrderItem> items)
        {
            ItemsGrid.Rows.Clear();
            if (items != null)
            {
                foreach (OrderItem item in items)
                {
                    int row = ItemsGrid.Rows.Add();
                    ShowDeliveryItemOnRow(ItemsGrid.Rows[row], item);
                }
                int r = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[r].Cells["colCount"].Value = "合计";
                ItemsGrid.Rows[r].Cells["colTotal"].Value = items.Sum(it => it.Amount).Trim();
            }
        }

        private void ShowDeliveryItemOnRow(DataGridViewRow row, OrderItem item)
        {
            row.Tag = item;
            row.Cells["colProductID"].Value = item.Product != null ? item.Product.ID : string.Empty;
            row.Cells["colProductName"].Value = item.Product != null ? item.Product.Name : string.Empty;
            row.Cells["colForeignName"].Value = item.Product != null ? item.Product.ForeignName : string.Empty;
            row.Cells["colProductCode"].Value = item.ProductCode;
            row.Cells["colSpecification"].Value = item.Product != null ? item.Product.Specification : string.Empty;
            row.Cells["colUnit"].Value = item.Unit;
            row.Cells["colPrice"].Value = item.Price.Trim();
            row.Cells["colCount"].Value = item.Count.Trim();
            row.Cells["colTotal"].Value = item.Amount.Trim();
            row.Cells["colOnPurchase"].Value = item.OnWay.Trim();
            row.Cells["colPurchase"].Value = "采购明细";
            row.Cells["colInventory"].Value = item.Inventory.Trim();
            row.Cells["colPrepared"].Value = (item.Inventory + item.OnWay).Trim();
            row.Cells["colShipped"].Value = item.Shipped.Trim();
            row.Cells["colNotShipped"].Value = item.NotShipped.Trim();
        }

        private List<OrderItem> GetOrderItemsFromGrid()
        {
            List<OrderItem> items = new List<OrderItem>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) items.Add(row.Tag as OrderItem);
            }
            return items;
        }

        private decimal GetTotalAmount()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) sum += (row.Tag as OrderItem).Amount;
            }
            return sum.Trim();
        }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtSheetNo.Text) && UpdatingItem != null)
            {
                MessageBox.Show("订单号不能为空");
                txtSheetNo.Focus();
                return false;
            }
            if (txtCustomer.Tag == null)
            {
                MessageBox.Show("没有选择客户");
                txtCustomer.Focus();
                return false;
            }
            if (txtCurrencyType.Tag == null)
            {
                MessageBox.Show("没有选择币别");
                return false;
            }
            if (string.IsNullOrEmpty(txtSalesPerson.Text))
            {
                MessageBox.Show("业务人员不能为空");
                txtSalesPerson.Focus();
                return false;
            }
            if (ItemsGrid.Rows.Count == 0)
            {
                MessageBox.Show("订单没有填写订货项");
                return false;
            }
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                OrderItem item = row.Tag as OrderItem;
                if (item != null && item.Count == 0)
                {
                    MessageBox.Show(string.Format("订单第 {0} 项数量为零", row.Index + 1));
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
            Order item = UpdatingItem as Order;
            if (item != null)
            {
                this.txtSheetNo.Text = item.ID;
                this.txtSheetNo.Enabled = false;
                this.txtCustomer.Text = item.Customer.Name;
                this.txtCustomer.Tag = item.Customer;
                this.txtFinalCustomer.Text = item.FinalCustomer != null ? item.FinalCustomer.Name : string.Empty;
                this.txtFinalCustomer.Tag = item.FinalCustomer;
                this.dtOrderDate.Value = item.OrderDate;
                this.txtPriceTerm.Text = item.PriceTerm;
                this.txtCurrencyType.Text = item.CurrencyType;
                this.txtExchangeRate.DecimalValue = item.ExchangeRate;
                this.txtCollectionType.Text = item.CollectionType;
                this.txtTransport.Text = item.Transport;
                this.txtLoadPort.Text = item.LoadPort;
                this.txtDestinationPort.Text = item.DestinationPort;
                this.txtSalesPerson.Text = item.SalesPerson;
                this.dtDeliveryDate.Value = item.DemandDate;
                ShowDeliveryItemsOnGrid(item.Items);
                List<DocumentOperation> items = (new DocumentOperationBLL(AppSettings.CurrentSetting.ConnectString)).GetHisOperations(item.ID, item.DocumentType).QueryObjects;
                ShowOperations(items, dataGridView1);
                ShowAttachmentHeaders();
                ShowButtonState();
            }
        }

        protected override object GetItemFromInput()
        {
            Order order = UpdatingItem as Order;
            if (order == null)
            {
                order = new Order();
                order.Items = new List<OrderItem>();
                order.OrderDate = DateTime.Now;
                order.ID = txtSheetNo.Text == "自动创建" ? string.Empty : this.txtSheetNo.Text;
            }
            else
            {
                order = UpdatingItem as Order;
            }
            order.OrderDate = this.dtOrderDate.Value;
            order.CustomerID = (this.txtCustomer.Tag as Customer).ID;
            order.Customer = this.txtCustomer.Tag as Customer;
            order.FinalCustomerID = this.txtFinalCustomer.Tag != null ? (this.txtFinalCustomer.Tag as Customer).ID : null;
            order.FinalCustomer = this.txtFinalCustomer.Tag as Customer;
            order.PriceTerm = this.txtPriceTerm.Text;
            order.CurrencyType = this.txtCurrencyType.Text;
            order.Symbol = (this.txtCurrencyType.Tag as CurrencyType).Symbol;
            order.ExchangeRate = this.txtExchangeRate.DecimalValue;
            order.CollectionType = this.txtCollectionType.Text;
            order.Transport = this.txtTransport.Text;
            order.LoadPort = this.txtLoadPort.Text;
            order.DestinationPort = this.txtDestinationPort.Text;
            order.SalesPerson = this.txtSalesPerson.Text;
            order.DemandDate = this.dtDeliveryDate.Value;
            order.Items = GetOrderItemsFromGrid();
            order.Items.ForEach(item => item.DemandDate = order.DemandDate);
            order.Items.ForEach(item => item.OrderID = order.ID);
            return order;
        }

        protected override void ShowButtonState()
        {
            if (UpdatingItem == null)
            {
                this.btnOk.Enabled = true;
                this.btnPrint.Enabled = false;
                this.btnApprove.Enabled = false;
                this.btnShip.Enabled = false;
            }
            else
            {
                Order sheet = UpdatingItem as Order;
                this.btnSave.Enabled = sheet.CanEdit;
                this.btnPrint.Enabled = true;
                this.btnApprove.Enabled = sheet.CanApprove;
            }
        }

        protected override CommandResult AddItem(object item)
        {
            return (new OrderBLL(AppSettings.CurrentSetting.ConnectString)).Add(item as Order, OperatorInfo.CurrentOperator.OperatorName);
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new OrderBLL(AppSettings.CurrentSetting.ConnectString)).Update(item as Order, OperatorInfo.CurrentOperator.OperatorName);
        }
        #endregion

        #region 公共方法
        public void AddOrdertem(Product product)
        {
            List<OrderItem> sources = GetOrderItemsFromGrid();
            if (!sources.Exists(it => it.ProductID == product.ID))
            {
                if (sources.Count < DeliverySheet.MaxItemCount)
                {
                    OrderItem item = new OrderItem()
                     {
                         ID = Guid.NewGuid(),
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
                if (MessageBox.Show("是否要审核此订单?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Order sheet = UpdatingItem as Order;
                    CommandResult ret = (new OrderBLL(AppSettings.CurrentSetting.ConnectString)).Approve(sheet.ID, OperatorInfo.CurrentOperator.OperatorName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        Order sheet1 = (new OrderBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheet.ID).QueryObject;
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

        private void btnNullify_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                if (MessageBox.Show("是否将此订单作废?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    Order sheet = UpdatingItem as Order;
                    CommandResult ret = (new OrderBLL(AppSettings.CurrentSetting.ConnectString)).Nullify(sheet.ID, OperatorInfo.CurrentOperator.OperatorName);
                    if (ret.Result == ResultCode.Successful)
                    {
                        Order sheet1 = (new OrderBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheet.ID).QueryObject;
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

        private void btnShip_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                Order order = UpdatingItem as Order;
                FrmDeliverySheetDetail frm = new FrmDeliverySheetDetail();
                frm.Order = order;
                frm.IsAdding = true;
                frm.ShowDialog();
            }
        }

        private void ItemsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewColumn col = ItemsGrid.Columns[e.ColumnIndex];
            DataGridViewRow row = ItemsGrid.Rows[e.RowIndex];
            if (row.Tag != null)
            {
                OrderItem item = row.Tag as OrderItem;
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
                else if (col.Name == "colProductCode")
                {
                    if (row.Cells[e.ColumnIndex].Value != null)
                    {
                        item.ProductCode = row.Cells[e.ColumnIndex].Value.ToString();
                    }
                    else
                    {
                        item.ProductCode = null;
                    }
                }
                else if (col.Name == "colMemo")
                {
                    if (row.Cells[e.ColumnIndex].Value != null)
                    {
                        item.Memo = row.Cells[e.ColumnIndex].Value.ToString();
                    }
                    else
                    {
                        item.Memo = null;
                    }
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
                AddOrdertem(p);
            }
        }

        private void mnu_Remove_Click(object sender, EventArgs e)
        {
            if (ItemsGrid.SelectedRows.Count > 0)
            {
                List<OrderItem> items = GetOrderItemsFromGrid();
                foreach (DataGridViewRow row in ItemsGrid.SelectedRows)
                {
                    if (row.Tag != null) items.Remove(row.Tag as OrderItem);
                }
                ShowDeliveryItemsOnGrid(items);
            }
        }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer item = frm.SelectedItem as Customer;
                txtCustomer.Text = item.Name;
                txtCustomer.Tag = item;
            }
        }

        private void lnkEndCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer item = frm.SelectedItem as Customer;
                txtFinalCustomer.Text = item.Name;
                txtFinalCustomer.Tag = item;
            }
        }

        private void lnkPriceTerm_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmPriceTermMaster frm = new FrmPriceTermMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                PriceTerm item = frm.SelectedItem as PriceTerm;
                txtPriceTerm.Text = item.ID;
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
                txtCurrencyType.Tag = item;
                txtExchangeRate.DecimalValue = item.ExchangeRate;
            }
        }

        private void lnkCollectionType_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCollectionTypeMaster frm = new FrmCollectionTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CollectionType item = frm.SelectedItem as CollectionType;
                if (string.IsNullOrEmpty(txtCollectionType.Text))
                {
                    txtCollectionType.Text = item.ID + ";";
                }
                else
                {
                    string[] temp = txtCollectionType.Text.Split(';');
                    if (temp.SingleOrDefault(it => it == item.ID) == null)
                    {
                        txtCollectionType.Text += item.ID + ";";
                    }
                }
            }
        }

        private void lnkTransport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmTransportMaster frm = new FrmTransportMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Transport item = frm.SelectedItem as Transport;
                txtTransport.Text = item.Name;
            }
        }

        private void lnkLoadPort_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmNativePortMaster frm = new FrmNativePortMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Port item = frm.SelectedItem as Port;
                txtLoadPort.Text = item.ID;
            }
        }

        private void lnkDestinationPort_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmForeignPortMaster frm = new FrmForeignPortMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Port item = frm.SelectedItem as Port;
                txtDestinationPort.Text = item.ID;
            }
        }

        private void lnkSalesPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmOperatorMaster frm = new FrmOperatorMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                OperatorInfo item = frm.SelectedItem as OperatorInfo;
                txtSalesPerson.Text = item.OperatorName;
            }
        }
        #endregion

        private void ItemsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (ItemsGrid.Columns[e.ColumnIndex].Name == "colShipped")
                {
                    OrderItem pi = ItemsGrid.Rows[e.RowIndex].Tag as OrderItem;
                    DeliveryRecordSearchCondition con = new DeliveryRecordSearchCondition();
                    con.OrderItem = pi.ID;
                    FrmDeliveryRecordView frm = new FrmDeliveryRecordView();
                    frm.SearchCondition = con;
                    frm.ShowDialog();
                }
            }
        }

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_Upload_Click(object sender, EventArgs e)
        {
            Order item = UpdatingItem as Order;
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
                    CommandResult ret = (new AttachmentBLL(AppSettings.CurrentSetting.ConnectString)).Upload(header, dig.FileName);
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

        private void ShowAttachmentHeaderOnRow(AttachmentHeader header, DataGridViewRow row)
        {
            row.Cells["colUploadDateTime"].Value = header.UploadDateTime;
            row.Cells["colOwner"].Value = header.Owner;
            row.Cells["colFileName"].Value = header.FileName;
        }

        private void ShowAttachmentHeaders()
        {
            gridAttachment.Rows.Clear();
            Order item = UpdatingItem as Order;
            if (item != null)
            {
                List<AttachmentHeader> items = (new AttachmentBLL(AppSettings.CurrentSetting.ConnectString)).GetHeaders(item.ID, item.DocumentType).QueryObjects;
                if (items != null && items.Count > 0)
                {
                    foreach (AttachmentHeader header in items)
                    {
                        int row = gridAttachment.Rows.Add();
                        ShowAttachmentHeaderOnRow(header, gridAttachment.Rows[row]);
                    }
                }
            }
        }
        #endregion
    }
}
