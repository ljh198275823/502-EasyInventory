using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LJH.GeneralLibrary.WinformControl;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmReportBase : Form
    {
        #region 构造函数
        public FrmReportBase()
        {
            InitializeComponent();
        }
        #endregion

        #region 事件
        public event EventHandler ItemSearching;

        protected virtual void OnItemSearching(EventArgs e)
        {
            if (this.ItemSearching != null) this.ItemSearching(this, e);
        }
        #endregion

        #region 事件处理程序
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOkAs_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridView view = this.GridView;
                if (view != null)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "Excel文档|*.xls|所有文件(*.*)|*.*";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string path = saveFileDialog1.FileName;
                        if (LJH.GeneralLibrary.WinformControl.DataGridViewExporter.Export(view, path))
                        {
                            MessageBox.Show("导出成功");
                        }
                        else
                        {
                            MessageBox.Show("保存到电子表格时出现错误!");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("保存到电子表格时出现错误!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.GridView.Rows.Clear();
            OnItemSearching(EventArgs.Empty);
            this.searchInfo.Text = string.Format("共{0}项", this.GridView.Rows.Count);
        }

        private void FrmReportBase_Load(object sender, EventArgs e)
        {
            if (GridView != null)
            {
                GridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }
        #endregion

        #region 公共属性
        public DataGridView GridView
        {
            get
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is DataGridView)
                    {
                        return ctrl as DataGridView;
                    }
                }
                return null;
            }
        }
        #endregion
    }
}
