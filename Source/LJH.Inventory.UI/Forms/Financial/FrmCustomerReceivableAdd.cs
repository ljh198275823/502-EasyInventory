using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.Inventory.UI.Forms.Sale;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmCustomerReceivableAdd : Form
    {
        public FrmCustomerReceivableAdd()
        {
            InitializeComponent();
        }

        #region 公共属性
        public CompanyInfo Customer { get; set; }

        public CustomerReceivableType ReceivableType { get; set; }
        #endregion

        private void FrmCustomerReceivableAdd_Load(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                this.txtCustomer.Text = Customer.Name;
            }
            if (ReceivableType == CustomerReceivableType.CustomerReceivable)
            {
                this.Text = "新增客户应收账款";
                btnOk.Enabled = Operator.Current.Permit(Permission.CustomerOtherReceivable, PermissionActions.Edit);
            }
            else if (ReceivableType == CustomerReceivableType.CustomerTax)
            {
                this.Text = "新增应开增值税";
            }
            else
            {
                btnOk.Enabled = false;
            }
        }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerMaster frm = new FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Customer = frm.SelectedItem as CompanyInfo;
                txtCustomer.Text = Customer.Name;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Customer == null)
            {
                MessageBox.Show("没有指定客户");
                return;
            }
            if (txtAmount.DecimalValue <= 0)
            {
                MessageBox.Show("金额不正确，需要填写大于零的数值");
                return;
            }
            CustomerReceivable cr = new CustomerReceivable();
            cr.ID = Guid.NewGuid();
            cr.ClassID = ReceivableType;
            cr.CustomerID = Customer.ID;
            cr.CreateDate = DateTime.Now;
            cr.Amount = txtAmount.DecimalValue;
            if (ReceivableType == CustomerReceivableType.CustomerReceivable) cr.SheetID = "其它应收款";
            if (ReceivableType == CustomerReceivableType.CustomerTax) cr.SheetID = "其它应开增值税";
            if (!string.IsNullOrEmpty(txtMemo.Text)) cr.Memo = txtMemo.Text;
            var ret = new CustomerReceivableBLL(AppSettings.Current.ConnStr).Add(cr);
            if (ret.Result == ResultCode.Successful)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }
    }
}
