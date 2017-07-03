using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LJH.Inventory.UI.Forms
{
    public partial class FrmSoftDogInfo : Form
    {
        public FrmSoftDogInfo()
        {
            InitializeComponent();
        }

        public LJH.GeneralLibrary.SoftDog.SoftDogInfo SoftDog { get; set; }

        private void FrmSoftDogInfo_Load(object sender, EventArgs e)
        {
            if (SoftDog != null)
            {
                lblProjectNum.Text = SoftDog.ProjectNo.ToString();
                lblStartDate.Text = SoftDog.StartDate.ToShortDateString();
                if (SoftDog.ExpiredDate.AddYears(2) <= new DateTime(2020, 12, 31)) lblExpireDate.Text = "长期有效";
                else lblExpireDate.Text = SoftDog.ExpiredDate.ToShortDateString();
            }
        }

        private void FrmSoftDogInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
