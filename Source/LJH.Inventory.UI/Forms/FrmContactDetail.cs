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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmContactDetail : Form
    {
        public FrmContactDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置联系人
        /// </summary>
        public Contact Contact { get; set; }
        #endregion

        #region 重写基类方法
        private bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("姓名不能为空");
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void ItemShowing()
        {
            txtName.Text = Contact.Name;
            txtPosition.Text = Contact.Position;
            txtMobile.Text = Contact.Mobile;
            txtTelphone.Text = Contact.TelPhone;
            txtQQ.Text = Contact.QQ;
            txtEmail.Text = Contact.Email;
            txtMemo.Text = Contact.Memo;
        }

        private Contact GetItemFromInput()
        {
            if (Contact == null)
            {
                Contact = new Contact();
                Contact.ID = Guid.NewGuid();
            }
            Contact.Name = txtName.Text;
            Contact.Position = txtPosition.Text;
            Contact.Mobile = txtMobile.Text;
            Contact.TelPhone = txtTelphone.Text;
            Contact.QQ = txtQQ.Text;
            Contact.Email = txtEmail.Text;
            Contact.Memo = txtMemo.Text;
            return Contact;
        }
        #endregion

        #region 事件处理程序
        private void FrmContactDetail_Load(object sender, EventArgs e)
        {
            if (Contact != null)
            {
                ItemShowing();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(CheckInput ())
            {
                this.Contact = GetItemFromInput();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
