using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.OrderForm;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystemTest;
using OrderAndStorageManagementSystemTest.Properties;
using System;
using System.Reflection;

namespace OrderAndStorageManagementSystem.PresentationModels.Test
{
    [TestClass()]
    public class OrderPresentationModelTest
    {
        private const string MEMBER_VARIABLE_NAME_MODEL = "_model";
        private const string MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT = "_currentSelectedProduct";
        private const string MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX = "_currentProductPageIndex";
        private const string MEMBER_VARIABLE_NAME_CURRENT_TAB_PAGE_INDEX = "_currentTabPageIndex";
        private OrderPresentationModel _orderPresentationModel;
        private PrivateObject _target;
        private Model _model;

        /// <summary>Initializes this instance.</summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _orderPresentationModel = new OrderPresentationModel(new Model(Resources.ProductsTableTest));
            _target = new PrivateObject(_orderPresentationModel);
            _model = ( Model )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_MODEL);
        }

        /// <summary>
        /// Tests the order presentation model.
        /// </summary>
        [TestMethod()]
        public void TestOrderPresentationModel()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new OrderPresentationModel(null));
            var orderPresentationModel = new OrderPresentationModel(new Model(TestDefinition.DUMP_STRING));
            var target = new PrivateObject(orderPresentationModel);
            Assert.IsNotNull(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_MODEL));
        }

        /// <summary>
        /// Tests the handle model order added.
        /// </summary>
        [TestMethod()]
        public void TestHandleModelOrderAdded()
        {
            const string MEMBER_FUNCTION_NAME_HANDLE_MODEL_ORDER_ADDED = "HandleModelOrderAdded";
            var arguments = new object[] { null };
            TargetInvocationException expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.Invoke(MEMBER_FUNCTION_NAME_HANDLE_MODEL_ORDER_ADDED, arguments));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(ArgumentNullException));
            var product = new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            var orderItem = new OrderItem(product);
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, product);
            int count = 0;
            _orderPresentationModel.AddButtonEnabledChanged += () => count++;
            arguments = new object[] { orderItem };
            _target.Invoke(MEMBER_FUNCTION_NAME_HANDLE_MODEL_ORDER_ADDED, arguments);
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// Tests the handle model order removed.
        /// </summary>
        [TestMethod()]
        public void TestHandleModelOrderRemoved()
        {
            const string MEMBER_FUNCTION_NAME_HANDLE_MODEL_ORDER_REMOVED = "HandleModelOrderRemoved";
            int count = 0;
            _orderPresentationModel.AddButtonEnabledChanged += () => count++;
            var arguments = new object[] { TestDefinition.DUMP_INTEGER, ( Product )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT) };
            _target.Invoke(MEMBER_FUNCTION_NAME_HANDLE_MODEL_ORDER_REMOVED, arguments);
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// Tests the update add button if current selected product is added to or removed from order.
        /// </summary>
        [TestMethod()]
        public void TestUpdateAddButtonIfCurrentSelectedProductIsAddedToOrRemovedFromOrder()
        {
            const string MEMBER_FUNCTION_NAME_UPDATE_ADD_BUTTON_IF_CURRENT_SELECTED_PRODUCT_IS_ADDED_TO_OR_REMOVED_FROM_ORDER = "UpdateAddButtonIfCurrentSelectedProductIsAddedToOrRemovedFromOrder";
            int count = 0;
            _orderPresentationModel.AddButtonEnabledChanged += () => count++;
            var arguments = new object[] { ( Product )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT) };
            _target.Invoke(MEMBER_FUNCTION_NAME_UPDATE_ADD_BUTTON_IF_CURRENT_SELECTED_PRODUCT_IS_ADDED_TO_OR_REMOVED_FROM_ORDER, arguments);
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// Tests the update current product information and add button if changed current selected product storage quantity.
        /// </summary>
        [TestMethod()]
        public void TestUpdateCurrentProductInfoAndAddButtonIfChangedCurrentSelectedProductStorageQuantity()
        {
            const string MEMBER_FUNCTION_NAME_UPDATE_CURRENT_PRODUCT_INFO_AND_ADD_BUTTON_IF_CHANGED_CURRENT_SELECTED_PRODUCT_STORAGE_QUANTITY = "UpdateCurrentProductInfoAndAddButtonIfChangedCurrentSelectedProductStorageQuantity";
            int count = 0;
            _orderPresentationModel.AddButtonEnabledChanged += () => count++;
            _orderPresentationModel.CurrentProductInfoChanged += () => count++;
            var arguments = new object[] { ( Product )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT) };
            _target.Invoke(MEMBER_FUNCTION_NAME_UPDATE_CURRENT_PRODUCT_INFO_AND_ADD_BUTTON_IF_CHANGED_CURRENT_SELECTED_PRODUCT_STORAGE_QUANTITY, arguments);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the notify observer change add button enabled.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeAddButtonEnabled()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ADD_BUTTON_ENABLED = "NotifyObserverChangeAddButtonEnabled";
            int count = 0;
            _orderPresentationModel.AddButtonEnabledChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ADD_BUTTON_ENABLED);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_ADD_BUTTON_ENABLED);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the is add button enabled.
        /// </summary>
        [TestMethod()]
        public void TestIsAddButtonEnabled()
        {
            Assert.IsFalse(_orderPresentationModel.IsAddButtonEnabled());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, _model.GetProduct(-1));
            Assert.IsTrue(_orderPresentationModel.IsAddButtonEnabled());
        }

        /// <summary>
        /// Tests the set current product page index and notify observer.
        /// </summary>
        [TestMethod()]
        public void TestSetCurrentProductPageIndexAndNotifyObserver()
        {
            const string MEMBER_FUNCTION_NAME_SET_CURRENT_PRODUCT_PAGE_INDEX_AND_NOTIFY_OBSERVER = "SetCurrentProductPageIndexAndNotifyObserver";
            var arguments = new object[] { -1 };
            TargetInvocationException expectedException = Assert.ThrowsException<TargetInvocationException>(() => _target.Invoke(MEMBER_FUNCTION_NAME_SET_CURRENT_PRODUCT_PAGE_INDEX_AND_NOTIFY_OBSERVER, arguments));
            Assert.IsInstanceOfType(expectedException.InnerException, typeof(ArgumentException));
            int count = 0;
            _orderPresentationModel.CurrentProductPageIndexChanged += () => count++;
            arguments = new object[] { 2 };
            _target.Invoke(MEMBER_FUNCTION_NAME_SET_CURRENT_PRODUCT_PAGE_INDEX_AND_NOTIFY_OBSERVER, arguments);
            Assert.AreEqual(( int )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX), 2);
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// Tests the index of the notify observer change current product page.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeCurrentProductPageIndex()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_PRODUCT_PAGE_INDEX = "NotifyObserverChangeCurrentProductPageIndex";
            int count = 0;
            _orderPresentationModel.CurrentProductPageIndexChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_PRODUCT_PAGE_INDEX);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_PRODUCT_PAGE_INDEX);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the go to previous product page.
        /// </summary>
        [TestMethod()]
        public void TestGoToPreviousProductPage()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX, 1);
            _orderPresentationModel.GoToPreviousProductPage();
            Assert.AreEqual(( int )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX), 0);
            Assert.IsNull(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT));
        }

        /// <summary>
        /// Tests the go to next product page.
        /// </summary>
        [TestMethod()]
        public void TestGoToNextProductPage()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX, 0);
            _orderPresentationModel.GoToNextProductPage();
            Assert.AreEqual(( int )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX), 1);
            Assert.IsNull(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT));
        }

        /// <summary>
        /// Tests the select product tab page.
        /// </summary>
        [TestMethod()]
        public void TestSelectProductTabPage()
        {
            Assert.ThrowsException<ArgumentException>(() => _orderPresentationModel.SelectProductTabPage(-1));
            _orderPresentationModel.SelectProductTabPage(2);
            Assert.AreEqual(( int )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_TAB_PAGE_INDEX), 2);
            Assert.AreEqual(( int )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX), 0);
            Assert.IsNull(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT));
        }

        /// <summary>
        /// Tests the select no product.
        /// </summary>
        [TestMethod()]
        public void TestSelectNoProduct()
        {
            const string MEMBER_FUNCTION_NAME_SELECT_NO_PRODUCT = "SelectNoProduct";
            _target.Invoke(MEMBER_FUNCTION_NAME_SELECT_NO_PRODUCT);
            Assert.IsNull(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT));
        }

        /// <summary>
        /// Tests the select product.
        /// </summary>
        [TestMethod()]
        public void TestSelectProduct()
        {
            var product = new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            int count = 0;
            _orderPresentationModel.CurrentProductInfoChanged += () => count++;
            _orderPresentationModel.AddButtonEnabledChanged += () => count++;
            _orderPresentationModel.SelectProduct(product);
            Assert.AreSame(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT), product);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the notify observer change current product information.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeCurrentProductInfo()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_PRODUCT_INFO = "NotifyObserverChangeCurrentProductInfo";
            int count = 0;
            _orderPresentationModel.CurrentProductInfoChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_PRODUCT_INFO);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_PRODUCT_INFO);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the get current product storage quantity.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentProductStorageQuantity()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, null);
            Assert.AreEqual(_orderPresentationModel.GetCurrentProductStorageQuantity(), "");
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), 6, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            Assert.AreEqual(_orderPresentationModel.GetCurrentProductStorageQuantity(), "庫存數量： 6");
        }

        /// <summary>
        /// Tests the get current product name and description.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentProductNameAndDescription()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, null);
            Assert.AreEqual(_orderPresentationModel.GetCurrentProductNameAndDescription(), "");
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, new Product(TestDefinition.DUMP_INTEGER, "name", TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, "description", TestDefinition.DUMP_STRING));
            Assert.AreEqual(_orderPresentationModel.GetCurrentProductNameAndDescription(), "name\n\ndescription");
        }

        /// <summary>
        /// Tests the get current product price.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentProductPrice()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, null);
            Assert.AreEqual(_orderPresentationModel.GetCurrentProductPrice(), "");
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(2500), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            Assert.AreEqual(_orderPresentationModel.GetCurrentProductPrice(), "單價： 2,500 元");
        }

        /// <summary>
        /// Tests the get page label text.
        /// </summary>
        [TestMethod()]
        public void TestGetPageLabelText()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX, 5);
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_TAB_PAGE_INDEX, 0);
            Assert.AreEqual(_orderPresentationModel.GetPageLabelText(), "Page: 6/ 1");
        }

        /// <summary>
        /// Tests the is left arrow button enabled.
        /// </summary>
        [TestMethod()]
        public void TestIsLeftArrowButtonEnabled()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX, -1);
            Assert.IsFalse(_orderPresentationModel.IsLeftArrowButtonEnabled());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX, 0);
            Assert.IsFalse(_orderPresentationModel.IsLeftArrowButtonEnabled());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX, 1);
            Assert.IsTrue(_orderPresentationModel.IsLeftArrowButtonEnabled());
        }

        /// <summary>
        /// Tests the is right arrow button enabled.
        /// </summary>
        [TestMethod()]
        public void TestIsRightArrowButtonEnabled()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX, 0);
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_TAB_PAGE_INDEX, 0);
            Assert.IsFalse(_orderPresentationModel.IsRightArrowButtonEnabled());
        }

        /// <summary>
        /// Tests the get product at current product page.
        /// </summary>
        [TestMethod()]
        public void TestGetProductAtCurrentProductPage()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_PRODUCT_PAGE_INDEX, 0);
            Assert.AreEqual(_orderPresentationModel.GetProductAtCurrentProductPage(0, 0).Id, -1);
        }

        /// <summary>
        /// Tests the add current selected product to order if product is not in order.
        /// </summary>
        [TestMethod()]
        public void TestAddCurrentSelectedProductToOrderIfProductIsNotInOrder()
        {
            var product = new Product(1, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, product);
            _orderPresentationModel.AddCurrentSelectedProductToOrderIfProductIsNotInOrder();
            Assert.AreEqual(_model.GetOrderItemAt(0).Product, product);
        }
    }
}