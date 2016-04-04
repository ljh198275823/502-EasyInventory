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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmChangePwd : Form
    {
        public FrmChangePwd()
        {
            InitializeComponent();
        }

        public  Operator Operator{get;set;}

        private void FrmChangePwd_Load(object sender, EventArgs e)
        {
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                OperatorBLL bll = new OperatorBLL(AppSettings.Current.ConnStr);
                string oldPwd = Operator.Password;
                Operator.Password = txtNewPwd.Text;
                CommandResult result=bll.Update (Operator );
                if (result.Result == ResultCode.Successful)
                {
                    this.Close();
                }
                else
                {
                    Operator.Password = oldPwd;
                    MessageBox.Show(result.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtNewPwd.Text))
            {
                MessageBox.Show("新密码不能为空!");
                txtNewPwd.SelectAll();
                return false;
            }
            if (txtNewPwd.Text != txtConfirmPwd.Text)
            {
                MessageBox.Show("新密码与确认密码不一致!");
                txtConfirmPwd.SelectAll();
                return false;
            }
            return true;
        }

       

        
    }
}
