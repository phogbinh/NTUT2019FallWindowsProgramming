using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OrderAndStorageManagementSystem.Models.OrderForm.Test
{
    [TestClass()]
    public class OrderTest
    {
        private const string MEMBER_VARIABLE_NAME_ORDER_ITEMS = "_orderItems";
        private const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER = "NotifyObserverChangeOrder";
        private const string MEMBER_FUNCTION_NAME_GET_STORAGE_QUANTITY = "GetStorageQuantity";
        private const string MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY = "IsExceededStorageQuantity";
        private Order _order;
        private PrivateObject _target;
        private List<OrderItem> _orderItems;

        [TestInitialize()]
        [DeploymentItem("OrderAndStorageManagementSystem.exe")]
        public void Initialize()
        {
            _order = new Order();
            _target = new PrivateObject(_order);
            _orderItems = ( List<OrderItem> )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_ORDER_ITEMS);
        }

        [TestMethod()]
        public void TestOrder()
        {
            Assert.IsNotNull(_orderItems);
        }

        [TestMethod()]
        public void TestGetTotalPrice()
        {
            Assert.AreEqual(_order.GetTotalPrice("元"), "0 元");
            for ( int i = 0; i < 10; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(500), i, "product description", "product image path");
                OrderItem orderItem = new OrderItem(product);
                _orderItems.Add(orderItem);
            }
            Assert.AreEqual(_order.GetTotalPrice("元"), "5,000 元");
        }

        [TestMethod()]
        public void TestAddProductToOrderIfProductIsNotInOrder()
        {
            int index = 0;
            for ( int i = -5; i < 0; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(0), 0, "product description", "product image path");
                _order.AddProductToOrderIfProductIsNotInOrder(product);
                Assert.AreSame(_orderItems[ index ].Product, product);
                index++;
            }
            Assert.AreEqual(_orderItems.Count, 5);
            Product newProduct = new Product(-5, "new product name", "new product type", new Money(0), 0, "new product description", "product image path");
            _order.AddProductToOrderIfProductIsNotInOrder(newProduct);
            Assert.AreEqual(_orderItems.Count, 5);
            newProduct = new Product(0, "new product name", "new product type", new Money(0), 0, "new product description", "product image path");
            _order.AddProductToOrderIfProductIsNotInOrder(newProduct);
            Assert.AreEqual(_orderItems.Count, 6);
            Assert.AreSame(_orderItems[ 5 ].Product, newProduct);
        }

        [TestMethod()]
        public void TestIsInOrder()
        {
            for ( int i = 0; i < 10; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(i), i, "product description", "product image path");
                OrderItem orderItem = new OrderItem(product);
                _orderItems.Add(orderItem);
            }
            Assert.IsTrue(_order.IsInOrder(0));
            Assert.IsTrue(_order.IsInOrder(9));
            Assert.IsFalse(_order.IsInOrder(-1));
            Assert.IsFalse(_order.IsInOrder(10));
        }

        [TestMethod()]
        public void TestAddOrderItem()
        {
            for ( int i = 0; i < 10; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(i), i, "product description", "product image path");
                OrderItem orderItem = new OrderItem(product);
                _order.AddOrderItem(orderItem);
                Assert.AreSame(_orderItems[ i ], orderItem);
            }
            Assert.AreEqual(_orderItems.Count, 10);
            OrderItem nullOrderItem = null;
            try
            {
                _order.AddOrderItem(nullOrderItem);
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(_orderItems.Count, 10);
            }
        }

        [TestMethod()]
        public void TestNotifyObserverChangeOrder()
        {
            int count = 0;
            _order.OrderChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER);
            Assert.AreEqual(count, 2);
        }

        [TestMethod()]
        public void TestRemoveOrderItemAt()
        {
            for ( int i = 0; i < 10; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(i), i, "product description", "product image path");
                OrderItem orderItem = new OrderItem(product);
                _orderItems.Add(orderItem);
            }
            try
            {
                _order.RemoveOrderItemAt(-1);
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(_orderItems.Count, 10);
            }
            _order.RemoveOrderItemAt(0);
            Assert.AreEqual(_orderItems.Count, 9);
            Assert.IsFalse(_order.IsInOrder(0));
            try
            {
                _order.RemoveOrderItemAt(9);
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(_orderItems.Count, 9);
            }
            _order.RemoveOrderItemAt(8);
            Assert.AreEqual(_orderItems.Count, 8);
            Assert.IsFalse(_order.IsInOrder(9));
        }

        [TestMethod()]
        public void TestGetOrderItemsCount()
        {
            for ( int i = 0; i < 10; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(i), i, "product description", "product image path");
                OrderItem orderItem = new OrderItem(product);
                _orderItems.Add(orderItem);
            }
            Assert.AreEqual(_order.GetOrderItemsCount(), 10);
        }

        [TestMethod()]
        public void TestClearOrder()
        {
            for ( int i = 0; i < 10; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(i), i, "product description", "product image path");
                OrderItem orderItem = new OrderItem(product);
                _orderItems.Add(orderItem);
            }
            _order.ClearOrder();
            Assert.AreEqual(_orderItems.Count, 0);
        }

        [TestMethod()]
        public void TestSetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise()
        {
            for ( int i = 0; i < 10; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(i), i, "product description", "product image path");
                OrderItem orderItem = new OrderItem(product);
                orderItem.OrderQuantity = i;
                _orderItems.Add(orderItem);
            }
            _order.SetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise(5, 4);
            Assert.AreEqual(_orderItems[ 5 ].OrderQuantity, 4);
            _order.SetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise(0, 1);
            Assert.AreEqual(_orderItems[ 0 ].OrderQuantity, 0);
            _order.SetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise(6, 0);
            Assert.AreEqual(_orderItems[ 6 ].OrderQuantity, 0);
            try
            {
                _order.SetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise(9, -1);
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(_orderItems[ 9 ].OrderQuantity, 9);
            }
            int count = 0;
            try
            {
                _order.SetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise(-1, 0);
                count++;
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(count, 0);
            }
        }

        [TestMethod()]
        public void TestIsExceededStorageQuantity()
        {
            for ( int i = 0; i < 10; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(i), 10, "product description", "product image path");
                OrderItem orderItem = new OrderItem(product);
                _orderItems.Add(orderItem);
            }
            object[] arguments = new object[] { 0, 10 };
            bool isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
            Assert.IsFalse(isExceededStorageQuantity);
            arguments = new object[] { 9, 11 };
            isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
            Assert.IsTrue(isExceededStorageQuantity);
            arguments = new object[] { -1, 6 };
            int count = 0;
            try
            {
                isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
                count++;
            }
            catch (TargetInvocationException)
            {
                Assert.AreEqual(count, 0);
            }
            arguments = new object[] { 10, 2 };
            try
            {
                isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
                count++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(count, 0);
            }
        }

        [TestMethod()]
        public void TestGetStorageQuantity()
        {
            for ( int i = 0; i < 10; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(i), i, "product description", "product image path");
                OrderItem orderItem = new OrderItem(product);
                _orderItems.Add(orderItem);
            }
            object[] arguments = new object[] { 5 };
            int storageQuantity = ( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_STORAGE_QUANTITY, arguments);
            Assert.AreEqual(storageQuantity, 5);
            int count = 0;
            try
            {
                arguments = new object[] { -1 };
                storageQuantity = ( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_STORAGE_QUANTITY, arguments);
                count++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(count, 0);
            }
            try
            {
                arguments = new object[] { 10 };
                storageQuantity = ( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_STORAGE_QUANTITY, arguments);
                count++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(count, 0);
            }
        }

        [TestMethod()]
        public void TestGetProductWithOrderQuantityContainers()
        {
            for ( int i = 0; i < 10; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(i), i, "product description", "product image path");
                OrderItem orderItem = new OrderItem(product);
                _orderItems.Add(orderItem);
            }
            IDictionary<Product, int> productWithOrderQuantityContainers = _order.GetProductWithOrderQuantityContainers();
            foreach ( OrderItem item in _orderItems )
            {
                Assert.IsTrue(productWithOrderQuantityContainers.ContainsKey(item.Product));
                Assert.AreEqual(productWithOrderQuantityContainers[ item.Product ], item.OrderQuantity);
            }
        }

        [TestMethod()]
        public void TestGetOrderItems()
        {
            Assert.AreSame(_order.GetOrderItems(), _orderItems);
        }

        [TestMethod()]
        public void TestGetOrderItemAt()
        {
            for ( int i = 0; i < 10; i++ )
            {
                Product product = new Product(i, "product name", "product type", new Money(i), i, "product description", "product image path");
                OrderItem orderItem = new OrderItem(product);
                _orderItems.Add(orderItem);
            }
            Assert.AreSame(_order.GetOrderItemAt(5), _orderItems[ 5 ]);
            int count = 0;
            try
            {
                _order.GetOrderItemAt(-1);
                count++;
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(count, 0);
            }
        }
    }
}