using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystemTest;
using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities.Test
{
    [TestClass()]
    public class ProductsAndProductTypesManagerTest
    {
        private const string MEMBER_VARIABLE_NAME_PRODUCTS_MANAGER = "_productsManager";
        private const string MEMBER_VARIABLE_NAME_PRODUCT_TYPES_MANAGER = "_productTypesManager";
        private ProductsAndProductTypesManager _productsAndProductTypesManager;
        private PrivateObject _target;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            List<Product> products = CreateSetupProducts();
            var productTypesManager = new ProductTypesManager(products);
            productTypesManager.ProductTypes.Add("Type D");
            _productsAndProductTypesManager = new ProductsAndProductTypesManager(new ProductsManager(products), productTypesManager);
            _target = new PrivateObject(_productsAndProductTypesManager);
        }

        /// <summary>
        /// Gets the setup products.
        /// </summary>
        private List<Product> CreateSetupProducts()
        {
            var products = new List<Product>();
            int productIdCount = 0;
            for ( int i = 0; i < 6; i++ )
            {
                products.Add(new Product(productIdCount++, TestDefinition.DUMP_STRING, "Type A", new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            }
            for ( int i = 0; i < 5; i++ )
            {
                products.Add(new Product(productIdCount++, TestDefinition.DUMP_STRING, "Type B", new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            }
            for ( int i = 0; i < 19; i++ )
            {
                products.Add(new Product(productIdCount++, TestDefinition.DUMP_STRING, "Type C", new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            }
            return products;
        }

        /// <summary>
        /// Tests the products and product types manager.
        /// </summary>
        [TestMethod()]
        public void TestProductsAndProductTypesManager()
        {
            var products = new List<Product>();
            Assert.ThrowsException<ArgumentNullException>(() => new ProductsAndProductTypesManager(null, new ProductTypesManager(products)));
            Assert.ThrowsException<ArgumentNullException>(() => new ProductsAndProductTypesManager(new ProductsManager(products), null));
            var productsManager = new ProductsManager(products);
            var productTypesManager = new ProductTypesManager(products);
            var productsAndProductTypesManager = new ProductsAndProductTypesManager(productsManager, productTypesManager);
            var target = new PrivateObject(productsAndProductTypesManager);
            Assert.AreSame(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS_MANAGER), productsManager);
            Assert.AreSame(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES_MANAGER), productTypesManager);
        }

        /// <summary>
        /// Tests the get product type product pages count.
        /// </summary>
        [TestMethod()]
        public void TestGetProductTypeProductPagesCount()
        {
            Assert.AreEqual(_productsAndProductTypesManager.GetProductTypeProductPagesCount("Type A"), 1);
            Assert.AreEqual(_productsAndProductTypesManager.GetProductTypeProductPagesCount("Type B"), 1);
            Assert.AreEqual(_productsAndProductTypesManager.GetProductTypeProductPagesCount("Type C"), 4);
            Assert.AreEqual(_productsAndProductTypesManager.GetProductTypeProductPagesCount("Type D"), 1);
        }

        /// <summary>
        /// Tests the get product type products count.
        /// </summary>
        [TestMethod()]
        public void TestGetProductTypeProductsCount()
        {
            const string MEMBER_FUNCTION_NAME_GET_PRODUCT_TYPE_PRODUCTS_COUNT = "GetProductTypeProductsCount";
            var arguments = new object[] { "Type A" };
            Assert.AreEqual(( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_PRODUCT_TYPE_PRODUCTS_COUNT, arguments), 6);
            arguments = new object[] { "Type B" };
            Assert.AreEqual(( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_PRODUCT_TYPE_PRODUCTS_COUNT, arguments), 5);
            arguments = new object[] { "Type C" };
            Assert.AreEqual(( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_PRODUCT_TYPE_PRODUCTS_COUNT, arguments), 19);
            arguments = new object[] { "Type D" };
            Assert.AreEqual(( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_PRODUCT_TYPE_PRODUCTS_COUNT, arguments), 0);
        }

        /// <summary>
        /// Tests the get product pages count.
        /// </summary>
        [TestMethod()]
        public void TestGetProductPagesCount()
        {
            const string MEMBER_FUNCTION_NAME_GET_PRODUCT_PAGES_COUNT = "GetProductPagesCount";
            var arguments = new object[] { 0 };
            Assert.AreEqual(( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_PRODUCT_PAGES_COUNT, arguments), 1);
            arguments = new object[] { 5 };
            Assert.AreEqual(( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_PRODUCT_PAGES_COUNT, arguments), 1);
            arguments = new object[] { 6 };
            Assert.AreEqual(( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_PRODUCT_PAGES_COUNT, arguments), 1);
            arguments = new object[] { 7 };
            Assert.AreEqual(( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_PRODUCT_PAGES_COUNT, arguments), 2);
        }

        /// <summary>
        /// Tests the get product.
        /// </summary>
        [TestMethod()]
        public void TestGetProduct()
        {
            Assert.IsNull(_productsAndProductTypesManager.GetProduct("Type D", TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_INTEGER));
            Assert.IsNull(_productsAndProductTypesManager.GetProduct("Type C", 3, 2));
            Product expectedProduct = _productsAndProductTypesManager.GetProduct("Type C", 0, 6);
            Assert.AreEqual(expectedProduct.Id, 17);
            expectedProduct = _productsAndProductTypesManager.GetProduct("Type C", 3, 0);
            Assert.AreEqual(expectedProduct.Id, 29);
            expectedProduct = _productsAndProductTypesManager.GetProduct("Type C", 2, 5);
            Assert.AreEqual(expectedProduct.Id, 28);
        }

        /// <summary>
        /// Tests the get product type products.
        /// </summary>
        [TestMethod()]
        public void TestGetProductTypeProducts()
        {
            Assert.ThrowsException<ArgumentException>(() => _productsAndProductTypesManager.GetProductTypeProducts("Type E"));
            List<Product> expectedProducts = _productsAndProductTypesManager.GetProductTypeProducts("Type A");
            Assert.AreEqual(expectedProducts.Count, 6);
            int productIdCount = 0;
            foreach ( Product product in expectedProducts )
            {
                Assert.AreEqual(product.Id, productIdCount++);
                Assert.AreEqual(product.Type, "Type A");
            }
        }
    }
}