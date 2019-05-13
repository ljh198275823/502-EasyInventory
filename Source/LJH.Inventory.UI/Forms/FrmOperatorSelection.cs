using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmOperatorSelection : Form
    {
        public FrmOperatorSelection()
        {
            InitializeComponent();
        }

        public string SelectedOperators { get; set; }

        public bool SingleSelect { get; set; }

        #region 私有方法
        private void InitPnlOperator(Panel pnl)
        {
            pnl.Controls.Clear();
            var _Items = (new OperatorBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            if (_Items != null)
            {
                foreach (var p in _Items)
                {
                    if (p.Permit(Permission.Account, PermissionActions.Read) || p.Permit(Permission.Account, PermissionActions.Edit))
                    {
                        CheckBox chk = GetControl(pnl, p.ID);
                        if (chk == null)
                        {
                            chk = new CheckBox();
                            pnl.Controls.Add(chk);
                        }
                        chk.Name = pnl.Name + "_Name_" + p.ID.ToString();
                        chk.AutoSize = false;
                        chk.MinimumSize = new Size(120, chk.Height);
                        chk.Text = p.Name;
                        chk.Tag = p;
                        chk.CheckedChanged += new EventHandler(chk_CheckedChanged);
                    }
                }
            }
        }

        private void ShowSelectedItems(string items)
        {
            if (!string.IsNullOrEmpty(items))
            {
                var pis = items.Split(',');
                foreach (Control c in pnlPhysicalItem1.Controls)
                {
                    if (c.Tag != null && c.Tag is Operator && c is CheckBox)
                    {
                        var tag = c.Tag as Operator;
                        (c as CheckBox).Checked = pis.Contains(tag.ID.ToString());
                    }
                }
            }
        }

        private CheckBox GetControl(Panel pnl, string pid)
        {
            foreach (Control c in pnl.Controls)
            {
                if (c.Tag != null && c.Tag is Operator && c is CheckBox)
                {
                    var tag = c.Tag as Operator;
                    if (tag.ID == pid) return c as CheckBox;
                }
            }
            return null;
        }
        #endregion

        #region 事件处理程序
        private void FrmPhysicalItemSelection_Load(object sender, EventArgs e)
        {
            InitPnlOperator(this.pnlPhysicalItem1);
            ShowSelectedItems(SelectedOperators);
        }

        private void chk_CheckedChanged(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            chk.BackColor = chk.Checked ? Color.Red : Color.White;
            chk.ForeColor = chk.Checked ? Color.White : Color.Black;
            if (chk.Checked && SingleSelect)
            {
                foreach (Control c in this.pnlPhysicalItem1.Controls)
                {
                    if (object.ReferenceEquals(chk, c) == false && c is CheckBox)
                    {
                        (c as CheckBox).Checked = false;
                    }
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SelectedOperators = string.Empty;
            foreach (Control ctrl in pnlPhysicalItem1.Controls)
            {
                CheckBox chk = ctrl as CheckBox;
                if (chk != null && chk.Checked)
                {
                    var p = chk.Tag as Operator;
                    SelectedOperators += p.ID.ToString() + ",";
                }
            }
            if (!string.IsNullOrEmpty(SelectedOperators)) SelectedOperators = SelectedOperators.TrimEnd(',');
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
