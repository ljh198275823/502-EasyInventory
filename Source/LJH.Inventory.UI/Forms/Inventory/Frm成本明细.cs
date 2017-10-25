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
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class Frm成本明细 : FrmMasterBase
    {
        public Frm成本明细()
        {
            InitializeComponent();
        }

        public ProductInventoryItem ProductInventoryItem { get; set; }

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            var records = ProductInventoryItem.GetAllCosts();
            if (records != null && records.Count > 0)
            {
                return (from item in records
                        where item.Price > 0 where item.Name !="结算成本"
                        orderby item.Price descending 
                        select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            CostItem record = item as CostItem;
            row.Tag = record;
            row.Cells["colName"].Value = record.Name;
            row.Cells["colPrice"].Value = record.Price;
            row.Cells["colWithTax"].Value = record.WithTax;
        }
        #endregion
    }
}
