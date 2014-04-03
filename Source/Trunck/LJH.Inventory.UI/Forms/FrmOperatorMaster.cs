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
    public partial class FrmOperatorMaster:FrmMasterBase
    {
        private List<OperatorInfo> operators;
        private OperatorBLL bll = new OperatorBLL(AppSettings .CurrentSetting .ConnStr );

        public FrmOperatorMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法和处理事件
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmOperatorDetail();
        }

        protected override List<object> GetDataSource()
        {
            operators = bll.GetAllOperators().QueryObjects.ToList();
            List<object> source = new List<object>();
            foreach (object o in operators)
            {
                source.Add(o);
            }
            return source;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row,object item)
        {
            OperatorInfo info = item as OperatorInfo;
            row.Tag = info;
            row.Cells["colOperatorID"].Value  = info.OperatorID;
            row.Cells["colOperatorName"].Value = info.OperatorName;
            row.Cells["colRoleID"] .Value = info.Role.RoleID;
            row.Cells["colDepartment"].Value = info.Department;
            row.Cells["colPost"].Value = info.Post;
        }

        protected override bool DeletingItem(object item)
        {
            OperatorInfo info = (OperatorInfo)item;
            CommandResult ret = bll.Delete(info);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message, "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return ret.Result == ResultCode.Successful;
        }

        protected override void Init()
        {
            base.Init();
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditOperator);
            menu.Items["btn_Delete"].Enabled = opt.Permit(Permission.EditOperator);
        }

        #endregion
    }
}
