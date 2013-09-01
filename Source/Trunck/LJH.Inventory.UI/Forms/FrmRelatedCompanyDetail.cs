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
    public partial class FrmRelatedCompanyDetail : FrmDetailBase
    {
        public FrmRelatedCompanyDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        public int CodeNum { get; set; }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
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
            //this.btnOk.Enabled = opt.Permit(Permission.EditRelatedCompany);
        }

        protected override void ItemShowing()
        {
            RelatedCompany c = UpdatingItem as RelatedCompany;
            if (c != null)
            {
                txtName.Text = c.Name;
                txtLinker.Text = c.Linker;
                txtTelephone.Text = c.TelPhone;
                txtAddress.Text = c.Address;
                txtMobile.Text = c.Mobile;
                txtFax.Text = c.Fax;
                txtQQ.Text = c.QQ;
                txtEmail.Text = c.Email;
                txtPostalCode.Text = c.PostalCode;
                txtWebSite.Text = c.Website;
                txtMemo.Text = c.Memo;
            }
        }

        protected override object GetItemFromInput()
        {
            RelatedCompany info;
            if (UpdatingItem == null)
            {
                info = new RelatedCompany();
                info.CodeNum = CodeNum;
            }
            else
            {
                info = UpdatingItem as RelatedCompany;
            }
            info.Name = txtName.Text;
            info.Linker = txtLinker.Text;
            info.TelPhone = txtTelephone.Text;
            info.Mobile = txtMobile.Text;
            info.Fax = txtFax.Text;
            info.Address = txtAddress.Text;
            info.PostalCode = txtPostalCode.Text;
            info.QQ = txtQQ.Text;
            info.Email = txtEmail.Text;
            info.Website = txtWebSite.Text;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            RelatedCompanyBLL bll = new RelatedCompanyBLL(AppSettings.CurrentSetting.ConnectString);
            return bll.Add(item as RelatedCompany);
        }

        protected override CommandResult UpdateItem(object item)
        {
            RelatedCompanyBLL bll = new RelatedCompanyBLL(AppSettings.CurrentSetting.ConnectString);
            return bll.Update(item as RelatedCompany);
        }
        #endregion
    }
}
