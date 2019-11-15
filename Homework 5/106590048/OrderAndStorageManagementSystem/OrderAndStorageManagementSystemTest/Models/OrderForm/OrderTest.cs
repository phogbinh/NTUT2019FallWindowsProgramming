using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystemTest;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OrderAndStorageManagementSystem.Models.OrderForm.Test
{
    [TestClass()]
    public class OrderTest
    {
        private const string MEMBER_VARIABLE_NAME_ORDER_ITEMS = "_orderItems";
        private bool _isExceptionThrown;
        private Order _order;
        private PrivateObject _target;
        private List<OrderItem> _orderItems;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem("OrderAndStorageManagementSystem.exe")]
        public void Initialize()
        {
            _isExceptionThrown = true;
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
            _orderItems.Add(new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(0), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            Assert.AreEqual(_order.GetTotalPrice("元"), "0 元");
            _orderItems.Add(new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(200), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            Assert.AreEqual(_order.GetTotalPrice("元"), "200 元");
            _orderItems.Add(new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(1234), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            Assert.AreEqual(_order.GetTotalPrice("元"), "1,434 元");
            _orderItems.Add(new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(2000000000), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            Assert.AreEqual(_order.GetTotalPrice("元"), "2,000,001,434 元");
            Assert.AreEqual(_order.GetTotalPrice(""), "2,000,001,434 ");
            Assert.AreEqual(_order.GetTotalPrice("-USD"), "2,000,001,434 -USD");
        }

        /// <summary>Tests the add product to order if product is not in order.</summary>
        [TestMethod()]
        public void TestAddProductToOrderIfProductIsNotInOrder()
        {
            Product product = new Product(0, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _order.AddProductToOrderIfProductIsNotInOrder(product);
            Assert.AreEqual(_orderItems.Count, 1);
            Assert.AreSame(_orderItems[ 0 ].Product, product);
            product = new Product(-1, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _order.AddProductToOrderIfProductIsNotInOrder(product);
            Assert.AreEqual(_orderItems.Count, 2);
            Assert.AreSame(_orderItems[ 1 ].Product, product);
            product = new Product(3, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _order.AddProductToOrderIfProductIsNotInOrder(product);
            Assert.AreEqual(_orderItems.Count, 3);
            Assert.AreSame(_orderItems[ 2 ].Product, product);
            product = new Product(3, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _order.AddProductToOrderIfProductIsNotInOrder(product);
            Assert.AreEqual(_orderItems.Count, 3);
            foreach ( OrderItem orderItem in _orderItems )
            {
                Assert.AreNotSame(orderItem.Product, product);
            }
            try
            {
                _order.AddProductToOrderIfProductIsNotInOrder(null);
                _isExceptionThrown = false;
            }
            catch ( ArgumentNullException )
            {
                Assert.IsTrue(_isExceptionThrown);
            }
        }

        /// <summary>Tests the is in order.</summary>
        [TestMethod()]
        public void TestIsInOrder()
        {
            _orderItems.Add(new OrderItem(new Product(-2, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            _orderItems.Add(new OrderItem(new Product(0, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            _orderItems.Add(new OrderItem(new Product(1, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            _orderItems.Add(new OrderItem(new Product(20, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            Assert.IsTrue(_order.IsInOrder(-2));
            Assert.IsTrue(_order.IsInOrder(0));
            Assert.IsTrue(_order.IsInOrder(1));
            Assert.IsTrue(_order.IsInOrder(20));
            Assert.IsFalse(_order.IsInOrder(-3));
            Assert.IsFalse(_order.IsInOrder(-1));
            Assert.IsFalse(_order.IsInOrder(5));
        }

        /// <summary>Tests the add order item.</summary>
        [TestMethod()]
        public void TestAddOrderItem()
        {
            OrderItem orderItem = new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            _order.AddOrderItem(orderItem);
            Assert.AreEqual(_orderItems.Count, 1);
            Assert.AreSame(_orderItems[ 0 ], orderItem);
            orderItem = new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            _order.AddOrderItem(orderItem);
            Assert.AreEqual(_orderItems.Count, 2);
            Assert.AreSame(_orderItems[ 1 ], orderItem);
            try
            {
                _order.AddOrderItem(null);
                _isExceptionThrown = false;
            }
            catch ( ArgumentNullException )
            {
                Assert.IsTrue(_isExceptionThrown);
            }
        }

        /// <summary>Tests the notify observer change order.</summary>
        [TestMethod()]
        public void TestNotifyObserverChangeOrder()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER = "NotifyObserverChangeOrder";
            int count = 0;
            _order.OrderChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER);
            Assert.AreEqual(count, 2);
        }

        /// <summary>Tests the notify observer add order.</summary>
        [TestMethod()]
        public void TestNotifyObserverAddOrder()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ADD_ORDER = "NotifyObserverAddOrder";
            int count = 0;
            _order.OrderAdded += (orderItem) => count++;
            object[] arguments = new object[] { new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)) };
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ADD_ORDER, arguments);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ADD_ORDER, arguments);
            Assert.AreEqual(count, 2);
        }

        /// <summary>Tests the remove order item at.</summary>
        [TestMethod()]
        public void TestRemoveOrderItemAt()
        {
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            }
            try
            {
                _order.RemoveOrderItemAt(-1);
                _isExceptionThrown = false;
            }
            catch ( ArgumentOutOfRangeException )
            {
                Assert.IsTrue(_isExceptionThrown);
            }
            try
            {
                _order.RemoveOrderItemAt(10);
                _isExceptionThrown = false;
            }
            catch ( ArgumentOutOfRangeException )
            {
                Assert.IsTrue(_isExceptionThrown);
            }
            OrderItem removeOrderItem = _orderItems[ 0 ];
            _order.RemoveOrderItemAt(0);
            Assert.IsFalse(_orderItems.Contains(removeOrderItem));
            removeOrderItem = _orderItems[ 8 ];
            _order.RemoveOrderItemAt(8);
            Assert.IsFalse(_orderItems.Contains(removeOrderItem));
        }

        /// <summary>Tests the notify observer remove order.</summary>
        [TestMethod()]
        public void TestNotifyObserverRemoveOrder()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_REMOVE_ORDER = "NotifyObserverRemoveOrder";
            int count = 0;
            _order.OrderRemoved += (orderItemIndex, removedProduct) => count++;
            object[] arguments = new object[] { TestDefinition.DUMP_INTEGER, new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING) };
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_REMOVE_ORDER, arguments);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_REMOVE_ORDER, arguments);
            Assert.AreEqual(count, 2);
        }

        /// <summary>Tests the get order items count.</summary>
        [TestMethod()]
        public void TestGetOrderItemsCount()
        {
            Assert.AreEqual(_order.GetOrderItemsCount(), 0);
            for ( int i = 0; i < 5; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            }
            Assert.AreEqual(_order.GetOrderItemsCount(), 5);
        }

        /// <summary>Tests the clear order.</summary>
        [TestMethod()]
        public void TestClearOrder()
        {
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            }
            _order.ClearOrder();
            Assert.AreEqual(_orderItems.Count, 0);
        }

        /// <summary>Tests the notify observer clear order.</summary>
        [TestMethod()]
        public void TestNotifyObserverClearOrder()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CLEAR_ORDER = "NotifyObserverClearOrder";
            int count = 0;
            _order.OrderCleared += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CLEAR_ORDER);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CLEAR_ORDER);
            Assert.AreEqual(count, 2);
        }

        /// <summary>Tests the set order item quantity if not exceeded storage quantity and notify observer otherwise.</summary>
        [TestMethod()]
        public void TestSetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise()
        {
            for ( int i = 0; i < 10; i++ )
            {
                OrderItem orderItem = new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), i, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
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
                _order.SetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise(9, 3);
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(_orderItems[ 9 ].OrderQuantity, 9);
            }
            int exceptionTestNumber = TestDefinition.DUMP_INTEGER;
            try
            {
                _order.SetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise(-1, 0);
                exceptionTestNumber++;
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(exceptionTestNumber, TestDefinition.DUMP_INTEGER);
            }
        }

        /// <summary>Tests the is exceeded storage quantity.</summary>
        [TestMethod()]
        public void TestIsExceededStorageQuantity()
        {
            const string MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY = "IsExceededStorageQuantity";
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), 10, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            }
            object[] arguments = new object[] { 0, 10 };
            bool isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
            Assert.IsFalse(isExceededStorageQuantity);
            arguments = new object[] { 9, 11 };
            isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
            Assert.IsTrue(isExceededStorageQuantity);
            arguments = new object[] { -1, 6 };
            int exceptionTestNumber = TestDefinition.DUMP_INTEGER;
            try
            {
                isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, TestDefinition.DUMP_INTEGER);
            }
            arguments = new object[] { 10, 2 };
            try
            {
                isExceededStorageQuantity = ( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, TestDefinition.DUMP_INTEGER);
            }
        }

        /// <summary>Tests the set order item quantity.</summary>
        [TestMethod()]
        public void TestSetOrderItemQuantity()
        {
            const string MEMBER_FUNCTION_NAME_SET_ORDER_ITEM_QUANTITY = "SetOrderItemQuantity";
            for ( int i = 0; i < 10; i++ )
            {
                OrderItem orderItem = new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
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
            int exceptionTestNumber = TestDefinition.DUMP_INTEGER;
            try
            {
                _target.Invoke(MEMBER_FUNCTION_NAME_SET_ORDER_ITEM_QUANTITY, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, TestDefinition.DUMP_INTEGER);
            }
            arguments = new object[] { 10, 5 };
            try
            {
                _target.Invoke(MEMBER_FUNCTION_NAME_SET_ORDER_ITEM_QUANTITY, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, TestDefinition.DUMP_INTEGER);
            }
        }

        /// <summary>Tests the get order item total price.</summary>
        [TestMethod()]
        public void TestGetOrderItemTotalPrice()
        {
            const string MEMBER_FUNCTION_NAME_GET_ORDER_ITEM_TOTAL_PRICE = "GetOrderItemTotalPrice";
            for ( int i = 0; i < 10; i++ )
            {
                OrderItem orderItem = new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(3000), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
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
            int exceptionTestNumber = TestDefinition.DUMP_INTEGER;
            try
            {
                _target.Invoke(MEMBER_FUNCTION_NAME_GET_ORDER_ITEM_TOTAL_PRICE, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, TestDefinition.DUMP_INTEGER);
            }
            arguments = new object[] { 10 };
            try
            {
                _target.Invoke(MEMBER_FUNCTION_NAME_GET_ORDER_ITEM_TOTAL_PRICE, arguments);
                exceptionTestNumber++;
            }
            catch ( TargetInvocationException )
            {
                Assert.AreEqual(exceptionTestNumber, TestDefinition.DUMP_INTEGER);
            }
        }

        /// <summary>Tests the notify observer change order item quantity.</summary>
        [TestMethod()]
        public void TestNotifyObserverChangeOrderItemQuantity()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER_ITEM_QUANTITY = "NotifyObserverChangeOrderItemQuantity";
            int count = 0;
            _order.OrderItemQuantityChanged += (orderItemIndex, orderItemTotalPrice) => count++;
            object[] arguments = new object[] { TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING };
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER_ITEM_QUANTITY, arguments);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ORDER_ITEM_QUANTITY, arguments);
            Assert.AreEqual(count, 2);
        }

        /// <summary>Tests the notify observer order item quantity is exceeded storage quantity.</summary>
        [TestMethod()]
        public void TestNotifyObserverOrderItemQuantityIsExceededStorageQuantity()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY = "NotifyObserverOrderItemQuantityIsExceededStorageQuantity";
            int count = 0;
            _order.OrderItemQuantityIsExceededStorageQuantity += (orderItemIndex, orderItemStorageQuantity) => count++;
            object[] arguments = new object[] { TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_INTEGER };
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_ORDER_ITEM_QUANTITY_IS_EXCEEDED_STORAGE_QUANTITY, arguments);
            Assert.AreEqual(count, 2);
        }

        /// <summary>Tests the get product with order quantity containers.</summary>
        [TestMethod()]
        public void TestGetProductWithOrderQuantityContainers()
        {
            for ( int i = 0; i < 10; i++ )
            {
                OrderItem orderItem = new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
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
                _orderItems.Add(new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            }
            Assert.AreSame(_order.GetOrderItemAt(5), _orderItems[ 5 ]);
            int exceptionTestNumber = TestDefinition.DUMP_INTEGER;
            try
            {
                _order.GetOrderItemAt(-1);
                exceptionTestNumber++;
            }
            catch ( ArgumentException )
            {
                Assert.AreEqual(exceptionTestNumber, TestDefinition.DUMP_INTEGER);
            }
        }

        /// <summary>Tests the is in order items index range.</summary>
        [TestMethod()]
        public void TestIsInOrderItemsIndexRange()
        {
            const string MEMBER_FUNCTION_NAME_IS_IN_ORDER_ITEMS_INDEX_RANGE = "IsInOrderItemsIndexRange";
            for ( int i = 0; i < 10; i++ )
            {
                _orderItems.Add(new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING)));
            }
            object[] arguments = new object[] { 0 };
            Assert.IsTrue(( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_IN_ORDER_ITEMS_INDEX_RANGE, arguments));
            arguments = new object[] { 9 };
            Assert.IsTrue(( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_IN_ORDER_ITEMS_INDEX_RANGE, arguments));
            arguments = new object[] { -1 };
            Assert.IsFalse(( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_IN_ORDER_ITEMS_INDEX_RANGE, arguments));
            arguments = new object[] { 10 };
            Assert.IsFalse(( bool )_target.Invoke(MEMBER_FUNCTION_NAME_IS_IN_ORDER_ITEMS_INDEX_RANGE, arguments));
        }
    }
}