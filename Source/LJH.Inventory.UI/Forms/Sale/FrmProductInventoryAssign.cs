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

namespace LJH.Inventory.UI.Forms.Sale
{
    public partial class FrmProductInventoryAssign : Form
    {
        public FrmProductInventoryAssign()
        {
            InitializeComponent();
            this.wareHouseComboBox1.Init();
            if (this.wareHouseComboBox1.Items.Count > 1) this.wareHouseComboBox1.SelectedIndex = 1;
            this.wareHouseComboBox1.SelectedIndexChanged += wareHouseComboBox1_SelectedIndexChanged;
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置库存所属的仓库
        /// </summary>
        public string WarehouseID
        {
            get
            {
                return this.wareHouseComboBox1.SelectedWareHouseID;
            }
            set
            {
                this.wareHouseComboBox1.SelectedWareHouseID = value;
            }
        }
        /// <summary>
        /// 获取或设置哪种产品的库存
        /// </summary>
        public string ProductID
        {
            get
            {
                return txtProduct.Tag != null ? (txtProduct.Tag as Product).ID : null;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Product p = (new ProductBLL(AppSettings.Current.ConnStr)).GetByID(value).QueryObject;
                    txtProduct.Tag = p;
                    txtProduct.Text = p != null ? p.Name : string.Empty;
                }
            }
        }
        /// <summary>
        /// 获取或设置要分配的数量
        /// </summary>
        public decimal Count
        {
            get
            {
                return txtCount.DecimalValue;
            }
            set
            {
                txtCount.DecimalValue = value;
            }
        }
        /// <summary>
        /// 获取或设置最大的分配数量,一般为订单项的最大备货量
        /// </summary>
        public decimal MaxCount { get; set; }
        #endregion

        private void FrmProductInventoryAssign_Load(object sender, EventArgs e)
        {
            Fresh();
        }

        private void Fresh()
        {
            if (!string.IsNullOrEmpty(WarehouseID) && !string.IsNullOrEmpty(ProductID))
            {
                ProductInventoryItemSearchCondition con = new ProductInventoryItemSearchCondition() { ProductID = ProductID, WareHouseID = WarehouseID };
                List<SteelRollSlice> items = (new SteelRollSliceBLL(AppSettings.Current.ConnStr)).GetSteelRollSlices(con).QueryObjects;
                if (items != null && items.Count > 0)
                {
                    txtCount.DecimalValue = items[0].Valid < MaxCount ? items[0].Valid : MaxCount;
                }
            }
        }

        private void wareHouseComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtProduct.Tag == null)
            {
                MessageBox.Show("没有指定产品");
                return;
            }
            if (string.IsNullOrEmpty(WarehouseID))
            {
                MessageBox.Show("没有指定仓库");
                return;
            }
            if (Count <= 0)
            {
                MessageBox.Show("没有指定预订数量");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
