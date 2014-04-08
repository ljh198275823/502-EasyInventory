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
    public partial class FrmProductCategoryDetail : FrmDetailBase
    {
        public FrmProductCategoryDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置父类别
        /// </summary>
        public ProductCategory ParentCategory { get; set; }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            if (ParentCategory != null)
            {
                txtParentCategory.Text = ParentCategory.Name;
            }
            base.InitControls();
            Operator opt = Operator.Current;
        }

        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("类别名称不能为空");
                txtID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("类别名称不能为空");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtPrefix.Text))
            {
                MessageBox.Show("商品编号前缀不能为空,否则不能自动生成此类型的商品编号");
                txtPrefix.Focus();
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            if (UpdatingItem != null)
            {
                ProductCategory p = UpdatingItem as ProductCategory;
                txtID.Text = p.ID;
                txtName.Text = p.Name;
                txtPrefix.Text = p.Prefix;
                if (!string.IsNullOrEmpty(p.Parent))
                {
                    ParentCategory = (new ProductCategoryBLL(AppSettings.Current.ConnStr)).GetByID(p.Parent).QueryObject;
                }
                txtMemo.Text = p.Memo;
            }
            if (ParentCategory != null)
            {
                txtParentCategory.Text = ParentCategory.Name;
            }
            txtID.Enabled = (UpdatingItem == null);
        }

        protected override Object GetItemFromInput()
        {
            ProductCategory p;
            if (UpdatingItem == null)
            {
                p = new ProductCategory();
            }
            else
            {
                p = UpdatingItem as ProductCategory;
            }
            p.ID = txtID.Text == "自动创建" ? string.Empty : txtID.Text;
            p.Name = txtName.Text;
            p.Prefix = txtPrefix.Text;
            p.Parent = ParentCategory != null ? ParentCategory.ID : null;
            p.Memo = txtMemo.Text;
            return p;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            ProductCategoryBLL bll = new ProductCategoryBLL(AppSettings.Current.ConnStr);
            return bll.Insert(addingItem as ProductCategory);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            ProductCategoryBLL bll = new ProductCategoryBLL(AppSettings.Current.ConnStr);
            return bll.Update(updatingItem as ProductCategory);
        }
        #endregion

        private void lnkParentCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductCategoryMaster frm = new FrmProductCategoryMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ParentCategory = frm.SelectedItem as ProductCategory;
                this.txtParentCategory.Text = ParentCategory.Name;
            }
        }
    }
}
