using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BusinessModel;
using LJH.Inventory.BLL;

namespace LJH.Inventory.UI.Controls
{
    public partial class UCProductSelection : UserControl
    {
        public UCProductSelection()
        {
            InitializeComponent();
        }

        #region 私有变量
        private List<Product> _Products;
        #endregion

        #region 公共方法
        public void Init()
        {
            _Products = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            _Products = (from p in _Products
                         orderby p.ID ascending, p.Name ascending
                         select p).ToList();
        }

        public void Filter(string criteria)
        {
            this.dataGridView1.Rows.Clear();
            foreach (Product p in _Products)
            {
                if (p.ID.IndexOf(criteria) == 0 || p.Name.IndexOf(criteria) == 0)
                {
                    int row = dataGridView1.Rows.Add();
                    dataGridView1.Rows[row].Cells["colID"].Value = p.ID;
                    dataGridView1.Rows[row].Cells["colName"].Value = p.Name;
                    dataGridView1.Rows[row].Cells["colSpecification"].Value = p.Specification;
                }
            }
        }
        #endregion
    }
}
