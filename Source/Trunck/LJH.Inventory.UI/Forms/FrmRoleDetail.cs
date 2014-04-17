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
using LJH.GeneralLibrary.DAL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmRoleDetail :FrmDetailBase  
    {
        private RoleBLL bll = new RoleBLL(AppSettings.Current.ConnStr);

        public FrmRoleDetail()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override  bool CheckInput()
        {
            if (string.IsNullOrEmpty (this.txtRoleID.Text.Trim()))
            {
                MessageBox .Show ("角色ID不能为空!");
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            functionTree1.Init();
            if (IsAdding)
            {
                this.Text = "增加角色";
            }
            Role role = Operator.Current.Role;
            this.btnOk.Enabled = role.Permit(Permission.EditRole);
        }

        protected override void ItemShowing()
        {
            Role info = (Role)UpdatingItem;
            this.txtRoleID.Text = info.ID;
            this.txtRoleID.Enabled = false;
            this.txtRoleID.BackColor = Color.White;
            this.txtDescription.Text = info.Description;
            this.functionTree1.SelectedRights = info.Permission;
            if (info.IsAdmin) this.functionTree1.Enabled = false;
            this.Text ="角色 "+ info.ID + " 的信息";
        }

        protected override object GetItemFromInput()
        {
            Role info;
            if (UpdatingItem == null)
            {
                info = new Role();
            }
            else
            {
                info = UpdatingItem as Role;
            }
            info.ID = this.txtRoleID.Text.Trim();
            info.Description = this.txtDescription.Text.Trim();
            info.Permission = this.functionTree1.SelectedRights;
            return info;
        }

        protected override CommandResult  AddItem(object item)
        {
            return bll.Insert((Role)item);
        }

        protected override CommandResult UpdateItem(object item)
        {
            return bll.Update(item as Role);
        }
        #endregion
    }
}
