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
        #endregion

        #region 事件处理程序
        private void FrmSlice_Load(object sender, EventArgs e)
        {
            dtSliceDate.Value = DateTime.Today;
            if (SlicingItem != null) ShowSlicingItem(SlicingItem);
            if (UserSettings.Current != null) txtCustomer.Text = UserSettings.Current.DefaultCustomer;
            btnOk.Enabled = Operator.Current.Permit(Permission.SteelRoll, PermissionActions.Slice);
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            if (chkOver.Checked) return;
            decimal? width = SpecificationHelper.GetWrittenWidth(SlicingItem.Product.Specification);
            if (width.HasValue && width > 0 && SlicingItem.Original克重.HasValue && SlicingItem.Original克重 > 0)
            {
                decimal weight = ProductInventoryItem.CalWeight(SlicingItem.Original克重.Value, width.Value, txtLength.DecimalValue * txtCount.IntergerValue);
                decimal len = SlicingItem.Length.HasValue ? SlicingItem.Length.Value : ProductInventoryItem.CalLength(SlicingItem.Original克重.Value, width.Value, SlicingItem.Weight.Value);
                if (weight <= SlicingItem.Weight)
                {
                    this.txtRemainWeight.DecimalValue = SlicingItem.Weight.Value - weight;
                    txtAfterLength.DecimalValue = len - txtLength.DecimalValue * txtCount.IntergerValue;
                }
                else
                {
                    var ret = MessageBox.Show(string.Format("原料当前重量不足以加工成 长度为 {0} 米的小件 {1} 件, 是否继续?", txtLength.DecimalValue, txtCount.IntergerValue), "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                    SourceRollWeight = SlicingItem.OriginalWeight,
                    Category = SlicingItem.Product.Category.Name,
                    Specification = SlicingItem.Product.Specification,
                    SliceType = ProductModel.开平,
                    BeforeWeight = SlicingItem.Weight.Value,
                    BeforeLength =SlicingItem .Length .HasValue ?SlicingItem .Length.Value  : ProductInventoryItem.CalLength(SlicingItem.Original克重.Value, SpecificationHelper.GetWrittenWidth(SlicingItem.Product.Specification).Value, SlicingItem.Weight.Value),
                    Customer = txtCustomer.Text,
                    Slicer = txtSlicers.Text,
                    Warehouse = (txtWareHouse.Tag as WareHouse).Name,
                    Operator = Operator.Current.Name,
                    Memo = txtMemo.Text,
                };
                record.Length = txtLength.DecimalValue;
                record.Count = txtCount.IntergerValue;
                record.AfterWeight = txtRemainWeight.DecimalValue;
                record.AfterLength = record.BeforeLength - record.Length.Value * record.Count;
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
