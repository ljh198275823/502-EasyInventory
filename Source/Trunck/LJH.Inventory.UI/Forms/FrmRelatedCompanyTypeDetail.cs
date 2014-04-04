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
    public partial class FrmRelatedCompanyTypeDetail : FrmDetailBase
    {
        public FrmRelatedCompanyTypeDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置父类别
        /// </summary>
        public RelatedCompanyType ParentCategory { get; set; }
        #endregion

        #region 重写基类方法
        protected override void InitControls()
        {
            base.InitControls();
            txtParentCategory.Text = ParentCategory != null ? ParentCategory.Name : string.Empty;
            btnOk.Enabled = Operator.Current.Permit(Permission.EditSupplier);
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
            RelatedCompanyType ct = UpdatingItem as RelatedCompanyType;
            txtName.Text = ct.Name;
            if (!string.IsNullOrEmpty(ct.Parent))
            {
                ParentCategory = (new RelatedCompanyTypeBLL(AppSettings.CurrentSetting.ConnStr)).GetByID(ct.Parent).QueryObject;
            }
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            RelatedCompanyType ct = UpdatingItem as RelatedCompanyType;
            if (IsAdding)
            {
                ct = new RelatedCompanyType();
                ct.ID = txtName.Text;
            }
            ct.Name = txtName.Text;
            ct.Parent = ParentCategory != null ? ParentCategory.ID : null;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new RelatedCompanyTypeBLL(AppSettings.CurrentSetting.ConnStr)).Add(addingItem as RelatedCompanyType);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new RelatedCompanyTypeBLL(AppSettings.CurrentSetting.ConnStr)).Update(updatingItem as RelatedCompanyType);
        }
        #endregion

        private void lnkParentCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRelatedCompanyTypeMaster frm = new FrmRelatedCompanyTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ParentCategory = frm.SelectedItem as RelatedCompanyType;
                this.txtParentCategory.Text = ParentCategory.Name;
            }
        }
    }
}
