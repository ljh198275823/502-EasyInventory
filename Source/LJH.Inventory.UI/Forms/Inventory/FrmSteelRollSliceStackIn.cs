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
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.Inventory.UI.Forms.General;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollSliceStackIn : Form
    {
        public FrmSteelRollSliceStackIn()
        {
            InitializeComponent();
        }

        #region 公共属性
        public Product Product { get; set; }

        public WareHouse WareHouse { get; set; }
        #endregion

        #region 私有方法
        private void InitControls()
        {
            cmbSpecification.Init();
            if (Product != null) ShowProduct(Product);
            if (WareHouse != null)
            {
                txtWareHouse.Text = WareHouse.Name;
                txtWareHouse.Tag = WareHouse;
            }
            btnOk.Enabled = Operator.Current.Permit(Permission.SteelRollSlice, PermissionActions.Edit);
        }

        private void ShowProduct(Product product)
        {
            cmbSpecification.Specification = product.Specification;
            txtCategory.Text = product.Category.Name;
            txtCategory.Tag = product.Category;
            rd开平.Checked = product.Model == rd开平.Text;
            rd开卷.Checked = product.Model == rd开卷.Text;
            rd开吨.Checked = product.Model == rd开吨.Text;
            txtLength.DecimalValue = product.Length.HasValue ? product.Length.Value : 0;
            txtWeight.DecimalValue = product.Weight.HasValue ? product.Weight.Value : 0;
            decimal? thick = SpecificationHelper.GetWrittenThick(product.Specification);
        }

        private Product CreateProduct()
        {
            string sliceTo = null;
            if (rd开平.Checked) sliceTo = rd开平.Text;
            else if (rd开卷.Checked) sliceTo = rd开卷.Text;
            else if (rd开吨.Checked) sliceTo = rd开吨.Text;
            decimal? weight = null;
            if (rd单件重.Checked) weight = txtWeight.DecimalValue != 0 ? (decimal?)txtWeight.DecimalValue : null;
            return new ProductBLL(AppSettings.Current.ConnStr).Create(
                             (txtCategory.Tag as ProductCategory).ID,
                             StringHelper.ToDBC(cmbSpecification.Specification).Trim(),
                             sliceTo,
                             weight,
                             txtLength.DecimalValue != 0 ? (decimal?)txtLength.DecimalValue : null,
                             7.85m);

        }

        private bool CheckInput()
        {
            if (txtCategory.Tag == null)
            {
                MessageBox.Show("没有选择类别");
                return false;
            }
            if (string.IsNullOrEmpty(cmbSpecification.Specification))
            {
                MessageBox.Show("没有指定规格");
                return false;
            }
            if (!rd开平.Checked && !rd开卷.Checked && !rd开吨.Checked)
            {
                MessageBox.Show("没有指定加工类型");
                return false;
            }
            if (SpecificationHelper.GetWrittenThick(cmbSpecification.Specification) == null || SpecificationHelper.GetWrittenWidth(cmbSpecification.Specification) == null)
            {
                MessageBox.Show("规格设置不正确,  规格格式为 \"厚度*宽度\" ");
                return false;
            }
            if (txtThick.DecimalValue <= 0)
            {
                MessageBox.Show("厚度不正确");
                txtThick.Focus();
                return false;
            }
            if (txtWareHouse.Tag == null)
            {
                MessageBox.Show("没有选择仓库");
                txtWareHouse.Focus();
                return false;
            }
            if (txtLength.DecimalValue == 0 && txtWeight.DecimalValue == 0)
            {
                MessageBox.Show("至少要指定小件的长度或重量中的一项");
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
        #endregion

        #region 事件处理程序
        private void FrmSteelRollSliceDetail_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void rdSliceType_CheckedChanged(object sender, EventArgs e)
        {
            txtLength.Enabled = !rd开吨.Checked;
            txtWeight.Enabled = rd开卷.Checked || rd开吨.Checked;
        }

        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmProductCategoryMaster frm = new FrmProductCategoryMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var c = frm.SelectedItem as ProductCategory;
                txtCategory.Text = c != null ? c.Name : string.Empty;
                txtCategory.Tag = c;
            }
        }

        private void lnkWarehouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmWareHouseMaster frm = new FrmWareHouseMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                WareHouse w = frm.SelectedItem as WareHouse;
                txtWareHouse.Text = w != null ? w.Name : string.Empty;
                txtWareHouse.Tag = w;
            }
        }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sale.FrmCustomerMaster frm = new Sale.FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCustomer.Text = (frm.SelectedItem as CompanyInfo).Name;
            }
        }

        private void lnkSupplier_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Purchase.FrmSupplierMaster frm = new Purchase.FrmSupplierMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CompanyInfo s = frm.SelectedItem as CompanyInfo;
                txtSupplier.Text = s.Name;
                txtSupplier.Tag = s;
            }
        }

        private void txtSupplier_DoubleClick(object sender, EventArgs e)
        {
            txtSupplier.Text = string.Empty;
            txtSupplier.Tag = null;
        }

        private void lnkBrand_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRelatedCompanyMaster frm = new FrmRelatedCompanyMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cmbBrand.Text = (frm.SelectedItem as CompanyInfo).Name;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            var p = CreateProduct();
            if (p == null)
            {
                MessageBox.Show("创建产品信息失败");
                return;
            }

            SteelRollSliceBLL bll = new SteelRollSliceBLL(AppSettings.Current.ConnStr);
            var ret = bll.CreateInventory(p, txtWareHouse.Tag as WareHouse, txtCustomer.Text, txtCount.DecimalValue, txtWeight.DecimalValue, txtThick.DecimalValue, Operator.Current.Name, txtMemo.Text);
            if (ret.Result == ResultCode.Successful)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }
        #endregion
    }
}
