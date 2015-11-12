﻿using System;
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
        private List<SteelRoll> _SteelRolls = null;
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
            List<SteelRoll> items = _SteelRolls;
            if (items != null && items.Count > 0)
            {
                if (chkStorageDT.Checked) items = items.Where(it => it.AddDate.Date == dtStorage.Value.Date).ToList();
                if (!string.IsNullOrEmpty(categoryComboBox1.Text)) items = items.Where(it => it.Product.CategoryID == categoryComboBox1.SelectedCategoryID).ToList();
                if (!string.IsNullOrEmpty(wareHouseComboBox1.Text)) items = items.Where(it => it.WareHouseID == wareHouseComboBox1.SelectedWareHouseID).ToList();
                if (!string.IsNullOrEmpty(cmbSpecification.Text)) items = items.Where(it => it.Product.Specification == cmbSpecification.Text).ToList();
                if (!string.IsNullOrEmpty(cmbSupplier.Text)) items = items.Where(it => it.SupplierID == cmbSupplier.Text).ToList();
                if (!string.IsNullOrEmpty(cmbBrand.Text)) items = items.Where(it => it.Manufacture == cmbBrand.Text).ToList();
                if (txtWeight.DecimalValue > 0) items = items.Where(it => it.Weight == txtWeight.DecimalValue).ToList();
                items = items.Where(it => (chkIntact.Checked && it.Status == "整卷") ||
                                       (chkPartial.Checked && it.Status == "余卷") ||
                                       (chkOnlyTail.Checked && it.Status == "尾卷") ||
                                       (chkRemainless.Checked && it.Status == "余料") ).ToList ();
                items.RemoveAll(it => (!chkNullified.Checked && it.State == ProductInventoryState.Nullified) ||
                                     (!chkShipped.Checked && it.State == ProductInventoryState.Shipped)
                                );
            }
            if (items != null && items.Count > 0)
            {
                return (from p in items
                        orderby p.AddDate descending, p.Product.CategoryID ascending, p.Product.Specification ascending
                        select (object)p).ToList();
            }
            return null;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            this.wareHouseComboBox1.Init();
            this.cmbSpecification.Init();
            this.categoryComboBox1.Init();
            InitSupplier(cmbBrand);
            InitSupplier(cmbSupplier);
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.ProductInventory, PermissionActions.Edit);
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
            var bll = new SteelRollBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition();
                con.Model = "原材料";
                _SteelRolls = bll.GetItems(con).QueryObjects;
            }
            else
            {
                _SteelRolls = bll.GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            SteelRoll sr = item as SteelRoll;
            row.Tag = sr;
            row.Cells["colAddDate"].Value = sr.AddDate.ToString("yyyy年MM月dd日");
            row.Cells["colCategory"].Value = sr.Product.Category == null ? sr.Product.CategoryID : sr.Product.Category.Name;
            row.Cells["colSpecification"].Value = sr.Product.Specification;
            row.Cells["colWareHouse"].Value = sr.WareHouse.Name;
            row.Cells["colOriginalWeight"].Value = sr.OriginalWeight.ToString("F3");
            row.Cells["colOriginalLength"].Value = sr.OriginalLength.ToString("F2");
            row.Cells["colWeight"].Value = sr.Weight.Value.ToString("F3");
            row.Cells["colLength"].Value = sr.Length.Value.ToString("F2");
            row.Cells["colSupplier"].Value = sr.SupplierID;
            row.Cells["colManufacture"].Value = sr.Manufacture;
            row.Cells["colState"].Value = ProductInventoryStateDescription.GetDescription(sr.State);
            row.Cells["colStatus"].Value =sr.Status;
            row.Cells["colSerialNumber"].Value = sr.SerialNumber;
            row.Cells["colDeliverySheet"].Value = sr.DeliverySheet;
            row.Cells["colMemo"].Value = sr.Memo;
            row.DefaultCellStyle.ForeColor = sr.State == ProductInventoryState.Nullified ? Color.Red : Color.Black;
        }
        #endregion

        #region 事件处理函数
        private void FreshData_Clicked(object sender, EventArgs e)
        {
            FreshData();
        }

        private void mnu_Slice_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
            {
                SteelRoll sr = dataGridView1.SelectedRows[0].Tag as SteelRoll;
                FrmSlice frm = new FrmSlice();
                frm.SlicingItem = sr;
                frm.SliceTo = "开平";
                frm.ShowDialog();
                ShowItemInGridViewRow(dataGridView1.SelectedRows[0], sr);
            }
        }

        private void mnu_SliceView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null && dataGridView1.SelectedRows.Count == 1)
            {
                SteelRoll sr = dataGridView1.SelectedRows[0].Tag as SteelRoll;
                SliceRecordSearchCondition con = new SliceRecordSearchCondition();
                con.SourceRoll = sr.ID;
                FrmSlicedRecordView frm = new FrmSlicedRecordView();
                frm.SearchCondition = con;
                frm.ShowDialog();
            }
        }

        private void mnu_Check_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                SteelRoll sr = dataGridView1.SelectedRows[0].Tag as SteelRoll;
                FrmSteelRollCheck frm = new FrmSteelRollCheck();
                frm.SteelRoll = sr;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ShowItemInGridViewRow(dataGridView1.SelectedRows[0], sr);
                }
            }
        }

        private void mnu_CheckView_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                SteelRoll sr = dataGridView1.SelectedRows[0].Tag as SteelRoll;
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
                    SteelRoll item = row.Tag as SteelRoll;
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
        #endregion
    }
}