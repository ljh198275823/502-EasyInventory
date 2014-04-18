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
using LJH.GeneralLibrary.DAL;
using LJH.GeneralLibrary.UI;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmProductDetail : FrmSheetDetailBase 
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
            txtID.Enabled = false;
            txtName.Text = p.Name;
            txtCategory.Text = p.Category.Name;
            Category = p.Category;
            txtBarCode.Text = p.BarCode;
            txtSpecification.Text = p.Specification;
            txtModel.Text = p.Model;
            txtUnit.Text = p.Unit;
            txtCost.DecimalValue = p.Cost;
            txtPrice.DecimalValue = p.Price;
            txtShortName.Text = p.ShortName;
            if (!string.IsNullOrEmpty(p.Company))
            {
                CompanyInfo c = (new CompanyBLL(AppSettings.Current.ConnStr)).GetByID(p.Company).QueryObject;
                txtCompany.Tag = c;
                txtCompany.Text = c != null ? c.ID : string.Empty;
            }
            if (!string.IsNullOrEmpty(p.InternalID))
            {
                Product pi = (new ProductBLL(AppSettings.Current.ConnStr)).GetByID(p.InternalID).QueryObject;
                txtInternalID.Tag = pi;
                txtInternalID.Text = pi != null ? pi.ID : string.Empty;
            }
            txtInternalID.Text = p.InternalID;
            txtMemo.Text = p.Memo;
            List<AttachmentHeader> headers = (new AttachmentBLL(AppSettings.Current.ConnStr)).GetHeaders(p.ID, p.DocumentType).QueryObjects;
            ShowAttachmentHeaders(headers, this.gridAttachment);
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
            p.BarCode = txtBarCode.Text;
            p.Specification = txtSpecification.Text;
            p.Model = txtModel.Text;
            p.Unit = txtUnit.Text;
            p.Price = txtPrice.DecimalValue;
            p.Cost = txtCost.DecimalValue;
            p.ShortName = txtShortName.Text;
            if (!string.IsNullOrEmpty(txtCompany.Text))
            {
                CompanyInfo c = txtCompany.Tag as CompanyInfo;
                p.Company = c != null ? c.ID : null;
            }
            else
            {
                p.Company = null;
            }
            if (!string.IsNullOrEmpty(txtInternalID.Text))
            {
                Product pi = txtInternalID.Tag as Product;
                p.InternalID = pi != null ? pi.ID : null;
            }
            else
            {
                p.InternalID = null;
            }
            p.Memo = txtMemo.Text;
            return p;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            Product p = addingItem as Product;
            CommandResult ret = null;
            //if (txtWarehouse.SelectedWareHouse != null && txtCount.DecimalValue > 0)
            //{
            //    ret = (new ProductBLL(AppSettings.Current.ConnStr)).AddProduct(p, txtWarehouse.SelectedWareHouse.ID, txtCount.DecimalValue);
            //}
            //else
            //{
            ret = (new ProductBLL(AppSettings.Current.ConnStr)).AddProduct(p);
            //}
            return ret;
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            Product p = updatingItem as Product;
            CommandResult ret = (new ProductBLL(AppSettings.Current.ConnStr)).UpdateProduct(p);
            return ret;
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            Product item = UpdatingItem as Product;
            if (item != null) PerformAddAttach(item.ID, item.DocumentType, gridAttachment);
        }

        private void mnu_AttachmentDelete_Click(object sender, EventArgs e)
        {
            PerformDelAttach(gridAttachment);
        }

        private void mnu_AttachmentSaveAs_Click(object sender, EventArgs e)
        {
            PerformAttachSaveAs(gridAttachment);
        }

        private void mnu_AttachmentOpen_Click(object sender, EventArgs e)
        {
            PerformAttachOpen(gridAttachment);
        }

        private void gridAttachment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PerformAttachOpen(gridAttachment);
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

        private void lnkCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo c = frm.SelectedItem as CompanyInfo;
                txtCompany.Text = c.ID;
                txtCompany.Tag = c;
            }
        }

        private void lnkInternalID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductMaster frm = new FrmProductMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Product p = frm.SelectedItem as Product;
                txtInternalID.Text = p.ID;
                txtInternalID.Tag = p;
            }
        }
    }
}
