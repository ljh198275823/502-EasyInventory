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
            txtCurrentLength.DecimalValue = item.Length;
            txtCurrentWeigth.DecimalValue = item.Weight;
            txtRemainLength.DecimalValue = item.Length;
            txtRemainWeight.DecimalValue = item.Weight;
            txtWareHouse.Text = item.WareHouse.Name;
            txtWareHouse.Tag = item.WareHouse;
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
            rdToPanel.Checked = (string.IsNullOrEmpty(SliceTo) || SliceTo == "开平");
            rdToRoll.Checked = SliceTo == "开卷";
            rdToWeight.Checked = SliceTo == "开吨";
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            if (!rdToWeight.Checked)
            {
                if (txtLength.DecimalValue * txtCount.IntergerValue <= SlicingItem.Length)
                {
                    this.txtRemainLength.DecimalValue = SlicingItem.Length - txtLength.DecimalValue * txtCount.IntergerValue;
                    this.txtRemainWeight.DecimalValue = (txtRemainLength.DecimalValue / SlicingItem.OriginalLength) * SlicingItem.OriginalWeight;
                }
                else
                {
                    MessageBox.Show(string.Format("原料长度不足，不能加工长度为 {0} 米的小件 {1} 块", txtLength.DecimalValue, txtCount.IntergerValue));
                    (sender as TextBox).Text = "0";
                    (sender as TextBox).SelectAll();
                }
            }
            else
            {
                if (txtWeight.DecimalValue * txtCount.IntergerValue <= SlicingItem.Weight)
                {
                    this.txtRemainWeight.DecimalValue = SlicingItem.Weight - txtWeight.DecimalValue * txtCount.IntergerValue;
                    this.txtRemainLength.DecimalValue = (txtRemainWeight.DecimalValue / SlicingItem.OriginalWeight) * SlicingItem.OriginalLength;
                }
                else
                {
                    MessageBox.Show(string.Format("原料重量不足，不能加工重量为 {0} 吨的小件 {1} 块", txtWeight.DecimalValue, txtCount.IntergerValue));
                    (sender as TextBox).Text = "0";
                    (sender as TextBox).SelectAll();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    SliceType = SliceTo,
                    BeforeLength = SlicingItem.Length,
                    BeforeWeight = SlicingItem.Weight,
                    Weight = txtWeight.DecimalValue,
                    Length = txtLength.DecimalValue,
                    Count = txtCount.IntergerValue,
                    AfterLength = txtRemainLength.DecimalValue,
                    AfterWeight = txtRemainWeight.DecimalValue,
                    Customer = string.Empty,
                    Slicer = txtSlicers.Text,
                    Warehouse =(txtWareHouse .Tag as WareHouse ).Name ,
                    Operator = Operator.Current.Name
                };
                if (txtWeight.Enabled) record.Weight = txtWeight.DecimalValue;

                CommandResult ret = (new ProductInventoryItemBLL(AppSettings.Current.ConnStr)).SteelRollSlice(SlicingItem, record, txtWareHouse.Tag as WareHouse);
                if (ret.Result == ResultCode.Successful)
                {
                    ShowSlicingItem(SlicingItem);
                    this.txtLength.DecimalValue = 0;
                    this.txtCount.IntergerValue = 0;
                    this.txtWeight.DecimalValue = 0;
                }
                else
                {
                    MessageBox.Show(ret.Message);
                }
            }
        }

        private bool CheckInput()
        {
            if (!rdToWeight.Checked && this.txtLength.DecimalValue <= 0)
            {
                MessageBox.Show("加工长度不正确，请重新输入");
                this.txtLength.Focus();
                return false;
            }
            if (rdToWeight.Checked && this.txtWeight.DecimalValue <= 0)
            {
                MessageBox.Show("加工重量不正确，请重新输入");
                txtWeight.Focus();
                return false;
            }
            if (this.txtCount.IntergerValue <= 0)
            {
                MessageBox.Show("加工数量不正确，请重新输入");
                this.txtCount.Focus();
                return false;
            }
            if (this.txtWareHouse.Tag == null)
            {
                MessageBox.Show("没有指定加工件存放的仓库");
                return false;
            }
            return true;
        }

        private void rdSliceType_CheckedChanged(object sender, EventArgs e)
        {
            SliceTo = (sender as RadioButton).Text;
            txtWeight.Enabled = rdToWeight.Checked;
        }
        #endregion

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

        private void txtWareHouse_DoubleClick(object sender, EventArgs e)
        {
            txtWareHouse.Text = string.Empty;
            txtWareHouse.Tag = null;
        }
    }
}
