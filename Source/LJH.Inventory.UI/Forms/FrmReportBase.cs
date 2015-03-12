using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LJH.GeneralLibrary.WinformControl;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmReportBase : LJH.GeneralLibrary.Core.UI.FrmMasterBase
    {
        #region 构造函数
        public FrmReportBase()
        {
            InitializeComponent();
        }
        #endregion

        #region 私有变量
        private bool _IsSearching = false;
        #endregion

        #region 重写基类方法
        protected override void ReFreshData()
        {
            if (!_IsSearching) return;
            base.ReFreshData();
        }
        #endregion

        #region 事件处理程序
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            ExportData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _IsSearching = true;
            ReFreshData();
        }

        private void btnColumn_Click(object sender, EventArgs e)
        {
            SelectColumns();
        }
        #endregion
    }
}
