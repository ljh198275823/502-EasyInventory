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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.Inventory.UI.Forms.Sale;

namespace LJH.Inventory.UI.Forms.General
{
    public partial class FrmProductDetail : FrmSheetDetailBase
    {
        public FrmProductDetail()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Product> _AllProducts = new ProductBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
        #endregion

        #region 私有方法
        private void InitCmbSpecification()
        {
            cmbSpecification.Items.Clear();
            if (_AllProducts != null && _AllProducts.Count > 0)
            {
                var items = (from p in _AllProducts
                             where !string.IsNullOrEmpty(p.Specification)
                             orderby p.Specification ascending
                             select p.Specification).Distinct();
                foreach (var item in items)
                {
                    cmbSpecification.Items.Add(item);
                }
            }
        }

        private void InitCmbBrand()
        {
            cmbBrand.Items.Clear();
            if (_AllProducts != null && _AllProducts.Count > 0)
            {
                var items = (from p in _AllProducts
                             where !string.IsNullOrEmpty(p.Brand)
                             orderby p.Brand ascending
                             select p.Brand).Distinct();
                foreach (var item in items)
                {
                    cmbBrand.Items.Add(item);
                }
            }
        }
        #endregion

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
                MessageBox.Show("编号不能为空");
                txtID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("名称不能为空");
                txtName.Focus();
                return false;
            }
            if (Category == null)
            {
                MessageBox.Show("类别没有指定");
                return false;
            }
            //if (string.IsNullOrEmpty(cmbSpecification.Text))
            //{
            //    MessageBox.Show("规格没有指定");
            //    return false;
            //}
            return true;
        }

        protected override void InitControls()
        {
            if (Category != null) txtCategory.Text = Category.Name;
            InitCmbSpecification();
            InitCmbBrand();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btnOk.Enabled = Operator.Current.Permit(Permission.Product, PermissionActions.Edit);
        }

        protected override void ItemShowing()
        {
            Product p = UpdatingItem as Product;
            txtID.Text = p.ID;
            txtID.Enabled = false;
            txtName.Text = p.Name;
            txtCategory.Text = p.Category.Name;
            Category = p.Category;
            cmbSpecification.Text = p.Specification;
            txtCost.DecimalValue = p.Cost;
            txtPrice.DecimalValue = p.Price;
            cmbBrand.Text = p.Brand;
            txtMemo.Text = p.Memo;
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
            p.CategoryID = Category != null ? Category.ID : null;
            p.Category = Category;
            p.Specification = cmbSpecification.Text;
            p.Model = string.Empty;
            p.Unit = string.Empty;
            p.Price = txtPrice.DecimalValue;
            p.Cost = txtCost.DecimalValue;
            p.Brand = cmbBrand.Text;
            p.IsService = true;
            p.Memo = txtMemo.Text;
            return p;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            Product p = addingItem as Product;
            CommandResult ret = null;
            ret = (new ProductBLL(AppSettings.Current.ConnStr)).Add(p);
            return ret;
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            Product p = updatingItem as Product;
            return (new ProductBLL(AppSettings.Current.ConnStr)).Update(p);
        }
        #endregion

        #region 事件处理程序
        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductCategoryMaster frm = new FrmProductCategoryMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Category = frm.SelectedItem as ProductCategory;
                txtCategory.Text = Category != null ? Category.Name : string.Empty;
            }
        }

        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            Category = null;
            txtCategory.Text = Category != null ? Category.Name : string.Empty;
        }
        #endregion
    }
}
