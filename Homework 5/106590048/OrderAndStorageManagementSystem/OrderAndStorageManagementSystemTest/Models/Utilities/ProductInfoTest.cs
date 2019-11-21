using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystemTest;
using System;

namespace OrderAndStorageManagementSystem.Models.Utilities.Test
{
    [TestClass()]
    public class ProductInfoTest
    {
        private const string MEMBER_VARIABLE_NAME_PRICE = "_price";
        private ProductInfo _productInfo;
        private PrivateObject _target;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _productInfo = new ProductInfo(TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _target = new PrivateObject(_productInfo);
        }

        /// <summary>
        /// Tests the set property price.
        /// </summary>
        [TestMethod()]
        public void TestSetPropertyPrice()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _productInfo.Price = null);
            Assert.ThrowsException<ArgumentException>(() => _productInfo.Price = new Money(-1));
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRICE, new Money(9));
            _productInfo.Price = new Money(10);
            Money expectedPrice = ( Money )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRICE);
            Assert.AreEqual(expectedPrice.GetString(), "10");
        }

        /// <summary>
        /// Tests the product information.
        /// </summary>
        [TestMethod()]
        public void TestProductInfo()
        {
            var productInfo = new ProductInfo("name", "type", new Money(5), "description", "image path");
            Assert.AreEqual(productInfo.Name, "name");
            Assert.AreEqual(productInfo.Type, "type");
            Assert.AreEqual(productInfo.Price.GetString(), "5");
            Assert.AreEqual(productInfo.Description, "description");
            Assert.AreEqual(productInfo.ImagePath, "image path");
        }
    }
}