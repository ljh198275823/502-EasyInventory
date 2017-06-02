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

        private List<AccountRecord> _AllAccountRecords = null;

        #region 私有方法
        private decimal GetAmount(Account ac)
        {
            decimal ret = 0;
            var cps = from it in _AllAccountRecords where it.AccountID == ac.ID select it;
            foreach (var it in cps)
            {
                if (it.ClassID == CustomerPaymentType.客户收款 || it.ClassID == CustomerPaymentType.其它收款 || it.ClassID == CustomerPaymentType.转账入 || it.ClassID == CustomerPaymentType.供应商退款) ret += it.Amount;
                else if (it.ClassID == CustomerPaymentType.供应商付款 || it.ClassID == CustomerPaymentType.公司管理费用 || it.ClassID == CustomerPaymentType.转账出 || it.ClassID == CustomerPaymentType.客户退款) ret -= it.Amount;
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
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Account ct = item as Account;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["colClass"].Value = ct.Class.ToString();
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

        private void mnu_增加其它收款_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var ac = dataGridView1.SelectedRows[0].Tag as Account;
                if (ac.Class != AccountType.银行账号 && ac.Class != AccountType.现金账号)
                {
                    MessageBox.Show("此账号不能增加收款");
                    return;
                }
                Frm其它收款 frm = new Frm其它收款();
                frm.Account = ac;
                frm.IsAdding = true;
                frm.ShowDialog();
                dataGridView1.SelectedRows[0].Cells["colAmount"].Value = new AccountBLL(AppSettings.Current.ConnStr).GetRemain(ac.ID);
            }
        }
    }
}
