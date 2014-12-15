using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.BillProject.BLL;
using LJH.BillProject.Model;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary;

namespace LJH.BillProject
{
    public partial class FrmPaymentLogMaster : LJH.GeneralLibrary.Core.UI.FrmMasterBase
    {
        public FrmPaymentLogMaster()
        {
            InitializeComponent();
        }

        #region 公共属性
        public List<PaymentLog> PaymentLogs { get; set; }
        #endregion

        #region 重写基类方法
        protected override void Init()
        {
            base.Init();
        }

        protected override List<object> GetDataSource()
        {
            List<object> ret = null;
            if (PaymentLogs != null && PaymentLogs.Count > 0)
            {
                ret = PaymentLogs.Select(item => (object)item).ToList();
            }
            return ret;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = new PaymentLogBLL(AppSettings.Current.ConnStr).Delete(item as PaymentLog);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message, "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return ret.Result == ResultCode.Successful;
        }

        protected override GeneralLibrary.Core.UI.FrmDetailBase GetDetailForm()
        {
            return new FrmPaymentLogDetail();
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            PaymentLog log = item as PaymentLog;
            row.Tag = log;
            row.Cells["colPaymentDate"].Value = log.PaymentDate.ToString("yyyy-MM-dd");
            row.Cells["colCategory"].Value = log.Category;
            row.Cells["colAmount"].Value = log.Amount.Trim();
            row.Cells["colPaymentMode"].Value = log.PaymentMode;
            row.Cells["colUser"].Value = log.User;
            row.Cells["colMemo"].Value = log.Memo;
        }
        #endregion
    }
}
