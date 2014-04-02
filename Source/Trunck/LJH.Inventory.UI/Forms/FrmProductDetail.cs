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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmProductDetail : FrmDetailBase
    {
        public FrmProductDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置产品类别
        /// </summary>
        public ProductCategory Category { get; set; }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("商品编号不能为空");
                txtID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("商品名称不能为空");
                txtName.Focus();
                return false;
            }
            if (Category == null)
            {
                MessageBox.Show("商品类别不能为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                MessageBox.Show("商品单位不能为空");
                txtUnit.Focus();
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            if (Category != null)
            {
                txtCategory.Text = Category.Name;
            }
        }

        protected override void ItemShowing()
        {
            Product p = UpdatingItem as Product;
            txtID.Text = p.ID;
            txtName.Text = p.Name;
            txtForeignName.Text = p.ForeignName;
            txtCategory.Text = p.Category.Name;
            Category = p.Category;
            txtBarCode.Text = p.BarCode;
            txtSpecification.Text = p.Specification;
            txtModel.Text = p.Model;
            txtUnit.Text = p.Unit;
            txtCost.DecimalValue = p.Cost;
            txtPrice.DecimalValue = p.Price;
            txtShortName.Text = p.ShortName;
            txtHSCode.Text = p.HSCode;
            txtMemo.Text = p.Memo;
            txtID.Enabled = p == null;
        }

        protected override Object GetItemFromInput()
        {
            Product p = null;
            if (UpdatingItem == null)
            {
                p = new Product();
            }
            else
            {
                p = UpdatingItem as Product;
            }
            p.ID = txtID.Text != "自动创建" ? txtID.Text : string.Empty;
            p.Name = txtName.Text;
            p.ForeignName = txtForeignName.Text;
            p.CategoryID = Category != null ? Category.ID : null;
            p.Category = Category;
            p.BarCode = txtBarCode.Text;
            p.Specification = txtSpecification.Text;
            p.Model = txtModel.Text;
            p.Unit = txtUnit.Text;
            p.Price = txtPrice.DecimalValue;
            p.Cost = txtCost.DecimalValue;
            p.ShortName = txtShortName.Text;
            p.HSCode = txtHSCode.Text;
            p.Memo = txtMemo.Text;
            return p;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            Product p = addingItem as Product;
            CommandResult ret = null;
            if (txtWarehouse.SelectedWareHouse != null && txtCount.DecimalValue > 0)
            {
                ret = (new ProductBLL(AppSettings.CurrentSetting.ConnectString)).AddProduct(p, txtWarehouse.SelectedWareHouse.ID, txtCount.DecimalValue);
            }
            else
            {
                ret = (new ProductBLL(AppSettings.CurrentSetting.ConnectString)).AddProduct(p);
            }
            return ret;
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            Product p = updatingItem as Product;
            CommandResult ret = (new ProductBLL(AppSettings.CurrentSetting.ConnectString)).UpdateProduct(p);
            return ret;
        }
        #endregion

        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductCategoryMaster frm = new FrmProductCategoryMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Category = frm.SelectedItem as ProductCategory;
                txtCategory.Text = Category.Name;
            }
        }

        private void lnkUnit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmUnitMaster frm = new FrmUnitMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtUnit.Text = (frm.SelectedItem as Unit).ID;
            }
        }
    }
}
