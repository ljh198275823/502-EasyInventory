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
    public partial class CategoryComboBox : ComboBox
    {
        #region 构造函数
        public CategoryComboBox()
        {
            InitializeComponent();
        }

        public CategoryComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region 公共方法及属性
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            ProductCategoryBLL bll = new ProductCategoryBLL(AppSettings.CurrentSetting.ConnectString);
            List<ProductCategory> items = bll.GetAll().QueryObjects;
            this.Items.Clear();
            if (items.Count > 0)
            {
                items = (from item in items
                         orderby item.Name descending
                         select item).ToList();
                items.Insert(0, new ProductCategory());
                this.DataSource = items;
            }
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        /// <summary>
        /// 获取或设置选中的商品类别ID
        /// </summary>
        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedCategoryID
        {
            get
            {
                if (this.SelectedIndex > 0)
                {
                    return (this.Items[SelectedIndex] as ProductCategory).ID;
                }
                return string.Empty;
            }
            set
            {
                this.SelectedIndex = -1;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if ((this.Items[i] as ProductCategory).ID == value)
                    {
                        this.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 获取选中的商品类别
        /// </summary>
        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ProductCategory SelectedCategory
        {
            get
            {
                if (this.SelectedIndex > 0)
                {
                    return this.Items[SelectedIndex] as ProductCategory;
                }
                return null;
            }
        }
        #endregion

    }
}
