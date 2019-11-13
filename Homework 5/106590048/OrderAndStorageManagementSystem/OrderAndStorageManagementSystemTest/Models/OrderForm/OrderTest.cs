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
        private const string MEMBER_FUNCTION_NAME_SET_ORDER_ITEM_QUANTITY = "SetOrderItemQuantity";
        private const string MEMBER_FUNCTION_NAME_GET_ORDER_ITEM_TOTAL_PRICE = "GetOrderItemTotalPrice";
        private const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER_ITEM_QUANTITY = "NotifyObserverChangeOrderItemQuantity";
        private const int DUMP_INTEGER = 0;
        private const string DUMP_STRING = "";
        private Order _order;
        private PrivateObject _target;
        private List<OrderItem> _orderItems;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem("OrderAndStorageManagementSystem.exe")]
        public void Initialize()
        {
            _order = new Order();
            _target = new PrivateObject(_order);
            _orderItems = ( List<OrderItem> )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_ORDER_ITEMS);
        }

        /// <summary>Tests the order.</summary>
        [TestMethod()]
        public void TestOrder()
        {
            Assert.IsNotNull(_orderItems);
        }

        /// <summary>Tests the get total price.</summary>
        [TestMethod()]
        public void TestGetTotalPrice()
        {
            Assert.AreEqual(_order.GetTotalPrice("元"), "0 元");
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(500), DUMP_INTEGER, DUMP_STRING, DUMP_STRING)));
            }
            Assert.AreEqual(_order.GetTotalPrice("元"), "5,000 元");
        }

        /// <summary>Tests the add product to order if product is not in order.</summary>
        [TestMethod()]
        public void TestAddProductToOrderIfProductIsNotInOrder()
        {
            int index = 0;
            for ( int i = -5; i < 0; i++ )
            {
                Product product = new Product(i, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), DUMP_INTEGER, DUMP_STRING, DUMP_STRING);
                _order.AddProductToOrderIfProductIsNotInOrder(product);
                Assert.AreSame(_orderItems[ index ].Product, product);
                index++;
            }
            Assert.AreEqual(_orderItems.Count, 5);
            Product newProduct = new Product(-5, "", "", new Money(0), 0, "", "");
            _order.AddProductToOrderIfProductIsNotInOrder(newProduct);
            Assert.AreEqual(_orderItems.Count, 5);
            newProduct = new Product(0, "", "", new Money(0), 0, "", "");
            _order.AddProductToOrderIfProductIsNotInOrder(newProduct);
            Assert.AreEqual(_orderItems.Count, 6);
            Assert.AreSame(_orderItems[ 5 ].Product, newProduct);
        }

        /// <summary>Tests the is in order.</summary>
        [TestMethod()]
        public void TestIsInOrder()
        {
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(i, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), DUMP_INTEGER, DUMP_STRING, DUMP_STRING)));
            }
            Assert.IsTrue(_order.IsInOrder(0));
            Assert.IsTrue(_order.IsInOrder(9));
            Assert.IsFalse(_order.IsInOrder(-1));
            Assert.IsFalse(_order.IsInOrder(10));
        }

        /// <summary>Tests the add order item.</summary>
        [TestMethod()]
        public void TestAddOrderItem()
        {
            for ( int i = 0; i < 10; i++ )
            {
                OrderItem orderItem = new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), DUMP_INTEGER, DUMP_STRING, DUMP_STRING));
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

        /// <summary>Tests the notify observer change order.</summary>
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

        /// <summary>Tests the remove order item at.</summary>
        [TestMethod()]
        public void TestRemoveOrderItemAt()
        {
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), DUMP_INTEGER, DUMP_STRING, DUMP_STRING)));
            }
            try
            {
                _order.RemoveOrderItemAt(-1);
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(_orderItems.Count, 10);
            }
            OrderItem removeOrderItem = _orderItems[ 0 ];
            _order.RemoveOrderItemAt(0);
            Assert.IsFalse(_orderItems.Contains(removeOrderItem));
            try
            {
                _order.RemoveOrderItemAt(9);
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(_orderItems.Count, 9);
            }
            removeOrderItem = _orderItems[ 8 ];
            _order.RemoveOrderItemAt(8);
            Assert.IsFalse(_orderItems.Contains(removeOrderItem));
        }

        /// <summary>Tests the get order items count.</summary>
        [TestMethod()]
        public void TestGetOrderItemsCount()
        {
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), DUMP_INTEGER, DUMP_STRING, DUMP_STRING)));
            }
            Assert.AreEqual(_order.GetOrderItemsCount(), 10);
        }

        /// <summary>Tests the clear order.</summary>
        [TestMethod()]
        public void TestClearOrder()
        {
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), DUMP_INTEGER, DUMP_STRING, DUMP_STRING)));
            }
            _order.ClearOrder();
            Assert.AreEqual(_orderItems.Count, 0);
        }

        /// <summary>Tests the set order item quantity if not exceeded storage quantity and notify observer otherwise.</summary>
        [TestMethod()]
        public void TestSetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise()
        {
            for ( int i = 0; i < 10; i++ )
            {
                OrderItem orderItem = new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), i, DUMP_STRING, DUMP_STRING));
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
            int exceptionTestNumber = DUMP_INTEGER;
            try
            {
                _order.SetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise(-1, 0);
                exceptionTestNumber++;
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(exceptionTestNumber, DUMP_INTEGER);
            }
        }

        /// <summary>Tests the is exceeded storage quantity.</summary>
        [TestMethod()]
        public void TestIsExceededStorageQuantity()
        {
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), 10, DUMP_STRING, DUMP_STRING)));
            }
            object[] arguments = new object[] { 0, 10 };
            bool isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
            Assert.IsFalse(isExceededStorageQuantity);
            arguments = new object[] { 9, 11 };
            isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
            Assert.IsTrue(isExceededStorageQuantity);
            arguments = new object[] { -1, 6 };
            int exceptionTestNumber = DUMP_INTEGER;
            try
            {
                isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, DUMP_INTEGER);
            }
            arguments = new object[] { 10, 2 };
            try
            {
                isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, DUMP_INTEGER);
            }
        }

        /// <summary>Tests the set order item quantity.</summary>
        [TestMethod()]
        public void TestSetOrderItemQuantity()
        {
            for ( int i = 0; i < 10; i++ )
            {
                OrderItem orderItem = new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), DUMP_INTEGER, DUMP_STRING, DUMP_STRING));
                orderItem.OrderQuantity = 3;
                _orderItems.Add(orderItem);
            }
            object[] arguments = new object[] { 0, 10 };
            _target.Invoke(MEMBER_FUNCTION_NAME_SET_ORDER_ITEM_QUANTITY, arguments);
            Assert.AreEqual(_orderItems[ 0 ].OrderQuantity, 10);
            arguments = new object[] { 9, 3 };
            _target.Invoke(MEMBER_FUNCTION_NAME_SET_ORDER_ITEM_QUANTITY, arguments);
            Assert.AreEqual(_orderItems[ 9 ].OrderQuantity, 3);
            arguments = new object[] { -1, 5 };
            int exceptionTestNumber = DUMP_INTEGER;
            try
            {
                _target.Invoke(MEMBER_FUNCTION_NAME_SET_ORDER_ITEM_QUANTITY, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, DUMP_INTEGER);
            }
            arguments = new object[] { 10, 5 };
            try
            {
                _target.Invoke(MEMBER_FUNCTION_NAME_SET_ORDER_ITEM_QUANTITY, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, DUMP_INTEGER);
            }
        }

        /// <summary>Tests the get order item total price.</summary>
        [TestMethod()]
        public void TestGetOrderItemTotalPrice()
        {
            for ( int i = 0; i < 10; i++ )
            {
                OrderItem orderItem = new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(3000), DUMP_INTEGER, DUMP_STRING, DUMP_STRING));
                orderItem.OrderQuantity = i;
                _orderItems.Add(orderItem);
            }
            object[] arguments = new object[] { 0 };
            string orderItemTotalPrice = ( string )_target.Invoke(MEMBER_FUNCTION_NAME_GET_ORDER_ITEM_TOTAL_PRICE, arguments);
            Assert.AreEqual(orderItemTotalPrice, "0");
            arguments = new object[] { 9 };
            orderItemTotalPrice = ( string )_target.Invoke(MEMBER_FUNCTION_NAME_GET_ORDER_ITEM_TOTAL_PRICE, arguments);
            Assert.AreEqual(orderItemTotalPrice, "27,000");
            arguments = new object[] { -1 };
            int exceptionTestNumber = DUMP_INTEGER;
            try
            {
                _target.Invoke(MEMBER_FUNCTION_NAME_GET_ORDER_ITEM_TOTAL_PRICE, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, DUMP_INTEGER);
            }
            arguments = new object[] { 10 };
            try
            {
                _target.Invoke(MEMBER_FUNCTION_NAME_GET_ORDER_ITEM_TOTAL_PRICE, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, DUMP_INTEGER);
            }
        }

        [TestMethod()]
        public void TestNotifyObserverChangeOrderItemQuantity()
        {
            int count = 0;
            _order.OrderItemQuantityChanged += (orderItemIndex, orderItemTotalPrice) => count++;
            object[] arguments = new object[] { DUMP_INTEGER, DUMP_STRING };
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER_ITEM_QUANTITY, arguments);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER_ITEM_QUANTITY, arguments);
            Assert.AreEqual(count, 2);
        }

        /// <summary>Tests the get storage quantity.</summary>
        [TestMethod()]
        public void TestGetStorageQuantity()
        {
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), i, DUMP_STRING, DUMP_STRING)));
            }
            object[] arguments = new object[] { 5 };
            int storageQuantity = ( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_STORAGE_QUANTITY, arguments);
            Assert.AreEqual(storageQuantity, 5);
            int exceptionTestNumber = DUMP_INTEGER;
            try
            {
                arguments = new object[] { -1 };
                storageQuantity = ( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_STORAGE_QUANTITY, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, DUMP_INTEGER);
            }
            try
            {
                arguments = new object[] { 10 };
                storageQuantity = ( int )_target.Invoke(MEMBER_FUNCTION_NAME_GET_STORAGE_QUANTITY, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, DUMP_INTEGER);
            }
        }

        /// <summary>Tests the get product with order quantity containers.</summary>
        [TestMethod()]
        public void TestGetProductWithOrderQuantityContainers()
        {
            for ( int i = 0; i < 10; i++ )
            {
                OrderItem orderItem = new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), DUMP_INTEGER, DUMP_STRING, DUMP_STRING));
                orderItem.OrderQuantity = i + 10;
                _orderItems.Add(orderItem);
            }
            IDictionary<Product, int> productWithOrderQuantityContainers = _order.GetProductWithOrderQuantityContainers();
            foreach ( OrderItem item in _orderItems )
            {
                Assert.IsTrue(productWithOrderQuantityContainers.ContainsKey(item.Product));
                Assert.AreEqual(productWithOrderQuantityContainers[ item.Product ], item.OrderQuantity);
            }
        }

        /// <summary>Tests the get order items.</summary>
        [TestMethod()]
        public void TestGetOrderItems()
        {
            Assert.AreSame(_order.GetOrderItems(), _orderItems);
        }

        /// <summary>Tests the get order item at.</summary>
        [TestMethod()]
        public void TestGetOrderItemAt()
        {
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(DUMP_INTEGER, DUMP_STRING, DUMP_STRING, new Money(DUMP_INTEGER), DUMP_INTEGER, DUMP_STRING, DUMP_STRING)));
            }
            Assert.AreSame(_order.GetOrderItemAt(5), _orderItems[ 5 ]);
            int exceptionTestNumber = DUMP_INTEGER;
            try
            {
                _order.GetOrderItemAt(-1);
                exceptionTestNumber++;
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(exceptionTestNumber, DUMP_INTEGER);
            }
        }
    }
}