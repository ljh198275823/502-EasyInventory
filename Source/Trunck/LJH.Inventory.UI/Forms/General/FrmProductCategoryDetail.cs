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
            base.InitControls();
            txtParentCategory.Text = ParentCategory != null ? ParentCategory.Name : string.Empty;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btnOk.Enabled = Operator.Current.Permit(Permission.ProductCategory, PermissionActions.Edit);
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
            if (ParentCategory != null && UpdatingItem != null && (UpdatingItem as ProductCategory).ID == ParentCategory.ID)
            {
                MessageBox.Show("产品类别的父类别不能是本身");
                return false;
            }
            if (ParentCategory != null && UpdatingItem != null && (UpdatingItem as ExpenditureType).ID == ParentCategory.ID)
            {
                MessageBox.Show("费用类别的父类别不能是本身");
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
            return bll.Add(addingItem as ProductCategory);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            ProductCategoryBLL bll = new ProductCategoryBLL(AppSettings.Current.ConnStr);
            return bll.Update(updatingItem as ProductCategory);
        }
        #endregion

        #region 事件处理程序
        private void lnkParentCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductCategoryMaster frm = new FrmProductCategoryMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ParentCategory = frm.SelectedItem as ProductCategory;
                this.txtParentCategory.Text = ParentCategory != null ? ParentCategory.Name : string.Empty;
            }
        }

        private void txtParentCategory_DoubleClick(object sender, EventArgs e)
        {
            ParentCategory = null;
            this.txtParentCategory.Text = ParentCategory != null ? ParentCategory.Name : string.Empty;
        }
        #endregion
    }
}
