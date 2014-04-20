using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.UI.Controls
{
    public partial class WareHouseComboBox : ComboBox
    {
        #region 构造函数
        public WareHouseComboBox()
        {
            InitializeComponent();
        }

        public WareHouseComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region 公共方法与属性
        public void Init()
        {
            this.Items.Clear();
            List<WareHouse> items = (new WareHouseBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            items = (from c in items
                     orderby c.Name ascending
                     select c).ToList();
            items.Insert(0, new WareHouse());
            this.DataSource = items;
            this.DisplayMember = "Name";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            if (this.Items.Count == 2) this.SelectedIndex = 1;
        }
        /// <summary>
        /// 获取或设置选择的客户ID
        /// </summary>
        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedWareHouseID
        {
            get
            {
                if (this.SelectedIndex > 0)
                {
                    return (this.Items[SelectedIndex] as WareHouse).ID;
                }
                return string.Empty;
            }
            set
            {
                this.SelectedIndex = -1;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if ((this.Items[i] as WareHouse).ID == value)
                    {
                        this.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 获取选中的仓库
        /// </summary>
        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WareHouse SelectedWareHouse
        {
            get
            {
                if (this.SelectedIndex > 0)
                {
                    return this.Items[SelectedIndex] as WareHouse;
                }
                return null;
            }
        }
        #endregion
    }
}
