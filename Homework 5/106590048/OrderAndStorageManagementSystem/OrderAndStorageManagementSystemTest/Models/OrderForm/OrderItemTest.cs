using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystemTest;
using System;

namespace OrderAndStorageManagementSystem.Models.OrderForm.Test
{
    [TestClass()]
    public class OrderItemTest
    {
        private OrderItem _orderItem;
        private PrivateObject _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.DEPLOYMENT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _orderItem = new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            _target = new PrivateObject(_orderItem);
        }


        /// <summary>Tests the set property order quantity.</summary>
        [TestMethod()]
        public void TestSetPropertyOrderQuantity()
        {
            const string MEMBER_VARIBLE_NAME_ORDER_QUANTITY = "_orderQuantity";
            Assert.ThrowsException<ArgumentException>(() => _orderItem.OrderQuantity = -1);
            _orderItem.OrderQuantity = 0;
            Assert.AreEqual(_target.GetFieldOrProperty(MEMBER_VARIBLE_NAME_ORDER_QUANTITY), 0);
            _orderItem.OrderQuantity = 1998;
            Assert.AreEqual(_target.GetFieldOrProperty(MEMBER_VARIBLE_NAME_ORDER_QUANTITY), 1998);
        }

        /// <summary>Tests the order item.</summary>
        [TestMethod()]
        public void TestOrderItem()
        {
            Assert.IsNotNull(_orderItem.Product);
            Assert.AreEqual(_orderItem.OrderQuantity, 1);
        }
    }
}