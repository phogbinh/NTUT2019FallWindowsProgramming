using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystemTest;

namespace OrderAndStorageManagementSystem.Models.OrderForm.Test
{
    [TestClass()]
    public class OrderItemTest
    {
        private OrderItem _orderItem;
        private PrivateObject _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem("OrderAndStorageManagementSystem.exe")]
        public void Initialize()
        {
            _orderItem = new OrderItem(new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            _target = new PrivateObject(_orderItem);
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