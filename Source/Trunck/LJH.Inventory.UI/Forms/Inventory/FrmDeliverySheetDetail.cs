using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.ExcelExporter;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmDeliverySheetDetail : FrmDetailBase
    {
        #region 构造函数
        public FrmDeliverySheetDetail()
        {
            InitializeComponent();
        }

        #endregion

        #region 私有方法
        private void ShowDeliveryItemsOnGrid(IEnumerable<DeliveryItem> items)
        {
            ItemsGrid.Rows.Clear();
            if (items != null)
            {
                foreach (DeliveryItem item in items)
                {
                    int row = ItemsGrid.Rows.Add();
                    ShowDeliveryItemOnRow(ItemsGrid.Rows[row], item);
                }
                int r = ItemsGrid.Rows.Add();
                ItemsGrid.Rows[r].Cells["colCount"].Value = "合计";
                ItemsGrid.Rows[r].Cells["colTotal"].Value = items.Sum(it => it.Amount);
            }
        }

        private void ShowDeliveryItemOnRow(DataGridViewRow row, DeliveryItem item)
        {
            row.Tag = item;
            row.Cells["colProductID"].Value = item.Product != null ? item.Product.ID : string.Empty;
            row.Cells["colProductName"].Value = item.Product != null ? item.Product.Name : string.Empty;
            row.Cells["colSpecification"].Value = item.Product != null ? item.Product.Specification : string.Empty;
            row.Cells["colUnit"].Value = item.Product != null ? item.Product.Unit : string.Empty;
            row.Cells["colPrice"].Value = item.Price;
            row.Cells["colCount"].Value = item.Count;
            row.Cells["colTotal"].Value = item.Amount;
            row.Cells["colOrderID"].Value = item.OrderID;
            row.Cells["colMemo"].Value = item.Memo;
        }

        private List<DeliveryItem> GetDeliveryItemsFromGrid()
        {
            List<DeliveryItem> items = new List<DeliveryItem>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) items.Add(row.Tag as DeliveryItem);
            }
            return items;
        }

        private decimal GetTotalAmount()
        {
            decimal sum = 0;
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null) sum += (row.Tag as DeliveryItem).Amount;
            }
            return sum;
        }

        private void ShowSheet(DeliverySheet item)
        {
            if (!string.IsNullOrEmpty(item.ID))
            {
                this.txtSheetNo.Text = item.ID;
                this.txtSheetNo.Enabled = false;
            }
            this.txtCustomer.Text = item.Customer != null ? item.Customer.Name : string.Empty;
            this.txtCustomer.Tag = item.Customer;
            this.txtWareHouse.Text = item.WareHouse != null ? item.WareHouse.Name : string.Empty;
            this.txtWareHouse.Tag = item.WareHouse;
            this.txtMemo.Text = item.Memo;
            ShowDeliveryItemsOnGrid(item.Items);
            List<DocumentOperation> items = (new DocumentOperationBLL(AppSettings.Current.ConnStr)).GetHisOperations(item.ID, item.DocumentType).QueryObjects;
            ShowOperations(items, dataGridView1);
            List<AttachmentHeader> headers = (new AttachmentBLL(AppSettings.Current.ConnStr)).GetHeaders(item.ID, item.DocumentType).QueryObjects;
            ShowAttachmentHeaders(headers, this.gridAttachment);
            ShowButtonState();
            if (item.State != SheetState.Add)
            {
                this.ItemsGrid.ReadOnly = true;
                this.ItemsGrid.ContextMenuStrip = null;
                this.ItemsGrid.ContextMenu = null;
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
            if (txtCustomer.Tag == null)
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
                DeliveryItem item = row.Tag as DeliveryItem;
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
            DeliverySheet sheet = UpdatingItem as DeliverySheet;
            if (sheet != null) ShowSheet(sheet);
        }

        protected override object GetItemFromInput()
        {
            DeliverySheet sheet = UpdatingItem as DeliverySheet;
            if (sheet == null)
            {
                sheet = new DeliverySheet();
                sheet.ID = txtSheetNo.Text == "自动创建" ? string.Empty : this.txtSheetNo.Text;
            }
            else
            {
                sheet = UpdatingItem as DeliverySheet;
            }
            sheet.CustomerID = this.txtCustomer.Tag != null ? (this.txtCustomer.Tag as CompanyInfo).ID : string.Empty;
            sheet.Customer = this.txtCustomer.Tag as CompanyInfo;
            if (!string.IsNullOrEmpty(this.txtWareHouse.Text) && this.txtWareHouse.Tag != null)
            {
                sheet.WareHouse = this.txtWareHouse.Tag as WareHouse;
                sheet.WareHouseID = sheet.WareHouse.ID;
            }
            else
            {
                sheet.WareHouse = null;
                sheet.WareHouseID = null;
            }
            sheet.Memo = txtMemo.Text;
            sheet.Items = new List<DeliveryItem>();
            foreach (DataGridViewRow row in ItemsGrid.Rows)
            {
                if (row.Tag != null)
                {
                    DeliveryItem item = row.Tag as DeliveryItem;
                    item.SheetNo = sheet.ID;
                    sheet.Items.Add(item);
                }
            }
            return sheet;
        }

        protected override CommandResult AddItem(object item)
        {
            return (new DeliverySheetBLL(AppSettings.Current.ConnStr)).Add(item as DeliverySheet, Operator.Current.ID);
        }

        protected override CommandResult UpdateItem(object item)
        {
            return (new DeliverySheetBLL(AppSettings.Current.ConnStr)).Update(item as DeliverySheet, Operator.Current.ID);
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
                DeliverySheet sheet = UpdatingItem as DeliverySheet;
                this.btnSave.Enabled = sheet.State == SheetState.Add;
                this.btnPrint.Enabled = sheet.CanPrint;
                this.btnApprove.Enabled = sheet.CanApprove;
                this.btnShip.Enabled = sheet.CanShip;
            }
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            DeliverySheet item = UpdatingItem as DeliverySheet;
            if (item != null)
            {
                OpenFileDialog dig = new OpenFileDialog();
                if (dig.ShowDialog() == DialogResult.OK)
                {
                    AttachmentHeader header = new AttachmentHeader();
                    header.ID = Guid.NewGuid();
                    header.DocumentID = item.ID;
                    header.DocumentType = item.DocumentType;
                    header.Owner = Operator.Current.Name;
                    header.FileName = System.IO.Path.GetFileName(dig.FileName);
                    header.UploadDateTime = DateTime.Now;
                    CommandResult ret = (new AttachmentBLL(AppSettings.Current.ConnStr)).Upload(header, dig.FileName);
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
                CommandResult ret = (new AttachmentBLL(AppSettings.Current.ConnStr)).Download(header, path);
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
                    CommandResult ret = (new AttachmentBLL(AppSettings.Current.ConnStr)).Download(header, dig.FileName);
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
                    CommandResult ret = (new AttachmentBLL(AppSettings.Current.ConnStr)).Delete(header);
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

        #region 公共属性
        /// <summary>
        /// 获取或设置发货的订单,用于增加送货单时指定要发货的订单
        /// </summary>
        public Order Order { get; set; }
        #endregion

        #region 公共方法
        public void AddDeliveryItem(Product p)
        {
            List<DeliveryItem> sources = GetDeliveryItemsFromGrid();
            if (!sources.Exists(it => it.ProductID == p.ID))
            {
                if (sources.Count < DeliverySheet.MaxItemCount)
                {
                    DeliveryItem item = new DeliveryItem()
                    {
                        ID = Guid.NewGuid(),
                        ProductID = p.ID,
                        Product = p,
                        Unit = p.Unit,
                        Price = p.Price,
                        Count = 0
                    };
                    sources.Add(item);
                }
                else
                {
                    MessageBox.Show("一个送货单最多只能有 " + DeliverySheet.MaxItemCount + " 个送货单项");
                }
            }
            ShowDeliveryItemsOnGrid(sources);
        }

        public void AddDeliveryItem(OrderItem oi, decimal count)
        {
            List<DeliveryItem> sources = GetDeliveryItemsFromGrid();
            if (!sources.Exists(it => it.OrderItem != null && it.OrderItem.Value == oi.ID))
            {
                if (sources.Count < DeliverySheet.MaxItemCount)
                {
                    DeliveryItem item = new DeliveryItem()
                    {
                        ID = Guid.NewGuid(),
                        OrderItem = oi.ID,
                        OrderID = oi.OrderID,
                        ProductID = oi.ProductID,
                        Product = oi.Product,
                        Unit = oi.Unit,
                        Price = oi.Price,
                        Count = count
                    };
                    sources.Add(item);
                }
                else
                {
                    MessageBox.Show("一个送货单最多只能有 " + DeliverySheet.MaxItemCount + " 个送货单项");
                }
            }
            ShowDeliveryItemsOnGrid(sources);
        }

        public void AddDeliveryItem(OrderRecord oi)
        {
            List<DeliveryItem> sources = GetDeliveryItemsFromGrid();
            if (!sources.Exists(it => it.OrderItem != null && it.OrderItem.Value == oi.ID))
            {
                if (sources.Count < DeliverySheet.MaxItemCount)
                {
                    DeliveryItem item = new DeliveryItem()
                    {
                        ID = Guid.NewGuid(),
                        OrderItem = oi.ID,
                        OrderID = oi.OrderID,
                        ProductID = oi.ProductID,
                        Product = oi.Product,
                        Unit = oi.Unit,
                        Price = oi.Price,
                        Count = oi.Inventory,
                    };
                    sources.Add(item);
                }
                else
                {
                    MessageBox.Show("一个送货单最多只能有 " + DeliverySheet.MaxItemCount + " 个送货单项");
                }
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
                CompanyInfo item = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = item.Name;
                txtCustomer.Tag = item;
            }
            else
            {
                txtCustomer.Text = string.Empty;
                txtCustomer.Tag = null;
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
                DeliveryItem item = row.Tag as DeliveryItem;
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
                    int count;
                    if (int.TryParse(row.Cells[e.ColumnIndex].Value.ToString(), out count))
                    {
                        if (count < 0) count = 0;
                        if (UserSettings.Current.CheckCountWhenSaveDeliverySheet)
                        {
                            string pid = (row.Tag as DeliveryItem).ProductID;
                            //if (txtWareHouse.SelectedWareHouse != null)
                            //{
                            //    InventoryItemID id = new InventoryItemID(pid, txtWareHouse.SelectedWareHouseID);
                            //    ProductInventory pi = (new ProductInventoryBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(id).QueryObject;
                            //    if (pi != null && count > pi.Count)
                            //    {
                            //        MessageBox.Show("库存数量不足出货");
                            //        count = 0;
                            //    }
                            //}
                        }
                        item.Count = count;
                        row.Cells[e.ColumnIndex].Value = count;
                    }
                }
                row.Cells["colTotal"].Value = item.Amount;
                ItemsGrid.Rows[ItemsGrid.Rows.Count - 1].Cells["colTotal"].Value = GetTotalAmount();
            }
        }

        private void mnu_AddOrderItem_Click(object sender, EventArgs e)
        {
            if (txtCustomer.Tag != null)
            {
                FrmOrderRecordSelection frm = new FrmOrderRecordSelection();
                frm.ForSelect = true;
                OrderRecordSearchCondition con = new OrderRecordSearchCondition();
                con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
                con.States = new List<SheetState>();
                con.States.Add(SheetState.Add);
                con.States.Add(SheetState.Approved);
                con.HasToDelivery = false;
                frm.SearchCondition = con;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    OrderRecord oi = frm.SelectedItem as OrderRecord;
                    AddDeliveryItem(oi);
                }
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmProductMaster frm = new FrmProductMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Product p = frm.SelectedItem as Product;
                AddDeliveryItem(p);
            }
        }

        private void mnu_Remove_Click(object sender, EventArgs e)
        {
            if (ItemsGrid.SelectedRows.Count > 0)
            {
                List<DeliveryItem> items = GetDeliveryItemsFromGrid();
                foreach (DataGridViewRow row in ItemsGrid.SelectedRows)
                {
                    if (row.Tag != null) items.Remove(row.Tag as DeliveryItem);
                }
                ShowDeliveryItemsOnGrid(items);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.btnOk.PerformClick();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                try
                {
                    if (MessageBox.Show("是否要审核此送货单?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        DeliverySheet sheet = UpdatingItem as DeliverySheet;
                        CommandResult ret = (new DeliverySheetBLL(AppSettings.Current.ConnStr)).Approve(sheet.ID, Operator.Current.Name);
                        if (ret.Result == ResultCode.Successful)
                        {
                            DeliverySheet sheet1 = (new DeliverySheetBLL(AppSettings.Current.ConnStr)).GetByID(sheet.ID).QueryObject;
                            this.UpdatingItem = sheet1;
                            ItemShowing();
                            ShowButtonState();
                            this.OnItemUpdated(new ItemUpdatedEventArgs(sheet1));
                        }
                        else
                        {
                            MessageBox.Show(ret.Message, "失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                try
                {
                    if (MessageBox.Show("是否要打印此送货单?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        string modal = System.IO.Path.Combine(Application.StartupPath, "送货单模板.xls");
                        DeliverySheetExporter exporter = null;
                        if (System.IO.File.Exists(modal))
                        {
                            DeliverySheet sheet = UpdatingItem as DeliverySheet;
                            exporter = new DeliverySheetExporter(modal);
                            exporter.PrintDeliverySheet(sheet);
                        }
                        else
                        {
                            MessageBox.Show("未找到送货单导出模板", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnShip_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                if (MessageBox.Show("是否要发货?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        DeliverySheet sheet = UpdatingItem as DeliverySheet;
                        CommandResult ret = (new DeliverySheetBLL(AppSettings.Current.ConnStr)).Delivery(sheet.ID, Operator.Current.Name);
                        if (ret.Result == ResultCode.Successful)
                        {
                            DeliverySheet sheet1 = (new DeliverySheetBLL(AppSettings.Current.ConnStr)).GetByID(sheet.ID).QueryObject;
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnNullify_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                //if (MessageBox.Show("是否要作废此送货单?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                //{
                //    DeliverySheet sheet = UpdatingItem as DeliverySheet;
                //    CommandResult ret = null;
                //    if (sheet.Paid > 0)
                //    {
                //        DialogResult qr = MessageBox.Show("取消送货单时，对于此送货单已经支付的金额，你是否想把它用于抵销其它应收项？", "询问", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                //        if (qr != DialogResult.Cancel)
                //        {
                //            ret = (new DeliverySheetBLL(AppSettings.CurrentSetting.ConnectString)).Cancel(sheet, OperatorInfo.CurrentOperator.OperatorName, qr == DialogResult.Yes);
                //        }
                //        else
                //        {
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        ret = (new DeliverySheetBLL(AppSettings.CurrentSetting.ConnectString)).Cancel(sheet, OperatorInfo.CurrentOperator.OperatorName, false);
                //    }
                //    if (ret.Result == ResultCode.Successful)
                //    {
                //        DeliverySheet sheet1 = (new DeliverySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheet.ID).QueryObject;
                //        this.UpdatingItem = sheet1;
                //        ItemShowing();
                //        ShowButtonState();
                //        this.OnItemUpdated(new ItemUpdatedEventArgs(sheet1));
                //    }
                //    else
                //    {
                //        MessageBox.Show(ret.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    }
                //}
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
        #endregion
    }
}
