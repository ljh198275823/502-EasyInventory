using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LJH.BillProject.Model;
using LJH.BillProject.BLL;

namespace BillProject_WPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region 私有变量
        private string _ConStr = string.Format("SQLITE:Data Source={0}", System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "BillProject.db"));
        private DateTime _LogFrom = DateTime.Now;
        private List<UIElement> _months = new List<UIElement>();
        private int _Showmode = 0;
        #endregion

        #region 私有方法
        private void UpGradeDataBase()
        {
            string path = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "DbUpdate_Sqlite.sql");
            if (File.Exists(path))
            {
                List<string> commands = (new LJH.GeneralLibrary.SQLHelper.SQLStringExtractor()).ExtractFromFile(path);
                if (commands != null && commands.Count > 0)
                {
                    string connStr = string.Format("Data Source={0}", System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "BillProject.db"));
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
            foreach (UIElement ui in _months)
            {
                itemPanel.Children.Remove(ui);
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
                    BillProject_WPF.Control.BillPanel p = new Control.BillPanel();
                    p.Title = group.Key;
                    p.Margin = new Thickness(5,5,0,0);
                    p.Amount = group.Sum(it => it.Deleted != null && it.Deleted.Value ? 0 : it.Amount);
                    p.Tag = group.ToList();
                    p.MouseDoubleClick += new MouseButtonEventHandler(p_MouseDoubleClick);
                    _months.Add(p);
                    this.itemPanel.Children.Add(p);
                }
            }
        }
        #endregion

        #region 事件处理程序
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title += string.Format(" [{0}]", System.Windows.Forms.Application.ProductVersion);
            AppSettings.Current.ConnStr = _ConStr;
            UpGradeDataBase();
            ShowThisMonth();
        }

        private void btn_Jizhang_Click(object sender, RoutedEventArgs e)
        {
            LJH.BillProject.FrmPaymentLogDetail frm = new LJH.BillProject.FrmPaymentLogDetail();
            frm.IsAdding = true;
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frm.ShowDialog();
            InitPanel(_LogFrom, _Showmode);
        }

        private void btn_ThisYear_Click(object sender, RoutedEventArgs e)
        {
            ShowThisYear();
        }

        private void btn_ThisMonth_Click(object sender, RoutedEventArgs e)
        {
            ShowThisMonth();
        }

        private void btn_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void p_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BillProject_WPF.Control.BillPanel p = sender as BillProject_WPF.Control.BillPanel;
            LJH.BillProject.FrmPaymentLogMaster frm = new LJH.BillProject.FrmPaymentLogMaster();
            frm.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            frm.PaymentLogs = p.Tag as List<PaymentLog>;
            frm.Text = string.Format("{0}", p.Title);
            frm.ShowDialog();
            InitPanel(_LogFrom, _Showmode);
        }
        #endregion
    }
}
