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
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.Report;
using LJH.Inventory.UI.Forms.Financial;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmCreditLine : Form
    {
        public FrmCreditLine()
        {
            InitializeComponent();
        }

        public CompanyInfo Customer { get; set; }

        private void FrmCreditLine_Load(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                txtOldCreditLine.DecimalValue = Customer.CreditLine;
                txtNewCreditLine.DecimalValue = Customer.CreditLine;
                txtNewCreditLine.SelectAll();
                txtNewCreditLine.Focus();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Customer != null)
            {
                Customer.CreditLine = txtNewCreditLine.DecimalValue;
                var ret = new CompanyBLL(AppSettings.Current.ConnStr).Update(Customer);
                if (ret.Result == GeneralLibrary.Core.DAL.ResultCode.Successful)
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
}
