using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystemTest;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OrderAndStorageManagementSystem.Models.Utilities.Test
{
    [TestClass()]
    public class ProductTypesManagerTest
    {
        private const string MEMBER_VARIABLE_NAME_PRODUCT_TYPES = "_productTypes";
        private ProductTypesManager _productTypesManager;
        private PrivateObject _target;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _productTypesManager = new ProductTypesManager(new List<Product>());
            _target = new PrivateObject(_productTypesManager);
        }

        /// <summary>
        /// Tests the product types manager.
        /// </summary>
        [TestMethod()]
        public void TestProductTypesManager()
        {
            List<Product> products = CreateProducts();
            var productTypesManager = new ProductTypesManager(products);
            var target = new PrivateObject(productTypesManager);
            List<string> expectedProductTypes = ( List<string> )target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES);
            Assert.AreEqual(expectedProductTypes[ 0 ], "Type A");
            Assert.AreEqual(expectedProductTypes[ 1 ], "Type B");
        }

        /// <summary>
        /// Creates the products.
        /// </summary>
        private List<Product> CreateProducts()
        {
            var products = new List<Product>();
            products.Add(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, "Type A", new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            products.Add(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, "Type A", new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            products.Add(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, "Type B", new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            return products;
        }

        /// <summary>
        /// Tests the initialize product types.
        /// </summary>
        [TestMethod()]
        public void TestInitializeProductTypes()
        {
            const string MEMBER_FUNCTION_NAME_INITIALIZE_PRODUCT_TYPES = "InitializeProductTypes";
            var arguments = new object[] { null };
            TargetInvocationException expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.Invoke(MEMBER_FUNCTION_NAME_INITIALIZE_PRODUCT_TYPES, arguments));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(ArgumentNullException));
            arguments = new object[] { CreateProducts() };
            _target.Invoke(MEMBER_FUNCTION_NAME_INITIALIZE_PRODUCT_TYPES, arguments);
            List<string> expectedProductTypes = ( List<string> )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES);
            Assert.AreEqual(expectedProductTypes[ 0 ], "Type A");
            Assert.AreEqual(expectedProductTypes[ 1 ], "Type B");
        }

        /// <summary>
        /// Tests the type of the get product.
        /// </summary>
        [TestMethod()]
        public void TestGetProductType()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES, new List<string> { "Type 1", "Type 2", "Type 3" });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _productTypesManager.GetProductType(-1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _productTypesManager.GetProductType(3));
            Assert.AreEqual(_productTypesManager.GetProductType(2), "Type 3");
        }

        /// <summary>
        /// Tests the is existing.
        /// </summary>
        [TestMethod()]
        public void TestIsExisting()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES, new List<string> { "Type 1", "Type 2", "Type 3" });
            Assert.IsTrue(_productTypesManager.IsExisting("Type 1"));
            Assert.IsFalse(_productTypesManager.IsExisting("Type 4"));
        }

        /// <summary>
        /// Adds the type of the product.
        /// </summary>
        [TestMethod()]
        public void TestAddProductType()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES, new List<string> { "Type 1", "Type 2", "Type 3" });
            _productTypesManager.AddProductType("Type 4");
            List<string> expectedProductTypes = ( List<string> )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES);
            Assert.AreEqual(expectedProductTypes.Count, 4);
            Assert.AreEqual(expectedProductTypes[ 3 ], "Type 4");
        }

        /// <summary>
        /// Tests the type of the notify observer add product.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverAddProductType()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ADD_PRODUCT_TYPE = "NotifyObserverAddProductType";
            int count = 0;
            _productTypesManager.ProductTypeAdded += (productType) => count++;
            var arguments = new object[] { TestDefinition.DUMP_STRING };
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ADD_PRODUCT_TYPE, arguments);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ADD_PRODUCT_TYPE, arguments);
            Assert.AreEqual(count, 2);
        }
    }
}