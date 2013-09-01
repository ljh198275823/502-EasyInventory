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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmSupplierDetail : FrmDetailBase
    {
        public FrmSupplierDetail()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("编号不能为空");
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
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            this.btnOk.Enabled = opt.Permit(Permission.EditSupplier);
        }

        protected override void ItemShowing()
        {
            Supplier c = UpdatingItem as Supplier;
            if (c != null)
            {
                txtID.Text = c.ID;
                txtCategory.Text = c.Category != null ? c.Category.Name : string.Empty;
                txtCategory.Tag = c.Category;
                txtNation.Text = c.Nation;
                txtName.Text = c.Name;
                txtTelephone.Text = c.TelPhone;
                txtFax.Text = c.Fax;
                txtPostalCode.Text = c.PostalCode;
                txtAddress.Text = c.Address;
                txtMemo.Text = c.Memo;
            }
            txtID.Enabled = (c == null);

            GridView.Rows.Clear();
            ContactSearchCondition con = new ContactSearchCondition() { CompanyID = c.ID };
            List<Contact> contacts = (new ContactBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(con).QueryObjects;
            if (contacts != null && contacts.Count > 0)
            {
                foreach (Contact contact in contacts)
                {
                    int row = GridView.Rows.Add();
                    ShowItemOnRow(GridView.Rows[row], contact);
                }
            }
        }

        protected override object GetItemFromInput()
        {
            Supplier info;
            if (UpdatingItem == null)
            {
                info = new Supplier();
            }
            else
            {
                info = UpdatingItem as Supplier;
            }
            info.ID = txtID.Text != "自动创建" ? txtID.Text : string.Empty;
            SupplierType st = txtCategory.Tag as SupplierType;
            info.CategoryID = st.ID;
            info.Category = st;
            info.Nation = txtNation.Text;
            info.Name = txtName.Text;
            info.TelPhone = txtTelephone.Text;
            info.Fax = txtFax.Text;
            info.Address = txtAddress.Text;
            info.PostalCode = txtPostalCode.Text;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            SupplierBLL bll = new SupplierBLL(AppSettings.CurrentSetting.ConnectString);
            Supplier c = item as Supplier;
            CommandResult ret = bll.Add(c);
            if (ret.Result == ResultCode.Successful)
            {
                foreach (DataGridViewRow row in GridView.Rows)
                {
                    Contact ct = row.Tag as Contact;
                    ct.Company = c.ID;
                    CommandResult r = (new ContactBLL(AppSettings.CurrentSetting.ConnectString)).Add(ct);
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
            SupplierBLL bll = new SupplierBLL(AppSettings.CurrentSetting.ConnectString);
            return bll.Update(item as Supplier);
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
                    Supplier c = UpdatingItem as Supplier;
                    ct.Company = c.ID;
                    CommandResult ret = (new ContactBLL(AppSettings.CurrentSetting.ConnectString)).Add(ct);
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
                    if (ct.ID > 0)
                    {
                        CommandResult ret = (new ContactBLL(AppSettings.CurrentSetting.ConnectString)).Update(ct);
                        if (ret.Result != ResultCode.Successful)
                        {
                            MessageBox.Show(ret.Message);
                            return;
                        }
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
                                CommandResult ret = (new ContactBLL(AppSettings.CurrentSetting.ConnectString)).Delete(c);
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

        private void lblCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSupplierTypeMaster frm = new FrmSupplierTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SupplierType ct = frm.SelectedItem as SupplierType;
                txtCategory.Text = ct.Name;
                txtCategory.Tag = ct;
            }
        }
    }
}
