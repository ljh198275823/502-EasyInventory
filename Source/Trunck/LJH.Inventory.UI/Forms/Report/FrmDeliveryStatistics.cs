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

namespace LJH.Inventory.UI.Report
{
    public partial class FrmDeliveryStatistics : FrmReportBase
    {
        public FrmDeliveryStatistics()
        {
            InitializeComponent();
        }

        private void FrmDeliveryStatistics_Load(object sender, EventArgs e)
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            txtCustomer.Init();
            txtProduct.Init();
            txtCategory.Init();
        }

        private void categoryComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtCategory.SelectedCategory == null)
            {
                txtProduct.Init();
            }
            else
            {
                txtProduct.Init(txtCategory.SelectedCategoryID);
            }
        }

        private List<DeliveryRecord> GetItems()
        {
            DeliveryRecordSearchCondition con = new DeliveryRecordSearchCondition();
            con.LastActiveDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            con.States = new List<SheetState>();
            con.States.Add(SheetState.Shipped);
            if (txtCustomer.SelectedCustomer != null)
            {
                con.CustomerID = txtCustomer.SelectedCustomer.ID;
            }
            if (txtProduct.SelectedProduct != null)
            {
                con.ProductID = txtProduct.SelectedProduct.ID;
            }
            if (txtCategory.SelectedCategory != null)
            {
                con.CategoryID = txtCategory.SelectedCategoryID;
            }
            return (new DeliverySheetBLL(AppSettings.Current.ConnStr)).GetDeliveryRecords(con).QueryObjects;
        }

        protected override void OnItemSearching(EventArgs e)
        {
            List<DeliveryRecord> records = GetItems();
            if (records != null && records.Count > 0)
            {
                IEnumerable<IGrouping<string, DeliveryRecord>> dtGroup = null;
                if (rdByDay.Checked)
                {
                    dtGroup = records.GroupBy(item => item.LastActiveDate .ToString("yyyy-MM-dd"));
                }
                else if (rdByMonth.Checked)
                {
                    dtGroup = records.GroupBy(item => item.LastActiveDate .ToString("yyyy-MM"));
                }
                else
                {
                    dtGroup = records.GroupBy(item => item.LastActiveDate .ToString("yyyy"));
                }
                foreach (var g in dtGroup)
                {
                    IEnumerable<IGrouping<string, DeliveryRecord>> group = null;
                    if (rdByProdcut.Checked)
                    {
                        group = g.GroupBy(item => (item.ProductID + " " + item.Product.Name));
                    }
                    else if (rdByCustomer.Checked)
                    {
                        group = g.GroupBy(item => item.CustomerID + " " + item.Customer.Name);
                    }
                    //else if (rdBySalesPerson.Checked)
                    //{
                    //    group = g.GroupBy(item => item.SalesPerson);
                    //}
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
                            decimal d1;
                            d1 = gp.Sum(item => item.Amount).Trim();
                            //d2 = gp.Sum(item => item.Cost).Trim();
                            gridView.Rows[row].Cells["colAmount"].Value = d1;
                            //gridView.Rows[row].Cells["colCost"].Value = d2;
                            //gridView.Rows[row].Cells["colProfit"].Value = ((d1 - d2) / d1).ToString("F3");
                        }
                    }
                }
            }
        }
    }
}
