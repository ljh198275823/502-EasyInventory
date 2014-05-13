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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.General
{
    public partial class FrmContactMaster : FrmMasterBase
    {
        public FrmContactMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override List<object> GetDataSource()
        {
            List<Contact> items = null;
            if (SearchCondition == null)
            {
                items = (new ContactBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                items = (new ContactBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            if (items != null)
            {
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Contact c = item as Contact;
            row.Tag = c;
            row.Cells["colName"].Value = c.Name;
            row.Cells["colPosition"].Value = c.Position;
            row.Cells["colMobile"].Value = c.Mobile;
            row.Cells["colTelphone"].Value = c.TelPhone;
            row.Cells["colEmail"].Value = c.Email;
            row.Cells["colQQ"].Value = c.QQ;
            row.Cells["colMemo"].Value = c.Memo;
        }
        #endregion
    }
}
