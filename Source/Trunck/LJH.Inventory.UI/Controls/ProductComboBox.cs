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
    public partial class ProductComboBox : System.Windows.Forms.ComboBox
    {
        #region 构造函数
        public ProductComboBox()
        {
            InitializeComponent();
        }

        public ProductComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        #endregion

        #region 私有变量
        private List<Product> _RenderItems;
        private List<Product> _SourceItems;
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取选择的客户,没有选择项时返回null;
        /// </summary>
        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Product SelectedProduct
        {
            get
            {
                if (this.SelectedIndex >= 0)
                {
                    return _RenderItems[this.SelectedIndex - 1];  //这里要减一，因为列表中多了一个空行
                }
                return null;
            }
        }
        #endregion

        #region 重写基类方法
        protected override void OnTextChanged(EventArgs e)
        {
            if (this.SelectedIndex <= 0)
            {
                if (_SourceItems != null && _SourceItems.Count > 0)
                {
                    int sp = this.SelectionStart;
                    if (!string.IsNullOrEmpty(this.Text))
                    {
                        _RenderItems = (from item in _SourceItems
                                        where item.Name.Contains(this.Text)
                                        orderby item.Name ascending
                                        select item).ToList();
                    }
                    else
                    {
                        _RenderItems = (from item in _SourceItems
                                        orderby item.Name ascending
                                        select item).ToList();
                    }
                    this.Items.Clear();
                    this.Items.Add(string.Empty);
                    foreach (Product  item in _RenderItems)
                    {
                        this.Items.Add(item.Name);
                        if (item.Name == this.Text)
                        {
                            this.SelectedIndex = this.Items.Count - 1;
                        }
                    }
                    this.SelectionStart = sp;
                }
            }
            base.OnTextChanged(e);
        }
        #endregion

        #region 公共方法
        public void Init()
        {
            this.Items.Clear();
            this.Items.Add(string.Empty);
            if (_SourceItems == null)
            {
                _SourceItems = (new ProductBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(null).QueryObjects;
            }
            if (_SourceItems != null && _SourceItems.Count > 0)
            {
                _RenderItems = (from item in _SourceItems
                                orderby item.Name ascending
                                select item).ToList();
                foreach (Product  item in _RenderItems)
                {
                    this.Items.Add(item.Name);
                }
            }
        }

        public void Init(string categoryID)
        {
            this.Text = string.Empty;
            this.Items.Clear();
            this.Items.Add(string.Empty);
            if (_SourceItems == null)
            {
                _SourceItems = (new ProductBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(null).QueryObjects;
            }
            if (_SourceItems != null && _SourceItems.Count > 0)
            {
                _RenderItems = (from p in _SourceItems
                                where p.CategoryID == categoryID
                                orderby p.Name ascending
                                select p).ToList();
                foreach (Product p in _RenderItems)
                {
                    this.Items.Add(p.Name);
                }
            }
        }
        #endregion 
    }
}
