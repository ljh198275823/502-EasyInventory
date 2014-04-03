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
    public partial class FrmCustomerDetail : FrmDetailBase
    {
        public FrmCustomerDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置客户类别
        /// </summary>
        public CustomerType Category { get; set; }
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
            this.txtCategory.Text = Category != null ? Category.Name : string.Empty;
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            this.btnOk.Enabled = opt.Permit(Permission.EditCustomer);
        }

        protected override void ItemShowing()
        {
            Customer c = UpdatingItem as Customer;
            txtID.Enabled = (c == null);
            if (c != null)
            {
                txtID.Text = c.ID;
                if (!string.IsNullOrEmpty(c.CategoryID))
                {
                    Category = (new CustomerTypeBLL(AppSettings.CurrentSetting.ConnStr)).GetByID(c.CategoryID).QueryObject;
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
            List<Contact> contacts = (new ContactBLL(AppSettings.CurrentSetting.ConnStr)).GetItems(con).QueryObjects;
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
            Customer info;
            if (UpdatingItem == null)
            {
                info = new Customer();
                info.ClassID = CustomerClass.Customer;
                info.Creater = OperatorInfo.CurrentOperator.OperatorName;
            }
            else
            {
                info = UpdatingItem as Customer;
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
            CustomerBLL bll = new CustomerBLL(AppSettings.CurrentSetting.ConnStr);
            Customer c = item as Customer;
            CommandResult ret = bll.Insert(item as Customer, 0, 0);
            if (ret.Result == ResultCode.Successful)
            {
                foreach (DataGridViewRow row in GridView.Rows)
                {
                    Contact ct = row.Tag as Contact;
                    ct.Company = c.ID;
                    CommandResult r = (new ContactBLL(AppSettings.CurrentSetting.ConnStr)).Add(ct);
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
            CustomerBLL bll = new CustomerBLL(AppSettings.CurrentSetting.ConnStr);
            return bll.Update(item as Customer);
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
                    Customer c = UpdatingItem as Customer;
                    ct.Company = c.ID;
                    CommandResult ret = (new ContactBLL(AppSettings.CurrentSetting.ConnStr)).Add(ct);
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
                Contact ct = GridView.Rows[e.RowIndex].Tag as Contact;
                frm.Contact = ct;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    CommandResult ret = (new ContactBLL(AppSettings.CurrentSetting.ConnStr)).Update(ct);
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
                                CommandResult ret = (new ContactBLL(AppSettings.CurrentSetting.ConnStr)).Delete(c);
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

        #region 事件处理程序
        private void lblCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMasterBase frm = null;
            frm = new FrmCustomerTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Category = frm.SelectedItem as CustomerType;
                this.txtCategory.Text = Category != null ? Category.Name : string.Empty;
            }
        }
        #endregion
    }
}
