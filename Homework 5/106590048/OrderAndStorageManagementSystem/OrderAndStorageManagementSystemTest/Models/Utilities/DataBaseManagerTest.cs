using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystemTest.Properties;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities.Test
{
    [TestClass()]
    public class DataBaseManagerTest
    {
        /// <summary>Tests the get products from file.</summary>
        [TestMethod()]
        public void TestGetProductsFromFile()
        {
            List<Product> expectedProducts = DataBaseManager.GetProductsFromFile(Resources.ProductsTableTest);
            Assert.AreEqual(expectedProducts[ 0 ].Id, -1);
            Assert.AreEqual(expectedProducts[ 0 ].Name, "First product name.");
            Assert.AreEqual(expectedProducts[ 0 ].Type, "主機板");
            Assert.AreEqual(expectedProducts[ 0 ].Price.GetString(), "1490");
            Assert.AreEqual(expectedProducts[ 0 ].StorageQuantity, 10);
            Assert.AreEqual(expectedProducts[ 0 ].Description, "First product description.");
            Assert.AreEqual(expectedProducts[ 1 ].Id, 0);
            Assert.AreEqual(expectedProducts[ 1 ].Name, "Second product name.");
            Assert.AreEqual(expectedProducts[ 1 ].Type, "記憶體");
            Assert.AreEqual(expectedProducts[ 1 ].Price.GetString(), "1389");
            Assert.AreEqual(expectedProducts[ 1 ].StorageQuantity, 70);
            Assert.AreEqual(expectedProducts[ 1 ].Description, "Second product description.");
            Assert.AreEqual(expectedProducts[ 2 ].Id, 3);
            Assert.AreEqual(expectedProducts[ 2 ].Name, "Third product name.");
            Assert.AreEqual(expectedProducts[ 2 ].Type, "CPU");
            Assert.AreEqual(expectedProducts[ 2 ].Price.GetString(), "7999");
            Assert.AreEqual(expectedProducts[ 2 ].StorageQuantity, 100);
            Assert.AreEqual(expectedProducts[ 2 ].Description, "Third product description.");
        }
    }
}