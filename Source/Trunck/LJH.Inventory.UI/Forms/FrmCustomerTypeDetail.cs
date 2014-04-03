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
    public partial class FrmCustomerTypeDetail : FrmDetailBase
    {
        public FrmCustomerTypeDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置父类别
        /// </summary>
        public CustomerType ParentCategory { get; set; }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            txtParentCategory.Text = ParentCategory != null ? ParentCategory.Name : string.Empty;
            OperatorInfo opt = OperatorInfo.CurrentOperator;
            btnOk.Enabled = opt.Permit(Permission.EditCustomer);
        }

        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("名称不能为空");
                txtName.Focus();
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            CustomerType ct = UpdatingItem as CustomerType;
            txtName.Text = ct.Name;
            if (!string.IsNullOrEmpty(ct.Parent))
            {
                ParentCategory = (new CustomerTypeBLL(AppSettings.CurrentSetting.ConnStr)).GetByID(ct.Parent).QueryObject;
                txtParentCategory.Text = ParentCategory != null ? ParentCategory.Name : string.Empty;
            }
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            CustomerType ct = UpdatingItem as CustomerType;
            if (IsAdding)
            {
                ct = new CustomerType();
                ct.ID = txtName.Text;
            }
            ct.Name = txtName.Text;
            ct.Parent = ParentCategory != null ? ParentCategory.ID : null;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new CustomerTypeBLL(AppSettings.CurrentSetting.ConnStr)).Add(addingItem as CustomerType);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new CustomerTypeBLL(AppSettings.CurrentSetting.ConnStr)).Update(updatingItem as CustomerType);
        }
        #endregion

        private void lnkParentCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCustomerTypeMaster frm = new FrmCustomerTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ParentCategory = frm.SelectedItem as CustomerType;
                this.txtParentCategory.Text = ParentCategory.Name;
            }
        }
    }
}
