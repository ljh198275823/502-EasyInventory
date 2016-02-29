using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.WinformControl;

namespace LJH.Inventory.UI.Forms.Sale
{
    public partial class FrmCustomerImport : Form
    {
        public FrmCustomerImport()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void ClearData()
        {
            this.dataGridView1.Rows.Clear();
            lblSource.Text = "条数据";
        }

        private bool FillColumn(DataGridViewColumn col, DataTable source, string sourceColName = null)
        {
            if (string.IsNullOrEmpty(sourceColName)) sourceColName = col.HeaderText.Trim('*').Trim();
            foreach (DataColumn dc in source.Columns)
            {
                if (dc.ColumnName == sourceColName)
                {
                    for (int i = 0; i < source.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows.Count < i + 1)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells["colRowIndex"].Value = i + 1; // 从1开始
                        }
                        object value = source.Rows[i][dc];
                        dataGridView1.Rows[i].Cells[col.Name].Value = value;
                    }
                    return true;
                }
            }
            return false;
        }

        private CompanyInfo GetDataFromRow(DataGridViewRow row)
        {
            string name = null;
            if (row.Cells["colName"].Value != null) name = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colName"].Value.ToString().Trim());
            if (string.IsNullOrEmpty(name))
            {
                row.Cells["colReason"].Value = "没有指定名称";
                return null;
            }
            CompanyInfo ret = new CompanyInfo();
            ret.Name = name;
            ret.ClassID = CompanyClass.Customer;
            ret.CreditLine = 50000;
            ret.CategoryID = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colCategory"].Value.ToString().Trim());
            ret.City = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colCity"].Value.ToString().Trim());
            ret.TelPhone = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colPhone"].Value.ToString().Trim());
            ret.Fax = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colFax"].Value.ToString().Trim());
            ret.PostalCode = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colPostCode"].Value.ToString().Trim());
            ret.Email = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colEmail"].Value.ToString().Trim());
            ret.Website = LJH.GeneralLibrary.StringHelper.ToDBC(row.Cells["colWeb"].Value.ToString().Trim());
            ret.Address = row.Cells["colAddress"].Value.ToString().Trim();
            return ret;
        }
        #endregion

        #region 事件处理程序
        private void FrmStudentImport_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dig = new OpenFileDialog();
                dig.Filter = "Excel文档|*.xls;*.xlsx|所有文件(*.*)|*.*";
                if (dig.ShowDialog() == DialogResult.OK)
                {
                    ClearData();
                    string path = dig.FileName;
                    txtPath.Text = path;
                    DataTable _SourceTable = NPOIExcelHelper.Import(path);
                    if (_SourceTable != null)
                    {
                        foreach (DataGridViewColumn col in dataGridView1.Columns)
                        {
                            if (!col.ReadOnly) FillColumn(col, _SourceTable); //可编辑的列才需要填充数据
                        }
                    }
                    lblSource.Text = string.Format("{0}条数据", _SourceTable != null ? _SourceTable.Rows.Count : 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            List<CompanyInfo> cs=new CompanyBLL (AppSettings .Current .ConnStr ).GetAllCustomers ().QueryObjects ;
            if(cs==null )cs=new List<CompanyInfo> ();

            int total = dataGridView1.Rows.Count - txtFirstRow.IntergerValue + 1;
            if (total == 0) return;
            int firstRow = txtFirstRow.IntergerValue;
            int count = 0;
            int success = 0;

            FrmProcessing frm = new FrmProcessing();
            Action action = delegate()
            {
                try
                {
                    CompanyBLL bll = new CompanyBLL(AppSettings.Current.ConnStr);
                    for (int i = firstRow - 1; i < dataGridView1.Rows.Count; i++)
                    {
                        try
                        {
                            if (dataGridView1.Rows[i].Visible)
                            {
                                count++;
                                var info = GetDataFromRow(dataGridView1.Rows[i]);
                                if (info != null)
                                {
                                    if (!cs.Exists(it => it.Name == info.Name))
                                    {
                                        CommandResult ret = bll.Add(info);
                                        if (ret.Result == ResultCode.Successful)
                                        {
                                            success++;
                                            cs.Add(info);
                                            this.Invoke((Action)(() => dataGridView1.Rows[i].Visible = false));
                                        }
                                        else
                                        {
                                            dataGridView1.Rows[i].Cells["colReason"].Value = ret.Message;
                                        }
                                    }
                                    else
                                    {
                                        dataGridView1.Rows[i].Cells["colReason"].Value = "客户已经存在";
                                    }
                                }
                                frm.ShowProgress(string.Format("导入{0}条数据 成功{1}条 失败{2}条", count, success, count - success), (decimal)(count) / total);
                            }
                        }
                        catch (Exception ex)
                        {
                            LJH.GeneralLibrary.ExceptionHandling.ExceptionPolicy.HandleException(ex);
                        }
                    }
                    frm.ShowProgress(string.Empty, 1);
                }
                catch (ThreadAbortException)
                {
                }
            };

            Thread t = new Thread(new ThreadStart(action));
            t.IsBackground = true;
            t.Start();
            if (frm.ShowDialog() != DialogResult.OK)
            {
                t.Abort();
            }
            MessageBox.Show(string.Format("共成功导入{0}条数据", success), "结果");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string modal = System.IO.Path.Combine(Application.StartupPath, "数据导入模板", "客户导入模板.xls");
                if (File.Exists(modal))
                {
                    SaveFileDialog dig = new SaveFileDialog();
                    dig.Filter = "Excel文档|*.xls;*.xlsx|所有文件(*.*)|*.*";
                    dig.FileName = "客户导入.xls";
                    if (dig.ShowDialog() == DialogResult.OK && dig.FileName != modal)
                    {
                        File.Copy(modal, dig.FileName);
                        MessageBox.Show("模板保存成功");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
