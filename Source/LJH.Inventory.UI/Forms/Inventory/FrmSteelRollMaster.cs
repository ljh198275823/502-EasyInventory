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
using LJH.Inventory.UI.Report;
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
        private List<ProductInventoryItem> _SteelRolls = null;
        private List<CompanyInfo> _AllSuppliers = null;
        #endregion

        #region 私有方法
        private void InitSupplier(ComboBox cmb)
        {
            cmb.Items.Clear();
            List<CompanyInfo> cs = new CompanyBLL(AppSettings.Current.ConnStr).GetAllSuppliers().QueryObjects;
            if (cs != null && cs.Count > 0)
            {
                cmb.Items.Add(string.Empty);
                var items = (from p in cs
                             orderby p.Name ascending
                             select p.Name);
                foreach (var item in items)
                {
                    cmb.Items.Add(item);
                }
            }
        }

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
                if (!string.IsNullOrEmpty(cmbSupplier.Text)) items = items.Where(it => it.Supplier == cmbSupplier.Text).ToList();
                if (!string.IsNullOrEmpty(cmbBrand.Text)) items = items.Where(it => it.Manufacture == cmbBrand.Text).ToList();
                if (!string.IsNullOrEmpty(customerCombobox1.Text)) items = items.Where(it => it.Customer == customerCombobox1.Text).ToList();
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
            else if (sr.State == ProductInventoryState.Shipped)
            {
                row.DefaultCellStyle.ForeColor = Color.Brown;
            }
            else if (sr.State == ProductInventoryState.Reserved)
            {
                row.DefaultCellStyle.ForeColor = Color.Cyan;
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
            this.cmbSpecification.Init();
            this.categoryComboBox1.Init();
            this.customerCombobox1.Init();
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectToday();
            InitSupplier(cmbBrand);
            InitSupplier(cmbSupplier);
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Edit);
            mnu_开平.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Slice);
            mnu_开条.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Slice);
            mnu_开吨.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Slice);
            mnu_Check.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Check);
            mnu_Nullify.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Nullify);
            更换仓库ToolStripMenuItem.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Edit);
            this.取消预订ToolStripMenuItem.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Edit);
            this.预订ToolStripMenuItem.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmSteelRollDetail frm = new FrmSteelRollDetail();
            return frm;
        }

        protected override bool DeletingItem(object item)
        {
            return false;
        }

        protected override List<object> GetDataSource()
        {
            _AllSuppliers = new CompanyBLL(AppSettings.Current.ConnStr).GetAllSuppliers().QueryObjects;
            var bll = new SteelRollBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                _SteelRolls = bll.GetItems(null).QueryObjects;
            }
            else
            {
                _SteelRolls = bll.GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = FilterData();
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
                lblTotalWeight.Text = string.Format("总剩余 {0:F3}吨", total);
                lblOriginalTotal.Text = string.Format("总入库 {0:F3}吨", original);
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
            row.Cells["colCategory"].Value = sr.Product.Category == null ? sr.Product.CategoryID : sr.Product.Category.Name;
            row.Cells["colSpecification"].Value = sr.Product.Specification;
            row.Cells["colWareHouse"].Value = sr.WareHouse.Name;
            row.Cells["colOriginalWeight"].Value = sr.OriginalWeight;
            row.Cells["colOriginalLength"].Value = sr.OriginalLength;
            row.Cells["colWeight"].Value = sr.Weight;
            row.Cells["colLength"].Value = sr.Length;
            row.Cells["colOriginalThick"].Value = sr.OriginalThick;
            row.Cells["colRealThick"].Value = sr.RealThick;
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
            row.Cells["colPurchasePrice"].Value = sr.PurchasePrice;
            row.Cells["colPurchaseTax"].Value = sr.WithTax;
            row.Cells["colTransCost"].Value = sr.TransCost;
            row.Cells["colOtherCost"].Value = sr.OtherCost;
            row.Cells["colDeliverySheet"].Value = sr.DeliverySheet;
            row.Cells["colMemo"].Value = sr.Memo;
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
            FreshData();
        }

        private void ucDateTimeInterval1_ValueChanged(object sender, EventArgs e)
        {
            if (chkStackIn.Checked) FreshData_Clicked(sender, e);
        }

        private void mnu_Slice_Click(object sender, EventArgs e)
        {
            string sliceTo = null;
            if (object.ReferenceEquals(sender, mnu_开平)) sliceTo = "开平";
            if (object.ReferenceEquals(sender, mnu_开卷)) sliceTo = "开卷";
            if (object.ReferenceEquals(sender, mnu_开条)) sliceTo = "开条";
            if (object.ReferenceEquals(sender, mnu_开吨)) sliceTo = "开吨";

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
        #endregion

        private void mnu_Import_Click(object sender, EventArgs e)
        {
            FrmSteelRollImport frm = new FrmSteelRollImport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
            cMnu_Fresh.PerformClick();
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
                if (ret == DialogResult.OK) ShowItemInGridViewRow(dataGridView1.SelectedRows[0], pi);
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
    }
}