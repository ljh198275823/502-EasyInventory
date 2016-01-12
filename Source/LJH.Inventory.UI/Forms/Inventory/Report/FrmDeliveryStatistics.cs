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
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.Forms;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Sale;
using LJH.GeneralLibrary;

namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    public partial class FrmDeliveryStatistics : FrmReportBase
    {
        public FrmDeliveryStatistics()
        {
            InitializeComponent();
        }

        #region 私有方法
        private List<StackOutRecord> GetItems()
        {
            StackOutRecordSearchCondition con = new StackOutRecordSearchCondition();
            con.LastActiveDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            con.States = new List<SheetState>();
            con.States.Add(SheetState.Shipped);
            con.SheetTypes = new List<StackOutSheetType>();
            con.SheetTypes.Add(StackOutSheetType.DeliverySheet);
            if (txtCustomer.Tag != null) con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            if (txtProductCategory.Tag != null) con.CategoryID = (txtProductCategory.Tag as ProductCategory).ID;
            List<StackOutRecord> items = (new StackOutSheetBLL(AppSettings.Current.ConnStr)).GetDeliveryRecords(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                decimal length = txtLength.DecimalValue;
                if (length != 0) items = items.Where(it => it.Length.HasValue && it.Length == length).ToList();
                decimal weight = txtWeight.DecimalValue;
                if (weight != 0) items = items.Where(it => it.Weight.HasValue && it.Weight == weight).ToList();
                decimal? width = SpecificationHelper.GetWrittenWidth(cmbSpecification.Specification);
                decimal? thick = SpecificationHelper.GetWrittenThick(cmbSpecification.Specification);
                return (from item in items
                        orderby item.LastActiveDate ascending, item.ProductID ascending
                        where (!width.HasValue || SpecificationHelper.GetWrittenWidth(item.Specification) == width) &&
                              (!thick.HasValue || SpecificationHelper.GetWrittenThick(item.Specification) == thick)
                        select item).ToList();
            }
            return null;
        }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            cmbSpecification.Init();
            base.Init();
        }

        protected override List<object> GetDataSource()
        {
            List<object> items = null;
            List<StackOutRecord> records = GetItems();
            if (records != null && records.Count > 0)
            {
                IEnumerable<IGrouping<string, StackOutRecord>> dtGroup = null;
                if (rdByDay.Checked)
                {
                    dtGroup = records.GroupBy(item => item.LastActiveDate.ToString("yyyy-MM-dd"));
                }
                else if (rdByMonth.Checked)
                {
                    dtGroup = records.GroupBy(item => item.LastActiveDate.ToString("yyyy-MM"));
                }
                else
                {
                    dtGroup = records.GroupBy(item => item.LastActiveDate.ToString("yyyy"));
                }
                foreach (var g in dtGroup)
                {
                    IEnumerable<IGrouping<string, StackOutRecord>> group = null;
                    if (rdByProdcut.Checked)
                    {
                        gridView.Columns["colName"].HeaderText = "卷";
                        group = g.GroupBy(item => item.ProductID);
                    }
                    else if (rdBySheet.Checked)
                    {
                        gridView.Columns["colName"].HeaderText = "送货单";
                        group = g.GroupBy(item => item.SheetNo);
                    }
                    else if (rdByCustomer.Checked)
                    {
                        gridView.Columns["colName"].HeaderText = "客户";
                        group = g.GroupBy(item => item.Customer.Name);
                    }
                    else if (rdByCategory.Checked)
                    {
                        gridView.Columns["colName"].HeaderText = "类别";
                        group = g.GroupBy(item => item.Product.Category.Name);
                    }
                    else if (rdByNone.Checked)
                    {
                        gridView.Columns["colName"].HeaderText = string.Empty;
                        group = g.GroupBy(it => string.Empty);
                    }
                    foreach (var gp in group)
                    {
                        if (items == null) items = new List<object>();
                        GroupData gd = new GroupData() { Key = g.Key, Group = gp };
                        items.Add(gd);
                    }
                }
            }
            return items;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            GroupData gd = item as GroupData;
            IGrouping<string, StackOutRecord> gp = gd.Group;
            row.Cells["colDeliveryDate"].Value = gd.Key;
            row.Cells["colName"].Value = gp.Key;
            decimal count = gp.Sum(it => it.Count).Trim();
            row.Cells["colCount"].Value = count;
            decimal d1 = gp.Sum(it => it.Amount).Trim();
            row.Cells["colAmount"].Value = d1;
            decimal d2 = gp.Sum(it => it.Cost).Trim();
            row.Cells["colCost"].Value = d2;
            if (d2 > 0)
            {
                row.Cells["colProfit"].Value = (d1 - d2).Trim();
                row.Cells["colProfitRate"].Value = ((d1 - d2) / d2).ToString("P3");
            }
            else
            {
                row.Cells["colProfit"].Value = "---";
                row.Cells["colProfitRate"].Value = "---";
            }
        }
        #endregion

        #region 事件处理程序
        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = customer != null ? customer.Name : string.Empty;
                txtCustomer.Tag = customer;
            }
        }

        private void txtCustomer_DoubleClick(object sender, EventArgs e)
        {
            txtCustomer.Text = string.Empty;
            txtCustomer.Tag = null;
        }

        private void lnkProductCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductCategoryMaster frm = new FrmProductCategoryMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ProductCategory pc = frm.SelectedItem as ProductCategory;
                txtProductCategory.Text = pc != null ? pc.Name : string.Empty;
                txtProductCategory.Tag = pc;
            }
        }

        private void txtProductCategory_DoubleClick(object sender, EventArgs e)
        {
            txtProductCategory.Text = string.Empty;
            txtProductCategory.Tag = null;
        }
        #endregion

        private class GroupData
        {
            public string Key { get; set; }
            public IGrouping<string, StackOutRecord> Group { get; set; }
        }
    }
}
