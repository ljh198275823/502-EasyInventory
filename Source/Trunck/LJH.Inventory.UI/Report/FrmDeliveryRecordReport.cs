using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Forms.Report
{
    public partial class FrmDeliveryRecordReport : FrmReportBase
    {
        public FrmDeliveryRecordReport()
        {
            InitializeComponent();
        }

        private void FrmDeliveryRecordReport_Load(object sender, EventArgs e)
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            customerCombobox1.Init();
            productComboBox1.Init();
            categoryComboBox1.Init();
        }

        protected override void OnItemSearching(EventArgs e)
        {
            DeliveryRecordSearchCondition con = new DeliveryRecordSearchCondition();
            con.DeliveryDateTime = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            if (customerCombobox1.SelectedCustomer != null)
            {
                con.CustomerID = customerCombobox1.SelectedCustomer.ID;
            }
            con.CategoryID = categoryComboBox1.SelectedCategoryID;
            if (productComboBox1.SelectedProduct != null)
            {
                con.ProductID = productComboBox1.SelectedProduct.ID;
            }
            List<DeliveryRecord> items = (new DeliverySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetDeliveryRecords(con).QueryObjects;
            foreach (DeliveryRecord item in items)
            {
                int row = gridView.Rows.Add();
                ShowItemOnRow(gridView.Rows[row], item);
            }
        }

        private void ShowItemOnRow(DataGridViewRow row, DeliveryRecord item)
        {
            row.Cells["colDeliveryDate"].Value = item.DeliveryDate.ToString("yyyy-MM-dd");
            row.Cells["colSheetNo"].Value = item.SheetNo;
            row.Cells["colCustomerName"].Value = item.Customer.Name;
            row.Cells["colOrderID"].Value = item.OrderID;
            row.Cells["colProductID"].Value = item.ProductID;
            row.Cells["colProductName"].Value = item.Product.Name;
            row.Cells["colCategoryID"].Value = item.Product.Category.Name;
            row.Cells["colPrice"].Value = item.Price;
            row.Cells["colCount"].Value = item.Count;
            row.Cells["colAmount"].Value = item.Amount.Trim();
        }

        private void gridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (gridView.Columns[e.ColumnIndex].Name == "colSheetNo")
                {
                    string sheetNo = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    DeliverySheet sheet = (new DeliverySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(sheetNo).QueryObject;
                    if (sheet != null)
                    {
                        FrmDeliverySheetDetail frm = new FrmDeliverySheetDetail();
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.UpdatingItem = sheet;
                        frm.IsForView = true;
                        frm.ShowDialog();
                    }
                }
                else if (gridView.Columns[e.ColumnIndex].Name == "colOrderID")
                {
                    string orderID = gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    Order order = (new OrderBLL(AppSettings.CurrentSetting.ConnectString)).GetByID(orderID ).QueryObject;
                    if (order != null)
                    {
                        FrmOrderDetail frm = new FrmOrderDetail();
                        frm.StartPosition = FormStartPosition.CenterParent;
                        frm.UpdatingItem = order;
                        frm.IsForView = true;
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void categoryComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoryComboBox1.SelectedCategory == null)
            {
                productComboBox1.Init();
            }
            else
            {
                productComboBox1.Init(categoryComboBox1.SelectedCategoryID);
            }
        }
    }
}
