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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.Inventory.UI.Forms.General;

namespace LJH.Inventory.UI.Forms.Inventory
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
        /// <summary>
        /// 获取或设置产品
        /// </summary>
        public Product Product { get; set; }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (Product == null)
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
            txtProductID.Text = Product != null ? Product.Name : string.Empty;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btnOk.Enabled = Operator.Current.Permit(Permission.ProductInventory, PermissionActions.Edit);
        }

        protected override void ItemShowing()
        {
            SteelRollSlice item = UpdatingItem as SteelRollSlice;
            Product = item.Product;
            txtProductID.Text = Product != null ? Product.Name : string.Empty;
            txtProductID.Enabled = false;
            lnkProduct.Enabled = false;
            WareHouse = item.WareHouse;
            txtWareHouseID.Text = WareHouse != null ? WareHouse.Name : string.Empty;
            txtWareHouseID.Enabled = false;
            lnkWarehouse.Enabled = false;
            txtCount.DecimalValue = item.Count;
            txtAmount.DecimalValue = item.Amount;
            btnOk.Enabled = false;
        }

        protected override object GetItemFromInput()
        {
            SteelRollSlice item = null;
            if (UpdatingItem == null)
            {
                item = new SteelRollSlice();
                item.ID = Guid.NewGuid();
            }
            else
            {
                item = UpdatingItem as SteelRollSlice;
            }
            item.ProductID = Product.ID;
            item.Product = Product;
            item.WareHouseID = WareHouse != null ? WareHouse.ID : null;
            item.WareHouse = WareHouse;
            item.ProductID = Product != null ? Product.ID : null;
            item.Product = Product;
            item.Valid = txtCount.DecimalValue;
            item.Unit = item.Product.Unit;
            item.ValidAmount = txtAmount.DecimalValue;
            return item;
        }

        protected override CommandResult AddItem(object item)
        {
            SteelRollSliceBLL bll = new SteelRollSliceBLL(AppSettings.Current.ConnStr);
            return bll.CreateInventory(item as SteelRollSlice);
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
                Product = frm.SelectedItem as Product;
                txtProductID.Text = Product != null ? Product.Name : string.Empty;
            }
        }

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

        private void txtWareHouseID_DoubleClick(object sender, EventArgs e)
        {
            WareHouse = null;
            txtWareHouseID.Text = WareHouse != null ? WareHouse.Name : string.Empty;
        }

        private void txtProductID_DoubleClick(object sender, EventArgs e)
        {
            Product = null;
            txtProductID.Text = Product != null ? Product.Name : string.Empty;
        }
        #endregion
    }
}
