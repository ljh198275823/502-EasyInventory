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
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory.View
{
    public partial class FrmSteelRollSliceView : FrmMasterBase
    {
        public FrmSteelRollSliceView()
        {
            InitializeComponent();
        }

        public SteelRollSlice SteelRollSlice { get; set; }

        List<Product> _Products = null;

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            _Products = new ProductBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            List<ProductInventoryItem> records = null;
            if (SearchCondition == null)
            {
                records = (new ProductInventoryItemBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                records = (new ProductInventoryItemBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            return (from item in records
                    orderby item.AddDate descending
                    select (object)item).ToList();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            mnu_Check.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Check);
            mnu_CreateInventory.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Edit);
            mnu_UnReserve.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Edit);
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ProductInventoryItem c = item as ProductInventoryItem;
            row.Tag = c;
            if (_Products == null) _Products = new List<Product>();
            Product p = _Products.SingleOrDefault(it => it.ID == c.ProductID);
            if (p == null)
            {
                p = new ProductBLL(AppSettings.Current.ConnStr).GetByID(c.ProductID).QueryObject;
                _Products.Add(p);
            }
            row.Cells["colCategory"].Value = p != null ? p.Category.Name : string.Empty;
            row.Cells["colSpecification"].Value = p != null ? p.Specification : string.Empty;
            row.Cells["colWeight"].Value = c.Weight;
            row.Cells["colLength"].Value = c.Length;
            row.Cells["colRealThick"].Value = c.RealThick;
            row.Cells["colInventoryDate"].Value = c.AddDate.ToString("yyyy-MM-dd");
            row.Cells["colCount"].Value = c.Count.Trim();
            row.Cells["colInventorySheet"].Value = c.InventorySheet;
            row.Cells["colOrderID"].Value = c.OrderID;
            row.Cells["colDeliverySheet"].Value = c.DeliverySheet;
            row.Cells["colCustomer"].Value = c.Customer;
            row.Cells["colMemo"].Value = c.Memo;
        }
        #endregion

        #region 事件处理程序
        private void mnu_CreateInventory_Click(object sender, EventArgs e)
        {
            FrmSteelRollSliceStackIn frm = new FrmSteelRollSliceStackIn();
            if (SteelRollSlice != null)
            {
                frm.Product = SteelRollSlice.Product;
                frm.WareHouse = SteelRollSlice.WareHouse;
            }
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ReFreshData();
            }
        }

        private void mnu_UnReserve_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否取消选中的订单备货项?", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    ProductInventoryItem pii = row.Tag as ProductInventoryItem;
                    CommandResult ret = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).UnReserve(pii);
                    if (ret.Result == ResultCode.Successful)
                    {
                        row.Cells["colOrderID"].Value = string.Empty;
                    }
                }
            }
        }

        private void mnu_Check_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var pi = dataGridView1.SelectedRows[0].Tag as ProductInventoryItem;
                FrmSteelRollSliceCheck frm = new FrmSteelRollSliceCheck();
                frm.ProductInventory = pi;
                DialogResult ret = frm.ShowDialog();
                if (ret == DialogResult.OK) ReFreshData();
            }
        }
        #endregion

        
    }
}
