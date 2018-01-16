using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using LJH.Inventory .BusinessModel ;
using LJH.Inventory .BLL ;

namespace LJH.Inventory.UI.Controls
{
    public partial class ProductNameComboBox : System.Windows.Forms.ComboBox
    {
        #region 构造函数
        public ProductNameComboBox()
        {
            InitializeComponent();
        }

        public ProductNameComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            this.Items.Clear();
            this.Items.Add(string.Empty);
            var items = (new ProductBLL(AppSettings.Current.ConnStr)).GetAllNames(null);
            if (items != null && items.Count > 0)
            {
                items = (from item in items
                         orderby item ascending
                         select item).ToList();
                foreach (var item in items)
                {
                    this.Items.Add(item);
                }
            }
        }
        #endregion 
    }
}
