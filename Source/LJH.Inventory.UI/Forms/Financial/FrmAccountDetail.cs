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
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmAccountDetail : FrmDetailBase
    {
        public FrmAccountDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置父类别
        /// </summary>
        public Account ParentCategory { get; set; }
        #endregion

        #region 重写基类方法
        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btnOk.Enabled = Operator.Current.Permit(Permission.Account, PermissionActions.Edit);
        }

        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("名称不能为空");
                txtName.Focus();
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            Account ct = UpdatingItem as Account;
            txtName.Text = ct.Name;
            chk对公账号.Checked = ct.Ispublic;
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            Account ct = UpdatingItem as Account;
            if (IsAdding)
            {
                ct = new Account();
                ct.ID = txtName.Text;
                ct.Operator = Operator.Current.Name;
                ct.AddDate = DateTime.Now;
            }
            ct.Name = txtName.Text;
            ct.Ispublic = chk对公账号.Checked;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new AccountBLL(AppSettings.Current.ConnStr)).Add(addingItem as Account);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new AccountBLL(AppSettings.Current.ConnStr)).Update(updatingItem as Account);
        }
        #endregion
    }
}
