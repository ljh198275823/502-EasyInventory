﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.Inventory .BusinessModel .SearchCondition ;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmMasterBase : Form
    {
        public FrmMasterBase()
        {
            InitializeComponent();
        }

        #region 私有变量
        private DataGridView _gridView;

        private DataGridView GridView
        {
            get
            {
                if (_gridView == null)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is DataGridView)
                        {
                            _gridView = ctrl as DataGridView;
                        }
                    }
                }
                return _gridView;
            }
        }

        private Panel _PnlLeft;

        private Panel PnlLeft
        {
            get
            {
                if (_PnlLeft == null)
                {
                    foreach (Control ctrl in this.Controls)
                    {
                        if (ctrl is Panel && ctrl.Name == "pnlLeft")
                        {
                            _PnlLeft = ctrl as Panel;
                            break;
                        }
                    }
                }
                return _PnlLeft;
            }
        }
        #endregion

        #region 私有方法
        private void InitToolbar()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is ToolStrip && ctrl.Name == "menu")  //初始化子窗体的菜单，如果有的话
                {
                    MenuStrip menu = ctrl as MenuStrip;
                    if (menu.Items["btn_Add"] != null) menu.Items["btn_Add"].Click += btnAdd_Click;
                    if (menu.Items["btn_Delete"] != null) menu.Items["btn_Delete"].Click += btnDelete_Click;
                    if (menu.Items["btn_Export"] != null) menu.Items["btn_Export"].Click += btnExport_Click;
                    if (menu.Items["btn_Fresh"] != null) menu.Items["btn_Fresh"].Click += btnFresh_Click;
                    if (menu.Items["btn_SelectColumns"] != null) menu.Items["btn_SelectColumns"].Click += btnSelectColumns_Click;
                    if (menu.Items["txtKeyword"] != null && menu.Items["txtKeyword"] is ToolStripTextBox)
                    {
                        (menu.Items["txtKeyword"] as ToolStripTextBox).TextChanged += txtKeyword_TextChanged;
                    }
                    break;
                }
            }
        }

        private void InitGridView()
        {
            if (GridView != null)
            {
                GridView.BorderStyle = BorderStyle.FixedSingle;
                GridView.BackgroundColor = Color.White;
                if (ForSelect)
                {
                    GridView.CellDoubleClick += GridView_DoubleClick1;
                }
                else
                {
                    GridView.CellDoubleClick += GridView_DoubleClick;
                }
                GridView.CellMouseDown += GridView_CellMouseDown;
                GridView.Sorted += new EventHandler(GridView_Sorted);

                if (GridView.ContextMenuStrip != null)
                {
                    ContextMenuStrip menu = GridView.ContextMenuStrip;
                    if (menu.Items["cMnu_Add"] != null) menu.Items["cMnu_Add"].Click += btnAdd_Click;
                    if (menu.Items["cMnu_Delete"] != null) menu.Items["cMnu_Delete"].Click += btnDelete_Click;
                    if (menu.Items["cMnu_Export"] != null) menu.Items["cMnu_Export"].Click += btnExport_Click;
                    if (menu.Items["cMnu_Fresh"] != null) menu.Items["cMnu_Fresh"].Click += btnFresh_Click;
                    if (menu.Items["cMnu_SelectColumns"] != null) menu.Items["cMnu_SelectColumns"].Click += btnSelectColumns_Click;
                }
            }
        }

        private void InitGridViewColumns()
        {
            DataGridView grid = this.GridView;
            if (grid == null) return;
            string temp = AppSettings.Current.GetConfigContent(string.Format("{0}_Columns", this.GetType().Name));
            if (string.IsNullOrEmpty(temp)) return;
            string[] cols = temp.Split(',');

            for (int i = 0; i < cols.Length; i++)
            {
                string[] col_Temp = cols[i].Split(':');
                if (col_Temp.Length >= 1 && grid.Columns.Contains(col_Temp[0]))
                {
                    grid.Columns[col_Temp[0]].DisplayIndex = i;
                    if (col_Temp.Length >= 2 && col_Temp[1].Trim() == "0")
                    {
                        grid.Columns[col_Temp[0]].Visible = false;
                    }
                    else
                    {
                        grid.Columns[col_Temp[0]].Visible = true;
                    }
                }
            }
        }

        private DataGridViewRow Add_A_Row(object item, bool forNewItem)
        {
            int row = GridView.Rows.Add();
            ShowItemInGridViewRow(GridView.Rows[row], item);
            GridView.Rows[row].Tag = item;
            if (forNewItem)
            {
                if (this.GridView.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow r in GridView.SelectedRows)
                    {
                        r.Selected = false;
                    }
                }
                GridView.Rows[row].Selected = true;
                if (row > GridView.DisplayedColumnCount(false))
                {
                    GridView.FirstDisplayedScrollingRowIndex = row - GridView.DisplayedColumnCount(false) + 1;
                }
            }
            this.toolStripStatusLabel1.Text = string.Format("总共 {0} 项", GridView.Rows.Count);
            return GridView.Rows[row];
        }

        private string[] GetAllVisiableColumns()
        {
            if (GridView != null)
            {
                List<string> cols = new List<string>();
                foreach (DataGridViewColumn col in GridView.Columns)
                {
                    if (col.Visible) cols.Add(col.Name);
                }
                return cols.ToArray();
            }
            return null;
        }

        private Button GetActiveButtonOnLeftPanel()
        {
            Button b = null;
            if (PnlLeft != null)
            {
                foreach (Control ctrl in PnlLeft.Controls)
                {
                    if (ctrl is Button)
                    {
                        if (b == null) b = ctrl as Button; //先将第一个按钮设置成活动按钮
                        if ((ctrl as Button).BackColor == SystemColors.ControlDark)
                        {
                            b = ctrl as Button;
                            break;
                        }
                    }
                }
            }
            return b;
        }

        private void btnLeftPanelButton_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                foreach (Control ctrl in PnlLeft.Controls)
                {
                    if (ctrl is Button)
                    {
                        (ctrl as Button).BackColor = SystemColors.Control;
                    }
                }
                Button b = sender as Button;
                b.BackColor = SystemColors.ControlDark;
                ShowItemsOnGrid(b.Tag as List<object>);
            }
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置窗体是否是用来做选择用的,(此属性需要在窗体显示之前指定)
        /// </summary>
        public bool ForSelect { get; set; }
        /// <summary>
        /// 获取或设置窗体在选择模式下的选择项
        /// </summary>
        public object SelectedItem { get; set; }
        /// <summary>
        /// 获取或设置查询条件
        /// </summary>
        public SearchCondition SearchCondition { get; set; }
        #endregion

        #region 保护方法
        /// <summary>
        /// 显示数据
        /// </summary>
        /// <param name="items">要显示的数据</param>
        /// <param name="reload">是否重新加载数据，如果为真，则表示先会清空之前的数据，否则保留旧有数据</param>
        protected virtual void ShowItemsOnGrid(List<object> items)
        {
            GridView.Rows.Clear();
            if (items != null && items.Count > 0)
            {
                foreach (object item in items)
                {
                    DataGridViewRow row = Add_A_Row(item, false);
                }
            }
            if (this.GridView.Rows.Count > 0)
            {
                ShowRowBackColor();
                this.GridView.Rows[0].Selected = false;
                this.toolStripStatusLabel1.Text = string.Format("总共 {0} 项", GridView.Rows.Count);
            }
        }
        /// <summary>
        /// 显示数据行的颜色
        /// </summary>
        protected virtual void ShowRowBackColor()
        {
            int count = 0;
            foreach (DataGridViewRow row in this.GridView.Rows)
            {
                if (row.Visible)
                {
                    count++;
                    row.DefaultCellStyle.BackColor = (count % 2 == 1) ? Color.FromArgb(230, 230, 230) : Color.White;
                }
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        protected virtual void FreshData()
        {
            List<object> datasource = GetDataSource();
            Button b = GetActiveButtonOnLeftPanel();
            if (b != null)
            {
                b.PerformClick();
            }
            else
            {
                ShowItemsOnGrid(datasource);
            }
        }
        /// <summary>
        /// 导出数据
        /// </summary>
        protected virtual void ExportData()
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
        /// <summary>
        /// 选择数据网格中要显示的列
        /// </summary>
        protected virtual void SelectColumns()
        {
            FrmColumnSelection frm = new FrmColumnSelection();
            frm.Selectee = this.GridView;
            frm.SelectedColumns = GetAllVisiableColumns();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                string[] cols = frm.SelectedColumns;
                if (cols != null && cols.Length > 0)
                {
                    string temp = string.Join(",", cols);
                    AppSettings.Current.SaveConfig(string.Format("{0}_Columns", this.GetType().Name), temp);
                    InitGridViewColumns();
                }
            }
        }
        /// <summary>
        /// 根据关键词过滤数据
        /// </summary>
        /// <param name="keyword"></param>
        protected virtual void Filter(string keyword)
        {
            int count = 0;
            DataGridView grid = this.GridView;
            foreach (DataGridViewRow row in grid.Rows)
            {
                bool visible = false;
                string[] temp = !string.IsNullOrEmpty(keyword) ? keyword.Split(';') : null;
                if (temp != null) temp = temp.Where(str => !string.IsNullOrEmpty(str.Trim())).ToArray(); //将数组中的空字符剔除
                if (temp == null || temp.Length == 0)
                {
                    visible = true;
                    count++;
                    break;
                }
                else
                {
                    foreach (string kw in temp)
                    {
                        foreach (DataGridViewColumn col in grid.Columns)
                        {
                            if (col.Visible && row.Cells[col.Index].Value != null && row.Cells[col.Index].Value.ToString().Contains(kw))
                            {
                                visible = true;
                                count++;
                                break;
                            }
                        }
                        if (visible) break; //如果为真，则跳出循环，不用再判断其它关键字,直接进入下一行
                    }
                }
                row.Visible = visible;
            }
            ShowRowBackColor();
            this.toolStripStatusLabel1.Text = string.Format("总共 {0} 项", count);
        }
        /// <summary>
        /// 进行删除数据操作
        /// </summary>
        protected virtual void PerformDeleteData()
        {
            try
            {
                if (this.GridView.SelectedRows.Count > 0)
                {
                    List<DataGridViewRow> deletingRows = new List<DataGridViewRow>();

                    DialogResult result = MessageBox.Show("确实要删除所选项吗?", "确定", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        for (int i = GridView.Rows.Count - 1; i > -1; i--)
                        {
                            DataGridViewRow row = GridView.Rows[i];
                            if (row.Selected)
                            {
                                object deletingItem = row.Tag;
                                if (DeletingItem(deletingItem))
                                {
                                    deletingRows.Add(row);
                                }
                            }
                        }
                        foreach (DataGridViewRow row in deletingRows)
                        {
                            GridView.Rows.Remove(row);
                        }
                        this.toolStripStatusLabel1.Text = string.Format("总共 {0} 项", GridView.Rows.Count);
                    }
                }
                else
                {
                    MessageBox.Show("没有选择项!", "Warning");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        /// <summary>
        /// 进行增加数据操作
        /// </summary>
        protected virtual void PerformAddData()
        {
            try
            {
                FrmDetailBase detailForm = GetDetailForm();
                if (detailForm != null)
                {
                    detailForm.IsAdding = true;
                    DataGridViewRow row = null;
                    detailForm.ItemAdded += delegate(object obj, ItemAddedEventArgs args)
                    {
                        row = Add_A_Row(args.AddedItem, true);
                    };
                    detailForm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
                    {
                        ShowItemInGridViewRow(row, args.UpdatedItem);
                    };
                    detailForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        /// <summary>
        /// 进行修改数据操作
        /// </summary>
        private void PerformUpdateData()
        {
            if (this.GridView != null && this.GridView.SelectedRows != null && this.GridView.SelectedRows.Count > 0)
            {
                object pre = this.GridView.SelectedRows[0].Tag;
                if (pre != null)
                {
                    FrmDetailBase detailForm = GetDetailForm();
                    if (detailForm != null)
                    {
                        detailForm.IsAdding = false;
                        detailForm.UpdatingItem = pre;

                        detailForm.ItemUpdated += delegate(object obj, ItemUpdatedEventArgs args)
                        {
                            ShowItemInGridViewRow(this.GridView.SelectedRows[0], args.UpdatedItem);
                        };
                        detailForm.ShowDialog();
                    }
                }
            }
        }
        /// <summary>
        /// 移动至上一行
        /// </summary>
        /// <param name="e"></param>
        protected void GotoPreviousRow(out RowChangeEventArgs e)
        {
            e = new RowChangeEventArgs();
            if (GridView.SelectedRows != null && GridView.SelectedRows.Count > 0)
            {
                int index = GridView.SelectedRows[0].Index;
                if (index > 0)
                {
                    GridView.Rows[index].Selected = false;
                    GridView.Rows[index - 1].Selected = true;
                }
                e.IsFirstRow = index - 1 == 0;
                e.IsLastRow = GridView.Rows.Count == 1;
                e.UpdatingItem = GridView.SelectedRows[0].Tag;
            }
        }
        /// <summary>
        /// 移动到下一行
        /// </summary>
        /// <param name="e"></param>
        protected void GotoNextRow(out RowChangeEventArgs e)
        {
            e = new RowChangeEventArgs();
            if (GridView.SelectedRows != null && GridView.SelectedRows.Count > 0)
            {
                int index = GridView.SelectedRows[0].Index;
                if (index < GridView.Rows.Count - 1)
                {
                    GridView.Rows[index].Selected = false;
                    GridView.Rows[index + 1].Selected = true;
                }
                e.IsFirstRow = GridView.Rows.Count == 1;
                e.IsLastRow = (GridView.Rows.Count - 1 == index + 1);
                e.UpdatingItem = GridView.SelectedRows[0].Tag;
            }
        }
        /// <summary>
        /// 移动到最后一行
        /// </summary>
        /// <param name="e"></param>
        protected void GotoLastRow(out RowChangeEventArgs e)
        {
            e = new RowChangeEventArgs();
            if (GridView.SelectedRows != null && GridView.SelectedRows.Count > 0)
            {
                int index = GridView.SelectedRows[0].Index;
                GridView.Rows[index].Selected = false;
                GridView.Rows[GridView.Rows.Count - 1].Selected = true;

                e.IsFirstRow = GridView.Rows.Count == 1;
                e.IsLastRow = true;
                e.UpdatingItem = GridView.SelectedRows[0].Tag;
            }
        }
        /// <summary>
        /// 移动到第一行
        /// </summary>
        /// <param name="e"></param>
        protected void GotoFirstRow(out RowChangeEventArgs e)
        {
            e = new RowChangeEventArgs();
            if (GridView.SelectedRows != null && GridView.SelectedRows.Count > 0)
            {
                int index = GridView.SelectedRows[0].Index;
                GridView.Rows[index].Selected = false;
                GridView.Rows[0].Selected = true;
                e.IsFirstRow = true;
                e.IsLastRow = GridView.Rows.Count == 1;
                e.UpdatingItem = GridView.SelectedRows[0].Tag;
            }
        }
        #endregion

        #region 子类要重写的方法
        /// <summary>
        /// 初始化
        /// </summary>
        protected virtual void Init()
        {
            InitToolbar();
            InitGridView();
            InitGridViewColumns();
        }
        /// <summary>
        /// 获取明细窗体
        /// </summary>
        /// <returns></returns>
        protected virtual FrmDetailBase GetDetailForm()
        {
            return null;
        }
        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        protected virtual List<object> GetDataSource()
        {
            return null;
        }
        /// <summary>
        /// 在网格行中显示单个数据
        /// </summary>
        /// <param name="row"></param>
        /// <param name="item"></param>
        protected virtual void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {

        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual bool DeletingItem(object item)
        {
            return false;
        }
        #endregion

        #region 事件处理
        private void FrmMasterBase_Load(object sender, EventArgs e)
        {
            Init();
            if (PnlLeft != null)
            {
                foreach (Control ctrl in PnlLeft.Controls)
                {
                    if (ctrl is Button)
                    {
                        (ctrl as Button).Click += btnLeftPanelButton_Click;
                    }
                }
            }
            if (GridView != null)
            {
                btnFresh_Click(null, null);
            }
        }

        private void GridView_Sorted(object sender, EventArgs e)
        {
            ShowRowBackColor();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PerformAddData();
        }

        private  void btnDelete_Click(object sender, EventArgs e)
        {
            PerformDeleteData();
        }

        private void btnFresh_Click(object sender, EventArgs e)
        {
            FreshData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportData();
        }

        private void btnSelectColumns_Click(object sender, EventArgs e)
        {
            SelectColumns();
        }

        private void GridView_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            PerformUpdateData();
        }

        private void GridView_DoubleClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.SelectedItem = this.GridView.Rows[e.RowIndex].Tag;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void GridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex > -1)
                {
                    if (!GridView.Rows[e.RowIndex].Selected)
                    {
                        foreach (DataGridViewRow row in GridView.Rows)
                        {
                            row.Selected = false;
                        }
                        GridView.Rows[e.RowIndex].Selected = true;
                    }
                }
            }
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            if (GridView == null) return;
            string keyword = string.Empty;
            if (sender is ToolStripTextBox)
            {
                keyword = (sender as ToolStripTextBox).Text;
            }
            Filter(keyword);
        }
        #endregion
    }
}
