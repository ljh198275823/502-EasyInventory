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

namespace LJH.Inventory.UI.Forms.Inventory.View
{
    public partial class Frm小件库存管理 : FrmMasterBase
    {
        public Frm小件库存管理()
        {
            InitializeComponent();
        }

        public SteelRollSlice SteelRollSlice { get; set; }

        List<ProductInventoryItem> srs = null;
        List<WareHouse> _AllWarehouse = null;
        private List<CompanyInfo> _AllSuppliers = null;

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            _AllWarehouse = new WareHouseBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            _AllSuppliers = new CompanyBLL(AppSettings.Current.ConnStr).GetAllSuppliers().QueryObjects;
            List<ProductInventoryItem> records = null;
            if (SearchCondition == null)
            {
                records = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                records = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            if (records != null && records.Count > 0)
            {
                var sids = records.Where(it => it.SourceRoll.HasValue).Select(it => it.SourceRoll.Value).Distinct().ToList();
                if (sids != null && sids.Count > 0)
                {
                    var f = new ProductInventoryItemSearchCondition();
                    f.IDS = sids;
                    srs = new SteelRollBLL(AppSettings.Current.ConnStr).GetItems(f).QueryObjects;
                }
            }
            return (from item in records
                    orderby item.AddDate descending
                    select (object)item).ToList();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            mnu_Check.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Check);
            mnu_CreateInventory.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Inventory);
            折包ToolStripMenuItem.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Edit);
            更换仓库ToolStripMenuItem.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Edit);
            mnu_设置结算单价.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.设置结算单价);
            mnu_修改入库单价.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.查看成本);
            mnu_查看价格改动记录.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.查看成本);
            cMnu_Export.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.导出);
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
            row.Cells["colSourceRoll"].Value = sr.SourceRoll.HasValue ? "查看来源卷" : null;
            if (srs != null)
            {
                var source = srs.SingleOrDefault(it => it.ID == sr.SourceRoll);
                row.Cells["colSourceRollWeight"].Value = source != null ? source.OriginalWeight : null;
            }
            if (Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.ShowPrice))
            {
                CostItem ci = sr.GetCost(CostItem.入库单价);
                if (ci != null) row.Cells["colPurchasePrice"].Value = ci.Price;
                if (ci != null) row.Cells["colPurchaseTax"].Value = ci.WithTax;
                ci = sr.GetCost(CostItem.结算单价);
                if (ci != null) row.Cells["col结算单价"].Value = ci.Price;
                ci = sr.GetCost(CostItem.运费);
                if (ci != null) row.Cells["colTransCost"].Value = ci.Price;
                ci = sr.GetCost(CostItem.其它费用);
                if (ci != null) row.Cells["colOtherCost"].Value = ci.Price;
                if (sr.CalUnitCost(true, UserSettings.Current.税点系数) > 0) row.Cells["col含税出单位成本"].Value = sr.CalUnitCost(true, UserSettings.Current.税点系数);
                if (sr.CalUnitCost(false, UserSettings.Current.税点系数) > 0) row.Cells["col不含税出单位成本"].Value = sr.CalUnitCost(false, UserSettings.Current.税点系数);
            }
            row.Cells["colMemo"].Value = sr.Memo;
        }
        #endregion

        #region 事件处理程序
        private void mnu_CreateInventory_Click(object sender, EventArgs e)
        {
            FrmSteelRollSliceStackIn frm = new FrmSteelRollSliceStackIn();
            if (SteelRollSlice != null)
            {
                frm.Product = SteelRollSlice.Product;
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ReFreshData();
            }
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            var pi = dataGridView1.Rows[e.RowIndex].Tag as ProductInventoryItem;
            if (pi.SourceID == null && pi.SourceRoll == null)
            {
                FrmSteelRollSliceStackIn frm = new FrmSteelRollSliceStackIn();
                frm.SteelRollSlice = pi;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
                ShowItemInGridViewRow(dataGridView1.Rows[e.RowIndex], pi);
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

        private void mnu_设置结算单价_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            Frm设置结算单价 frm = new Frm设置结算单价();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var pi = row.Tag as ProductInventoryItem;
                    if (pi.SourceID == null && pi.SourceRoll == null) //只有新建入库的才能改单价，
                    {
                        var ret = new ProductInventoryItemBLL(AppSettings.Current.ConnStr).设置结算单价(pi, frm.结算单价, Operator.Current.Name, Operator.Current.ID);
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
                var costs = frm.Costs;
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var pi = row.Tag as ProductInventoryItem;
                    if (pi.SourceID == null && pi.SourceRoll == null) //只有新建入库的才能改单价，
                    {
                        var ret = new SteelRollBLL(AppSettings.Current.ConnStr).ChangeCost(pi, costs, Operator.Current.Name, Operator.Current.ID);
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

        private void 查看价格改动记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
            {
                ProductInventoryItem sr = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                DocumentSearchCondition con = new DocumentSearchCondition() { DocumentID = sr.ID.ToString() };
                Frm修改记录日志明细 frm = new Frm修改记录日志明细();
                frm.SearchCondition = con;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
        #endregion

        
    }
}
