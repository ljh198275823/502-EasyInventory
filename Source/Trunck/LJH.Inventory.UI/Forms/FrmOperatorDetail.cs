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
    public partial class FrmOperatorDetail : FrmDetailBase
    {
        private OperatorBLL bll = new OperatorBLL(AppSettings.CurrentSetting.ConnectString);
        private string _subPwd = new string('*', 10);

        public FrmOperatorDetail()
        {
            InitializeComponent();
        }

        #region 重写基类的方法
        protected override void InitControls()
        {
            comRoleList.Init();
            if (IsAdding)
            {
                this.btnChangePwd.Visible = false;
                this.txtPassword.Size = this.txtOperatorName.Size;
            }
            RoleInfo role = OperatorInfo.CurrentOperator.Role;
            this.btnOk.Enabled = role.Permit(Permission.EditOperator);
        }

        protected override void ItemShowing()
        {
            OperatorInfo info = (OperatorInfo)UpdatingItem;
            this.txtOperatorID.Text = info.OperatorID;
            this.txtOperatorID.Enabled = false;
            this.txtOperatorID.BackColor = Color.White;
            this.txtOperatorName.Text = info.OperatorName;
            this.txtPassword.Text = _subPwd;
            this.txtPassword.Enabled = false;
            this.txtPassword.BackColor = Color.White;
            this.comRoleList.SelectedRoleID = info.RoleID;
            this.txtDepartment.Text = info.Department;
            this.txtPost.Text = info.Post;
            this.comRoleList.Enabled = info.CanEdit;
        }


        protected override object GetItemFromInput()
        {
            OperatorInfo info = null;
            if (CheckInput())
            {
                if (IsAdding)
                {
                    info = new OperatorInfo();
                    info.Password = txtPassword.Text.Trim();
                }
                else
                {
                    info = UpdatingItem as OperatorInfo;
                    if (txtPassword.Text.Trim() != _subPwd)
                    {
                        info.Password = txtPassword.Text.Trim();
                    }
                }
                info.OperatorID = txtOperatorID.Text.Trim();
                info.OperatorName = txtOperatorName.Text.Trim();
                info.Role = comRoleList.Role;
                info.RoleID = comRoleList.SelectedRoleID;
                info.Department = txtDepartment.Text;
                info.Post = txtPost.Text;
            }
            return info;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return bll.Insert((OperatorInfo)addingItem);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return bll.Update(updatingItem as OperatorInfo);
        }

        protected override bool CheckInput()
        {
            if (txtOperatorID.Text.Trim().Length == 0)
            {
                MessageBox.Show("操作员登录ID不能为空!");
                return false;
            }

            if (txtOperatorName.Text.Trim().Length == 0)
            {
                MessageBox.Show("操作员姓名不能为空!");
                return false;
            }

            if (txtPassword.Text.Trim().Length == 0)
            {
                MessageBox.Show("操作员密码不能为空!");
                return false;
            }
            return true;
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            FrmChangePwd frm = new FrmChangePwd();
            frm.Operator = UpdatingItem as OperatorInfo;
            frm.ShowDialog();
        }
        #endregion
    }
}
