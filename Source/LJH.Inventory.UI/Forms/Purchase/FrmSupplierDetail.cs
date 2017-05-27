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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.Purchase
{
    public partial class FrmSupplierDetail : FrmSheetDetailBase
    {
        public FrmSupplierDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置供应商类别
        /// </summary>
        public SupplierType Category { get; set; }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("客户编号不能为空");
                txtID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("公司名称不能为空");
                txtName.Focus();
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            base.InitControls();
            txtCategory.Text = Category != null ? Category.Name : string.Empty;
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btnOk.Enabled = Operator.Current.Permit(Permission.Supplier, PermissionActions.Edit);
            mnu_AddContact.Enabled = Operator.Current.Permit(Permission.Supplier, PermissionActions.Edit);
            mnu_DeleteContact.Enabled = Operator.Current.Permit(Permission.Supplier, PermissionActions.Edit);
            GridView.Enabled = Operator.Current.Permit(Permission.Supplier, PermissionActions.Edit);
            mnu_AttachmentAdd.Enabled = Operator.Current.Permit(Permission.Supplier, PermissionActions.Edit);
            mnu_AttachmentDelete.Enabled = Operator.Current.Permit(Permission.Supplier, PermissionActions.Edit);
        }

        protected override void ItemShowing()
        {
            CompanyInfo c = UpdatingItem as CompanyInfo;
            txtID.Enabled = (c == null);
            if (c != null)
            {
                txtID.Text = c.ID;
                if (!string.IsNullOrEmpty(c.CategoryID))
                {
                    Category = (new SupplierTypeBLL(AppSettings.Current.ConnStr)).GetByID(c.CategoryID).QueryObject;
                }
                this.txtCategory.Text = Category != null ? Category.Name : string.Empty;
                txtNation.Text = c.Nation;
                txtName.Text = c.Name;
                txtNation.Text = c.Nation;
                txtCity.Text = c.City;
                txtTelphone.Text = c.TelPhone;
                txtFax.Text = c.Fax;
                txtPost.Text = c.PostalCode;
                txtWeb.Text = c.Website;
                txtAddress.Text = c.Address;
                txtMemo.Text = c.Memo;
            }

            GridView.Rows.Clear();
            ContactSearchCondition con = new ContactSearchCondition() { CompanyID = c.ID };
            List<Contact> contacts = (new ContactBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            if (contacts != null && contacts.Count > 0)
            {
                foreach (Contact contact in contacts)
                {
                    int row = GridView.Rows.Add();
                    ShowItemOnRow(GridView.Rows[row], contact);
                }
            }
            ShowAttachmentHeaders(c.ID, c.DocumentType, this.gridAttachment);
        }

        protected override object GetItemFromInput()
        {
            CompanyInfo info;
            if (UpdatingItem == null)
            {
                info = new CompanyInfo();
                info.ClassID = CompanyClass.Supplier ;
            }
            else
            {
                info = UpdatingItem as CompanyInfo;
            }
            info.ID = txtID.Text != "自动创建" ? txtID.Text : string.Empty;
            info.CategoryID = Category != null ? Category.ID : null;
            info.Nation = txtNation.Text;
            info.Name = txtName.Text;
            info.Nation = txtNation.Text;
            info.City = txtCity.Text;
            info.TelPhone = txtTelphone.Text;
            info.Fax = txtFax.Text;
            info.PostalCode = txtPost.Text;
            info.Website = txtWeb.Text;
            info.Address = txtAddress.Text;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            CompanyInfo c = item as CompanyInfo;
            CommandResult ret = bll.Add(item as CompanyInfo);
            if (ret.Result == ResultCode.Successful)
            {
                foreach (DataGridViewRow row in GridView.Rows)
                {
                    Contact ct = row.Tag as Contact;
                    ct.ID = Guid.NewGuid();
                    ct.Company = c.ID;
                    CommandResult r = (new ContactBLL(AppSettings.Current.ConnStr)).Add(ct);
                    if (r.Result != ResultCode.Successful)
                    {
                        MessageBox.Show(r.Message);
                    }
                }
            }
            return ret;
        }

        protected override CommandResult UpdateItem(object item)
        {
            CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
            return bll.Update(item as CompanyInfo);
        }
        #endregion

        #region 联系人相关事件处理
        private void mnu_AddContact_Click(object sender, EventArgs e)
        {
            FrmContactDetail frm = new FrmContactDetail();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Contact ct = frm.Contact;
                if (this.UpdatingItem != null)
                {
                    CompanyInfo c = UpdatingItem as CompanyInfo;
                    ct.ID = Guid.NewGuid();
                    ct.Company = c.ID;
                    CommandResult ret = (new ContactBLL(AppSettings.Current.ConnStr)).Add(ct);
                    if (ret.Result != ResultCode.Successful)
                    {
                        MessageBox.Show(ret.Message);
                        return;
                    }
                }
                int row = GridView.Rows.Add();
                ShowItemOnRow(GridView.Rows[row], ct);
            }
        }

        private void GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                FrmContactDetail frm = new FrmContactDetail();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Contact ct = frm.Contact;
                    CommandResult ret = (new ContactBLL(AppSettings.Current.ConnStr)).Update(ct);
                    if (ret.Result != ResultCode.Successful)
                    {
                        MessageBox.Show(ret.Message);
                        return;
                    }
                    ShowItemOnRow(GridView.Rows[e.RowIndex], ct);
                }
            }
        }

        private void ShowItemOnRow(DataGridViewRow row, Contact item)
        {
            row.Tag = item;
            row.Cells["colName"].Value = item.Name;
            row.Cells["colPosition"].Value = item.Position;
            row.Cells["colMobile"].Value = item.Mobile;
            row.Cells["colTelphone"].Value = item.TelPhone;
            row.Cells["colEmail"].Value = item.Email;
            row.Cells["colQQ"].Value = item.QQ;
            row.Cells["colMemo"].Value = item.Memo;
        }

        private void mnu_DeleteContact_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.GridView.SelectedRows.Count > 0)
                {
                    List<DataGridViewRow> deletingRows = new List<DataGridViewRow>();
                    DialogResult result = MessageBox.Show("确实要删除所选项吗?", "确定", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        for (int i = GridView.Rows.Count - 1; i > -1; i--)
                        {
                            DataGridViewRow row = GridView.Rows[i];
                            if (row.Selected)
                            {
                                Contact c = row.Tag as Contact;
                                CommandResult ret = (new ContactBLL(AppSettings.Current.ConnStr)).Delete(c);
                                if (ret.Result == ResultCode.Successful)
                                {
                                    deletingRows.Add(row);
                                }
                            }
                        }
                        foreach (DataGridViewRow row in deletingRows)
                        {
                            GridView.Rows.Remove(row);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("没有选择项!", "Warning");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion

        #region 与附件操作相关的方法和事件处理程序
        private void mnu_AttachmentAdd_Click(object sender, EventArgs e)
        {
            CompanyInfo item = UpdatingItem as CompanyInfo;
            if (item != null) PerformAddAttach(item.ID, item.DocumentType, gridAttachment);
        }

        private void mnu_AttachmentDelete_Click(object sender, EventArgs e)
        {
            PerformDelAttach(gridAttachment);
        }

        private void mnu_AttachmentSaveAs_Click(object sender, EventArgs e)
        {
            PerformAttachSaveAs(gridAttachment);
        }

        private void mnu_AttachmentOpen_Click(object sender, EventArgs e)
        {
            PerformAttachOpen(gridAttachment);
        }

        private void gridAttachment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PerformAttachOpen(gridAttachment);
        }
        #endregion

        #region 事件处理程序
        private void lblCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMasterBase frm = null;
            frm = new FrmSupplierTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Category = frm.SelectedItem as SupplierType;
                txtCategory.Text = Category != null ? Category.Name : string.Empty;
            }
        }

        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            Category = null;
            txtCategory.Text = string.Empty;
        }
        #endregion
    }
}
