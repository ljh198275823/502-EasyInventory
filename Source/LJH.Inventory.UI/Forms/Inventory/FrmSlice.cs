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
            txtCurrentWeigth.DecimalValue = item.Weight.Value;
            if (item.Length.HasValue) txtBeforeLength.DecimalValue = item.Length.Value;
            txtRemainWeight.DecimalValue = item.Weight.Value;
            var ws = new WareHouseBLL(AppSettings.Current.ConnStr).GetByID(item.WareHouseID).QueryObject;
            if (ws != null)
            {
                txtWareHouse.Text = ws.Name;
                txtWareHouse.Tag = ws;
            }
        }

        private bool CheckInput()
        {
            if (rd开平.Checked || rd开卷.Checked)
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
            if (string.IsNullOrEmpty(this.txtCustomer.Text))
            {
                MessageBox.Show("没有指定加工的客户");
                return false;
            }
            return true;
        }

        private string GetSliceType()
        {
            if (rd开平.Checked) return rd开平.Text;
            if (rd开卷.Checked) return rd开卷.Text;
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
            rd开卷.Checked = SliceTo == rd开卷.Text;
            rd开条.Checked = SliceTo == rd开条.Text;
            rd开吨.Checked = SliceTo == rd开吨.Text;
            if (UserSettings.Current != null) txtCustomer.Text = UserSettings.Current.DefaultCustomer;
            btnOk.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Slice);
        }

        private void rdSliceType_CheckedChanged(object sender, EventArgs e)
        {
            txtLength.Enabled = rd开平.Checked || rd开卷.Checked;
            txtCount.Enabled = rd开平.Checked || rd开卷.Checked;
            chkOver.Enabled = rd开平.Checked || rd开卷.Checked;
            if (rd开吨.Checked || rd开条.Checked) chkOver.Checked = false;

            txtFormula.Enabled = rd开条.Checked;
            if (rd开条.Checked || rd开吨.Checked)
            {
                txtRemainWeight.DecimalValue = 0;
                txtAfterLength.DecimalValue = 0;
            }
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            if (chkOver.Checked) return;
            decimal? width = SpecificationHelper.GetWrittenWidth(SlicingItem.Product.Specification);
            if (width.HasValue && width > 0 && SlicingItem.OriginalThick.HasValue && SlicingItem.OriginalThick > 0)
            {
                decimal weight = ProductInventoryItem.CalWeight(SlicingItem.OriginalThick.Value, width.Value, txtLength.DecimalValue * txtCount.IntergerValue, SlicingItem.Product.Density.Value);
                if (weight <= SlicingItem.Weight)
                {
                    this.txtRemainWeight.DecimalValue = SlicingItem.Weight.Value - weight;
                    txtAfterLength.DecimalValue = ProductInventoryItem.CalLength(SlicingItem.OriginalThick.Value, SpecificationHelper.GetWrittenWidth(SlicingItem.Product.Specification).Value, txtRemainWeight.DecimalValue, SlicingItem.Product.Density.Value);
                }
                else
                {
                    var ret = MessageBox.Show(string.Format("原料当前重量不足以加工成 长度为 {0} 米的小件 {1} 件, 是否继续?", txtLength.DecimalValue, txtCount.IntergerValue),
                                              "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (ret == DialogResult.Yes)
                    {
                        if (!chkOver.Checked) chkOver.Checked = true;
                    }
                    else
                    {
                        (sender as TextBox).Text = "0";
                        (sender as TextBox).SelectAll();
                    }
                }
            }
        }

        private void chkOver_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOver.Checked)
            {
                this.txtRemainWeight.DecimalValue = 0;
                this.txtAfterLength.DecimalValue = 0;
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
                    OriginalLength = SlicingItem.OriginalLength,
                    OriginalWeight = SlicingItem.OriginalWeight,
                    Category = SlicingItem.Product.Category.Name,
                    Specification = SlicingItem.Product.Specification,
                    SliceType = GetSliceType(),
                    BeforeWeight = SlicingItem.Weight.Value,
                    BeforeLength = ProductInventoryItem.CalLength(SlicingItem.OriginalThick.Value, SpecificationHelper.GetWrittenWidth(SlicingItem.Product.Specification).Value, SlicingItem.Weight.Value, SlicingItem.Product.Density.Value),
                    Customer = txtCustomer.Text,
                    Slicer = txtSlicers.Text,
                    Warehouse = (txtWareHouse.Tag as WareHouse).Name,
                    Operator = Operator.Current.Name,
                    Memo = txtMemo.Text,
                };
                if (rd开平.Checked || rd开卷.Checked)
                {
                    record.Length = txtLength.DecimalValue;
                    record.Count = txtCount.IntergerValue;
                    record.AfterWeight = txtRemainWeight.DecimalValue;
                    record.AfterLength = ProductInventoryItem.CalLength(SlicingItem.OriginalThick.Value, SpecificationHelper.GetWrittenWidth(SlicingItem.Product.Specification).Value, record.AfterWeight, SlicingItem.Product.Density.Value);
                }
                else if (rd开吨.Checked)
                {
                    record.Weight = SlicingItem.Weight;
                    record.AfterLength = 0;
                    record.AfterWeight = 0;
                    record.Count = 1;
                }
                else if (rd开条.Checked)
                {
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
                        new SteelRollBLL(AppSettings.Current.ConnStr).CalRealThick(SlicingItem, UserSettings.Current.RealCountWhenCalRealThick);
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
