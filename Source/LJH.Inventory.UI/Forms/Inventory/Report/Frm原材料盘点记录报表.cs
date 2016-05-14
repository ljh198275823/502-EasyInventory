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
using LJH.Inventory.UI.Forms.Sale;

namespace LJH.Inventory.UI.Forms.Inventory.Report
{
    public partial class Frm原材料盘点记录报表 : FrmReportBase
    {
        public Frm原材料盘点记录报表()
        {
            InitializeComponent();
        }

        private List<WareHouse> _AllWareHuouses = null;

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
            this.ucDateTimeInterval1.Init();
            this.ucDateTimeInterval1.SelectThisMonth();
            this.categoryComboBox1.Init();
            this.comSpecification1.Init();
            this.wareHouseComboBox1.Init();
        }

        protected override List<object> GetDataSource()
        {
            _AllWareHuouses = new WareHouseBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            InventoryCheckRecordSearchCondition con = new InventoryCheckRecordSearchCondition();
            con.CheckDate = new DateTimeRange(this.ucDateTimeInterval1.StartDateTime, this.ucDateTimeInterval1.EndDateTime);
            con.WareHouseID = wareHouseComboBox1.SelectedWareHouseID;
            List<InventoryCheckRecord> records = (new InventoryCheckRecordBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            if (records != null && records.Count > 0)
            {
                return (from it in records
                        where (it.Product.Model == "原材料" &&
                               (string.IsNullOrEmpty(categoryComboBox1.Text) || it.Product.CategoryID == categoryComboBox1.SelectedCategoryID) &&
                               (string.IsNullOrEmpty(comSpecification1.Text) || it.Product.Specification == comSpecification1.Text))
                        orderby it.CheckDateTime descending
                        select (object)it).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            InventoryCheckRecord record = item as InventoryCheckRecord;
            row.Tag = record;
            row.Cells["colCheckDate"].Value = record.CheckDateTime.ToString("yyyy年MM月dd日");
            WareHouse w = _AllWareHuouses.SingleOrDefault(it => it.ID == record.WarehouseID);
            row.Cells["colWareHouse"].Value = w != null ? w.Name : null;
            Product p = record.Product;
            if (p != null)
            {
                row.Cells["colCategoryID"].Value = p.Category.Name;
                row.Cells["colSpecification"].Value = p.Specification;
                row.Cells["colModel"].Value = p.Model;
            }
            row.Cells["colBeforeWeight"].Value = record.BeforeWeight;
            row.Cells["colCheckWeight"].Value = record.Weight;
            row.Cells["colState"].Value = record.CheckCount > record.Inventory ? "盘盈" : "盘亏";
            row.DefaultCellStyle.ForeColor = record.CheckCount > record.Inventory ? Color.Black : Color.Red;
            row.Cells["colChecker"].Value = record.Checker;
            row.Cells["colCustomer"].Value = record.Customer;
            row.Cells["colMemo"].Value = record.Memo;
        }
        #endregion

        #region 事件处理程序
        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
        }
        #endregion
    }
}
