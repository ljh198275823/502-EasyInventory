using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LJH.Inventory.BLL;
using LJH.Inventory.BusinessModel;

namespace LJH.Inventory.UI.Controls
{
    public partial class FrmProductDropdownList : Form
    {

        #region 构造函数
        public FrmProductDropdownList()
        {
            InitializeComponent();
            Init();
        }
        #endregion

        #region 私有变量
        private List<Product> _Products;
        #endregion

        #region 公共事件
        /// <summary>
        /// 当选择了某个商品时产生此事件
        /// </summary>
        public event EventHandler<ProductSelectedArgs> ProductSelected;
        #endregion

        #region 公共方法
        private void Init()
        {
            _Products = (new ProductBLL(AppSettings.Current.ConnStr)).GetItems(null).QueryObjects;
            _Products = (from p in _Products
                         orderby p.ID ascending, p.Name ascending
                         select p).ToList();
        }

        /// <summary>
        /// 根据查询的关键字来过滤商品信息
        /// </summary>
        /// <param name="criteria">查询关键字</param>
        /// <param name="qid">是否过滤商品编号中的关键字</param>
        /// <param name="qname">是否过滤商品名称中的关键字</param>
        /// <param name="qspecification">是否过滤商品规格中的关键字</param>
        public void Filter(string criteria, bool qid, bool qname, bool qspecification)
        {
            this.dataGridView1.Rows.Clear();
            foreach (Product p in _Products)
            {
                if ((string.IsNullOrEmpty(criteria)) ||
                    (qid && p.ID.IndexOf(criteria) == 0) ||
                    (qname && p.Name.IndexOf(criteria) == 0) ||
                    (qspecification && p.Specification.IndexOf(criteria) == 0))
                {
                    int row = dataGridView1.Rows.Add();
                    dataGridView1.Rows[row].Tag = p;
                    dataGridView1.Rows[row].Cells["colID"].Value = p.ID;
                    dataGridView1.Rows[row].Cells["colName"].Value = p.Name;
                    dataGridView1.Rows[row].Cells["colSpecification"].Value = p.Specification;
                }
            }
        }


        #endregion
        private void FrmProductDropdownList_Load(object sender, EventArgs e)
        {
            Filter(string.Empty, false, false, false);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Product p = dataGridView1.Rows[e.RowIndex].Tag as Product;
            if (p != null && ProductSelected != null)
            {
                ProductSelected(this, new ProductSelectedArgs(p));
            }
        }
    }

    /// <summary>
    /// 商品选择事件的事件参数
    /// </summary>
    public class ProductSelectedArgs : EventArgs
    {
        #region 构造函数
        public ProductSelectedArgs()
        {
        }

        public ProductSelectedArgs(Product p)
        {
            SelectedProduct = p;
        }
        #endregion

        #region 公共属性
        /// <summary>
        /// 获取或设置选择的商品信息
        /// </summary>
        public Product SelectedProduct { get; set; }
        #endregion
    }
}
