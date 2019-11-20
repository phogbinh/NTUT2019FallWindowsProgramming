using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystemTest;
using System;
using System.Reflection;

namespace OrderAndStorageManagementSystem.Models.Utilities.Test
{
    [TestClass()]
    public class MoneyTest
    {
        private const string MEMBER_VARIABLE_NAME_VALUE = "_value";
        private Money _money;
        private PrivateObject _target;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.DEPLOYMENT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _money = new Money(TestDefinition.DUMP_INTEGER);
            _target = new PrivateObject(_money);
        }

        /// <summary>
        /// Tests the money.
        /// </summary>
        [TestMethod()]
        public void TestMoney()
        {
            var money = new Money(5);
            var target = new PrivateObject(money);
            Assert.AreEqual(( int )target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE), 5);
        }

        /// <summary>
        /// Tests the get currency format with currency unit.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrencyFormatWithCurrencyUnit()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE, 6000);
            Assert.AreEqual(_money.GetCurrencyFormatWithCurrencyUnit("USD"), "6,000 USD");
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE, -500);
            Assert.AreEqual(_money.GetCurrencyFormatWithCurrencyUnit("VND"), "-500 VND");
        }

        /// <summary>
        /// Tests the get currency format.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrencyFormat()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE, 123456789);
            Assert.AreEqual(_money.GetCurrencyFormat(), "123,456,789");
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE, -10000);
            Assert.AreEqual(_money.GetCurrencyFormat(), "-10,000");
        }

        /// <summary>
        /// Tests the get not negative currency format.
        /// </summary>
        [TestMethod()]
        public void TestGetNotNegativeCurrencyFormat()
        {
            const string MEMBER_FUNCTION_NAME_GET_NOT_NEGATIVE_CURRENCY_FORMAT = "GetNotNegativeCurrencyFormat";
            var arguments = new object[] { -1 };
            TargetInvocationException expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.Invoke(MEMBER_FUNCTION_NAME_GET_NOT_NEGATIVE_CURRENCY_FORMAT, arguments));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(ArgumentException));
            arguments = new object[] { 0 };
            Assert.AreEqual(( string )_target.Invoke(MEMBER_FUNCTION_NAME_GET_NOT_NEGATIVE_CURRENCY_FORMAT, arguments), "0");
            arguments = new object[] { 111222333 };
            Assert.AreEqual(( string )_target.Invoke(MEMBER_FUNCTION_NAME_GET_NOT_NEGATIVE_CURRENCY_FORMAT, arguments), "111,222,333");
        }

        /// <summary>
        /// Tests the add.
        /// </summary>
        [TestMethod()]
        public void TestAdd()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE, 100);
            Assert.ThrowsException<ArgumentNullException>(() => _money.Add(null));
            _money.Add(new Money(20));
            Assert.AreEqual(( int )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE), 120);
            _money.Add(new Money(-60));
            Assert.AreEqual(( int )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE), 60);
        }

        /// <summary>
        /// Tests the multiply constant.
        /// </summary>
        [TestMethod()]
        public void TestMultiplyConstant()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE, 15);
            Money expectedMoney = _money.MultiplyConstant(4);
            var expectedMoneyTarget = new PrivateObject(expectedMoney);
            Assert.AreEqual(( int )expectedMoneyTarget.GetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE), 60);
            expectedMoney = _money.MultiplyConstant(-2);
            expectedMoneyTarget = new PrivateObject(expectedMoney);
            Assert.AreEqual(( int )expectedMoneyTarget.GetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE), -30);
            expectedMoney = _money.MultiplyConstant(0);
            expectedMoneyTarget = new PrivateObject(expectedMoney);
            Assert.AreEqual(( int )expectedMoneyTarget.GetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE), 0);
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        [TestMethod()]
        public void TestGetString()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE, 9999);
            Assert.AreEqual(_money.GetString(), "9999");
        }

        /// <summary>
        /// Tests the is negative.
        /// </summary>
        [TestMethod()]
        public void TestIsNegative()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE, -1);
            Assert.IsTrue(_money.IsNegative());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE, 0);
            Assert.IsFalse(_money.IsNegative());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_VALUE, 1);
            Assert.IsFalse(_money.IsNegative());
        }
    }
}