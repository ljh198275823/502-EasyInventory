using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.Inventory.UI.Report;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class FrmSlice : Form
    {
        public FrmSlice()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置要加工的原材料
        /// </summary>
        public ProductInventoryItem SlicingItem { get; set; }
        /// <summary>
        /// 获取或设置要加工的类型
        /// </summary>
        public string SliceTo { get; set; }

        #endregion

        #region 私有方法
        private void ShowSlicingItem(ProductInventoryItem item)
        {
            txtCategory.Text = item.Product.Category.Name;
            txtSpecification.Text = item.Product.Specification;
            txtCurrentLength.DecimalValue = item.Length.Value;
            txtCurrentWeigth.DecimalValue = item.Weight.Value;
            txtRemainLength.DecimalValue = item.Length.Value;
            txtRemainWeight.DecimalValue = item.Weight.Value;
            txtWareHouse.Text = item.WareHouse.Name;
            txtWareHouse.Tag = item.WareHouse;
        }

        private bool CheckInput()
        {
            if (rd开平.Checked)
            {
                if (this.txtLength.DecimalValue <= 0)
                {
                    MessageBox.Show("开平长度不正确，请重新输入");
                    this.txtLength.Focus();
                    return false;
                }
                if (this.txtCount.IntergerValue <= 0)
                {
                    MessageBox.Show("开平数量不正确，请重新输入");
                    this.txtCount.Focus();
                    return false;
                }
            }
            if (rd开条.Checked)
            {
                if (string.IsNullOrEmpty(txtFormula.Text))
                {
                    MessageBox.Show("没有输入开条公式");
                    return false;
                }
                if (string.IsNullOrEmpty(txtResult.Text))
                {
                    MessageBox.Show("开条公式不是有效的数学公式，不能计算出结果");
                    return false;
                }
            }
            if (this.txtWareHouse.Tag == null)
            {
                MessageBox.Show("没有指定加工件存放的仓库");
                return false;
            }
            if (this.txtCustomer.Tag == null)
            {
                MessageBox.Show("没有指定加工的客户");
                return false;
            }
            return true;
        }

        private string GetSliceType()
        {
            if (rd开平.Checked) return rd开平.Text;
            if (rd开条.Checked) return rd开条.Text;
            if (rd开吨.Checked) return rd开吨.Text;
            return null;
        }
        #endregion

        #region 事件处理程序
        private void FrmSlice_Load(object sender, EventArgs e)
        {
            dtSliceDate.Value = DateTime.Today;
            if (SlicingItem != null)
            {
                ShowSlicingItem(SlicingItem);
            }
            rd开平.Checked = SliceTo == rd开平.Text;
            rd开条.Checked = SliceTo == rd开条.Text;
            rd开吨.Checked = SliceTo == rd开吨.Text;
            btnOk.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Slice);
        }

        private void rd开平_CheckedChanged(object sender, EventArgs e)
        {
            txtLength.Enabled = rd开平.Checked;
            txtCount.Enabled = rd开平.Checked;
        }

        private void rd开条_CheckedChanged(object sender, EventArgs e)
        {
            txtFormula.Enabled = rd开条.Checked;
            if (rd开条.Checked)
            {
                txtRemainLength.DecimalValue = 0;
                txtRemainWeight.DecimalValue = 0;
            }
        }

        private void rd开吨_CheckedChanged(object sender, EventArgs e)
        {
            if (rd开吨.Checked)
            {
                txtLength.DecimalValue = SlicingItem.Length.Value;
                txtRemainLength.DecimalValue = 0;
                txtRemainWeight.DecimalValue = 0;
            }
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            if (chkOver.Checked) return;
            if (txtLength.DecimalValue * txtCount.IntergerValue <= SlicingItem.Length)
            {
                this.txtRemainLength.DecimalValue = SlicingItem.Length.Value - txtLength.DecimalValue * txtCount.IntergerValue;
                this.txtRemainWeight.DecimalValue = (txtRemainLength.DecimalValue / SlicingItem.OriginalLength.Value) * SlicingItem.OriginalWeight.Value;
            }
            else
            {
                var ret = MessageBox.Show(string.Format("原料长度不足，不能加工长度为 {0} 米的小件 {1} 块, 是否继续开平?", txtLength.DecimalValue, txtCount.IntergerValue),
                                          "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ret == DialogResult.Yes)
                {
                    this.txtRemainLength.DecimalValue = 0;
                    this.txtRemainWeight.DecimalValue = 0;
                    btnOk.BackColor = Color.Red;
                    btnOk.ForeColor = Color.White;
                }
                else
                {
                    (sender as TextBox).Text = "0";
                    (sender as TextBox).SelectAll();
                }
            }
        }

        private void chkOver_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOver.Checked)
            {
                this.txtRemainLength.DecimalValue = 0;
                this.txtRemainWeight.DecimalValue = 0;
                btnOk.BackColor = Color.Red;
                btnOk.ForeColor = Color.White;
            }
            else
            {
                btnOk.ForeColor = Color.Black;
                btnOk.BackColor = SystemColors.Control;
                txtLength_TextChanged(txtLength, EventArgs.Empty);
            }
        }

        private void txtFormula_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFormula.Text.Trim()))
            {
                decimal ret;
                if (JSEngine.CalExpression(txtFormula.Text, out ret))
                {
                    txtResult.Text = ret.ToString();
                }
                else
                {
                    txtResult.Text = string.Empty;
                }
            }
            else
            {
                txtResult.Text = string.Empty;
            }
        }

        private void lnkWareHouse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmWareHouseMaster frm = new FrmWareHouseMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtWareHouse.Text = (frm.SelectedItem as WareHouse).Name;
                txtWareHouse.Tag = frm.SelectedItem;
            }
        }

        private void lnkCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Sale.FrmCustomerMaster frm = new Sale.FrmCustomerMaster();
            frm.ForSelect = true;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtCustomer.Text = (frm.SelectedItem as CompanyInfo).Name;
                txtCustomer.Tag = frm.SelectedItem;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                SteelRollSliceRecord record = new SteelRollSliceRecord()
                {
                    ID = Guid.NewGuid(),
                    SliceDate = dtSliceDate.Value,
                    SliceSource = SlicingItem.ID,
                    Category = SlicingItem.Product.Category.Name,
                    Specification = SlicingItem.Product.Specification,
                    SliceType = GetSliceType(),
                    BeforeLength = SlicingItem.Length.Value,
                    BeforeWeight = SlicingItem.Weight.Value,
                    AfterLength = txtRemainLength.DecimalValue,
                    AfterWeight = txtRemainWeight.DecimalValue,
                    Customer = txtCustomer.Text,
                    Slicer = txtSlicers.Text,
                    Warehouse = (txtWareHouse.Tag as WareHouse).Name,
                    Operator = Operator.Current.Name
                };
                if (rd开平.Checked)
                {
                    if (txtLength.DecimalValue > 0) record.Length = txtLength.DecimalValue;
                    record.Count = txtCount.IntergerValue;
                }
                else if (rd开吨.Checked)
                {
                    record.Length = SlicingItem.Length;
                    record.Weight = SlicingItem.Weight;
                    record.AfterLength = 0;
                    record.AfterWeight = 0;
                    record.Count = 1;
                }
                else if (rd开条.Checked)
                {
                    record.Length = SlicingItem.Length;
                    record.Weight = SlicingItem.Weight;
                    record.AfterLength = 0;
                    record.AfterWeight = 0;
                    record.Count = 1;
                    record.Memo = "开条:" + string.Format("{0}={1}", txtFormula.Text.Trim(), txtResult.Text.Trim());
                }
                CommandResult ret = (new SteelRollBLL(AppSettings.Current.ConnStr)).Slice(SlicingItem, record, txtWareHouse.Tag as WareHouse);
                if (ret.Result == ResultCode.Successful)
                {
                    MessageBox.Show("加工成功!");
                    if (SlicingItem.Status == "余料")
                    {
                        //重新计算厚度
                        new SteelRollBLL(AppSettings.Current.ConnStr).CalRealThick(SlicingItem);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.txtLength.DecimalValue = 0;
                        this.txtCount.IntergerValue = 0;
                        ShowSlicingItem(SlicingItem);
                    }
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
