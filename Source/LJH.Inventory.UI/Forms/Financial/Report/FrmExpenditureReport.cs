using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.GeneralLibrary;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.BLL;
using LJH.Inventory.UI.Forms;
using LJH.Inventory.UI.Forms.General;
using LJH.Inventory.UI.Forms.Sale;
using LJH.Inventory.UI.Forms.Financial.View;

namespace LJH.Inventory.UI.Forms.Financial.Report
{
    public partial class FrmExpenditureReport : FrmReportBase
    {
        public FrmExpenditureReport()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<ExpenditureType> _AllTypes = null;
        private List<Account> _AllAccounts = null;
        #endregion

        #region 重写基类方法
        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            ExpenditureRecord info = item as ExpenditureRecord;
            row.Tag = info;
            row.Cells["colID"].Value = info.ID;
            row.Cells["colSheetDate"].Value = info.SheetDate.ToString("yyyy-MM-dd");
            row.Cells["colAmount"].Value = info.Amount;
            ExpenditureType et = _AllTypes.SingleOrDefault(it => it.ID == info.Category);
            row.Cells["colCategory"].Value = et != null ? et.Name : string.Empty;
            Account ac = null;
            if (!string.IsNullOrEmpty(info.AccountID) && _AllAccounts != null) ac = _AllAccounts.SingleOrDefault(it => it.ID == info.AccountID);
            row.Cells["colAccount"].Value = ac != null ? ac.Name : null;
            row.Cells["colRequest"].Value = info.Request;
            row.Cells["colPayee"].Value = info.Payee;
            row.Cells["colState"].Value = SheetStateDescription.GetDescription(info.State);
            row.Cells["colMemo"].Value = info.Memo;
        }

        protected override List<object> GetDataSource()
        {
            _AllAccounts = new AccountBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            _AllTypes = new ExpenditureTypeBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            var con = new ExpenditureRecordSearchCondition();
            con.SheetDate = new DateTimeRange(ucDateTimeInterval1.StartDateTime, ucDateTimeInterval1.EndDateTime);
            con.States = new List<SheetState>() { SheetState.Add, SheetState.Approved };
            if (txtCategory.Tag != null) con.Category = (txtCategory.Tag as ExpenditureType).ID;
            var items = (new ExpenditureRecordBLL(AppSettings.Current.ConnStr)).GetItems(con).QueryObjects;
            return (from item in items
                    orderby item.SheetDate ascending, item.ID ascending
                    where txtRequest.Tag == null || item.Category == (txtRequest.Tag as Staff).Name
                    select (object)item).ToList();
        }

        protected override void Init()
        {
            ucDateTimeInterval1.ShowTime = false;
            ucDateTimeInterval1.Init();
            ucDateTimeInterval1.SelectThisMonth();
            base.Init();
        }
        #endregion

        #region 事件处理程序
        private void lnkCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmExpenditureTypeMaster frm = new FrmExpenditureTypeMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                ExpenditureType et = frm.SelectedItem as ExpenditureType;
                txtCategory.Text = et.Name;
                txtCategory.Tag = et;
            }
        }

        private void txtCategory_DoubleClick(object sender, EventArgs e)
        {
            txtCategory.Text = string.Empty;
            txtCategory.Tag = null;
        }

        private void lnkRequest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmStaffMaster frm = new FrmStaffMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var r = frm.SelectedItem as Staff;
                txtRequest.Text = r != null ? r.Name : string.Empty;
                txtRequest.Tag = r;
            }
        }

        private void txtRequest_DoubleClick(object sender, EventArgs e)
        {
            txtRequest.Text = string.Empty;
            txtRequest.Tag = null;
        }
        #endregion
    }
}
