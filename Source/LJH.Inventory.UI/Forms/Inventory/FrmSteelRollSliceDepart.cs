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
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollSliceDepart : Form
    {
        public FrmSteelRollSliceDepart()
        {
            InitializeComponent();
        }

        #region 公共属性
        public ProductInventoryItem ProductInventory { get; set; }
        #endregion

        private void FrmSteelRollSliceDepart_Load(object sender, EventArgs e)
        {
            ucSpecification1.Init();
            if (ProductInventory != null)
            {
                txtOriginal.DecimalValue = ProductInventory.Count;
                ucSpecification1.Specification = ProductInventory.Product.Specification;
                WareHouse w = ProductInventory.WareHouse;
                txtWareHouse.Text = w != null ? w.Name : string.Empty;
                txtWareHouse.Tag = w;
                txtCustomer.Text = ProductInventory.Customer;
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
            if (txtDepart.DecimalValue == 0)
            {
                MessageBox.Show("没有指定拆包的数量");
                return;
            }
            if (txtWareHouse.Tag == null)
            {
                MessageBox.Show("没有选择仓库");
                txtWareHouse.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtCustomer.Text))
            {
                MessageBox.Show("没有指定客户");
                return;
            }
            if (SpecificationHelper.GetWrittenThick(ucSpecification1.Specification) == null ||
                SpecificationHelper .GetWrittenWidth (ucSpecification1 .Specification )==null )
            {
                MessageBox.Show("规格不正确，请同时指定厚度和长度");
                return;
            }
            CommandResult ret = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).Depart(ProductInventory, txtWareHouse.Tag as WareHouse, txtCustomer.Text, txtDepart.DecimalValue, ucSpecification1.Specification, txtMemo.Text);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message, "失败");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
