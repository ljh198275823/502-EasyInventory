using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LJH.GeneralLibrary;

namespace BillProject_WPF.Control
{
    /// <summary>
    /// BillPanel.xaml 的交互逻辑
    /// </summary>
    public partial class BillPanel : UserControl
    {
        public BillPanel()
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
        #endregion
    }
}
