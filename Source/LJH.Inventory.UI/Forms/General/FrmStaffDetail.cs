﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.Report;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.General
{
    public partial class FrmStaffDetail : FrmDetailBase
    {
        public FrmStaffDetail()
        {
            InitializeComponent();
        }

        #region 私有变量
        private string _subPwd = new string('*', 12);
        #endregion

        #region 私有方法
        private Operator GetOperatorFromInput()
        {
            if (!string.IsNullOrEmpty(txtOperatorID.Text.Trim()))
            {
                Operator info = new Operator();
                info.ID = txtOperatorID.Text.Trim();
                if (txtPassword.Tag == null)
                {
                    info.Password = txtPassword.Text.Trim();
                }
                else
                {
                    info.Password = txtPassword.Tag.ToString();
                }
                info.Role = txtRole.Tag as Role;
                info.RoleID = info.Role != null ? info.Role.ID : null;
                return info;
            }
            return null;
        }

        private void ShowOperator(Operator info)
        {
            txtOperatorID.Text = info.ID;
            txtPassword.Text = _subPwd;
            txtPassword.Tag = info.Password;
            txtPassword.Enabled = false;
            txtRole.Tag = info.Role;
            txtRole.Text = info.Role != null ? info.Role.Name : null;
        }
        #endregion

        #region 公共属性
        public Department Department { get; set; }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            if (IsAdding)
            {
                this.btnChangePwd.Visible = false;
                this.txtPassword.Size = this.txtOperatorID.Size;
            }
            this.dtHireDate.IsNull = true;
            txtDepartment.Text = Department != null ? Department.Name : string.Empty;
        }

        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("没有设置员工姓名");
                return false;
            }
            if (txtOperatorID.Text.Trim() == Operator.DefaultLogID)
            {
                MessageBox.Show("admin 为系统默认操作员，不能归属到任何员工,请选择其它的登录ID");
                txtOperatorID.Text = string.Empty;
                txtOperatorID.Focus();
                return false;
            }
            return true;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btnOk.Enabled = Operator.Current.Permit(Permission.Staff, PermissionActions.Edit);
            btnBrowserPhoto.Enabled = Operator.Current.Permit(Permission.Staff, PermissionActions.Edit);
            btnDelPhoto.Enabled = Operator.Current.Permit(Permission.Staff, PermissionActions.Edit);
        }

        protected override void ItemShowing()
        {
            Staff staff = UpdatingItem as Staff;
            txtName.Text = staff.Name;
            txtCertificate.Text = staff.Certificate;
            Department = (new DepartmentBLL(AppSettings.Current.ConnStr)).GetByID(staff.DepartmentID).QueryObject;
            txtDepartment.Text = Department != null ? Department.Name : string.Empty;
            txtUserPosition.Text = staff.UserPosition;
            rdMale.Checked = staff.Sex == "男";
            rdFemale.Checked = staff.Sex == "女";
            if (staff.HireDate != null) dtHireDate.Value = staff.HireDate.Value;
            rdResign.Checked = staff.Resigned != null && staff.Resigned.Value;
            List<Operator> opts = (new OperatorBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            Operator opt = opts.FirstOrDefault(item => item.StaffID == staff.ID);
            if (opt != null)
            {
                ShowOperator(opt);
            }
            StaffPhoto sp = (new StaffBLL(AppSettings.Current.ConnStr)).GetPhoto(staff.ID).QueryObject;
            if (sp != null)
            {
                picPhoto.Image = sp.Photo;
            }
        }

        protected override CommandResult AddItem(object addingItem)
        {
            Staff staff = addingItem as Staff;
            CommandResult ret = (new StaffBLL(AppSettings.Current.ConnStr)).Add(staff);
            if (ret.Result == ResultCode.Successful)
            {
                Operator opt = GetOperatorFromInput();
                ret = new StaffBLL(AppSettings.Current.ConnStr).SaveOperator(opt, staff);
            }
            if (ret.Result == ResultCode.Successful && picPhoto.Tag != null)
            {
                ret = (new StaffBLL(AppSettings.Current.ConnStr)).SavePhoto(staff.ID, picPhoto.Tag.ToString());
                if (ret.Result != ResultCode.Successful)
                {
                    MessageBox.Show("人员信息增加成功，但人员照片保存失败，失败原因:" + ret.Message);
                }
            }
            return ret;
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            Staff staff = updatingItem as Staff;
            CommandResult ret = (new StaffBLL(AppSettings.Current.ConnStr)).Update(staff);
            if (ret.Result == ResultCode.Successful)
            {
                Operator opt = GetOperatorFromInput();
                ret = new StaffBLL(AppSettings.Current.ConnStr).SaveOperator(opt, staff);
            }
            if (ret.Result == ResultCode.Successful && picPhoto.Tag != null)
            {
                ret = (new StaffBLL(AppSettings.Current.ConnStr)).SavePhoto(staff.ID, picPhoto.Tag.ToString());
                if (ret.Result != ResultCode.Successful)
                {
                    MessageBox.Show("人员信息增加成功，但人员照片保存失败，失败原因:" + ret.Message);
                }
            }
            return ret;
        }

        protected override Object GetItemFromInput()
        {
            Staff info;
            if (UpdatingItem == null)
            {
                info = new Staff();
            }
            else
            {
                info = UpdatingItem as Staff;
            }
            info.Name = txtName.Text;
            info.Certificate = txtCertificate.Text;
            info.DepartmentID = Department != null ? Department.ID : null;
            info.Sex = rdMale.Checked ? "男" : "女";
            info.UserPosition = txtUserPosition.Text;
            if (!dtHireDate.IsNull)
            {
                info.HireDate = dtHireDate.Value.Date;
            }
            else
            {
                info.HireDate = null;
            }
            info.Resigned = rdResign.Checked;
            return info;
        }
        #endregion

        #region 事件处理程序
        private void btnDelPhoto_Click(object sender, EventArgs e)
        {
            if (UpdatingItem != null)
            {
                Staff staff = UpdatingItem as Staff;
                CommandResult ret = (new StaffBLL(AppSettings.Current.ConnStr)).DeletePhoto(staff.ID);
                if (ret.Result == ResultCode.Successful)
                {
                    picPhoto.Image = null;
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
            else
            {
                picPhoto.Image = null;
            }
        }

        private void btnBrowserPhoto_Click(object sender, EventArgs e)
        {
            if (picPhoto.Image != null)
            {
                MessageBox.Show("员工照片已经存在，请先删除旧照片");
                return;
            }
            try
            {
                OpenFileDialog saveFileDialog1 = new OpenFileDialog();
                saveFileDialog1.Filter = "JPG文件|*.jpg|所有文件(*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName;
                    picPhoto.Image = Image.FromFile(path);
                    picPhoto.Tag = path;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lnkDepartment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmDepartmentMaster frm = new FrmDepartmentMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Department = frm.SelectedItem as Department;
                txtDepartment.Text = Department != null ? Department.Name : string.Empty;
            }
        }

        private void txtDepartment_DoubleClick(object sender, EventArgs e)
        {
            Department = null;
            txtDepartment.Text = Department != null ? Department.Name : string.Empty;
        }
        #endregion

        private void lnkRole_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRoleMaster frm = new FrmRoleMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Role r = frm.SelectedItem as Role;
                txtRole.Tag = r;
                txtRole.Text = r != null ? r.Name : null;
            }
        }

        private void txtRole_DoubleClick(object sender, EventArgs e)
        {
            txtRole.Text = null;
            txtRole.Tag = null;
        }

    }
}
