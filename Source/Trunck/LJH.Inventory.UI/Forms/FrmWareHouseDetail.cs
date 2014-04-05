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

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmWareHouseDetail : FrmDetailBase
    {
        public FrmWareHouseDetail()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置父仓库
        /// </summary>
        public WareHouse ParentWareHouse { get; set; }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("仓库编号不能为空");
                txtID.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("仓库名称不能为空");
                txtName.Focus();
                return false;
            }
            return true;
        }

        protected override void InitControls()
        {
            Operator opt = Operator.Current;
            this.btnOk.Enabled = opt.Permit(Permission.EditWareHouse);
        }

        protected override void ItemShowing()
        {
            WareHouse w = UpdatingItem as WareHouse;
            if (w != null)
            {
                txtID.Text = w.ID;
                txtName.Text = w.Name;
                txtMemo.Text = w.Memo;
            }
            txtID.Enabled = (w == null);
        }

        protected override object GetItemFromInput()
        {
            WareHouse info;
            if (UpdatingItem == null)
            {
                info = new WareHouse();
            }
            else
            {
                info = UpdatingItem as WareHouse;
            }
            info.ID = txtID.Text != "自动创建" ? txtID.Text : string.Empty;
            info.Name = txtName.Text;
            info.Memo = txtMemo.Text;
            return info;
        }

        protected override CommandResult AddItem(object item)
        {
            WareHouseBLL bll = new WareHouseBLL(AppSettings.Current.ConnStr);
            return bll.Add(item as WareHouse);
        }

        protected override CommandResult UpdateItem(object item)
        {
            WareHouseBLL bll = new WareHouseBLL(AppSettings.Current.ConnStr);
            return bll.Update(item as WareHouse);
        }
        #endregion
    }
}
