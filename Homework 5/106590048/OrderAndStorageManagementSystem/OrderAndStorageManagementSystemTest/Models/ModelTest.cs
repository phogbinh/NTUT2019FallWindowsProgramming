using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystemTest;
using OrderAndStorageManagementSystemTest.Properties;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Test
{
    [TestClass()]
    public class ModelTest
    {
        private const string MEMBER_VARIABLE_NAME_PRODUCTS_MANAGER = "_productsManager";
        private const string MEMBER_VARIABLE_NAME_PRODUCT_TYPES_MANAGER = "_productTypesManager";
        private const string MEMBER_VARIABLE_NAME_PRODUCTS_AND_PRODUCT_TYPES_MANAGER = "_productsAndProductTypesManager";
        private const string MEMBER_VARIABLE_NAME_ORDER = "_order";
        private Model _model;
        private PrivateObject _target;
        private ProductsManager _productsManager;
        private ProductTypesManager _productTypesManager;
        private Order _order;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _model = new Model(Resources.ProductsTableTest);
            _target = new PrivateObject(_model);
            _productsManager = ( ProductsManager )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS_MANAGER);
            _productTypesManager = ( ProductTypesManager )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES_MANAGER);
            _order = ( Order )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_ORDER);
            InitializeOrder();
        }

        /// <summary>
        /// Initializes the order.
        /// </summary>
        private void InitializeOrder()
        {
            _order.AddProductToOrderIfProductIsNotInOrder(_productsManager.GetProduct(-1));
            _order.AddProductToOrderIfProductIsNotInOrder(_productsManager.GetProduct(0));
            _order.AddProductToOrderIfProductIsNotInOrder(_productsManager.GetProduct(3));
        }

        /// <summary>
        /// Tests the get property order changed.
        /// </summary>
        [TestMethod()]
        public void TestGetPropertyOrderChanged()
        {
            Assert.AreSame(_model.OrderChanged, _order.OrderChanged);
        }

        /// <summary>
        /// Tests the set property order changed.
        /// </summary>
        [TestMethod()]
        public void TestSetPropertyOrderChanged()
        {
            _model.OrderChanged += () => { };
            Assert.IsNotNull(_model.OrderChanged);
        }

        /// <summary>
        /// Tests the get property order item quantity changed.
        /// </summary>
        [TestMethod()]
        public void TestGetPropertyOrderItemQuantityChanged()
        {
            Assert.AreSame(_model.OrderItemQuantityChanged, _order.OrderItemQuantityChanged);
        }

        /// <summary>
        /// Tests the set property order item quantity changed.
        /// </summary>
        [TestMethod()]
        public void TestSetPropertyOrderItemQuantityChanged()
        {
            _model.OrderItemQuantityChanged += (orderItemIndex, orderItemTotalPrice) => { };
            Assert.IsNotNull(_model.OrderItemQuantityChanged);
        }

        /// <summary>
        /// Tests the get property order item quantity is exceeded storage quantity.
        /// </summary>
        [TestMethod()]
        public void TestGetPropertyOrderItemQuantityIsExceededStorageQuantity()
        {
            Assert.AreSame(_model.OrderItemQuantityIsExceededStorageQuantity, _order.OrderItemQuantityIsExceededStorageQuantity);
        }

        /// <summary>
        /// Tests the set property order item quantity is exceeded storage quantity.
        /// </summary>
        [TestMethod()]
        public void TestSetPropertyOrderItemQuantityIsExceededStorageQuantity()
        {
            _model.OrderItemQuantityIsExceededStorageQuantity += (orderItemIndex, orderItemStorageQuantity) => { };
            Assert.IsNotNull(_model.OrderItemQuantityIsExceededStorageQuantity);
        }

        /// <summary>
        /// Tests the get property product information changed.
        /// </summary>
        [TestMethod()]
        public void TestGetPropertyProductInfoChanged()
        {
            Assert.AreSame(_model.ProductInfoChanged, _productsManager.ProductInfoChanged);
        }

        /// <summary>
        /// Tests the set property product information changed.
        /// </summary>
        [TestMethod()]
        public void TestSetPropertyProductInfoChanged()
        {
            _model.ProductInfoChanged += (product) => { };
            Assert.IsNotNull(_model.ProductInfoChanged);
        }

        /// <summary>
        /// Tests the get property product added.
        /// </summary>
        [TestMethod()]
        public void TestGetPropertyProductAdded()
        {
            Assert.AreSame(_model.ProductAdded, _productsManager.ProductAdded);
        }

        /// <summary>
        /// Tests the set property product added.
        /// </summary>
        [TestMethod()]
        public void TestSetPropertyProductAdded()
        {
            _model.ProductAdded += (product) => { };
            Assert.IsNotNull(_model.ProductAdded);
        }

        /// <summary>
        /// Tests the get products.
        /// </summary>
        [TestMethod()]
        public void TestGetProducts()
        {
            Assert.AreSame(_model.Products, _productsManager.Products);
        }

        /// <summary>
        /// Tests the model.
        /// </summary>
        [TestMethod()]
        public void TestModel()
        {
            var model = new Model(TestDefinition.DUMP_STRING);
            var target = new PrivateObject(model);
            Assert.IsNotNull(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS_MANAGER));
            Assert.IsNotNull(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES_MANAGER));
            Assert.IsNotNull(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS_AND_PRODUCT_TYPES_MANAGER));
            Assert.IsNotNull(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_ORDER));
        }

        /// <summary>
        /// Tests the add product to order if product is not in order.
        /// </summary>
        [TestMethod()]
        public void TestAddProductToOrderIfProductIsNotInOrder()
        {
            _model.AddProductToOrderIfProductIsNotInOrder(new Product(2, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            Assert.AreEqual(_order.GetOrderItemsCount(), 4);
        }

        /// <summary>
        /// Tests the is in order.
        /// </summary>
        [TestMethod()]
        public void TestIsInOrder()
        {
            Assert.IsFalse(_model.IsInOrder(-2));
            Assert.IsTrue(_model.IsInOrder(-1));
            Assert.IsTrue(_model.IsInOrder(0));
            Assert.IsFalse(_model.IsInOrder(1));
            Assert.IsFalse(_model.IsInOrder(2));
            Assert.IsTrue(_model.IsInOrder(3));
        }

        /// <summary>
        /// Tests the get order total price.
        /// </summary>
        [TestMethod()]
        public void TestGetOrderTotalPrice()
        {
            Assert.AreEqual(_model.GetOrderTotalPrice(), "10,878 元");
        }

        /// <summary>
        /// Tests the remove order item at.
        /// </summary>
        [TestMethod()]
        public void TestRemoveOrderItemAt()
        {
            _model.RemoveOrderItemAt(0);
            Assert.AreEqual(_order.GetOrderItemsCount(), 2);
        }

        /// <summary>
        /// Tests the get order items count.
        /// </summary>
        [TestMethod()]
        public void TestGetOrderItemsCount()
        {
            Assert.AreEqual(_model.GetOrderItemsCount(), 3);
        }

        /// <summary>
        /// Tests the set order item quantity.
        /// </summary>
        [TestMethod()]
        public void TestSetOrderItemQuantity()
        {
            _model.SetOrderItemQuantity(0, 2);
            Assert.AreEqual(_order.GetOrderItemAt(0).OrderQuantity, 2);
        }

        /// <summary>
        /// Tests the submit order.
        /// </summary>
        [TestMethod()]
        public void TestSubmitOrder()
        {
            _model.SubmitOrder();
            Assert.AreEqual(_productsManager.GetProduct(-1).StorageQuantity, 9);
            Assert.AreEqual(_productsManager.GetProduct(0).StorageQuantity, 69);
            Assert.AreEqual(_productsManager.GetProduct(3).StorageQuantity, 99);
            Assert.AreEqual(_order.GetOrderItemsCount(), 0);
        }

        /// <summary>
        /// Tests the get product.
        /// </summary>
        [TestMethod()]
        public void TestGetProduct()
        {
            Assert.AreSame(_model.GetProduct(-1), _productsManager.GetProduct(-1));
        }

        /// <summary>
        /// Tests the supply product storage quantity.
        /// </summary>
        [TestMethod()]
        public void TestSupplyProductStorageQuantity()
        {
            Product product = _productsManager.GetProduct(-1);
            _model.SupplyProductStorageQuantity(product, 5);
            Assert.AreEqual(product.StorageQuantity, 15);
        }

        /// <summary>
        /// Tests the get order items.
        /// </summary>
        [TestMethod()]
        public void TestGetOrderItems()
        {
            Assert.AreSame(_model.GetOrderItems(), _order.GetOrderItems());
        }

        /// <summary>
        /// Tests the get product types count.
        /// </summary>
        [TestMethod()]
        public void TestGetProductTypesCount()
        {
            Assert.AreEqual(_model.GetProductTypesCount(), 3);
        }

        /// <summary>
        /// Tests the get product types.
        /// </summary>
        [TestMethod()]
        public void TestGetProductTypes()
        {
            Assert.AreSame(_model.GetProductTypes(), _productTypesManager.ProductTypes);
        }

        /// <summary>
        /// Tests the get tab page product pages count.
        /// </summary>
        [TestMethod()]
        public void TestGetTabPageProductPagesCount()
        {
            Assert.AreEqual(_model.GetTabPageProductPagesCount(0), 1);
        }

        /// <summary>
        /// Tests the get product.
        /// </summary>
        [TestMethod()]
        public void TestGetProductByTabPageIndexAndProductPageIndexAndProductIndex()
        {
            Assert.IsNull(_model.GetProduct(2, 0, 1));
            Assert.AreSame(_model.GetProduct(0, 0, 0), _productsManager.GetProduct(-1));
        }

        /// <summary>
        /// Tests the update product information.
        /// </summary>
        [TestMethod()]
        public void TestUpdateProductInfo()
        {
            Product product = _productsManager.GetProduct(0);
            var productInfo = new ProductInfo(TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _model.UpdateProductInfo(product, productInfo);
            Assert.AreSame(product.ProductInfo, productInfo);
        }

        /// <summary>
        /// Tests the get order item at.
        /// </summary>
        [TestMethod()]
        public void TestGetOrderItemAt()
        {
            Assert.AreSame(_model.GetOrderItemAt(0), _order.GetOrderItemAt(0));
        }

        /// <summary>
        /// Tests the add product.
        /// </summary>
        [TestMethod()]
        public void TestAddProduct()
        {
            var productInfo = new ProductInfo(TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _model.AddProduct(productInfo);
            Assert.AreSame(_productsManager.GetProduct(1).ProductInfo, productInfo);
        }

        /// <summary>
        /// Tests the get product type products.
        /// </summary>
        [TestMethod()]
        public void TestGetProductTypeProducts()
        {
            List<Product> expectedProducts = _model.GetProductTypeProducts("主機板");
            Assert.AreEqual(expectedProducts.Count, 1);
            Assert.AreSame(expectedProducts[ 0 ], _productsManager.GetProduct(-1));
        }

        /// <summary>
        /// Tests the type of the add product.
        /// </summary>
        [TestMethod()]
        public void TestAddProductType()
        {
            _model.AddProductType("New Type");
            Assert.AreEqual(_productTypesManager.ProductTypes.Count, 4);
            Assert.IsTrue(_productTypesManager.IsExisting("New Type"));
        }

        /// <summary>
        /// Tests the get product at.
        /// </summary>
        [TestMethod()]
        public void TestGetProductAt()
        {
            Assert.AreSame(_model.GetProductAt(0), _productsManager.GetProductAt(0));
            Assert.AreSame(_model.GetProductAt(1), _productsManager.GetProductAt(1));
        }
    }
}