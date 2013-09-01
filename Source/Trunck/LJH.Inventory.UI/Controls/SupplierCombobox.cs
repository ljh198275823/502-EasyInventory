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
    public partial class SupplierCombobox : ComboBox
    {
        #region 构造函数
        public SupplierCombobox()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDown;
        }

        public SupplierCombobox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDown;
        }
        #endregion

        #region 私有变量
        private List<Supplier > _RenderItems;
        private List<Supplier > _SourceItems;
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取选择的供应商,没有选择项时返回null;
        /// </summary>
        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Supplier SelectedCustomer
        {
            get
            {
                if (this.SelectedIndex > 0)
                {
                    return _RenderItems[this.SelectedIndex - 1];
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
                    foreach (Supplier item in _RenderItems)
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
                _SourceItems = (new SupplierBLL(AppSettings.CurrentSetting.ConnectString)).GetItems(null).QueryObjects;
            }
            if (_SourceItems != null && _SourceItems.Count > 0)
            {
                _RenderItems = (from item in _SourceItems
                                orderby item.Name ascending
                                select item).ToList();
                foreach (Supplier item in _RenderItems)
                {
                    this.Items.Add(item.Name);
                }
            }
        }
        #endregion

        
    }
}
