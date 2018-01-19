using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Inventory.View
{
    public partial class FrmSteelRollSliceCheckRecordView : FrmMasterBase
    {
        public FrmSteelRollSliceCheckRecordView()
        {
            InitializeComponent();
        }

        private List<Product> _AllProducts = null;
        private List<WareHouse> _AllWareHuouses = null;

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            _AllProducts = new ProductBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            _AllWareHuouses = new WareHouseBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            List<InventoryCheckRecord> records = null;
            if (SearchCondition == null)
            {
                records = (new InventoryCheckRecordBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                records = (new InventoryCheckRecordBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            return (from item in records
                    orderby item.CheckDateTime descending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            InventoryCheckRecord record = item as InventoryCheckRecord;
            row.Tag = record;
            row.Cells["colCheckDate"].Value = record.CheckDateTime.ToString("yyyy年MM月dd日");
            WareHouse w = _AllWareHuouses.SingleOrDefault(it => it.ID == record.WarehouseID);
            row.Cells["colWareHouse"].Value = w != null ? w.Name : null;
            Product p = _AllProducts.SingleOrDefault(it => it.ID == record.ProductID);
            if (p != null)
            {
                row.Cells["colName"].Value = p.Name;
                row.Cells["colWidth"].Value = SpecificationHelper.GetWrittenWidth(p.Specification);
                row.Cells["col克重"].Value = SpecificationHelper.GetWritten克重(p.Specification);
                row.Cells["colModel"].Value = p.Model;
                if (p.Length.HasValue) row.Cells["colLength"].Value = (int)p.Length;
                row.Cells["colWeight"].Value = p.Weight;
            }
            row.Cells["colInventory"].Value = record.Inventory;
            row.Cells["colCheckCount"].Value = record.CheckCount;
            row.Cells["colState"].Value = record.CheckCount > record.Inventory ? "盘盈" : "盘亏";
            row.DefaultCellStyle.ForeColor = record.CheckCount > record.Inventory ? Color.Black : Color.Red;
            row.Cells["colChecker"].Value = record.Checker;
            row.Cells["colCustomer"].Value = record.Customer;
            row.Cells["colMemo"].Value = record.Memo;
        }
        #endregion
    }
}
