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
    public partial class CustomerCombobox : ComboBox
    {
        public CustomerCombobox()
        {
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDown;
        }

        public CustomerCombobox(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            this.DropDownStyle = ComboBoxStyle.DropDown;
        }

        #region 私有变量
        private List<CompanyInfo> _RenderItems;
        private List<CompanyInfo> _SourceItems;
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取选择的客户,没有选择项时返回null;
        /// </summary>
        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CompanyInfo SelectedCustomer
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
                    foreach (CompanyInfo item in _RenderItems)
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
                _SourceItems = (new CompanyBLL(AppSettings.Current.ConnStr)).GetAllCustomers().QueryObjects;
            }
            if (_SourceItems != null && _SourceItems.Count > 0)
            {
                _RenderItems = (from item in _SourceItems
                                orderby item.Name ascending
                                select item).ToList();
                foreach (CompanyInfo item in _RenderItems)
                {
                    this.Items.Add(item.Name);
                }
            }
        }
        #endregion
    }
}
