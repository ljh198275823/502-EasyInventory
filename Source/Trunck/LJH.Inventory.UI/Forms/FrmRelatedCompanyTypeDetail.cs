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

        #region 重写基类方法
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
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            RelatedCompanyType ct = UpdatingItem as RelatedCompanyType;
            if (IsAdding)
            {
                ct = new RelatedCompanyType();
            }
            ct.ID = txtName.Text;
            ct.Name = txtName.Text;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new RelatedCompanyTypeBLL(AppSettings.CurrentSetting.ConnectString)).Add(addingItem as RelatedCompanyType);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new RelatedCompanyTypeBLL(AppSettings.CurrentSetting.ConnectString)).Update(updatingItem as RelatedCompanyType);
        }
        #endregion
    }
}
