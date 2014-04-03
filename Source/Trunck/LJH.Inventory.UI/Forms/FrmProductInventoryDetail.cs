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
using LJH.Inventory.UI.Controls;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmProductInventoryDetail : FrmDetailBase
    {
        public FrmProductInventoryDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置仓库
        /// </summary>
        public WareHouse WareHouse { get; set; }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (IsAdding && txtProductID.Tag == null)
            {
                MessageBox.Show("没有选择库存商品");
                txtProductID.Focus();
                return false;
            }
            if (WareHouse == null)
            {
                MessageBox.Show("没有选择仓库");
                txtWareHouseID.Focus();
                return false;
            }
            if (txtCount.DecimalValue == 0)
            {
                MessageBox.Show("库存数量没有填写");
                txtCount.Focus();
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            base.InitControls();
            this.txtWareHouseID.Text = WareHouse != null ? WareHouse.Name : string.Empty;
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            this.btnOk.Enabled = opt.Permit(Permission.CreateInventory);
        }

        protected override void ItemShowing()
        {
            ProductInventory item = UpdatingItem as ProductInventory;
            txtProductID.Text = item.ProductID + ":" + item.Product.Name;
            txtProductID.Tag = item.Product;
            txtProductID.Enabled = false;
            lnkProduct.Enabled = false;
            WareHouse = item.WareHouse;
            txtWareHouseID.Text = WareHouse != null ? WareHouse.Name : string.Empty;
            txtCount.DecimalValue = item.Count;
            txtAmount.DecimalValue = item.Amount;
            btnOk.Enabled = false;
        }

        protected override object GetItemFromInput()
        {
            ProductInventory item = null;
            if (UpdatingItem == null)
            {
                item = new ProductInventory();
                item.ID = Guid.NewGuid();
            }
            else
            {
                item = UpdatingItem as ProductInventory;
            }
            item.ProductID = (txtProductID.Tag as Product).ID;
            item.Product = txtProductID.Tag as Product;
            item.WareHouseID = WareHouse != null ? WareHouse.ID : null;
            item.WareHouse = WareHouse;
            item.Valid = txtCount.DecimalValue;
            item.Unit = item.Product.Unit;
            item.ValidAmount = txtAmount.DecimalValue;
            return item;
        }

        protected override CommandResult AddItem(object item)
        {
            ProductInventoryBLL bll = new ProductInventoryBLL(AppSettings.CurrentSetting.ConnStr);
            return bll.CreateInventory(item as ProductInventory);
        }

        protected override CommandResult UpdateItem(object item)
        {
            return new CommandResult(ResultCode.Fail, "库存项不能进行更新操作");
        }
        #endregion

        #region 事件处理程序
        private void txtCount_TextChanged(object sender, EventArgs e)
        {
            txtAmount.DecimalValue = txtCost.DecimalValue * txtCount.DecimalValue;
        }

        private void lnkProduct_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductMaster frm = new FrmProductMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Product p = frm.SelectedItem as Product;
                txtProductID.Tag = p;
                txtProductID.Text = p.ID + ":" + p.Name;
            }
            else
            {
                txtProductID.Text = string.Empty;
                txtProductID.Tag = null;
            }
        }
        #endregion

        private void lnkWarehouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmWareHouseMaster frm = new FrmWareHouseMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                WareHouse = frm.SelectedItem as WareHouse;
                txtWareHouseID.Text = WareHouse != null ? WareHouse.Name : string.Empty;
            }
        }
    }
}
