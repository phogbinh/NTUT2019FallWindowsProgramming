using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models.OrderForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderAndStorageManagementSystem.Models.OrderForm.Test
{
    [TestClass()]
    public class OrderTest
    {
        private Order _order;
        private PrivateObject _target;

        [TestInitialize()]
        [DeploymentItem("OrderAndStorageManagementSystem.exe")]
        public void Initialize()
        {
            _order = new Order();
            _target = new PrivateObject(_order);
        }

        [TestMethod()]
        public void TestOrder()
        {
            Assert.IsNotNull(_target.GetFieldOrProperty("_orderItems"));
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
            Assert.Fail();
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