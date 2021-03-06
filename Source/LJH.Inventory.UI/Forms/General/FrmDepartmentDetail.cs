﻿using System;
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

namespace LJH.Inventory.UI.Forms.General
{
    public partial class FrmDepartmentDetail : FrmDetailBase
    {
        public FrmDepartmentDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置父类别
        /// </summary>
        public Department ParentDepartment { get; set; }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            txtParentCategory.Text = ParentDepartment != null ? ParentDepartment.Name : string.Empty;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btnOk.Enabled = Operator.Current.Permit(Permission.Department, PermissionActions.Edit);
        }

        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("名称不能为空");
                txtName.Focus();
                return false;
            }
            if (ParentDepartment != null && UpdatingItem != null && ParentDepartment.ID == (UpdatingItem as Department).ID)
            {
                MessageBox.Show("部门的上级部门不能是本部门");
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            Department ct = UpdatingItem as Department;
            txtName.Text = ct.Name;
            if (!string.IsNullOrEmpty(ct.Parent))
            {
                ParentDepartment = (new DepartmentBLL(AppSettings.Current.ConnStr)).GetByID(ct.Parent).QueryObject;
                txtParentCategory.Text = ParentDepartment != null ? ParentDepartment.Name : string.Empty;
            }
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            Department ct = UpdatingItem as Department;
            if (IsAdding)
            {
                ct = new Department();
            }
            ct.Name = txtName.Text;
            ct.Parent = ParentDepartment != null ? ParentDepartment.ID : null;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new DepartmentBLL(AppSettings.Current.ConnStr)).Add(addingItem as Department);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new DepartmentBLL(AppSettings.Current.ConnStr)).Update(updatingItem as Department);
        }
        #endregion

        #region 事件处理程序
        private void lnkParentCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDepartmentMaster frm = new FrmDepartmentMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ParentDepartment = frm.SelectedItem as Department;
                txtParentCategory.Text = ParentDepartment != null ? ParentDepartment.Name : string.Empty;
            }
        }

        private void txtParentCategory_DoubleClick(object sender, EventArgs e)
        {
            ParentDepartment = null; 
            txtParentCategory.Text = ParentDepartment != null ? ParentDepartment.Name : string.Empty;
        }
        #endregion
    }
}
