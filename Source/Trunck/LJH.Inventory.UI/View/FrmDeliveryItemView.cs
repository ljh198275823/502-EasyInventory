using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.View
{
    public partial class FrmDeliveryItemView : LJH.Inventory.UI.Forms.FrmMasterBase
    {
        public FrmDeliveryItemView()
        {
            InitializeComponent();
        }

        public string OrderID { get; set; }

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
        }

        protected override LJH.Inventory.UI.Forms.FrmDetailBase GetDetailForm()
        {
            return null;
        }

        protected override List<object> GetDataSource()
        {
            List<DeliveryRecord> records = (new DeliverySheetBLL(AppSettings.CurrentSetting.ConnectString)).GetDeliveryRecords(OrderID).QueryObjects;
            return (from item in records
                    orderby item.ProductID ascending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            DeliveryRecord c = item as DeliveryRecord;
            row.Tag = c;
            row.Cells["colDeliverySheet"].Value = c.OrderID;
            row.Cells["colProductID"].Value = c.ProductID;
            row.Cells["colProductName"].Value = c.Product.Name;
            row.Cells["colSpecification"].Value = c.Product.Specification;
            row.Cells["colCount"].Value = c.Count.Trim();
            row.Cells["colPrice"].Value = c.Price.Trim();
            row.Cells["colAmount"].Value = c.Amount.Trim();
        }
        #endregion
    }
}
