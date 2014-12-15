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

        private void InitPanel()
        {
            for (int i = 0; i < 6; i++)
            {
                PaymentPanel p = new PaymentPanel();
                this.flowLayoutPanel1.Controls.Add(p);
            }

            Button btnAdd = new Button();
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 40);
            btnAdd.Text = "增加消费";
            btnAdd.Click += new EventHandler(btnAdd_Click);
            this.flowLayoutPanel1.Controls.Add(btnAdd);
        }


        #endregion


        #region 事件处理程序
        private void FrmMain_Load(object sender, EventArgs e)
        {
            AppSettings.Current.ConnStr = _ConStr;
            UpGradeDataBase();
            InitPanel();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmPaymentLogDetail frm = new FrmPaymentLogDetail();
            frm.IsAdding = true;
            frm.ShowDialog();
        }
        #endregion
    }
}
