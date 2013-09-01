using System.IO;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace LJH.Inventory.DAL.LinqProvider
{
    internal class DataContextFactory
    {
        public static DataContext CreateDataContext(string connStr)
        {
            System.Diagnostics.Debug.Assert(!string.IsNullOrEmpty(connStr), "没有找到有效的数据库连接!");
            Stream stream = typeof(DataContextFactory).Assembly.GetManifestResourceStream("LJH.Inventory.DAL.LinqProvider.Inventory.xml");
            MappingSource mappingSource = XmlMappingSource.FromStream(stream);
            DataContext inventory = new DataContext(connStr, mappingSource);
            inventory.Log = System.Console.Out;
            return inventory;
        }
    }
}
