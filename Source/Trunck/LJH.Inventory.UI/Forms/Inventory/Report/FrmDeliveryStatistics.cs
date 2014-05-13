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
            con.SheetTypes = new List<StackOutSheetType>();
            con.SheetTypes.Add(StackOutSheetType.DeliverySheet);
            con.States = new List<SheetState>();
            con.States.Add(SheetState.Shipped);
            if (txtCustomer.Tag != null) con.CustomerID = (txtCustomer.Tag as CompanyInfo).ID;
            if (txtProductCategory.Tag != null) con.CategoryID = (txtProductCategory.Tag as ProductCategory).ID;
            if (txtProduct.Tag != null) con.ProductID = (txtProduct.Tag as Product).ID;
            return (new StackOutSheetBLL(AppSettings.Current.ConnStr)).GetDeliveryRecords(con).QueryObjects;
        }
        #endregion

        #region 重写基类方法
        protected override void OnItemSearching(EventArgs e)
        {
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
                        group = g.GroupBy(item => (item.ProductID + " " + item.Product.Name));
                    }
                    else if (rdByCustomer.Checked)
                    {
                        group = g.GroupBy(item => item.CustomerID + " " + item.Customer.Name);
                    }
                    else if (rdBySalesPerson.Checked)
                    {
                        group = g.GroupBy(item => item.SalesPerson);
                    }
                    else if (rdByCategory.Checked)
                    {
                        group = g.GroupBy(item => item.Product.CategoryID + " " + item.Product.Category.Name);
                    }
                    foreach (var gp in group)
                    {
                        if (!string.IsNullOrEmpty(gp.Key))
                        {
                            int row = gridView.Rows.Add();
                            gridView.Rows[row].Cells["colDeliveryDate"].Value = g.Key;
                            gridView.Rows[row].Cells["colName"].Value = gp.Key;
                            decimal count = gp.Sum(item => item.Count).Trim();
                            gridView.Rows[row].Cells["colCount"].Value = count;
                            decimal d1 = gp.Sum(item => item.Amount).Trim();
                            gridView.Rows[row].Cells["colAmount"].Value = d1;
                            decimal d2 = gp.Sum(item => item.Product.Cost * item.Count).Trim();
                            gridView.Rows[row].Cells["colCost"].Value = d2;
                            if (d2 > 0)
                            {
                                gridView.Rows[row].Cells["colProfit"].Value = (d1 - d2).Trim();
                                gridView.Rows[row].Cells["colProfitRate"].Value = ((d1 - d2) / d2).ToString("P3");
                            }
                            else
                            {
                                gridView.Rows[row].Cells["colProfit"].Value = "---";
                                gridView.Rows[row].Cells["colProfitRate"].Value = "---";
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 事件处理程序
        private void FrmDeliveryStatistics_Load(object sender, EventArgs e)
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
        }

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

        private void lnkProduct_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductMaster frm = new FrmProductMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Product p = frm.SelectedItem as Product;
                txtProduct.Text = p != null ? p.Name : string.Empty;
                txtProduct.Tag = p;
            }
        }

        private void txtProduct_DoubleClick(object sender, EventArgs e)
        {
            txtProduct.Text = string.Empty;
            txtProduct.Tag = null;
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
    }
}
