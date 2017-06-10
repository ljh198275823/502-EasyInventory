using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Financial
{
    public partial class FrmSetFileID : Form
    {
        public FrmSetFileID()
        {
            InitializeComponent();
        }

        public List<int> ExcludeFileIDs { get; set; }

        public bool ForTaxFileID { get; set; }

        public CompanyInfo Customer { get; set; }

        private void FrmSetFileID_Load(object sender, EventArgs e)
        {
            int max = 1;
            this.comboBox1.Items.Clear();
            if (ExcludeFileIDs != null && ExcludeFileIDs.Count > 0) max = ExcludeFileIDs.Max() + 5;
            for (int i = 1; i <= max; i++)
            {
                if (ExcludeFileIDs == null || !ExcludeFileIDs.Contains(i)) this.comboBox1.Items.Add(i.ToString());
            }
            this.comboBox1.SelectedIndex = 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int fid = 0;
            if (!string.IsNullOrEmpty(comboBox1.Text) && int.TryParse(comboBox1.Text, out fid))
            {
                if (ExcludeFileIDs.Contains(fid))
                {
                    MessageBox.Show("归档号已经被其它客户占用，不能使用");
                    return;
                }
                CommandResult ret = null;
                if (!ForTaxFileID) ret = new CompanyBLL(AppSettings.Current.ConnStr).SetFileID(Customer, fid);
                else ret = new CompanyBLL(AppSettings.Current.ConnStr).SetTaxFileID(Customer, fid);
                if (ret.Result == ResultCode.Successful)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
            else
            {
                MessageBox.Show("归档号不能转化成整数");
            }
        }
    }
}
