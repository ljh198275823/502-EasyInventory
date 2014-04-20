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
            RoleBLL bll = new RoleBLL(AppSettings.Current.ConnStr);
            this.DataSource = bll.GetItems(null).QueryObjects;
            this.DisplayMember = "ID";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Role Role
        {
            get
            {
                if (this.SelectedIndex == -1)
                {
                    return null;
                }
                else
                {
                    return ((Role)this.Items[SelectedIndex]);
                }
            }
            set
            {
                for (int i=0 ;i<this.Items.Count ;i++)
                {
                    Role info = (Role)this.Items[i];
                    if (info.ID == value.ID)
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
                    Role role = (Role)this.Items[SelectedIndex];
                    return role.ID;
                }
            }
            set
            {
                for (int i = 0; i < this.Items.Count; i++)
                {
                    Role info = (Role)this.Items[i];
                    if (info.ID == value)
                    {
                        this.SelectedIndex = i;
                        break;
                    }
                }
            }
        }


    }
}
