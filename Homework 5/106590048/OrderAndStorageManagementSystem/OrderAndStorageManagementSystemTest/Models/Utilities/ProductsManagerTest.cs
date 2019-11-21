using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystemTest;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OrderAndStorageManagementSystem.Models.Utilities.Test
{
    [TestClass()]
    public class ProductsManagerTest
    {
        private const string MEMBER_VARIABLE_NAME_PRODUCTS = "_products";
        private ProductsManager _productsManager;
        private PrivateObject _target;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _productsManager = new ProductsManager(new List<Product>());
            _target = new PrivateObject(_productsManager);
        }

        /// <summary>
        /// Tests the products manager.
        /// </summary>
        [TestMethod()]
        public void TestProductsManager()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ProductsManager(null));
            Assert.ThrowsException<ArgumentException>(() => new ProductsManager(CreateNotUniqueProductIdQualifiedProducts()));
            var products = new List<Product>();
            var productsManager = new ProductsManager(products);
            var target = new PrivateObject(productsManager);
            Assert.AreSame(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS), products);
        }

        /// <summary>
        /// Creates the not unique product identifier qualified products.
        /// </summary>
        private List<Product> CreateNotUniqueProductIdQualifiedProducts()
        {
            var products = new List<Product>();
            products.Add(new Product(1, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            products.Add(new Product(1, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            return products;
        }

        /// <summary>
        /// Tests the is unique product identifier qualified.
        /// </summary>
        [TestMethod()]
        public void TestIsUniqueProductIdQualified()
        {
            const string MEMBER_FUNCTION_NAME_IS_UNIQUE_PRODUCT_ID_QUALIFIED = "IsUniqueProductIdQualified";
            var arguments = new object[] { null };
            TargetInvocationException expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.Invoke(MEMBER_FUNCTION_NAME_IS_UNIQUE_PRODUCT_ID_QUALIFIED, arguments));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(ArgumentNullException));
            arguments = new object[] { CreateUniqueProductIdQualifiedProducts() };
            Assert.IsTrue(( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_UNIQUE_PRODUCT_ID_QUALIFIED, arguments));
            arguments = new object[] { CreateNotUniqueProductIdQualifiedProducts() };
            Assert.IsFalse(( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_UNIQUE_PRODUCT_ID_QUALIFIED, arguments));
        }

        /// <summary>
        /// Creates the unique product identifier qualified products.
        /// </summary>
        private List<Product> CreateUniqueProductIdQualifiedProducts()
        {
            var products = new List<Product>();
            products.Add(new Product(-1, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            products.Add(new Product(0, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            products.Add(new Product(1, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            return products;
        }

        /// <summary>
        /// Tests the get product.
        /// </summary>
        [TestMethod()]
        public void TestGetProduct()
        {
            List<Product> products = CreateUniqueProductIdQualifiedProducts();
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS, products);
            Assert.AreSame(_productsManager.GetProduct(-1), products[ 0 ]);
            Assert.ThrowsException<ArgumentException>(() => _productsManager.GetProduct(2));
        }

        /// <summary>
        /// Tests the decrease product storage quantities by order quantities.
        /// </summary>
        [TestMethod()]
        public void TestDecreaseProductStorageQuantitiesByOrderQuantities()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _productsManager.DecreaseProductStorageQuantitiesByOrderQuantities(null));
            List<Product> products = CreateUniqueProductIdQualifiedProducts();
            products[ 1 ].StorageQuantity = 5;
            products[ 2 ].StorageQuantity = 2;
            var productWithOrderQuantityContainers = new Dictionary<Product, int> { { products[ 1 ], 2 }, { products[ 2 ], 2 } };
            _productsManager.DecreaseProductStorageQuantitiesByOrderQuantities(productWithOrderQuantityContainers);
            Assert.AreEqual(products[ 1 ].StorageQuantity, 3);
            Assert.AreEqual(products[ 2 ].StorageQuantity, 0);
        }

        /// <summary>
        /// Tests the add product storage quantity.
        /// </summary>
        [TestMethod()]
        public void TestAddProductStorageQuantity()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _productsManager.AddProductStorageQuantity(null, TestDefinition.DUMP_INTEGER));
            var product = new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), 10, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _productsManager.AddProductStorageQuantity(product, 100);
            Assert.AreEqual(product.StorageQuantity, 110);
        }

        /// <summary>
        /// Tests the notify observer change product storage quantity.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeProductStorageQuantity()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCT_STORAGE_QUANTITY = "NotifyObserverChangeProductStorageQuantity";
            int count = 0;
            _productsManager.ProductStorageQuantityChanged += (product) => count++;
            var arguments = new object[] { new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING) };
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCT_STORAGE_QUANTITY, arguments);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCT_STORAGE_QUANTITY, arguments);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the update product information.
        /// </summary>
        [TestMethod()]
        public void TestUpdateProductInfo()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _productsManager.UpdateProductInfo(null, null));
            var product = new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            ProductInfo oldProductInfo = product.ProductInfo;
            var newProductInfo = new ProductInfo(TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _productsManager.UpdateProductInfo(product, newProductInfo);
            Assert.AreSame(product.ProductInfo, newProductInfo);
            Assert.AreNotSame(product.ProductInfo, oldProductInfo);
        }

        /// <summary>
        /// Tests the notify observer change product information.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeProductInfo()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCT_INFO = "NotifyObserverChangeProductInfo";
            int count = 0;
            _productsManager.ProductInfoChanged += (product) => count++;
            var arguments = new object[] { new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING) };
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCT_INFO, arguments);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCT_INFO, arguments);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the add product.
        /// </summary>
        [TestMethod()]
        public void TestAddProduct()
        {
            List<Product> products = CreateUniqueProductIdQualifiedProducts();
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS, products);
            var newProductInfo = new ProductInfo(TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _productsManager.AddProduct(newProductInfo);
            Assert.AreEqual(products[ 3 ].Id, 2);
            Assert.AreSame(products[ 3 ].ProductInfo, newProductInfo);
        }

        /// <summary>
        /// Tests the create new unique product identifier.
        /// </summary>
        [TestMethod()]
        public void TestCreateNewUniqueProductId()
        {
            const string MEMBER_FUNCTION_NAME_CREATE_NEW_UNIQUE_PRODUCT_ID = "CreateNewUniqueProductId";
            List<Product> products = CreateUniqueProductIdQualifiedProducts();
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS, products);
            Assert.AreEqual(( int )_target.Invoke(MEMBER_FUNCTION_NAME_CREATE_NEW_UNIQUE_PRODUCT_ID), 2);
            products = CreateFromZeroToOneThousandUniqueProductIdQualifiedProducts();
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS, products);
            TargetInvocationException expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.Invoke(MEMBER_FUNCTION_NAME_CREATE_NEW_UNIQUE_PRODUCT_ID));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(ApplicationException));
        }

        /// <summary>
        /// Creates from zero to one thousand unique product identifier qualified products.
        /// </summary>
        private List<Product> CreateFromZeroToOneThousandUniqueProductIdQualifiedProducts()
        {
            var products = new List<Product>();
            for ( int productId = 0; productId <= 1000; productId++ )
            {
                products.Add(new Product(productId, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            }
            return products;
        }

        /// <summary>
        /// Tests the is existed product identifier.
        /// </summary>
        [TestMethod()]
        public void TestIsExistedProductId()
        {
            const string MEMBER_FUNCTION_NAME_IS_EXISTED_PRODUCT_ID = "IsExistedProductId";
            List<Product> products = CreateUniqueProductIdQualifiedProducts();
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS, products);
            var arguments = new object[] { 0 };
            Assert.IsTrue(( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXISTED_PRODUCT_ID, arguments));
            arguments = new object[] { -2 };
            Assert.IsFalse(( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXISTED_PRODUCT_ID, arguments));
        }

        /// <summary>
        /// Tests the notify observer add product.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverAddProduct()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ADD_PRODUCT = "NotifyObserverAddProduct";
            int count = 0;
            _productsManager.ProductAdded += (product) => count++;
            var arguments = new object[] { new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING) };
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ADD_PRODUCT, arguments);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ADD_PRODUCT, arguments);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the get product at.
        /// </summary>
        [TestMethod()]
        public void TestGetProductAt()
        {
            List<Product> products = CreateUniqueProductIdQualifiedProducts();
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS, products);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _productsManager.GetProductAt(-1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _productsManager.GetProductAt(3));
            Assert.AreSame(_productsManager.GetProductAt(0), products[ 0 ]);
            Assert.AreSame(_productsManager.GetProductAt(1), products[ 1 ]);
        }
    }
}