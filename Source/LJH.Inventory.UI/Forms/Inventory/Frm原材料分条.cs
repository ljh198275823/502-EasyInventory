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
using LJH.Inventory.BusinessModel.SearchCondition;
using LJH.GeneralLibrary;
using LJH.GeneralLibrary.Core.UI;
using LJH.GeneralLibrary.Core.DAL;

namespace LJH.Inventory.UI.Forms.Inventory
{
    public partial class Frm原材料分条 : Form
    {
        public Frm原材料分条()
        {
            InitializeComponent();
        }

        #region 公共属性
        /// <summary>
        /// 获取或设置要加工的原材料
        /// </summary>
        public ProductInventoryItem SlicingItem { get; set; }

        public List<ProductInventoryItem> NewRolls { get; set; }
        #endregion

        private int GetTotalSlicing()
        {
            int sum = 0;
            sum += txtWidth1.IntergerValue * txtCount1.IntergerValue;
            sum += txtWidth2.IntergerValue * txtCount2.IntergerValue;
            sum += txtWidth3.IntergerValue * txtCount3.IntergerValue;
            sum += txtWidth4.IntergerValue * txtCount4.IntergerValue;
            sum += txtWidth5.IntergerValue * txtCount5.IntergerValue;
            return sum;
        }

        private bool CheckInput()
        {
            if ((txtWidth1.IntergerValue > 0 && txtCount1.IntergerValue == 0) || (txtWidth1.IntergerValue == 0 && txtCount1.IntergerValue > 0))
            {
                MessageBox.Show("没有输入宽度或数量");
                return false;
            }
            if ((txtWidth2.IntergerValue > 0 && txtCount2.IntergerValue == 0) || (txtWidth2.IntergerValue == 0 && txtCount2.IntergerValue > 0))
            {
                MessageBox.Show("没有输入宽度或数量");
                return false;
            }
            if ((txtWidth3.IntergerValue > 0 && txtCount3.IntergerValue == 0) || (txtWidth3.IntergerValue == 0 && txtCount3.IntergerValue > 0))
            {
                MessageBox.Show("没有输入宽度或数量");
                return false;
            }
            if ((txtWidth4.IntergerValue > 0 && txtCount4.IntergerValue == 0) || (txtWidth4.IntergerValue == 0 && txtCount4.IntergerValue > 0))
            {
                MessageBox.Show("没有输入宽度或数量");
                return false;
            }
            if ((txtWidth5.IntergerValue > 0 && txtCount5.IntergerValue == 0) || (txtWidth5.IntergerValue == 0 && txtCount5.IntergerValue > 0))
            {
                MessageBox.Show("没有输入宽度或数量");
                return false;
            }
            var sum = GetTotalSlicing();
            if (sum == 0)
            {
                MessageBox.Show("没有指定分条的规格");
                return false;
            }
            return true;
        }

        private void Frm原材料分条_Load(object sender, EventArgs e)
        {
            txtSpecification.Text = SlicingItem.Product.Specification;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            int sum = GetTotalSlicing();
            int width = (int)SpecificationHelper.GetWrittenWidth(SlicingItem.Product.Specification).Value;
            txtRemain.IntergerValue = width - sum > 0 ? width - sum : 0;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!CheckInput()) return;
            string formula = string.Empty;
            var items = new List<int>();
            if (txtWidth1.IntergerValue > 0 && txtCount1.IntergerValue > 0)
            {
                for (int i = 0; i < txtCount1.IntergerValue; i++)
                {
                    items.Add(txtWidth1.IntergerValue);
                }
                formula += string.Format("{0}*{1}+", txtWidth1.IntergerValue, txtCount1.IntergerValue);
            }
            if (txtWidth2.IntergerValue > 0 && txtCount2.IntergerValue > 0)
            {
                for (int i = 0; i < txtCount2.IntergerValue; i++)
                {
                    items.Add(txtWidth2.IntergerValue);
                }
                formula += string.Format("{0}*{1}+", txtWidth2.IntergerValue, txtCount2.IntergerValue);
            }
            if (txtWidth3.IntergerValue > 0 && txtCount3.IntergerValue > 0)
            {
                for (int i = 0; i < txtCount3.IntergerValue; i++)
                {
                    items.Add(txtWidth3.IntergerValue);
                }
                formula += string.Format("{0}*{1}+", txtWidth3.IntergerValue, txtCount3.IntergerValue);
            }
            if (txtWidth4.IntergerValue > 0 && txtCount4.IntergerValue > 0)
            {
                for (int i = 0; i < txtCount4.IntergerValue; i++)
                {
                    items.Add(txtWidth4.IntergerValue);
                }
                formula += string.Format("{0}*{1}+", txtWidth4.IntergerValue, txtCount4.IntergerValue);
            }
            if (txtWidth5.IntergerValue > 0 && txtCount5.IntergerValue > 0)
            {
                for (int i = 0; i < txtCount5.IntergerValue; i++)
                {
                    items.Add(txtWidth5.IntergerValue);
                }
                formula += string.Format("{0}*{1}+", txtWidth5.IntergerValue, txtCount5.IntergerValue);
            }
            if (txtRemain.IntergerValue > 0)
            {
                items.Add(txtRemain.IntergerValue);
                formula += string.Format("{0}+", txtRemain.IntergerValue);
            }
            formula = formula.TrimEnd('+') + " = " + SpecificationHelper.GetWrittenWidth(SlicingItem.Product.Specification);
            List<ProductInventoryItem> newrolls;
            var ret = new SteelRollBLL(AppSettings.Current.ConnStr).原材料拆条(SlicingItem, items, formula, out newrolls);
            if (ret.Result == ResultCode.Successful)
            {
                NewRolls = newrolls;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(ret.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
