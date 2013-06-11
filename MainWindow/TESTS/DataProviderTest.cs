using System;
using DataProvider;
using System.Configuration;
using System.Text;
using NUnit.Framework;


namespace TESTS
{
    [TestFixture]
    public class DataLoadFromTestTab
    {
        [Test]
        public void TestDataLoad()
        {
            string connectionString;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            }
            catch
            {
                throw new Exception("Конфигурационный файл не найден");
            }
            var dataProvider = new OracleDbProvider("TV_MANAGER", "TEST", connectionString);
            var query = new SelectQuery("TEST_TAB", new string[] { "ID", "NAME" }, null);
            var tableInfo = dataProvider.GetTableData(query);
        }

        [Test]
        public void TestTableSelectQuery()
        {
            var SelectQuery = new SelectQuery("TEST_TAB", new string[] { "COL1", "COL2", "COL3" }, null);
            var TableInfo = new TableInformationItem(SelectQuery);
            Assert.That(TableInfo.TableName, Is.EqualTo("TEST_TAB"));
            Assert.That(TableInfo.TabCols.Count, Is.EqualTo(0));
        }

        [Test]
        public void TestTableInformationItemData()
        {
            string connectionString;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            }
            catch
            {
                throw new Exception("Конфигурационный файл не найден");
            }
            var SelectQuery = new SelectQuery("TEST_TAB", new string[] { "ID", "NAME" }, null);
            var dataProvider = new OracleDbProvider("ppn_v3", "ppn_v3", connectionString);
            var TableInfo = dataProvider.GetTableData(SelectQuery);

            Assert.That(TableInfo.TableName, Is.EqualTo("TEST_TAB"));
            Assert.That(TableInfo.TabCols.Count, Is.EqualTo(2));
            Assert.That(TableInfo.GetColDataByIdx("ID", 0), Is.EqualTo("1000"));
            Assert.That(TableInfo.GetColDataByIdx("ID", 1), Is.EqualTo("1001"));
            Assert.That(TableInfo.GetColDataByIdx("NAME", 0), Is.EqualTo("test1"));
            Assert.That(TableInfo.GetColDataByIdx("NAME", 1), Is.EqualTo("test2"));
        }
        
        [Test]
        public void TestRowItem()
        {
            string connectionString;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            }
            catch
            {
                throw new Exception("Конфигурационный файл не найден");
            }
            var SelectQuery = new SelectQuery("TEST_TAB", new string[] { "ID", "NAME" }, null);
            var dataProvider = new OracleDbProvider("ppn_v3", "ppn_v3", connectionString);
            var TableInfo = dataProvider.GetTableData(SelectQuery);

            var rowItem1 = TableInfo.GetColData("ID");
            var rowItem2 = TableInfo.GetColData("NAME");
            Assert.That(rowItem1.GetVal(0), Is.EqualTo("1000"));
            Assert.That(rowItem1.GetVal(1), Is.EqualTo("1001"));
        }

        [Test]
        public void TestSetValByIndex()
        {
            string connectionString;
            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            }
            catch
            {
                throw new Exception("Конфигурационный файл не найден");
            }
            var SelectQuery = new SelectQuery("TEST_TAB", new string[] { "ID", "NAME" }, null);
            var dataProvider = new OracleDbProvider("ppn_v3", "ppn_v3", connectionString);
            var TableInfo = dataProvider.GetTableData(SelectQuery);

            TableInfo["ID"].SetVal(0, "2000");
            TableInfo["ID"].SetVal(1, "2222");
            Assert.That(TableInfo.GetColDataByIdx("ID", 0), Is.EqualTo("2000"));
            Assert.That(TableInfo.GetColDataByIdx("ID", 1), Is.EqualTo("2222"));
        }
    }
}
