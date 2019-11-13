﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models.Utilities;
using System;
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
            Assert.IsNotNull(_orderItems);
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