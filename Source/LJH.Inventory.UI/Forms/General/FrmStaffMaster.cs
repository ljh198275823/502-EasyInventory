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
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.Report;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.General
{
    public partial class FrmStaffMaster : FrmMasterBase
    {
        public FrmStaffMaster()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Staff> _Staffs = null;
        private List<Operator> _Operators = null;
        #endregion

        #region 私有方法
        private void FreshData()
        {
            List<object> items = FilterData();
            ShowItemsOnGrid(items);
        }

        private List<object> FilterData()
        {
            List<Staff> items = _Staffs;
            List<Department> pc = null;
            if (this.departmentTree1.SelectedNode != null && this.departmentTree1.SelectedNode.Tag != null)
            {
                pc = departmentTree1.GetDepartmentofNode(this.departmentTree1.SelectedNode);
                if (pc != null && pc.Count > 0) items = _Staffs.Where(it => pc.Exists(c => c.ID == it.DepartmentID)).ToList();
            }
            return (from p in items
                    orderby p.Name ascending
                    select (object)p).ToList();
        }
        #endregion

        #region 重写基类方法
        protected override void ReFreshData()
        {
            departmentTree1.Init();
            _Operators = new OperatorBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            base.ReFreshData();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btn_Add.Enabled = Operator.Current.Permit(Permission.Staff, PermissionActions.Edit);
            btn_Delete.Enabled = Operator.Current.Permit(Permission.Staff, PermissionActions.Edit);
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.Staff, PermissionActions.Edit);
            cMnu_Delete.Enabled = Operator.Current.Permit(Permission.Staff, PermissionActions.Edit);
            mnu_AddStaff.Enabled = Operator.Current.Permit(Permission.Staff, PermissionActions.Edit);
            mnu_AddDepartment.Enabled = Operator.Current.Permit(Permission.Department, PermissionActions.Edit);
            mnu_DeleteDepartment.Enabled = Operator.Current.Permit(Permission.Department, PermissionActions.Edit);
        }

        protected override FrmDetailBase GetDetailForm()
        {
            FrmStaffDetail frm = new FrmStaffDetail();
            frm.Department = departmentTree1.SelectedNode != null ? (departmentTree1.SelectedNode.Tag as Department) : null;
            return frm;
        }

        protected override bool DeletingItem(object item)
        {
            Staff c = item as Staff;
            StaffBLL bll = new StaffBLL(AppSettings.Current.ConnStr);
            CommandResult ret = bll.Delete(c);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            else
            {
                _Staffs.Remove(c);
            }
            return ret.Result == ResultCode.Successful;
        }

        protected override List<object> GetDataSource()
        {
            StaffBLL bll = new StaffBLL(AppSettings.Current.ConnStr);
            if (SearchCondition == null)
            {
                _Staffs = bll.GetItems(null).QueryObjects;
            }
            else
            {
                _Staffs = bll.GetItems(SearchCondition).QueryObjects;
            }
            List<object> records = FilterData();
            return records;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Staff c = item as Staff;
            row.Tag = c;
            row.Cells["colImage"].Value = Properties.Resources.customer;
            row.Cells["colName"].Value = c.Name;
            Department dept = departmentTree1.GetDepartment(c.DepartmentID);
            row.Cells["colDepartment"].Value = dept != null ? dept.Name : string.Empty;
            row.Cells["colCertificate"].Value = c.Certificate;
            row.Cells["colSex"].Value = c.Sex;
            row.Cells["colPosition"].Value = c.UserPosition;
            row.Cells["colHireDate"].Value = c.HireDate != null ? c.HireDate.Value.ToString("yyyy-MM-dd") : string.Empty;
            if (_Operators != null && _Operators.Count > 0)
            {
                Operator opt = _Operators.FirstOrDefault(it => it.StaffID == c.ID);
                row.Cells["colLogID"].Value = opt != null ? opt.ID : string.Empty;
                row.Cells["colRole"].Value = opt != null && opt.Role != null ? opt.Role.Name : string.Empty;
            }
            row.Cells["colMemo"].Value = c.Memo;
            if (_Staffs == null || !_Staffs.Exists(it => it.ID == c.ID))
            {
                if (_Staffs == null) _Staffs = new List<Staff>();
                _Staffs.Add(c);
            }
        }

        protected override void ShowItemsOnGrid(List<object> items)
        {
            base.ShowItemsOnGrid(items);
            Filter(txtKeyword.Text.Trim());
        }

        protected override void PerformAddData()
        {
            try
            {
                FrmDetailBase detailForm = GetDetailForm();
                if (detailForm != null)
                {
                    detailForm.IsAdding = true;
                    DataGridViewRow row = null;
                    detailForm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
                    {
                        _Operators = new OperatorBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
                        row = Add_And_Show_Row(args.AddedItem);
                    };
                    detailForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        protected override void PerformUpdateData()
        {
            if (this.GridView != null && this.GridView.SelectedRows != null && this.GridView.SelectedRows.Count > 0)
            {
                object pre = this.GridView.SelectedRows[0].Tag;
                if (pre != null)
                {
                    FrmDetailBase detailForm = GetDetailForm();
                    if (detailForm != null)
                    {
                        detailForm.IsAdding = false;
                        detailForm.UpdatingItem = pre;

                        detailForm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
                        {
                            _Operators = new OperatorBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
                            ShowItemInGridViewRow(this.GridView.SelectedRows[0], args.UpdatedItem);
                        };
                        detailForm.ShowDialog();
                    }
                }
            }
        }
        #endregion

        #region 类别树右键菜单
        private void departmentTree1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            FreshData();
        }

        private void mnu_AddDepartment_Click(object sender, EventArgs e)
        {
            Department pc = departmentTree1.SelectedNode.Tag as Department;
            FrmDepartmentDetail frm = new FrmDepartmentDetail();
            frm.IsAdding = true;
            frm.ParentDepartment = pc;
            frm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
            {
                Department item = args.AddedItem as Department;
                departmentTree1.AddDepartmentNode(item, departmentTree1.SelectedNode);
                departmentTree1.SelectedNode.Expand();
            };
            frm.ShowDialog();
        }

        private void mnu_DeleteDepartment_Click(object sender, EventArgs e)
        {
            Department pc = departmentTree1.SelectedNode.Tag as Department;
            if (pc != null && MessageBox.Show("是否删除此部门及其子部门?", "询问", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
            {
                CommandResult ret = (new DepartmentBLL(AppSettings.Current.ConnStr)).Delete(pc);
                if (ret.Result == ResultCode.Successful)
                {
                    departmentTree1.SelectedNode.Parent.Nodes.Remove(departmentTree1.SelectedNode);
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void mnu_DepartmentProperty_Click(object sender, EventArgs e)
        {
            Department pc = departmentTree1.SelectedNode.Tag as Department;
            FrmDepartmentDetail frm = new FrmDepartmentDetail();
            frm.IsAdding = false;
            frm.UpdatingItem = pc;
            frm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
            {
                departmentTree1.Init();
                departmentTree1.SelectDeptNode(pc.ID);
                FreshData();
            };
            frm.ShowDialog();
        }

        private void mnu_AddStaff_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }
        #endregion
    }
}
