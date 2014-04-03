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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmRoleMaster : FrmMasterBase
    {
        private List<RoleInfo> roles;

        public FrmRoleMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法及事件处理
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmRoleDetail();
        }

        protected override bool DeletingItem(object item)
        {
            RoleBLL bll = new RoleBLL(AppSettings.CurrentSetting.ConnectString);
            RoleInfo info = (RoleInfo)item;
            CommandResult result = bll.Delete(info);
            if (result.Result != ResultCode.Successful)
            {
                MessageBox.Show(result.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return result.Result == ResultCode.Successful;
        }

        protected override List<object> GetDataSource()
        {
            RoleBLL bll = new RoleBLL(AppSettings.CurrentSetting.ConnectString);
            roles = bll.GetAllRoles().QueryObjects.ToList();
            List<object> source = new List<object>();
            foreach (object o in roles)
            {
                source.Add(o);
            }
            return source;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            RoleInfo info = item as RoleInfo;
            row.Tag = item;
            row.Cells["colRoleID"].Value = info.RoleID;
            row.Cells["colRoleName"].Value = info.Description;
        }

        protected override void Init()
        {
            base.Init();
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            //menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditRole);
            //menu.Items["btn_Delete"].Enabled = opt.Permit(Permission.EditRole);
        }
        #endregion
    }
}
