using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LJH.BillProject.Model;
using LJH.BillProject.BLL;
using LJH.GeneralLibrary.Core.DAL;
using LJH.GeneralLibrary.Core.UI;

namespace LJH.BillProject
{
    public partial class FrmPaymentLogDetail : FrmDetailBase
    {
        public FrmPaymentLogDetail()
        {
            InitializeComponent();
        }

        #region 私有方法
        private void InittxtCategorys()
        {
            txtCategory.Items.Clear();
            string categorys = AppSettings.Current.Categorys;
            if (!string.IsNullOrEmpty(categorys))
            {
                string[] temp = categorys.Split(',');
                this.txtCategory.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                foreach (string item in temp)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        this.txtCategory.AutoCompleteCustomSource.Add(item);
                        this.txtCategory.Items.Add(item);
                    }
                }
            }
        }

        private void InittxtUsers()
        {
            txtUser.Items.Clear();
            string Users = AppSettings.Current.Users;
            if (!string.IsNullOrEmpty(Users))
            {
                string[] temp = Users.Split(',');
                this.txtUser .AutoCompleteCustomSource = new AutoCompleteStringCollection();
                foreach (string item in temp)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        this.txtUser.AutoCompleteCustomSource.Add(item);
                        this.txtUser.Items.Add(item);
                    }
                }
            }
        }

        private void InittxtPaymentModes()
        {
            txtPaymentMode.Items.Clear();
            string PaymentModes = AppSettings.Current.PaymentModes;
            if (!string.IsNullOrEmpty(PaymentModes))
            {
                string[] temp = PaymentModes.Split(',');
                this.txtPaymentMode.AutoCompleteCustomSource = new AutoCompleteStringCollection();
                foreach (string item in temp)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        this.txtPaymentMode.AutoCompleteCustomSource.Add(item);
                        this.txtPaymentMode.Items.Add(item);
                    }
                }
            }
        }
        #endregion

        #region 重写基类方法
        protected override bool CheckInput()
        {
            return true;
        }

        protected override void InitControls()
        {
            base.InitControls();
            dtPaymentLog.Value = DateTime.Today;
            InittxtCategorys();
            InittxtUsers();
            InittxtPaymentModes();
        }

        protected override void ItemShowing()
        {
            PaymentLog log = UpdatingItem as PaymentLog;
            dtPaymentLog.Value = log.PaymentDate;
            txtCategory.Text = log.Category;
            txtUser.Text = log.User;
            txtAmount.DecimalValue = log.Amount;
            txtPaymentMode.Text = log.PaymentMode;
            txtMemo.Text = log.Memo;
        }

        protected override object GetItemFromInput()
        {
            PaymentLog log = UpdatingItem as PaymentLog;
            if (log == null)
            {
                log = new PaymentLog();
                log.ID = Guid.NewGuid();
            }
            log.PaymentDate = dtPaymentLog.Value;
            log.Category = txtCategory.Text;
            log.User = txtUser.Text;
            log.Amount = txtAmount.DecimalValue;
            log.PaymentMode = txtPaymentMode.Text;
            log.Memo = txtMemo.Text;
            return log;
        }

        protected override CommandResult AddItem(object addingItem)
        {
            CommandResult ret = new PaymentLogBLL(AppSettings.Current.ConnStr).Add(addingItem as PaymentLog);
            return ret;
        }

        protected override CommandResult UpdateItem(object updatingItem)
        {
            CommandResult ret = new PaymentLogBLL(AppSettings.Current.ConnStr).Update(updatingItem as PaymentLog);
            return ret;
        }
        #endregion
    }
}
