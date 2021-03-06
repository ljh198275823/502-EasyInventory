﻿using System;
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
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory.View
{
    public partial class FrmProductInventoryItemView : FrmMasterBase
    {
        public FrmProductInventoryItemView()
        {
            InitializeComponent();
        }

        List<Product> _Products = null;

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            List<ProductInventoryItem> records = null;
            if (SearchCondition == null)
            {
                _Products = new ProductBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
                records = (new ProductInventoryItemBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                records = (new ProductInventoryItemBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            return (from item in records
                    orderby item.AddDate ascending
                    select (object)item).ToList();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventoryItem c = item as ProductInventoryItem;
            row.Tag = c;
            row.Cells["colInventorySheet"].Value = c.InventorySheet;
            row.Cells["colPurchaseID"].Value = c.PurchaseID;
            row.Cells["colProductID"].Value = c.ProductID;
            if (_Products == null) _Products = new List<Product>();
            Product p = _Products.SingleOrDefault(it => it.ID == c.ProductID);
            if (p == null)
            {
                p = new ProductBLL(AppSettings.Current.ConnStr).GetByID(c.ProductID).QueryObject;
                _Products.Add(p);
            }
            row.Cells["colProductName"].Value = p != null ? p.Name : string.Empty;
            row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
            row.Cells["colInventoryDate"].Value = c.AddDate.ToString("yyyy-MM-dd");
            row.Cells["colCount"].Value = c.Count.Trim();
            row.Cells["colOrderID"].Value = c.OrderID;
            row.Cells["colDeliverySheet"].Value = c.DeliverySheet;
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
        }
        #endregion

        #region 事件处理程序
        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            Filter(txtKeyword.Text.Trim());
        }

        private void mnu_UnReserve_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否取消选中的订单备货项?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    ProductInventoryItem pii = row.Tag as ProductInventoryItem;
                    CommandResult ret = (new ProductInventoryBLL(AppSettings.Current.ConnStr)).UnReserve(pii);
                    if (ret.Result == ResultCode.Successful)
                    {
                        row.Cells["colOrderID"].Value = string.Empty;
                    }
                }
            }
        }
        #endregion
    }
}
