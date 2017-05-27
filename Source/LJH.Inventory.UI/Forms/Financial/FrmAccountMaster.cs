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
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;
using LJH.Inventory.UI.Forms.Financial.Report;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmAccountMaster : FrmMasterBase
    {
        public FrmAccountMaster()
        {
            InitializeComponent();
        }

        public bool? Ispublic { get; set; }

        private List<AccountRecord> _AllAccountRecords = null;

        #region 私有方法
        private decimal GetAmount(Account ac)
        {
            decimal ret = 0;
            var cps = from it in _AllAccountRecords where it.AccountID == ac.ID select it;
            foreach (var it in cps)
            {
                if (it.ClassID == CustomerPaymentType.Customer) ret += it.Amount;
                else if (it.ClassID == CustomerPaymentType.Supplier || it.ClassID == CustomerPaymentType.公司管理费用) ret -= it.Amount;
            }
            return ret;
        }
        #endregion

        #region 重写基类方法
        protected override FrmDetailBase GetDetailForm()
        {
            return new FrmAccountDetail();
        }

        public override void ShowOperatorRights()
        {
            base.ShowOperatorRights();
            btn_Add.Enabled = Operator.Current.Permit(Permission.Account, PermissionActions.Edit);
            btn_Delete.Enabled = Operator.Current.Permit(Permission.Account, PermissionActions.Edit);
            eMnu_Edit.Enabled = Operator.Current.Permit(Permission.Account, PermissionActions.Edit);
            cMnu_Add.Enabled = Operator.Current.Permit(Permission.Account, PermissionActions.Edit);
            cMnu_Delete.Enabled = Operator.Current.Permit(Permission.Account, PermissionActions.Edit);
        }

        protected override List<object> GetDataSource()
        {
            _AllAccountRecords = new AccountRecordBLL(AppSettings.Current.ConnStr).GetItems(null).QueryObjects;
            List<Account> items = null;
            if (SearchCondition == null)
            {
                items = (new AccountBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            }
            else
            {
                items = (new AccountBLL(AppSettings.Current.ConnStr)).GetItems(SearchCondition).QueryObjects;
            }
            if (items != null)
            {
                if (Ispublic.HasValue) items = items.Where(it => it.Ispublic == Ispublic.Value).ToList();
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Account ct = item as Account;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["col对公账号"].Value = ct.Ispublic;
            row.Cells["colAmount"].Value = GetAmount(ct);
            row.Cells["colOperator"].Value = ct.Operator;
            row.Cells["colAddDate"].Value = ct.AddDate;
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new AccountBLL(AppSettings.Current.ConnStr)).Delete(item as Account);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion

        #region 事件处理程序
        private void eMnu_Edit_Click(object sender, EventArgs e)
        {
            PerformUpdateData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "colAmount")
                {
                    Frm账号往来报表 frm = new Frm账号往来报表();
                    frm.Account = dataGridView1.Rows[e.RowIndex].Tag as Account;
                    frm.StartPosition = FormStartPosition.CenterParent;
                    frm.ShowDialog();
                }
            }
        }
        #endregion
    }
}
