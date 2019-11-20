using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystemTest;
using OrderAndStorageManagementSystemTest.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace OrderAndStorageManagementSystem.Models.Utilities.Test
{
    [TestClass()]
    public class DataBaseManagerTest
    {
        private PrivateType _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.DEPLOYMENT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _target = new PrivateType(typeof(DataBaseManager));
        }

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

        /// <summary>Tests the get line values.</summary>
        [TestMethod()]
        public void TestGetLineValues()
        {
            const string MEMBER_FUNCTION_NAME_GET_LINE_VALUES = "GetLineValues";
            var arguments = new object[] { "0,1,2,3,4" };
            string[] expectedLineValues = ( string[] )_target.InvokeStatic(MEMBER_FUNCTION_NAME_GET_LINE_VALUES, arguments);
            for ( int index = 0; index < 5; index++ )
            {
                Assert.AreEqual(expectedLineValues[ index ], index.ToString());
            }
            arguments = new object[] { ",,,,,," };
            expectedLineValues = ( string[] )_target.InvokeStatic(MEMBER_FUNCTION_NAME_GET_LINE_VALUES, arguments);
            for ( int index = 0; index < 7; index++ )
            {
                Assert.AreEqual(expectedLineValues[ index ], "");
            }
            arguments = new object[] { "corrupted, length" };
            TargetInvocationException expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.InvokeStatic(MEMBER_FUNCTION_NAME_GET_LINE_VALUES, arguments));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(IOException));
        }

        /// <summary>
        /// Tests the create product.
        /// </summary>
        [TestMethod()]
        public void TestCreateProduct()
        {
            const string MEMBER_FUNCTION_NAME_CREATE_PRODUCT = "CreateProduct";
            var arguments = new object[] { null };
            TargetInvocationException expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.InvokeStatic(MEMBER_FUNCTION_NAME_CREATE_PRODUCT, arguments));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(ArgumentNullException));
            arguments = new object[] { new string[] { "1", "2", "3", "4" } };
            expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.InvokeStatic(MEMBER_FUNCTION_NAME_CREATE_PRODUCT, arguments));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(ArgumentException));
            arguments = new object[] { new string[] { "0", "product name", "product type", "1000", "1", "product description" } };
            Product expectedProduct = ( Product )_target.InvokeStatic(MEMBER_FUNCTION_NAME_CREATE_PRODUCT, arguments);
            Assert.AreEqual(expectedProduct.Id, 0);
            Assert.AreEqual(expectedProduct.Name, "product name");
            Assert.AreEqual(expectedProduct.Type, "product type");
            Assert.AreEqual(expectedProduct.Price.GetString(), "1000");
            Assert.AreEqual(expectedProduct.StorageQuantity, 1);
            Assert.AreEqual(expectedProduct.Description, "product description");
            Assert.AreEqual(expectedProduct.ImagePath, Directory.GetCurrentDirectory() + @"\..\..\Resources\img_AppDatabase_ProductsTable_0.jpg");
        }
    }
}