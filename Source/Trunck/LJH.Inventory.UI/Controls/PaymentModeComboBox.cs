using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BusinessModel.Resource;

namespace LJH.Inventory.UI.Controls
{
    public partial class PaymentModeComboBox : System.Windows.Forms.ComboBox
    {
        public PaymentModeComboBox()
        {
            InitializeComponent();
        }

        public PaymentModeComboBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Init()
        {
            this.Items.Clear();
            TextValueItem<PaymentMode>[] items = new TextValueItem<PaymentMode>[]{
            new TextValueItem<PaymentMode>(PaymentMode.None , PaymentModeDescription .GetDescription (PaymentMode .None  )),
            new TextValueItem<PaymentMode>(PaymentMode.Cash, PaymentModeDescription .GetDescription (PaymentMode .Cash )),
            new TextValueItem<PaymentMode>(PaymentMode.Transfer ,PaymentModeDescription .GetDescription (PaymentMode.Transfer  )),
            new TextValueItem <PaymentMode>(PaymentMode .Prepay ,PaymentModeDescription.GetDescription (PaymentMode.Check  )),
            new TextValueItem <PaymentMode>(PaymentMode .Prepay ,PaymentModeDescription.GetDescription (PaymentMode .Prepay )),
            };
            this.DataSource = items;
            this.DisplayMember = "Text";
            this.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        [Browsable(false)]
        [Localizable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public PaymentMode SelectedPaymentMode
        {
            get
            {
                PaymentMode mode = PaymentMode.None;
                if (this.SelectedItem != null)
                {
                    TextValueItem<PaymentMode> item = SelectedItem as TextValueItem<PaymentMode>;
                    if (item != null)
                    {
                        mode = item.Value;
                    }
                }
                return mode;
            }
            set
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    TextValueItem<PaymentMode> item = Items[i] as TextValueItem<PaymentMode>;
                    if (item != null && item.Value == value)
                    {
                        SelectedIndex = i;
                    }
                }
            }
        }
    }
}
