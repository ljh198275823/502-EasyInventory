﻿using System;
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
    public partial class FrmLogin : Form
    {
        private bool _Adance = false;
        private SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();

        public FrmLogin()
        {
            InitializeComponent();
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

            if (DoLogin(logName, pwd)==false)
            {
                MessageBox.Show("用户名或者密码输入不正确!");
            }
        }

        private bool DoLogin(string logName, string pwd)
        {
            SaveConnectString();

            if (UpGradeDataBase())
            {//升级数据库
                AppSettings.Current.DatabaseNeedUpgrade = false;
            }

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

        private void Login_Load(object sender, EventArgs e)
        {
            this.gpDB.Visible = false;
            this.Height = 150;
            if (!string.IsNullOrEmpty(AppSettings.Current.ConnStr))
            {
                try
                {
                    sb = new SqlConnectionStringBuilder(AppSettings.Current.ConnStr);
                    txtServer.Text = sb.DataSource;
                    txtDataBase.Text = sb.InitialCatalog;
                    if (sb.IntegratedSecurity)
                    {
                        this.rdSystem.Checked = true;
                    }
                    else
                    {
                        this.rdUser.Checked = true;
                        this.txtUserID.Text = sb.UserID;
                        this.txtPasswd.Text = sb.Password;
                    }
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

        private void rdSystem_CheckedChanged(object sender, EventArgs e)
        {
            this.txtUserID.Enabled = !rdSystem.Checked;
            this.txtPasswd.Enabled = !rdSystem.Checked;
        }

        private void rdUser_CheckedChanged(object sender, EventArgs e)
        {
            this.txtUserID.Enabled = rdUser.Checked;
            this.txtPasswd.Enabled = rdUser.Checked;
        }

        private void btnAdvance_Click(object sender, EventArgs e)
        {
            _Adance = !_Adance;
            if (_Adance)
            {
                this.gpDB.Visible = _Adance;
                this.Height = 250;
            }
            else
            {
                this.gpDB.Visible = false;
                this.Height = 150;
            }
        }

        private void SaveConnectString()
        {
            sb.DataSource = this.txtServer.Text;
            sb.InitialCatalog = this.txtDataBase.Text;
            sb.IntegratedSecurity = rdSystem.Checked;
            sb.UserID = this.txtUserID.Text;
            sb.Password = this.txtPasswd.Text;

            sb.PersistSecurityInfo = true;
            AppSettings.Current.ConnStr  = sb.ConnectionString;
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

        private void chkRememberLogid_CheckedChanged(object sender, EventArgs e)
        {
            AppSettings.Current.RememberLogID = chkRememberLogid.Checked;
        }
    }
}
