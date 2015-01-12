using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using LJH.BillProject.Model;
using LJH.BillProject.BLL;
using LJH.BillProject.Control;

namespace LJH.BillProject.BillProject
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 私有变量
        private string _ConStr = string.Format("SQLITE:Data Source={0}", Path.Combine(Application.StartupPath, "BillProject.db"));
        private List<PaymentPanel> _months = new List<PaymentPanel>();
        private DateTime _LogFrom = DateTime.Now;
        private int _Showmode = 0;
        #endregion

        #region 私有方法
        private void UpGradeDataBase()
        {
            bool ret = false;
            string path = System.IO.Path.Combine(Application.StartupPath, "DbUpdate_Sqlite.sql");
            if (File.Exists(path))
            {
                List<string> commands = (new LJH.GeneralLibrary.SQLHelper.SQLStringExtractor()).ExtractFromFile(path);
                if (commands != null && commands.Count > 0)
                {
                    string connStr = string.Format("Data Source={0}", Path.Combine(Application.StartupPath, "BillProject.db"));
                    using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection(connStr))
                    {
                        using (System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand(con))
                        {
                            con.Open();
                            foreach (string command in commands)
                            {
                                try
                                {
                                    cmd.CommandText = command;
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    //LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ShowThisMonth()
        {
            DateTime dt = DateTime.Now;
            _LogFrom = new DateTime(dt.Year, dt.Month, 1);
            _Showmode = 1;
            InitPanel(_LogFrom, _Showmode);
        }


        private void ShowThisYear()
        {
            DateTime dt = DateTime.Now;
            _LogFrom = new DateTime(dt.Year, 1, 1);
            _Showmode = 0;
            InitPanel(_LogFrom, _Showmode);
        }

        private void InitPanel(DateTime logFrom, int mode)
        {
            foreach (PaymentPanel p in _months)
            {
                this.flowLayoutPanel1.Controls.Remove(p);
            }
            _months.Clear();
            PaymentLogSearchCondition con = new PaymentLogSearchCondition() { LogFrom = logFrom };
            List<PaymentLog> items = new PaymentLogBLL(AppSettings.Current.ConnStr).GetItems(con).QueryObjects;
            if (items != null && items.Count > 0)
            {
                IEnumerable<IGrouping<string, PaymentLog>> groups = null;
                if (mode == 0) //按月
                {
                    groups = from item in items
                             orderby item.PaymentDate descending
                             group item by item.PaymentDate.ToString("yyyy年MM月");
                }
                else if (mode == 1) //按天
                {
                    groups = from item in items
                             orderby item.PaymentDate descending
                             group item by item.PaymentDate.ToString("yyyy年MM月dd日");
                }
                else  //按年
                {
                    groups = from item in items
                             orderby item.PaymentDate descending
                             group item by item.PaymentDate.ToString("yyyy年");
                }
                foreach (var group in groups)
                {
                    PaymentPanel p = new PaymentPanel();
                    p.Title = group.Key;
                    p.Amount = group.Sum(it => it.Deleted != null && it.Deleted.Value ? 0 : it.Amount);
                    p.Tag = group.ToList();
                    p.ContentDoubleClick += new EventHandler(p_DoubleClick);
                    _months.Add(p);
                    this.flowLayoutPanel1.Controls.Add(p);
                }
            }
            lblAmount.Text = string.Format("共消费 {0} 元", items != null && items.Count > 0 ? items.Sum(it => it.Deleted != null && it.Deleted.Value ? 0 : it.Amount) : 0);
        }
        #endregion

        #region 事件处理程序
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text += string.Format(" [{0}]", Application.ProductVersion);
            AppSettings.Current.ConnStr = _ConStr;
            UpGradeDataBase();
            ShowThisMonth();
        }

        private void btnAddLog_Click(object sender, EventArgs e)
        {
            FrmPaymentLogDetail frm = new FrmPaymentLogDetail();
            frm.IsAdding = true;
            frm.ShowDialog();
            InitPanel(_LogFrom, _Showmode);
        }

        private void btnThisMonth_Click(object sender, EventArgs e)
        {
            ShowThisMonth();
        }

        private void btnShowThisYear_Click(object sender, EventArgs e)
        {
            ShowThisYear();
        }

        private void p_DoubleClick(object sender, EventArgs e)
        {
            PaymentPanel p = sender as PaymentPanel;
            FrmPaymentLogMaster frm = new FrmPaymentLogMaster();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.PaymentLogs = (sender as PaymentPanel).Tag as List<PaymentLog>;
            frm.Text = string.Format("{0}", p.Title);
            frm.ShowDialog();
            InitPanel(_LogFrom, _Showmode);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        private void btn_Report_Click(object sender, EventArgs e)
        {
            FrmPaymentLogReport frm = new FrmPaymentLogReport();
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        private void btnShowLastYear_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            _LogFrom = new DateTime(dt.Year, dt.Month, 1).AddMonths(-11);
            _Showmode = 0;
            InitPanel(_LogFrom, _Showmode);
        }
    }
}
