using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.GeneralLibrary;

namespace LJH.BillProject.Control
{
    public partial class PaymentPanel : UserControl
    {
        public PaymentPanel()
        {
            InitializeComponent();
        }

        #region 私有变量
        private string _Title = string.Empty;
        private decimal _Amount = 0;
        #endregion

        #region 公共属性
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
                lblTitle.Text = value;
            }
        }

        public Decimal Amount
        {
            get
            {
                return _Amount;
            }
            set
            {
                _Amount = value.Trim();
                lblAmount.Text = value.Trim().ToString() + " 元";
            }
        }

        public event EventHandler ContentDoubleClick;
        #endregion

        #region 事件处理程序
        private void lblAmount_DoubleClick(object sender, EventArgs e)
        {
            if (this.ContentDoubleClick != null) this.ContentDoubleClick(this, e);
        }

        private void PaymentPanel_DoubleClick(object sender, EventArgs e)
        {
            if (this.ContentDoubleClick != null) this.ContentDoubleClick(this, e);
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            if (this.ContentDoubleClick != null) this.ContentDoubleClick(this, e);
        }
        #endregion
    }
}
