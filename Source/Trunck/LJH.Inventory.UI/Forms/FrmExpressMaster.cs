using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmExpressMaster :FrmMasterBase 
    {
        public FrmExpressMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override FrmDetailBase GetDetailForm()
        {
            FrmRelatedCompanyDetail frm = new FrmRelatedCompanyDetail();
            frm.CodeNum = 4;
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            RelatedCompanyBLL bll = new RelatedCompanyBLL(AppSettings.CurrentSetting.ConnectString);
            List<RelatedCompany> items = bll.GetAll().QueryObjects;
            if (items != null && items.Count > 0)
            {
                return (from item in items where item.CodeNum == 4 select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            RelatedCompany s = item as RelatedCompany;
            row.Tag = s;
            row.Cells["colName"].Value = s.Name;
            row.Cells["colLinker"].Value = s.Linker;
            row.Cells["colTelephone"].Value = s.TelPhone;
            row.Cells["colMobile"].Value = s.Mobile;
            row.Cells["colFax"].Value = s.Fax;
            row.Cells["colAddress"].Value = s.Address;
            row.Cells["colPostalCode"].Value = s.PostalCode;
            row.Cells["colQQ"].Value = s.QQ;
            row.Cells["colEmail"].Value = s.Email;
            row.Cells["colWebSite"].Value = s.Website;
            row.Cells["colMemo"].Value = s.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CustomerBLL bll = new CustomerBLL(AppSettings.CurrentSetting.ConnectString);
            CommandResult ret = bll.Delete(item as Customer);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
