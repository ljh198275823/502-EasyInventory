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
    public partial class FrmNativePortMaster :FrmMasterBase 
    {
        public FrmNativePortMaster()
        {
            InitializeComponent();
        }

        #region 重写基类方法
        protected override FrmDetailBase GetDetailForm()
        {
            FrmPortDetail frm= new FrmPortDetail();
            frm.IsForeignPort = false;
            return frm;
        }

        protected override List<object> GetDataSource()
        {
            List<Port> items = (new PortBLL(AppSettings.Current.ConnStr)).GetNativePorts();
            if (items != null)
            {
                return (from item in items select (object)item).ToList();
            }
            return null;
        }

        protected override void ShowItemInGridViewRow(DataGridViewRow row, object item)
        {
            Port ct = item as Port;
            row.Cells["colID"].Value = ct.ID;
            row.Cells["colName"].Value = ct.Name;
            row.Cells["colCountry"].Value = ct.Country;
            row.Cells["colRegion"].Value = ct.Region;
            row.Cells["colMemo"].Value = ct.Memo;
        }

        protected override bool DeletingItem(object item)
        {
            CommandResult ret = (new PortBLL(AppSettings.Current.ConnStr)).Delete(item as Port);
            if (ret.Result != ResultCode.Successful)
            {
                MessageBox.Show(ret.Message);
            }
            return ret.Result == ResultCode.Successful;
        }
        #endregion
    }
}
