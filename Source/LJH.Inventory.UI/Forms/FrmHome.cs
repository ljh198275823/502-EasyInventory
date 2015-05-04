using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.UI.Forms.Sale;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
        }

        public IMyMDIForm MDIForm { get; set; }

        private void btn_Click(object sender, EventArgs e)
        {
            foreach (ToolStripItem  b in toolStrip1.Items)
            {
                if (object.ReferenceEquals(sender, b))
                {
                    b.BackColor = Color.Blue;
                    b.ForeColor = Color.White;
                    if (b.Tag != null)
                    {
                        string tag = b.Tag.ToString();
                        int index = tabControl1.TabPages.IndexOfKey(tag);
                        if (index >= 0) tabControl1.SelectedIndex = index;
                    }
                }
                else
                {
                    b.BackColor = SystemColors.Control;
                    b.ForeColor = Color.Black;
                }
            }
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            tabControl1.Left -= tabControl1.ItemSize.Height + 5;
            tabControl1.Top = -5;
            tabControl1.Width = panel2.Width + 10;
            tabControl1.Height = panel2.Height + 10;
            btnGeneral.PerformClick();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            if (this.MDIForm != null) this.MDIForm.ShowSingleForm<LJH.Inventory.UI.Forms.Sale.FrmCustomerMaster>();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (this.MDIForm != null) this.MDIForm.ShowSingleForm<LJH.Inventory.UI.Forms.Sale.FrmOrderMaster>();
        }

        private void btnOrderMonitor_Click(object sender, EventArgs e)
        {
            if (this.MDIForm != null) this.MDIForm.ShowSingleForm<LJH.Inventory.UI.Forms.Sale.FrmOrderItemRecordMaster>();
        }
    }
}
