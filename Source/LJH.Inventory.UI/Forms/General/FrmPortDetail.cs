using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.Inventory.UI.Forms.General
{
    public partial class FrmPortDetail :FrmDetailBase
    {
        public FrmPortDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置增加的港口是否是国外港口                                                                      c                                                                            c                                                                                                             
        /// </summary>
        public bool IsForeignPort { get; set; }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("ID不能为空");
                txtID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("名称不能为空");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtCountry.Text))
            {
                MessageBox.Show("国别不能为空");
                txtCountry.Focus();
                return false;
            }
            return true;
        }

        protected override void ItemShowing()
        {
            Port ct = UpdatingItem as Port;
            txtID.Text = ct.ID;
            txtID.Enabled = false;
            txtName.Text = ct.Name;
            txtCountry.Text = ct.Country;
            txtRegion.Text = ct.Region;
            txtMemo.Text = ct.Memo;
        }

        protected override Object GetItemFromInput()
        {
            Port ct = UpdatingItem as Port;
            if (IsAdding)
            {
                ct = new Port();
                ct.IsForeign = this.IsForeignPort;
            }
            ct.ID = txtID.Text;
            ct.Name = txtName.Text;
            ct.Country = txtCountry.Text;
            ct.Region = txtRegion.Text;
            ct.Memo = txtMemo.Text;
            return ct;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            return (new PortBLL(AppSettings.Current.ConnStr)).Add(addingItem as Port);
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            return (new PortBLL(AppSettings.Current.ConnStr)).Update(updatingItem as Port);
        }

        protected override void  InitControls()
        {
            if (!IsForeignPort) txtCountry.Text = "中国";
            base.InitControls();
        }
        #endregion
    }
}
