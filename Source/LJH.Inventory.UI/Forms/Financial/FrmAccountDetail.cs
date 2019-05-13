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
            if (!rd银行账号.Checked && !rd现金账号.Checked && !rd财务核算.Checked)
            {
                MessageBox.Show("没有指定账号类型");
                return false;
            }
            if (chk对公账号.Checked && !rd银行账号.Checked)
            {
                MessageBox.Show("对公账号不能是非银行账号");
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            Account ct = UpdatingItem as Account;
            txtName.Text = ct.Name;
            chk对公账号.Checked = ct.Ispublic;
            rd银行账号.Checked = ct.Class == AccountType.银行账号;
            rd现金账号.Checked = ct.Class == AccountType.现金账号;
            rd财务核算.Checked = ct.Class == AccountType.财务核算;
            txtOperators.Text = ct.GetProperty(SheetNote.关联操作员);
            txtMemo.Text = ct.Memo;
            if (ct.Class != AccountType.无效)
            {
                rd财务核算.Enabled = false;
                rd现金账号.Enabled = false;
                rd银行账号.Enabled = false;
            }
            chk对公账号.Enabled = false;
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
            if (rd银行账号.Checked) ct.Class = AccountType.银行账号;
            else if (rd现金账号.Checked) ct.Class = AccountType.现金账号;
            else if (rd财务核算.Checked) ct.Class = AccountType.财务核算;
            ct.SetProperty(SheetNote.关联操作员, txtOperators.Text);
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

        private void lnkOperators_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = new FrmOperatorSelection();
            if (UpdatingItem != null) frm.SelectedOperators = (UpdatingItem as Account).GetProperty(SheetNote.关联操作员);
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtOperators.Text = frm.SelectedOperators;
            }
        }
    }
}
