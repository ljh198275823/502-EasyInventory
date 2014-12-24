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
using LJH.GeneralLibrary.Core.UI;

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

        #region 私有方法
        private decimal GetAmount()
        {
            decimal ret = 0;
            foreach (DataGridViewRow row in dataGridview1.Rows)
            {
                if (row.Visible)
                {
                    PaymentLog log = row.Tag as PaymentLog;
                    ret += log.Deleted != null && log.Deleted.Value ? 0 : log.Amount;
                }
            }
            return ret.Trim();
        }

        private int VisiableCount()
        {
            int ret = 0;
            foreach (DataGridViewRow row in dataGridview1.Rows)
            {
                if (row.Visible) ret++;
            }
            return ret;
        }
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

        protected override void FreshStatusBar()
        {
            System.Windows.Forms.Control[] ctrls = this.Controls.Find("statusStrip1", true);
            if (ctrls != null && ctrls.Length == 1)
            {
                StatusStrip ctrl = ctrls[0] as StatusStrip;
                var items = ctrl.Items.Find("toolStripStatusLabel1", false);
                if (items != null && items.Length == 1)
                {
                    ToolStripStatusLabel lbl = items[0] as ToolStripStatusLabel;
                    if (lbl != null) lbl.Text = string.Format("总共 {0} 项  总额 {1} 元", VisiableCount(), GetAmount());
                }
            }
        }

        protected override void PerformDeleteData()
        {
            foreach (DataGridViewRow row in dataGridview1.SelectedRows)
            {
                PaymentLog log = row.Tag as PaymentLog;
                CommandResult ret = new PaymentLogBLL(AppSettings.Current.ConnStr).Delete(log);
                if (ret.Result != ResultCode.Successful)
                {
                    MessageBox.Show(ret.Message, "出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ShowItemInGridViewRow(row, log);
                }
            }
            FreshStatusBar();
        }

        protected override void PerformAddData()
        {
            FrmPaymentLogDetail frm = new FrmPaymentLogDetail();
            frm.IsAdding = true;
            frm.ItemAdded += delegate(object sender, ItemAddedEventArgs e)
            {
                PaymentLog log = e.AddedItem as PaymentLog;
                PaymentLogs.Add(log);
                int row = dataGridview1.Rows.Add();
                ShowItemInGridViewRow(dataGridview1.Rows[row], log);
                dataGridview1.FirstDisplayedScrollingRowIndex = row <= 5 ? 0 : row - 5;
                foreach (DataGridViewRow dr in dataGridview1.Rows)
                {
                    dr.Selected = dr.Index == row;
                }
                FreshStatusBar();
            };
            frm.ShowDialog();
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
            if (log.Deleted != null && log.Deleted.Value)
            {
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.DefaultCellStyle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            }
        }
        #endregion
    }
}