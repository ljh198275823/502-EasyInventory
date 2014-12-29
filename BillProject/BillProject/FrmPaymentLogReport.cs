using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.BillProject.Model;
using LJH.BillProject.BLL;
using LJH.GeneralLibrary;

namespace LJH.BillProject
{
    public partial class FrmPaymentLogReport : Form
    {
        public FrmPaymentLogReport()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void InittxtCategorys()
        {
            txtCategory.Items.Clear();
            txtCategory.Items.Add(string.Empty);
            string categorys = AppSettings.Current.Categorys;
            if (!string.IsNullOrEmpty(categorys))
            {
                string[] temp = categorys.Split(',');
                this.txtCategory.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                foreach (string item in temp)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        this.txtCategory.AutoCompleteCustomSource.Add(item);
                        this.txtCategory.Items.Add(item);
                    }
                }
            }
        }

        private void InittxtUsers()
        {
            txtUser.Items.Clear();
            txtUser.Items.Add(string.Empty);
            string Users = AppSettings.Current.Users;
            if (!string.IsNullOrEmpty(Users))
            {
                string[] temp = Users.Split(',');
                this.txtUser.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                foreach (string item in temp)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        this.txtUser.AutoCompleteCustomSource.Add(item);
                        this.txtUser.Items.Add(item);
                    }
                }
            }
        }

        private void InittxtPaymentModes()
        {
            txtPaymentMode.Items.Clear();
            txtPaymentMode.Items.Add(string.Empty);
            string PaymentModes = AppSettings.Current.PaymentModes;
            if (!string.IsNullOrEmpty(PaymentModes))
            {
                string[] temp = PaymentModes.Split(',');
                this.txtPaymentMode.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                foreach (string item in temp)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        this.txtPaymentMode.AutoCompleteCustomSource.Add(item);
                        this.txtPaymentMode.Items.Add(item);
                    }
                }
            }
        }

        private void FreshStatusBar()
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

        private void ShowItemInGridViewRow(DataGridViewRow row, PaymentLog log)
        {
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

        #region 事件处理程序
        private void FrmPaymentLogReport_Load(object sender, EventArgs e)
        {
            InittxtCategorys();
            InittxtPaymentModes();
            InittxtUsers();
            ucDateTimeInterval1.SelectThisMonth();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridview1.Rows.Clear();
            PaymentLogSearchCondition con = new PaymentLogSearchCondition();
            con.LogFrom = ucDateTimeInterval1.StartDateTime;
            con.LogEnd = ucDateTimeInterval1.EndDateTime;
            con.Category = txtCategory.Text;
            con.User = txtUser.Text;
            con.PaymentMode = txtPaymentMode.Text;
            List<PaymentLog> ret = new PaymentLogBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
            if (ret != null && ret.Count > 0)
            {
                foreach (PaymentLog log in ret)
                {
                    int row = dataGridview1.Rows.Add();
                    ShowItemInGridViewRow(dataGridview1.Rows[row], log);
                }
            }
            FreshStatusBar();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel文档|*.xls;*.xlsx|所有文件(*.*)|*.*";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFileDialog1.FileName;
                    LJH.GeneralLibrary.WinformControl.DataGridViewExporter.Export(dataGridview1, path, false);
                    MessageBox.Show("导出成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存到电子表格时出现错误!");
            }
        }
        #endregion
    }
}
