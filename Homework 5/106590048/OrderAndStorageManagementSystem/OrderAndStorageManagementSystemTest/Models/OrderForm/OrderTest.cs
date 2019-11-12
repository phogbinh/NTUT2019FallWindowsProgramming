using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models.Utilities;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.OrderForm.Test
{
    [TestClass()]
    public class OrderTest
    {
        private const string MEMBER_VARIABLE_NAME_ORDER_ITEMS = "_orderItems";
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
            Assert.IsNotNull(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_ORDER_ITEMS));
        }

        [TestMethod()]
        public void TestGetTotalPrice()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestAddProductToOrderIfProductIsNotInOrder()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestIsInOrder()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestAddOrderItem()
        {
            Product product = new Product(0, "product name", "product type", new Money(0), 0, "product description", "product image path");
            OrderItem orderItem = new OrderItem(product);
            _order.AddOrderItem(orderItem);
            List<OrderItem> orderItems = ( List<OrderItem> ) _target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_ORDER_ITEMS);
            Assert.AreEqual(orderItems.Count, 1);
            Assert.AreSame(orderItems[0], orderItem);
        }

        [TestMethod()]
        public void TestRemoveOrderItemAt()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetOrderItemsCount()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestClearOrder()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestSetOrderItemQuantityIfNotExceededStorageQuantityAndNotifyObserverOtherwise()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetProductWithOrderQuantityContainers()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetOrderItems()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TestGetOrderItemAt()
        {
            Assert.Fail();
        }
    }
}