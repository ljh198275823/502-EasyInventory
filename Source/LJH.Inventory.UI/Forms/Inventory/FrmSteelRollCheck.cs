using System;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSteelRollCheck : Form
    {
        public FrmSteelRollCheck()
        {
            InitializeComponent();
        }

        #region 公共属性
        public ProductInventoryItem SteelRoll { get; set; }
        #endregion

        private void FrmSteelRollCheck_Load(object sender, EventArgs e)
        {
            if (SteelRoll != null)
            {
                txtNewLength.DecimalValue = SteelRoll.Length.Value;
                txtNewWeigth.DecimalValue = SteelRoll.Weight.Value;
            }
            btnOk.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Check);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtNewWeigth.DecimalValue < 0)
            {
                MessageBox.Show("重量输入不正确，请重新输入");
                txtNewWeigth.Focus();
                return;
            }
            if (txtNewLength.DecimalValue < 0)
            {
                MessageBox.Show("长度输入不正确，请重新输入");
                txtNewLength.Focus();
                return;
            }
            CommandResult ret = new SteelRollBLL(AppSettings.Current.ConnStr).Check(SteelRoll, txtNewWeigth.DecimalValue, txtNewLength.DecimalValue, txtMemo.Text, txtChecker.Text, Operator.Current.Name);
            if (ret.Result == ResultCode.Successful)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }

        private void lnkChecker_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.General.FrmStaffMaster frm = new Forms.General.FrmStaffMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Staff item = frm.SelectedItem as Staff;
                txtChecker.Text = item != null ? item.Name : string.Empty;
            }
        }
    }
}