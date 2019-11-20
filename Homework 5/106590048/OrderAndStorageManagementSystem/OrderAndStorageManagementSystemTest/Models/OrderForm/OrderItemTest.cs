using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystemTest;
using System;

namespace OrderAndStorageManagementSystem.Models.OrderForm.Test
{
    [TestClass()]
    public class OrderItemTest
    {
        const string MEMBER_VARIABLE_NAME_PRODUCT = "_product";
        const string MEMBER_VARIABLE_NAME_ORDER_QUANTITY = "_orderQuantity";
        private OrderItem _orderItem;
        private PrivateObject _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            /* Body intentionally empty */
        }

        /// <summary>Tests the set property order quantity.</summary>
        [TestMethod()]
        public void TestSetPropertyOrderQuantity()
        {
            _orderItem = new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            _target = new PrivateObject(_orderItem);
            Assert.ThrowsException<ArgumentException>(() => _orderItem.OrderQuantity = -1);
            _orderItem.OrderQuantity = 0;
            Assert.AreEqual(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_ORDER_QUANTITY), 0);
            _orderItem.OrderQuantity = 1998;
            Assert.AreEqual(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_ORDER_QUANTITY), 1998);
        }

        /// <summary>Tests the order item.</summary>
        [TestMethod()]
        public void TestOrderItem()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _orderItem = new OrderItem(null));
            Product product = new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _orderItem = new OrderItem(product);
            _target = new PrivateObject(_orderItem);
            Assert.AreSame(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT), product);
            Assert.AreEqual(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_ORDER_QUANTITY), 1);
        }

        /// <summary>Tests the get total price.</summary>
        [TestMethod()]
        public void TestGetTotalPrice()
        {
            _orderItem = new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(20), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            _orderItem.OrderQuantity = 4;
            Assert.AreEqual(_orderItem.GetTotalPrice().GetString(), "80");
        }
    }
}