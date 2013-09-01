using System;
using System.ComponentModel;
using System.Windows.Forms;
using LJH.GeneralLibrary;

namespace LJH.Inventory.UI.Controls
{
    /// <summary>
    /// 表示半角输入框，所有输入的字符串都会转换成半角字符串
    /// </summary>
    public partial class TooStripDBCTextBox : ToolStripTextBox 
    {
        public TooStripDBCTextBox()
        {
            InitializeComponent();
        }

        public TooStripDBCTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region 重写基类方法
        protected override void OnTextChanged(EventArgs e)
        {
            int p = this.SelectionStart;
            this.Text = StringHelper.ToDBC(this.Text);
            this.SelectionStart = p;
            base.OnTextChanged(e);
        }
        #endregion
    }
}
