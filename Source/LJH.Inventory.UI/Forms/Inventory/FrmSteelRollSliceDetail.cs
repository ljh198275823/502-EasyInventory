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
    public partial class FrmSteelRollSliceDetail : Form
    {
        public FrmSteelRollSliceDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        public Product Product { get; set; }

        public WareHouse WareHouse { get; set; }
        #endregion

        private void ShowProduct(Product product)
        {
            cmbSpecification.Text = product.Specification;
            txtCategory.Text = product.Category.Name;
            txtCategory.Tag = product.Category;
            rdToPanel.Checked = product.Model == "开平";
            rdToRoll.Checked = product.Model == "开卷";
            rdToWeight.Checked = product.Model == "开吨";
            txtLength.DecimalValue = product.Length.HasValue ? product.Length.Value : 0;
            txtWeight.DecimalValue = product.Weight.HasValue ? product.Weight.Value : 0;
            decimal ? thick=SpecificationHelper .GetWrittenThick (product.Specification );
            txtThick.DecimalValue = thick != null ? thick.Value : 0;
        }

        private Product CreateProduct()
        {
            string sliceTo = null;
            if (rdToPanel.Checked) sliceTo = rdToPanel.Text;
            else if (rdToRoll.Checked) sliceTo = rdToRoll.Text;
            else if (rdToWeight.Checked) sliceTo = rdToWeight.Text;
            return new ProductBLL(AppSettings.Current.ConnStr).Create(
                             (txtCategory.Tag as ProductCategory).ID,
                             StringHelper.ToDBC(cmbSpecification.Text).Trim(),
                             sliceTo,
                             txtWeight.DecimalValue != 0 ? (decimal?)txtWeight.DecimalValue : null,
                             txtLength.DecimalValue != 0 ? (decimal?)txtLength.DecimalValue : null,
                             7.85m);
        }

        #region 重写基类方法
        private bool CheckInput()
        {
            if (txtCategory.Tag == null)
            {
                MessageBox.Show("没有选择类别");
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

        private void InitControls()
        {
            cmbSpecification.Init();
            if (Product != null) ShowProduct(Product);
            if (WareHouse != null)
            {
                txtWareHouse.Text = WareHouse.Name;
                txtWareHouse.Tag = WareHouse;
            }
            txtCount.Focus();
            btnOk.Enabled = Operator.Current.Permit(Permission.ProductInventory, PermissionActions.Edit);
        }
        #endregion

        #region 事件处理程序
        private void FrmSteelRollSliceDetail_Load(object sender, EventArgs e)
        {
            InitControls();
        }

        private void rdSliceType_CheckedChanged(object sender, EventArgs e)
        {
            txtLength.Enabled = !rdToWeight.Checked;
            txtWeight.Enabled = rdToWeight.Checked;
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

        private void btnOk_Click(object sender, EventArgs e)
        {
            var p = CreateProduct();
            if (p == null)
            {
                MessageBox.Show("创建产品信息失败");
                return;
            }
            SteelRollSliceBLL bll = new SteelRollSliceBLL(AppSettings.Current.ConnStr);
            var ret = bll.CreateInventory(p, txtWareHouse.Tag as WareHouse, txtCustomer.Text, txtCount.DecimalValue, txtThick.DecimalValue, Operator.Current.Name, txtMemo.Text);
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
