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
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class Frm小件库存管理 : FrmMasterBase
    {
        public Frm小件库存管理()
        {
            InitializeComponent();
        }

        #region  私有变量
        private bool _DataLoaded = false;
        List<WareHouse> _AllWarehouse = null;
        private List<CompanyInfo> _AllSuppliers = null;
        private List<ProductInventoryItem> _SteelRolls = null;
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
                if (txtWeight.DecimalValue > 0) items = items.Where(it => it.SourceRollWeight == txtWeight.DecimalValue).ToList();
                if (txtLength.DecimalValue > 0) items = items.Where(it => it.Product.Length == txtLength.DecimalValue).ToList();
                items = items.Where(it => (chk开平.Checked && it.Product.Model == chk开平.Text) ||
                                          (chk开卷.Checked && it.Product.Model == chk开卷.Text) ||
                                          (chk开条.Checked && it.Product.Model == chk开条.Text) ||
                                          (chk开吨.Checked && it.Product.Model == chk开吨.Text)).ToList();
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
                                SpecificationHelper.GetWrittenWidth(p.Product.Specification) ascending,
                                SpecificationHelper.GetWrittenThick(p.Product.Specification) ascending,
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

        protected override List<object> GetDataSource()
        {
            _AllWarehouse = new WareHouseBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            _AllSuppliers = new CompanyBLL(AppSettings.Current.ConnStr).GetAllSuppliers().QueryObjects;
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
                _SteelRolls = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            }
            else
            {
                _SteelRolls = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = FilterData();
            _DataLoaded = true;
            return records;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            mnu_Check.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Check);
            mnu_CreateInventory.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Inventory);
            折包ToolStripMenuItem.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Edit);
            mnu_更换仓库.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Edit);
            mnu_Nullify.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Nullify);
            mnu_设置入库单价.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.设置成本);
            mnu_设置其它成本.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.设置成本);
            mnu_查看价格改动记录.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.显示成本) | Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.设置成本);
            mnu_查看成本明细.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.显示成本) | Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.设置成本);
            cMnu_Export.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.导出);
            mnu_Import.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Inventory);
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            if (items != null)
            {
                decimal total = 0;
                decimal weight = 0;
                foreach (var item in items)
                {
                    var pi = item as ProductInventoryItem;
                    if (pi.State != ProductInventoryState.Nullified)
                    {
                        total += pi.Count;
                        if (pi.UnitWeight.HasValue) weight += pi.UnitWeight.Value * pi.Count;
                    }
                }
                lblTotalWeight.Text = string.Format("数量{0:F0}", total);
                lblOriginalTotal.Text = string.Format("重量{0:F3}", weight);
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
            Product p = sr.Product;
            row.Cells["colCategory"].Value = p != null ? p.Category.Name : string.Empty;
            if (_AllWarehouse != null)
            {
                var ws = _AllWarehouse.SingleOrDefault(it => it.ID == sr.WareHouseID);
                row.Cells["colWareHouse"].Value = ws != null ? ws.Name : null;
            }
            row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
            row.Cells["colModel"].Value = p.Model;
            row.Cells["colWeight"].Value = sr.Weight;
            row.Cells["colLength"].Value = sr.Product.Length;
            row.Cells["colOriginalThick"].Value = sr.OriginalThick;
            row.Cells["colRealThick"].Value = sr.RealThick;
            row.Cells["colInventoryDate"].Value = sr.AddDate.ToString("yyyy-MM-dd");
            row.Cells["colCount"].Value = sr.Count;
            row.Cells["colDeliverySheet"].Value = sr.DeliverySheet;
            row.Cells["colCustomer"].Value = sr.Customer;
            if (_AllSuppliers != null)
            {
                var s = _AllSuppliers.SingleOrDefault(it => it.ID == sr.Supplier);
                row.Cells["colSupplier"].Value = s != null ? s.Name : null;
            }
            row.Cells["colManufacture"].Value = sr.Manufacture;
            row.Cells["colSourceRoll"].Value = sr.SourceRollWeight;
            if (Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.设置成本) || Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.显示成本))
            {
                CostItem ci = sr.GetCost(CostItem.入库单价);
                if (ci != null) row.Cells["colPurchasePrice"].Value = ci.Price;
                if (ci != null) row.Cells["colPurchaseTax"].Value = ci.WithTax;
                ci = sr.GetCost(CostItem.运费);
                if (ci != null && ci.Price > 0) row.Cells["col运费"].Value = ci.Price;
                ci = sr.GetCost(CostItem.加工费);
                if (ci != null && ci.Price > 0)
                {
                    row.Cells["col加工费"].Value = ci.Price;
                }
                else
                {
                    ci = sr.GetCost("开平费");
                    if (ci != null && ci.Price > 0) row.Cells["col加工费"].Value = ci.Price;
                }
                ci = sr.GetCost(CostItem.吊装费);
                if (ci != null && ci.Price > 0) row.Cells["col吊装费"].Value = ci.Price;
                ci = sr.GetCost(CostItem.其它费用);
                if (ci != null && ci.Price > 0) row.Cells["col其它费用"].Value = ci.Price;
                if (sr.CalUnitCost(true, UserSettings.Current.税点系数) > 0) row.Cells["col含税出单位成本"].Value = sr.CalUnitCost(true, UserSettings.Current.税点系数);
                if (sr.CalUnitCost(false, UserSettings.Current.税点系数) > 0) row.Cells["col不含税出单位成本"].Value = sr.CalUnitCost(false, UserSettings.Current.税点系数);
            }
            row.Cells["colMaterial"].Value = sr.Material;
            row.Cells["colCarplate"].Value = sr.Carplate;
            row.Cells["colPurchaseID"].Value = sr.PurchaseID;
            row.Cells["colPosition"].Value = sr.Position;
            row.Cells["colMemo"].Value = sr.Memo;
            if (sr.State == ProductInventoryState.Nullified)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
            if (!_SteelRolls.Exists(it => it.ID == sr.ID))
            {
                _SteelRolls.Add(sr);
            }
            ShowRowColor(row);
        }
        #endregion

        #region 事件处理程序
        private void FreshData_Clicked(object sender, EventArgs e)
        {
            if (_DataLoaded) FreshData();
        }

        private void ucDateTimeInterval1_ValueChanged(object sender, EventArgs e)
        {
            if (chkStackIn.Checked) FreshData_Clicked(sender, e);
        }

        private void chk发货_CheckedChanged(object sender, EventArgs e)
        {
            if (_DataLoaded) cMnu_Fresh.PerformClick();
        }

        private void mnu_CreateInventory_Click(object sender, EventArgs e)
        {
            FrmSteelRollSliceStackIn frm = new FrmSteelRollSliceStackIn();
            frm.ItemAdded += delegate(object o, ItemAddedEventArgs args)
            {
                ReFreshData();
            };
            frm.ShowDialog();
        }

        private void mnu_Check_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var pi = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                FrmSteelRollSliceCheck frm = new FrmSteelRollSliceCheck();
                frm.ProductInventory = pi;
                DialogResult ret = frm.ShowDialog();
                if (ret == DialogResult.OK) ReFreshData();
            }
        }

        private void 折包ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var pi = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                FrmSteelRollSliceDepart frm = new FrmSteelRollSliceDepart();
                frm.ProductInventory = pi;
                DialogResult ret = frm.ShowDialog();
                if (ret == DialogResult.OK) ReFreshData();
            }
        }

        private void 更换仓库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var pi = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                FrmChangeWareHouse frm = new FrmChangeWareHouse();
                frm.ProductInventory = pi;
                DialogResult ret = frm.ShowDialog();
                if (ret == DialogResult.OK) ReFreshData();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            var pi = dataGridView1.Rows[e.RowIndex].Tag as ProductInventoryItem;
            if (dataGridView1.Columns[e.ColumnIndex].Name == "colSourceRoll")
            {
                if (pi != null && pi.SourceRoll != null)
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
            else if (GridView.Columns[e.ColumnIndex].Name == "colDeliverySheet" && !string.IsNullOrEmpty(pi.DeliverySheet))
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
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ForSelect) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var pi = dataGridView1.Rows[e.RowIndex].Tag as ProductInventoryItem;
            if (pi.SourceRoll == null && pi.CostID.HasValue)
            {
                var item = new SteelRollSliceBLL(AppSettings.Current.ConnStr).GetByID(pi.CostID.Value).QueryObject;
                FrmSteelRollSliceStackIn frm = new FrmSteelRollSliceStackIn();
                frm.SteelRollSlice = item;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                if (item.ID == pi.ID)
                {
                    _SteelRolls.Remove(pi);
                    _SteelRolls.Add(item);
                    ShowItemInGridViewRow(dataGridView1.Rows[e.RowIndex], item);
                }
            }
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

        private void mnu_设置入库单价_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            Frm设置单价 frm = new Frm设置单价();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var pi = row.Tag as ProductInventoryItem;
                    if (pi.SourceRoll == null) //只有新建入库的才能改单价，
                    {
                        var ci = new CostItem() { Name = CostItem.入库单价, Price = frm.结算单价, WithTax = frm.WithTax, SupllierID = pi.Supplier };
                        var ret = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).设置成本(pi, ci, Operator.Current.Name, Operator.Current.ID);
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
        }

        private void mnu_修改入库单价_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            FrmChangeCosts frm = new FrmChangeCosts();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var ci = frm.Cost;
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var pi = row.Tag as ProductInventoryItem;
                    if (pi.SourceRoll == null) //只有新建入库的才能改单价，
                    {
                        var ret = new SteelRollBLL(AppSettings.Current.ConnStr).设置成本(pi, ci, Operator.Current.Name, Operator.Current.ID);
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
                DocumentSearchCondition con = new DocumentSearchCondition() { DocumentID = sr.ID.ToString() };
                View.Frm修改记录日志明细 frm = new View.Frm修改记录日志明细();
                frm.SearchCondition = con;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }

        private void mnu_Import_Click(object sender, EventArgs e)
        {
            FrmSteelRollSliceImport frm = new FrmSteelRollSliceImport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            cMnu_Fresh.PerformClick();
        }

        private void mnu_Nullify_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否要作废所选的库存项?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    ProductInventoryItem item = row.Tag as ProductInventoryItem;
                    if (item.State == ProductInventoryState.Inventory && item.SourceRoll == null && item.SourceID == null && item.OriginalCount == item.Count)
                    {
                        CommandResult ret = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).Nullify(item);
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
        #endregion
    }
}
