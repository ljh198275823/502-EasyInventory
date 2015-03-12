using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows .Forms ;

namespace LJH.Inventory.UI.Controls
{
    public partial class NullableDateTimePicker : System.Windows.Forms.DateTimePicker
    {
        #region 构造函数
        public NullableDateTimePicker()
        {
            InitializeComponent();
        }

        public NullableDateTimePicker(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }
        #endregion

        #region 私有变量
        private DateTimePickerFormat _myFormat;
        private string _myCustomerFormat;
        #endregion

        #region 重写基类方法
        protected override void OnValueChanged(EventArgs eventargs)
        {
            if (_myFormat != 0)
            {
                this.Format = _myFormat;
                this.CustomFormat = _myCustomerFormat;
            }
            base.OnValueChanged(eventargs);
        }

        protected override void OnClick(EventArgs e)
        {
            if (this.IsNull)
            {
                this.Value = DateTime.Today;
            }
            base.OnClick(e);
        }
        #endregion

        /// <summary>
        /// 获取或设置日期是否为空
        /// </summary>
        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsNull
        {
            get
            {
                return string.IsNullOrEmpty(this.Text.Trim());
            }
            set
            {
                if (value)
                {
                    _myFormat = this.Format;
                    _myCustomerFormat = this.CustomFormat;
                    this.Format = DateTimePickerFormat.Custom;
                    this.CustomFormat = " ";
                }
            }
        }
    }
}
