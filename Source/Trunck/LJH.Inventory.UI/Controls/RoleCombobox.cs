using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows .Forms ;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Controls
{
    public partial class RoleComboBox:ComboBox 
    {
        public RoleComboBox()
        {
            InitializeComponent();
        }

        public RoleComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Init()
        {
            RoleBLL bll = new RoleBLL(AppSettings.CurrentSetting.ConnectString);
            this.DataSource = bll.GetAllRoles().QueryObjects;
            this.DisplayMember = "RoleID";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RoleInfo Role
        {
            get
            {
                if (this.SelectedIndex == -1)
                {
                    return null;
                }
                else
                {
                    return ((RoleInfo)this.Items[SelectedIndex]);
                }
            }
            set
            {
                for (int i=0 ;i<this.Items.Count ;i++)
                {
                    RoleInfo info = (RoleInfo)this.Items[i];
                    if (info.RoleID == value.RoleID)
                    {
                        this.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SelectedRoleID
        {
            get
            {
                if (this.SelectedIndex == -1)
                {
                    return string.Empty;
                }
                else
                {
                    RoleInfo role = (RoleInfo)this.Items[SelectedIndex];
                    return role.RoleID;
                }
            }
            set
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    RoleInfo info = (RoleInfo)this.Items[i];
                    if (info.RoleID == value)
                    {
                        this.SelectedIndex = i;
                        break;
                    }
                }
            }
        }


    }
}
