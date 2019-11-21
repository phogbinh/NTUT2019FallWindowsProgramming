using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystemTest;
using OrderAndStorageManagementSystemTest.Properties;
using System;

namespace OrderAndStorageManagementSystem.PresentationModels.Test
{
    [TestClass()]
    public class ProductTypesManagementTabPagePresentationModelTest
    {
        private const string MEMBER_VARIABLE_NAME_MODEL = "_model";
        private const string MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT_TYPE = "_currentSelectedProductType";
        private const string MEMBER_VARIABLE_NAME_IS_VALID_PRODUCT_TYPE_INFO = "_isValidProductTypeInfo";
        private const string MEMBER_VARIABLE_NAME_PRODUCT_TYPES_MANAGEMENT_TAB_PAGE_STATE = "_productTypesManagementTabPageState";
        private ProductTypesManagementTabPagePresentationModel _productTypesManagementTabPagePresentationModel;
        private PrivateObject _target;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _productTypesManagementTabPagePresentationModel = new ProductTypesManagementTabPagePresentationModel(new Model(Resources.ProductsTableTest));
            _target = new PrivateObject(_productTypesManagementTabPagePresentationModel);
        }

        /// <summary>
        /// Tests the product types management tab page presentation model.
        /// </summary>
        [TestMethod()]
        public void TestProductTypesManagementTabPagePresentationModel()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ProductTypesManagementTabPagePresentationModel(null));
            var productTypesManagementTabPagePresentationModel = new ProductTypesManagementTabPagePresentationModel(new Model(TestDefinition.DUMP_STRING));
            var target = new PrivateObject(productTypesManagementTabPagePresentationModel);
            Assert.IsNotNull(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_MODEL));
        }

        /// <summary>
        /// Tests the set current selected product type and notify observer.
        /// </summary>
        [TestMethod()]
        public void TestSetCurrentSelectedProductTypeAndNotifyObserver()
        {
            int count = 0;
            _productTypesManagementTabPagePresentationModel.CurrentSelectedProductTypeChanged += () => count++;
            _productTypesManagementTabPagePresentationModel.SetCurrentSelectedProductTypeAndNotifyObserver("New Type");
            Assert.AreSame(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT_TYPE), "New Type");
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// Tests the type of the notify observer change current selected product.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeCurrentSelectedProductType()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_SELECTED_PRODUCT_TYPE = "NotifyObserverChangeCurrentSelectedProductType";
            int count = 0;
            _productTypesManagementTabPagePresentationModel.CurrentSelectedProductTypeChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_SELECTED_PRODUCT_TYPE);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_SELECTED_PRODUCT_TYPE);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the notify observer change submit product type information button enabled.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeSubmitProductTypeInfoButtonEnabled()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_SUBMIT_PRODUCT_TYPE_INFO_BUTTON_ENABLED = "NotifyObserverChangeSubmitProductTypeInfoButtonEnabled";
            int count = 0;
            _productTypesManagementTabPagePresentationModel.SubmitProductTypeInfoButtonEnabledChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_SUBMIT_PRODUCT_TYPE_INFO_BUTTON_ENABLED);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_SUBMIT_PRODUCT_TYPE_INFO_BUTTON_ENABLED);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the is submit product type information button enabled.
        /// </summary>
        [TestMethod()]
        public void TestIsSubmitProductTypeInfoButtonEnabled()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES_MANAGEMENT_TAB_PAGE_STATE, ProductTypesManagementTabPageState.AddProductType);
            Assert.IsFalse(_productTypesManagementTabPagePresentationModel.IsSubmitProductTypeInfoButtonEnabled());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_IS_VALID_PRODUCT_TYPE_INFO, true);
            Assert.IsTrue(_productTypesManagementTabPagePresentationModel.IsSubmitProductTypeInfoButtonEnabled());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES_MANAGEMENT_TAB_PAGE_STATE, ProductTypesManagementTabPageState.ViewProductType);
            Assert.IsFalse(_productTypesManagementTabPagePresentationModel.IsSubmitProductTypeInfoButtonEnabled());
        }

        /// <summary>
        /// Tests the set is valid product type information and notify observer.
        /// </summary>
        [TestMethod()]
        public void TestSetIsValidProductTypeInfoAndNotifyObserver()
        {
            int count = 0;
            _productTypesManagementTabPagePresentationModel.IsValidProductTypeInfoChanged += () => count++;
            _productTypesManagementTabPagePresentationModel.SetIsValidProductTypeInfoAndNotifyObserver(true);
            Assert.IsTrue(( bool )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_IS_VALID_PRODUCT_TYPE_INFO));
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// Tests the notify observer change is valid product information.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeIsValidProductInfo()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_IS_VALID_PRODUCT_TYPE_INFO = "NotifyObserverChangeIsValidProductInfo";
            int count = 0;
            _productTypesManagementTabPagePresentationModel.SubmitProductTypeInfoButtonEnabledChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_IS_VALID_PRODUCT_TYPE_INFO);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_IS_VALID_PRODUCT_TYPE_INFO);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the click submit product type information button.
        /// </summary>
        [TestMethod()]
        public void TestClickSubmitProductTypeInfoButton()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES_MANAGEMENT_TAB_PAGE_STATE, ProductTypesManagementTabPageState.AddProductType);
            _productTypesManagementTabPagePresentationModel.ClickSubmitProductTypeInfoButton("類別");
            Model model = ( Model )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_MODEL);
            Assert.AreEqual(model.GetProductTypes()[ 3 ], "類別");
        }

        /// <summary>
        /// Tests the set product types management tab page state and notify observer.
        /// </summary>
        [TestMethod()]
        public void TestSetProductTypesManagementTabPageStateAndNotifyObserver()
        {
            int count = 0;
            _productTypesManagementTabPagePresentationModel.ProductTypesManagementTabPageStateChanged += () => count++;
            _productTypesManagementTabPagePresentationModel.SetProductTypesManagementTabPageStateAndNotifyObserver(ProductTypesManagementTabPageState.AddProductType);
            Assert.AreEqual(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCT_TYPES_MANAGEMENT_TAB_PAGE_STATE), ProductTypesManagementTabPageState.AddProductType);
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// Tests the state of the notify observer change product types management tab page.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeProductTypesManagementTabPageState()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCT_TYPES_MANAGEMENT_TAB_PAGE_STATE = "NotifyObserverChangeProductTypesManagementTabPageState";
            int count = 0;
            _productTypesManagementTabPagePresentationModel.ProductTypesManagementTabPageStateChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCT_TYPES_MANAGEMENT_TAB_PAGE_STATE);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCT_TYPES_MANAGEMENT_TAB_PAGE_STATE);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the name of the get current selected product type.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentSelectedProductTypeName()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT_TYPE, null);
            Assert.AreEqual(_productTypesManagementTabPagePresentationModel.GetCurrentSelectedProductTypeName(), "");
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT_TYPE, "日本");
            Assert.AreEqual(_productTypesManagementTabPagePresentationModel.GetCurrentSelectedProductTypeName(), "日本");
        }

        /// <summary>
        /// Tests the get current selected product type products.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentSelectedProductTypeProducts()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT_TYPE, null);
            Assert.AreEqual(_productTypesManagementTabPagePresentationModel.GetCurrentSelectedProductTypeProducts().Count, 0);
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT_TYPE, "主機板");
            Assert.AreEqual(_productTypesManagementTabPagePresentationModel.GetCurrentSelectedProductTypeProducts().Count, 1);
        }
    }
}