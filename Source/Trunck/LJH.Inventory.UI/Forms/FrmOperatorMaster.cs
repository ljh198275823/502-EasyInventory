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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmOperatorMaster:FrmMasterBase
    {
        private List<Operator> operators;
        private OperatorBLL bll = new OperatorBLL(AppSettings .Current .ConnStr );

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
            operators = bll.GetItems(null).QueryObjects.ToList();
            List<object> source = new List<object>();
            foreach (object o in operators)
            {
                source.Add(o);
            }
            return source;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Operator info = item as Operator;
            row.Tag = info;
            row.Cells["colOperatorID"].Value = info.ID;
            row.Cells["colOperatorName"].Value = info.Name;
            row.Cells["colRoleID"].Value = info.Role != null ? info.Role.ID : string.Empty;
            row.Cells["colDepartment"].Value = info.DepartmentID;
            row.Cells["colPost"].Value = info.Post;
        }

        protected override bool DeletingItem(object item)
        {
            Operator info = (Operator)item;
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
            Operator opt = Operator.Current;
            menu.Items["btn_Add"].Enabled = opt.Permit(Permission.EditOperator);
            menu.Items["btn_Delete"].Enabled = opt.Permit(Permission.EditOperator);
        }

        #endregion
    }
}
