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
using LJH.Inventory.UI.Forms.Inventory.View;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollMaster : FrmMasterBase
    {
        public FrmSteelRollMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private bool _DataLoaded = false;
        private List<ProductInventoryItem> _SteelRolls = null;
        private List<CompanyInfo> _AllSuppliers = null;
        private List<WareHouse> _AllWarehouse = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            List<ProductInventoryItem> items = _SteelRolls;
            if (items != null && items.Count > 0)
            {
                if (chkStackIn.Checked) items = items.Where(it => it.AddDate >= ucDateTimeInterval1.StartDateTime && it.AddDate <= ucDateTimeInterval1.EndDateTime).ToList();
                if (!string.IsNullOrEmpty(categoryComboBox1.Text)) items = items.Where(it => it.Product.CategoryID == categoryComboBox1.SelectedCategoryID).ToList();
                if (!string.IsNullOrEmpty(wareHouseComboBox1.Text)) items = items.Where(it => it.WareHouseID == wareHouseComboBox1.SelectedWareHouseID).ToList();
                if (!string.IsNullOrEmpty(cmbSpecification.Text)) items = items.Where(it => it.Product.Specification.Contains(cmbSpecification.Text)).ToList();
                if (cmbSupplier.SelectedCustomer != null) items = items.Where(it => it.Supplier == cmbSupplier.SelectedCustomer.ID).ToList();
                if (!string.IsNullOrEmpty(cmbBrand.Text)) items = items.Where(it => it.Manufacture == cmbBrand.Text).ToList();
                if (!string.IsNullOrEmpty(customerCombobox1.Text)) items = items.Where(it => it.Customer.Contains(customerCombobox1.Text)).ToList();
                if (!string.IsNullOrEmpty(txtPurchaseID.Text)) items = items.Where(it => !string.IsNullOrEmpty(it.PurchaseID) && it.PurchaseID.Contains(txtPurchaseID.Text)).ToList();
                if (txtWeight.DecimalValue > 0) items = items.Where(it => it.OriginalWeight == txtWeight.DecimalValue).ToList();
                items = items.Where(it => (chkIntact.Checked && it.Status == "整卷") ||
                                       (chkPartial.Checked && it.Status == "余卷") ||
                                       (chkOnlyTail.Checked && it.Status == "尾卷") ||
                                       (chkRemainless.Checked && it.Status == "余料")).ToList();
                items = items.Where(it => (chk作废.Checked && it.State == ProductInventoryState.Nullified) ||
                                          (chk发货.Checked && it.State == ProductInventoryState.Shipped) ||
                                          (chk待发货.Checked && it.State == ProductInventoryState.WaitShipping) ||
                                          (chk预订.Checked && it.State == ProductInventoryState.Reserved) ||
                                          (chk在库.Checked && it.State == ProductInventoryState.Inventory)).ToList();
            }
            if (items != null && items.Count > 0)
            {
                return (from p in items
                        orderby p.Product.CategoryID ascending,
                                SpecificationHelper.GetWritten克重(p.Product.Specification) ascending,
                                SpecificationHelper.GetWrittenWidth(p.Product.Specification) ascending,
                                p.AddDate descending
                        select (object)p).ToList();
            }
            return null;
        }

        private void ShowRowColor(DataGridViewRow row)
        {
            ProductInventoryItem sr = row.Tag as ProductInventoryItem;
            if (sr.State == ProductInventoryState.Nullified)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
            else if (sr.State == ProductInventoryState.WaitShipping)
            {
                row.DefaultCellStyle.ForeColor = Color.Brown;
            }
            else if (sr.State == ProductInventoryState.Shipped)
            {
                row.DefaultCellStyle.ForeColor = Color.Brown;
            }
            else if (sr.State == ProductInventoryState.Reserved)
            {
                row.DefaultCellStyle.ForeColor = Color.Brown;
            }
            else if (sr.Status == "整卷")
            {
                row.DefaultCellStyle.ForeColor = Color.Blue;
            }
            else if (sr.Status == "余卷")
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
            else if (sr.Status == "尾卷")
            {
                row.DefaultCellStyle.ForeColor = Color.Orange;
            }
            else
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
            }
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            this.wareHouseComboBox1.Init();
            this.cmbSpecification.Init(new List<string> { ProductModel.原材料, ProductModel.开平, ProductModel.开卷, ProductModel.开吨, ProductModel.开条 });
            this.categoryComboBox1.Init();
            this.cmbBrand.Init(CompanyClass.厂家);
            this.cmbSupplier.Init(CompanyClass.Supplier);
            this.customerCombobox1.Init(CompanyClass.Customer);
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisMonth();
            pnlStates.Enabled = !ForSelect;
            if (this.MultiSelect) GridView.ContextMenuStrip = null;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Inventory);
            mnu_拆卷.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Edit) || Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Inventory);
            mnu_开平.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Slice);
            mnu_Check.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Check);
            mnu_Nullify.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Nullify);
            更换仓库ToolStripMenuItem.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Edit);
            this.取消预订ToolStripMenuItem.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Edit);
            this.预订ToolStripMenuItem.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Edit);
            mnu_Import.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Inventory);
            mnu_设置入库单价.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.设置成本);
            mnu_设置其它成本.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.设置成本);
            mnu_查看成本明细.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.设置成本) | Operator.Current.Permit(Permission.SteelRoll, PermissionActions.显示成本);
            mnu_查看价格改动记录.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.设置成本) | Operator.Current.Permit(Permission.SteelRoll, PermissionActions.显示成本);
            cMnu_Export.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.导出);
            mnu_原材料拆条.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Slice);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmSteelRollDetail frm = new FrmSteelRollDetail();
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            _AllWarehouse = new WareHouseBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            _AllSuppliers = new CompanyBLL(AppSettings.Current.ConnStr).GetAllSuppliers().QueryObjects;
            var bll = new SteelRollBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                var con = new ProductInventoryItemSearchCondition();
                con.HasRemain = true;
                con.States = new List<ProductInventoryState>();
                con.States.Add(ProductInventoryState.Inventory);
                con.States.Add(ProductInventoryState.WaitShipping);
                con.States.Add(ProductInventoryState.Reserved);
                if (chk发货.Checked) con.States.Add(ProductInventoryState.Shipped);
                if (chk作废.Checked) con.States.Add(ProductInventoryState.Nullified);
                if (!chkRemainless.Checked) con.HasWeight = true;
                _SteelRolls = bll.GetItems(con).QueryObjects;
            }
            else
            {
                _SteelRolls = bll.GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = FilterData();
            _DataLoaded = true;
            return records;
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            if (items != null)
            {
                decimal total = 0;
                decimal original = 0;
                foreach (var item in items)
                {
                    var pi = item as ProductInventoryItem;
                    if (pi.State != ProductInventoryState.Nullified && pi.State != ProductInventoryState.Shipped && pi.Status != "余料")
                    {
                        total += pi.Weight.Value;
                    }
                    if (pi.State != ProductInventoryState.Nullified) original += pi.OriginalWeight.Value;
                }
                lblTotalWeight.Text = string.Format("总剩余{0:F3}", total);
                lblOriginalTotal.Text = string.Format("总入库{0:F3}", original);
            }
            else
            {
                lblTotalWeight.Text = string.Empty;
                lblOriginalTotal.Text = string.Empty;
            }
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventoryItem sr = item as ProductInventoryItem;
            row.Tag = sr;
            row.Cells["colAddDate"].Value = sr.AddDate.ToString("yyyy-MM-dd");
            row.Cells["colName"].Value = sr.Product.Name;
            row.Cells["colCategory"].Value = sr.Product.Category == null ? sr.Product.CategoryID : sr.Product.Category.Name;
            row.Cells["colSpecification"].Value = sr.Product.Specification;
            WareHouse ws = null;
            if (_AllWarehouse != null) ws = _AllWarehouse.SingleOrDefault(it => it.ID == sr.WareHouseID);
            row.Cells["colWareHouse"].Value = ws != null ? ws.Name : null;
            row.Cells["colOriginalWeight"].Value = sr.OriginalWeight;
            row.Cells["colOriginalLength"].Value = sr.OriginalLength;
            row.Cells["colWeight"].Value = sr.Weight;
            row.Cells["colLength"].Value = sr.Length;
            if (sr.Original克重.HasValue) row.Cells["colOriginalThick"].Value = sr.Original克重.Value.Trim();
            if (sr.Real克重.HasValue) row.Cells["colRealThick"].Value = sr.Real克重.Value.Trim();
            row.Cells["colCustomer"].Value = sr.Customer;
            if (_AllSuppliers != null)
            {
                var s = _AllSuppliers.SingleOrDefault(it => it.ID == sr.Supplier);
                row.Cells["colSupplier"].Value = s != null ? s.Name : null;
            }
            row.Cells["colManufacture"].Value = sr.Manufacture;
            row.Cells["colState"].Value = ProductInventoryStateDescription.GetDescription(sr.State);
            row.Cells["colStatus"].Value = sr.Status;
            row.Cells["colSerialNumber"].Value = sr.SerialNumber;
            if (Operator.Current.Permit(Permission.SteelRoll, PermissionActions.设置成本) || Operator.Current.Permit(Permission.SteelRoll, PermissionActions.显示成本))
            {
                CostItem ci = sr.GetCost(CostItem.入库单价);
                if (ci != null) row.Cells["colPurchasePrice"].Value = ci.Price;
                if (ci != null) row.Cells["colPurchaseTax"].Value = ci.WithTax;
                ci = sr.GetCost(CostItem.运费);
                if (ci != null && ci.Price > 0) row.Cells["col运费"].Value = ci.Price;
                ci = sr.GetCost(CostItem.加工费);
                if (ci != null && ci.Price > 0)
                {
                    row.Cells["col开平费"].Value = ci.Price;
                }
                else
                {
                    ci = sr.GetCost("开平费");
                    if (ci != null && ci.Price > 0) row.Cells["col开平费"].Value = ci.Price;
                }
                ci = sr.GetCost(CostItem.吊装费);
                if (ci != null && ci.Price > 0) row.Cells["col吊装费"].Value = ci.Price;
                ci = sr.GetCost(CostItem.其它费用);
                if (ci != null && ci.Price > 0) row.Cells["col其它费用"].Value = ci.Price;
            }
            row.Cells["colDeliverySheet"].Value = sr.DeliverySheet;
            row.Cells["colPosition"].Value = sr.Position;
            row.Cells["colMaterial"].Value = sr.Material;
            row.Cells["colCarplate"].Value = sr.Carplate;
            row.Cells["colPurchaseID"].Value = sr.PurchaseID;
            row.Cells["colOperator"].Value = sr.Operator;
            row.Cells["colMemo"].Value = sr.Memo;
            if (sr.SourceRoll.HasValue) row.Cells["colSourceRoll"].Value = "查看";
            ShowRowColor(row);
            if (!_SteelRolls.Exists(it => it.ID == sr.ID))
            {
                _SteelRolls.Add(sr);
            }
            if (sr.State == ProductInventoryState.Nullified)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }
        #endregion

        #region 事件处理函数
        private void FreshData_Clicked(object sender, EventArgs e)
        {
            if (_DataLoaded) FreshData();
        }

        private void chk发货_CheckedChanged(object sender, EventArgs e)
        {
            if (_DataLoaded) cMnu_Fresh.PerformClick();
        }

        private void ucDateTimeInterval1_ValueChanged(object sender, EventArgs e)
        {
            if (chkStackIn.Checked) FreshData_Clicked(sender, e);
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colMemo")
            {
                var pi = dataGridView1.Rows[e.RowIndex].Tag as ProductInventoryItem;
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string memo = cell.Value != null ? cell.Value.ToString() : null;
                var ret = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).UpdateMemo(pi, memo);
                if (ret.Result != ResultCode.Successful)
                {
                    MessageBox.Show(ret.Message);
                    cell.Value = pi.Memo;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colPosition")
            {
                var pi = dataGridView1.Rows[e.RowIndex].Tag as ProductInventoryItem;
                var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string position = cell.Value != null ? cell.Value.ToString() : null;
                var ret = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).UpdatePosition(pi, position);
                if (ret.Result != ResultCode.Successful)
                {
                    MessageBox.Show(ret.Message);
                    cell.Value = pi.Position;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var pi = GridView.Rows[e.RowIndex].Tag as ProductInventoryItem;
                if (GridView.Columns[e.ColumnIndex].Name == "colDeliverySheet" && !string.IsNullOrEmpty(pi.DeliverySheet))
                {
                    var sheet = new StackOutSheetBLL(AppSettings.Current.ConnStr).GetByID(pi.DeliverySheet).QueryObject;
                    if (sheet != null)
                    {
                        Inventory.FrmStackOutSheetDetail frm = new Inventory.FrmStackOutSheetDetail();
                        frm.IsAdding = false;
                        frm.IsForView = true;
                        frm.UpdatingItem = sheet;
                        frm.ShowDialog();
                    }
                }
                else if (GridView.Columns[e.ColumnIndex].Name == "colSourceRoll" && pi.SourceRoll.HasValue)
                {
                    var steelRoll = new SteelRollBLL(AppSettings.Current.ConnStr).GetByID(pi.SourceRoll.Value).QueryObject;
                    if (steelRoll != null)
                    {
                        FrmSteelRollDetail frm = new FrmSteelRollDetail();
                        frm.IsForView = true;
                        frm.UpdatingItem = steelRoll;
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void mnu_拆卷_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                if (sr.State == ProductInventoryState.Inventory)
                {
                    Frm拆卷 frm = new Frm拆卷();
                    frm.SteelRoll = sr;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ShowItemInGridViewRow(dataGridView1.SelectedRows[0], sr);
                        var newR = frm.NewRoll;
                        _SteelRolls.Add(newR);
                        var row = dataGridView1.SelectedRows[0].Index;
                        dataGridView1.Rows.Insert(row, 1);
                        ShowItemInGridViewRow(dataGridView1.Rows[row], newR);
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("原材料处于 \"{0}\" 状态,不能进行拆卷", ProductInventoryStateDescription.GetDescription(sr.State)));
                }
            }
        }

        private void mnu_Slice_Click(object sender, EventArgs e)
        {
            string sliceTo = null;
            if (object.ReferenceEquals(sender, mnu_开平)) sliceTo = ProductModel.开平;

            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                if (sr.State == ProductInventoryState.Inventory)
                {
                    FrmSlice frm = new FrmSlice();
                    frm.SlicingItem = sr;
                    frm.SliceTo = sliceTo;
                    frm.ShowDialog();
                    ShowItemInGridViewRow(dataGridView1.SelectedRows[0], sr);
                }
                else
                {
                    MessageBox.Show(string.Format("原材料处于 \"{0}\" 状态,不能进行加工", ProductInventoryStateDescription.GetDescription(sr.State)));
                }
            }
        }

        private void mnu_SliceView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                SliceRecordSearchCondition con = new SliceRecordSearchCondition();
                con.SourceRoll = sr.ID;
                FrmSliceRecordView frm = new FrmSliceRecordView();
                frm.SearchCondition = con;
                frm.ShowDialog();
                cMnu_Fresh.PerformClick(); //
            }
        }

        private void mnu_Check_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                if (sr.State == ProductInventoryState.Inventory)
                {
                    FrmSteelRollCheck frm = new FrmSteelRollCheck();
                    frm.SteelRoll = sr;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ShowItemInGridViewRow(dataGridView1.SelectedRows[0], sr);
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("原材料处于 \"{0}\" 状态,不能进行盘点", ProductInventoryStateDescription.GetDescription(sr.State)));
                }
            }
        }

        private void mnu_CheckView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                View.FrmSteelRollCheckRecordView frm = new FrmSteelRollCheckRecordView();
                frm.SearchCondition = new InventoryCheckRecordSearchCondition() { SourceID = sr.ID };
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void mnu_Nullify_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要作废所选的原材料?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    ProductInventoryItem item = row.Tag as ProductInventoryItem;
                    if (item.State == ProductInventoryState.Inventory)
                    {
                        CommandResult ret = (new SteelRollBLL(AppSettings.Current.ConnStr)).Nullify(item);
                        if (ret.Result == ResultCode.Successful)
                        {
                            ShowItemInGridViewRow(row, item);
                        }
                        else
                        {
                            MessageBox.Show(ret.Message);
                        }
                    }
                }
            }
        }

        private void mnu_Import_Click(object sender, EventArgs e)
        {
            FrmSteelRollImport frm = new FrmSteelRollImport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            cMnu_Fresh.PerformClick();
        }

        private void 更换仓库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var pi = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                FrmChangeWareHouse frm = new FrmChangeWareHouse();
                frm.ProductInventory = pi;
                DialogResult ret = frm.ShowDialog();
                if (ret == DialogResult.OK) ShowItemInGridViewRow(dataGridView1.SelectedRows[0], pi);
            }
        }

        private void 预订ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var pi = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                if (pi.State == ProductInventoryState.Inventory)
                {
                    FrmReserve frm = new FrmReserve();
                    frm.ProductInventory = pi;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    DialogResult ret = frm.ShowDialog();
                    if (ret == DialogResult.OK) ShowItemInGridViewRow(dataGridView1.SelectedRows[0], pi);
                }
                else
                {
                    MessageBox.Show("此项不能预订");
                }
            }
        }

        private void 取消预订ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 &&
                MessageBox.Show("是否取消预订？", "询问", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var pi = row.Tag as ProductInventoryItem;
                    if (pi.State == ProductInventoryState.Reserved)
                    {
                        var ret = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).UnReserve(pi);
                        if (ret.Result == ResultCode.Successful) ShowItemInGridViewRow(row, pi);
                    }
                }
            }
        }

        private void mnu_设置入库单价_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            Frm设置单价 frm = new Frm设置单价();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var pi = row.Tag as ProductInventoryItem;
                    var ci = new CostItem() { Name = CostItem.入库单价, Price = frm.结算单价, WithTax = frm.WithTax, SupllierID = string.IsNullOrEmpty(frm.SupplierID) ? pi.Supplier : frm.SupplierID };
                    var ret = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).设置成本(pi, ci, Operator.Current.Name, Operator.Current.ID, frm.Memo);
                    if (ret.Result == ResultCode.Successful)
                    {
                        ShowItemInGridViewRow(row, pi);
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }

        private void mnu_设置其它成本_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            FrmChangeCosts frm = new FrmChangeCosts();
            frm.chk总金额.Enabled = dataGridView1.SelectedRows.Count == 1;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ci = frm.Cost;
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    decimal? 总额 = null;
                    var pi = row.Tag as ProductInventoryItem;
                    if (frm.chk总金额.Checked && pi.CostID.HasValue)
                    {
                        总额 = ci.Price;
                        var f = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).GetByID(pi.CostID.Value).QueryObject;
                        if (pi.OriginalWeight > 0) ci.Price = Math.Round(ci.Price / pi.OriginalWeight.Value, 2); //如果是总额，则换算成吨价
                    }
                    var ret = new SteelRollBLL(AppSettings.Current.ConnStr).设置成本(pi, ci, Operator.Current.Name, Operator.Current.ID, frm.Memo, 总额, frm.CarPlate);
                    if (ret.Result == ResultCode.Successful)
                    {
                        ShowItemInGridViewRow(row, pi);
                    }
                    else
                    {
                        MessageBox.Show(ret.Message);
                    }
                }
            }
        }

        private void mnu_查看成本明细_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                var frm = new Frm成本明细();
                frm.ProductInventoryItem = sr;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void 查看价格改动记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                if (sr.CostID.HasValue)
                {
                    DocumentSearchCondition con = new DocumentSearchCondition() { DocumentID = sr.CostID.Value.ToString() };
                    Frm修改记录日志明细 frm = new Frm修改记录日志明细();
                    frm.SearchCondition = con;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            }
        }

        private void mnu_原材料拆条_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                if (sr.State == ProductInventoryState.Inventory && (sr.Status == "整卷" || sr.Status == "余卷"))
                {
                    Frm原材料分条 frm = new Frm原材料分条();
                    frm.SlicingItem = sr;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ShowItemInGridViewRow(dataGridView1.SelectedRows[0], sr);
                        var newR = frm.NewRolls;
                        _SteelRolls.AddRange(newR);
                        var row = dataGridView1.SelectedRows[0].Index;
                        foreach (var item in newR)
                        {
                            dataGridView1.Rows.Insert(row, 1);
                            ShowItemInGridViewRow(dataGridView1.Rows[row], item);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("原材料处于 \"{0}\" 状态,不能进行加工", ProductInventoryStateDescription.GetDescription(sr.State)));
                }
            }
        }

        private void mnu_撤销分条_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                if (sr.State == ProductInventoryState.Inventory && (sr.Status == "整卷" || sr.Status == "余卷"))
                {
                    Frm原材料分条 frm = new Frm原材料分条();
                    frm.SlicingItem = sr;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        ShowItemInGridViewRow(dataGridView1.SelectedRows[0], sr);
                        var newR = frm.NewRolls;
                        _SteelRolls.AddRange(newR);
                        var row = dataGridView1.SelectedRows[0].Index;
                        foreach (var item in newR)
                        {
                            dataGridView1.Rows.Insert(row, 1);
                            ShowItemInGridViewRow(dataGridView1.Rows[row], item);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(string.Format("原材料处于 \"{0}\" 状态,不能进行加工", ProductInventoryStateDescription.GetDescription(sr.State)));
                }
            }
        }
        #endregion
    }
}