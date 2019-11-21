using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystemTest;
using System;
using System.IO;

namespace OrderAndStorageManagementSystem.Models.Utilities.Test
{
    [TestClass()]
    public class ProductTest
    {
        private const string MEMBER_VARIABLE_NAME_STORAGE_QUANTITY = "_storageQuantity";
        private const string MEMBER_VARIABLE_NAME_PRODUCT_INFO = "_productInfo";
        private Product _product;
        private PrivateObject _target;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _product = new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _target = new PrivateObject(_product);
        }

        /// <summary>
        /// Sets the property storage quantity.
        /// </summary>
        [TestMethod()]
        public void TestSetPropertyStorageQuantity()
        {
            Assert.ThrowsException<ArgumentException>(() => _product.StorageQuantity = -1);
            _product.StorageQuantity = 0;
            Assert.AreEqual(( int )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_STORAGE_QUANTITY), 0);
            _product.StorageQuantity = 500;
            Assert.AreEqual(( int )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_STORAGE_QUANTITY), 500);
        }

        /// <summary>
        /// Sets the property product information.
        /// </summary>
        [TestMethod()]
        public void TestSetPropertyProductInfo()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _product.ProductInfo = null);
            var productInfo = new ProductInfo(TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _product.ProductInfo = productInfo;
            Assert.AreSame(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_INFO), productInfo);
        }

        /// <summary>
        /// Tests the type of the set property.
        /// </summary>
        [TestMethod()]
        public void TestSetPropertyType()
        {
            _product.Type = "Type X";
            Assert.AreEqual(_product.Type, "Type X");
        }

        /// <summary>
        /// Tests the set property image path.
        /// </summary>
        [TestMethod()]
        public void TestSetPropertyImagePath()
        {
            _product.ImagePath = "看不到未來.jpg";
            Assert.AreEqual(_product.ImagePath, "看不到未來.jpg");
        }

        /// <summary>
        /// Tests the product seven parameters constructor.
        /// </summary>
        [TestMethod()]
        public void TestProductSevenParametersConstructor()
        {
            var product = new Product(8, "GIGABYTE-666", "主機板", new Money(666), 5, "Badass.", "GIGABYTE-666.jpg");
            Assert.AreEqual(product.Id, 8);
            Assert.AreEqual(product.Name, "GIGABYTE-666");
            Assert.AreEqual(product.Type, "主機板");
            Assert.AreEqual(product.Price.GetString(), "666");
            Assert.AreEqual(product.StorageQuantity, 5);
            Assert.AreEqual(product.Description, "Badass.");
            Assert.AreEqual(product.ImagePath, "GIGABYTE-666.jpg");
        }

        /// <summary>
        /// Tests the product six parameters constructor.
        /// </summary>
        [TestMethod()]
        public void TestProductSixParametersConstructor()
        {
            var product = new Product(-6, "ASUS-H246", "螢幕", new Money(1024), 10, "Kick asses.");
            Assert.AreEqual(product.Id, -6);
            Assert.AreEqual(product.Name, "ASUS-H246");
            Assert.AreEqual(product.Type, "螢幕");
            Assert.AreEqual(product.Price.GetString(), "1024");
            Assert.AreEqual(product.StorageQuantity, 10);
            Assert.AreEqual(product.Description, "Kick asses.");
            Assert.AreEqual(product.ImagePath, Directory.GetCurrentDirectory() + @"\..\..\Resources\img_AppDatabase_ProductsTable_-6.jpg");
        }

        /// <summary>
        /// Tests the product two parameters constructor.
        /// </summary>
        [TestMethod()]
        public void TestProductTwoParametersConstructor()
        {
            var productInfo = new ProductInfo(TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            var product = new Product(2, productInfo);
            Assert.AreEqual(product.Id, 2);
            Assert.AreEqual(product.StorageQuantity, 0);
            Assert.AreSame(product.ProductInfo, productInfo);
        }

        /// <summary>
        /// Tests the get product name and description.
        /// </summary>
        [TestMethod()]
        public void TestGetProductNameAndDescription()
        {
            _product.Name = "Bob";
            _product.Description = "The most handsome person in the world.";
            Assert.AreEqual(_product.GetProductNameAndDescription(), "Bob\n\nThe most handsome person in the world.");
        }

        /// <summary>
        /// Tests the get storage quantity.
        /// </summary>
        [TestMethod()]
        public void TestGetStorageQuantity()
        {
            _product.StorageQuantity = 100;
            Assert.AreEqual(_product.GetStorageQuantity(), "100");
        }

        /// <summary>
        /// Tests the get price.
        /// </summary>
        [TestMethod()]
        public void TestGetPrice()
        {
            _product.Price = new Money(5000);
            Assert.AreEqual(_product.GetPrice("Yen"), "5,000 Yen");
        }

        /// <summary>
        /// Tests to string.
        /// </summary>
        [TestMethod()]
        public void TestToString()
        {
            _product.Name = "William";
            Assert.AreEqual(_product.ToString(), "William");
        }
    }
}