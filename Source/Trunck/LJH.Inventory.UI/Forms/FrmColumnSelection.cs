using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmColumnSelection : Form
    {
        public FrmColumnSelection()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置被选择列的网格控件
        /// </summary>
        public DataGridView Selectee { get; set; }
        /// <summary>
        /// 获取或设置选取的所有列
        /// </summary>
        public string[] SelectedColumns { get; set; }
        #endregion

        private void FrmColumnSelection_Load(object sender, EventArgs e)
        {
            this.listView1.Items.Clear();
            if (Selectee != null)
            {
                foreach (DataGridViewColumn col in Selectee.Columns)
                {
                    ListViewItem item = new ListViewItem(col.HeaderText);
                    item.Tag = col.Name;
                    listView1.Items.Add(item);
                    if (SelectedColumns != null && SelectedColumns.Contains(col.Name))
                    {
                        item.Checked = true;
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<string > cols=new List<string> ();
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                {
                    cols.Add(item.Tag as string);
                }
            }
            if (cols.Count > 0)
            {
                this.SelectedColumns = cols.ToArray();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("没有选择任何列,请至少选择一列");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
