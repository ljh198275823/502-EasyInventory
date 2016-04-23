using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.SQLHelper;

namespace InventoryApplication
{
    public partial class FrmLoginDog : Form
    {
        public FrmLoginDog()
        {
            InitializeComponent();
        }

        #region 私有变量
        private readonly  string DBNAME = "inventory";
        private SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
        #endregion

        #region 公共属性
        public LJH.GeneralLibrary.SoftDog.SoftDogInfo SoftDog { get; set; }
        #endregion

        #region 私有方法
        private bool CheckConnect()
        {
            sb.DataSource = this.txtServer.Text;
            sb.InitialCatalog = (SoftDog != null && !string.IsNullOrEmpty(SoftDog.DBName)) ? SoftDog.DBName : DBNAME;
            sb.IntegratedSecurity = false;
            sb.UserID = SoftDog != null ? SoftDog.DBUser : string.Empty;
            sb.Password = SoftDog != null ? SoftDog.DBPassword : string.Empty;
            sb.PersistSecurityInfo = true;
            sb.ConnectTimeout = 5;
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    con.ConnectionString = sb.ConnectionString;
                    con.Open();
                    con.Close();
                    AppSettings.Current.ConnStr = sb.ConnectionString;
                    return true;
                }
            }
            catch (Exception ex)
            {
                LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                return false;
            }
        }

        private bool UpGradeDataBase()
        {
            bool ret = false;
            string path = System.IO.Path.Combine(Application.StartupPath, "DbUpdate.sql");
            if (System.IO.File.Exists(path))
            {
                try
                {
                    SqlClient client = new SqlClient(AppSettings.Current.ConnStr);
                    client.Connect();
                    client.ExecuteSQLFile(path);
                    ret = true;
                }
                catch (Exception ex)
                {
                    LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                }
            }
            return ret;
        }

        private List<string> GetHistoryOperators()
        {
            List<string> items = null;
            string file = Path.Combine(Application.StartupPath, "HistoryOperators.txt");
            if (File.Exists(file))
            {
                try
                {
                    using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            items = new List<string>();
                            while (!reader.EndOfStream)
                            {
                                items.Add(reader.ReadLine());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                }
            }
            return items;
        }

        private void SaveHistoryOperators()
        {
            List<string> items = new List<string>();
            if (txtLogName.AutoCompleteCustomSource != null && txtLogName.AutoCompleteCustomSource.Count > 0)
            {
                string[] history = new string[txtLogName.AutoCompleteCustomSource.Count];
                txtLogName.AutoCompleteCustomSource.CopyTo(history, 0);
                items.AddRange(history);

            }
            if (!items.Contains(txtLogName.Text)) items.Add(txtLogName.Text);
            try
            {
                string file = Path.Combine(Application.StartupPath, "HistoryOperators.txt");
                using (FileStream stream = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                    {
                        foreach (string item in items)
                        {
                            writer.WriteLine(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
            }
        }
        #endregion

        #region 事件处理程序
        private void Login_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(AppSettings.Current.ConnStr))
            {
                try
                {
                    sb = new SqlConnectionStringBuilder(AppSettings.Current.ConnStr);
                    txtServer.Text = sb.DataSource;
                    txtDBName.Text = (SoftDog != null && !string.IsNullOrEmpty(SoftDog.DBName)) ? SoftDog.DBName : DBNAME;
                }
                catch
                {
                }
            }

            this.chkRememberLogid.Checked = AppSettings.Current.RememberLogID;
            if (AppSettings.Current.RememberLogID)
            {
                List<string> history = GetHistoryOperators();
                if (history != null && history.Count > 0)
                {
                    this.txtLogName.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                    foreach (string item in history)
                    {
                        this.txtLogName.AutoCompleteCustomSource.Add(item);
                        this.txtLogName.Items.Add(item);
                    }
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string logName = this.txtLogName.Text.Trim();
            string pwd = this.txtPassword.Text.Trim();

            if (logName.Length == 0)
            {
                MessageBox.Show("用户名不能为空!");
                return;
            }
            if (pwd.Length == 0)
            {
                MessageBox.Show("密码不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(txtServer.Text))
            {
                MessageBox.Show("数据库服务器不能为空");
                return;
            }
            if (!CheckConnect()) //检查连接
            {
                MessageBox.Show("数据库连接失败");
                return;
            }

            UpGradeDataBase(); //升级数据库
            if (DoLogin(logName, pwd) == false)
            {
                MessageBox.Show("用户名或者密码输入不正确!");
            }
        }

        private bool DoLogin(string logName, string pwd)
        {
            OperatorBLL authen = new OperatorBLL(AppSettings.Current.ConnStr);
            if (authen.Authentication(logName, pwd))
            {
                this.DialogResult = DialogResult.OK;
                if (AppSettings.Current.RememberLogID) SaveHistoryOperators();
                this.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkRememberLogid_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.Current.RememberLogID = chkRememberLogid.Checked;
        }
        #endregion
    }
}
