using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrderAndStorageManagementSystem.Models;
using OrderAndStorageManagementSystem.Models.Utilities;
using OrderAndStorageManagementSystemTest;
using OrderAndStorageManagementSystemTest.Properties;
using System;

namespace OrderAndStorageManagementSystem.PresentationModels.Test
{
    [TestClass()]
    public class ProductsManagementTabPagePresentationModelTest
    {
        private const string MEMBER_VARIABLE_NAME_MODEL = "_model";
        private const string MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT = "_currentSelectedProduct";
        private const string MEMBER_VARIABLE_NAME_IS_VALID_PRODUCT_INFO = "_isValidProductInfo";
        private const string MEMBER_VARIABLE_NAME_IS_EDITED_PRODUCT_INFO = "_isEditedProductInfo";
        private const string MEMBER_VARIABLE_NAME_PRODUCTS_MANAGEMENT_TAB_PAGE_STATE = "_productsManagementTabPageState";
        private ProductsManagementTabPagePresentationModel _productsManagementTabPagePresentationModel;
        private PrivateObject _target;

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        [TestInitialize()]
        [DeploymentItem(TestDefinition.OUTPUT_ITEM_FILE_PATH)]
        public void Initialize()
        {
            _productsManagementTabPagePresentationModel = new ProductsManagementTabPagePresentationModel(new Model(Resources.ProductsTableTest));
            _target = new PrivateObject(_productsManagementTabPagePresentationModel);
        }

        /// <summary>
        /// Tests the products management tab page presentation model.
        /// </summary>
        [TestMethod()]
        public void TestProductsManagementTabPagePresentationModel()
        {
            Assert.ThrowsException<ArgumentNullException>(() => new ProductsManagementTabPagePresentationModel(null));
            var productsManagementTabPagePresentationModel = new ProductsManagementTabPagePresentationModel(new Model(TestDefinition.DUMP_STRING));
            var target = new PrivateObject(productsManagementTabPagePresentationModel);
            Assert.IsNotNull(target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_MODEL));
        }

        /// <summary>
        /// Tests the set current selected product and notify observer.
        /// </summary>
        [TestMethod()]
        public void TestSetCurrentSelectedProductAndNotifyObserver()
        {
            var product = new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            int count = 0;
            _productsManagementTabPagePresentationModel.CurrentSelectedProductChanged += () => count++;
            _productsManagementTabPagePresentationModel.SetCurrentSelectedProductAndNotifyObserver(product);
            Assert.AreSame(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT), product);
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// Tests the notify observer change current selected product.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeCurrentSelectedProduct()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_SELECTED_PRODUCT = "NotifyObserverChangeCurrentSelectedProduct";
            int count = 0;
            _productsManagementTabPagePresentationModel.CurrentSelectedProductChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_SELECTED_PRODUCT);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_CURRENT_SELECTED_PRODUCT);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the notify observer change submit product info button enabled.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeSubmitProductInfoButtonEnabled()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_SUBMIT_PRODUCT_INFO_BUTTON_ENABLED = "NotifyObserverChangeSubmitProductInfoButtonEnabled";
            int count = 0;
            _productsManagementTabPagePresentationModel.SubmitProductInfoButtonEnabledChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_SUBMIT_PRODUCT_INFO_BUTTON_ENABLED);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_SUBMIT_PRODUCT_INFO_BUTTON_ENABLED);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the is submit product information button enabled.
        /// </summary>
        [TestMethod()]
        public void TestIsSubmitProductInfoButtonEnabled()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS_MANAGEMENT_TAB_PAGE_STATE, ProductsManagementTabPageState.EditProduct);
            Assert.IsFalse(_productsManagementTabPagePresentationModel.IsSubmitProductInfoButtonEnabled());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            Assert.IsFalse(_productsManagementTabPagePresentationModel.IsSubmitProductInfoButtonEnabled());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_IS_VALID_PRODUCT_INFO, true);
            Assert.IsFalse(_productsManagementTabPagePresentationModel.IsSubmitProductInfoButtonEnabled());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_IS_EDITED_PRODUCT_INFO, true);
            Assert.IsTrue(_productsManagementTabPagePresentationModel.IsSubmitProductInfoButtonEnabled());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS_MANAGEMENT_TAB_PAGE_STATE, ProductsManagementTabPageState.AddProduct);
            Assert.IsTrue(_productsManagementTabPagePresentationModel.IsSubmitProductInfoButtonEnabled());
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_IS_VALID_PRODUCT_INFO, false);
            Assert.IsFalse(_productsManagementTabPagePresentationModel.IsSubmitProductInfoButtonEnabled());
        }

        /// <summary>
        /// Tests the set is valid product information and notify observer.
        /// </summary>
        [TestMethod()]
        public void TestSetIsValidProductInfoAndNotifyObserver()
        {
            int count = 0;
            _productsManagementTabPagePresentationModel.IsValidProductInfoChanged += () => count++;
            _productsManagementTabPagePresentationModel.SetIsValidProductInfoAndNotifyObserver(true);
            Assert.IsTrue(( bool )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_IS_VALID_PRODUCT_INFO));
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// Tests the notify observer change is valid product information.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeIsValidProductInfo()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_IS_VALID_PRODUCT_INFO = "NotifyObserverChangeIsValidProductInfo";
            int count = 0;
            _productsManagementTabPagePresentationModel.SubmitProductInfoButtonEnabledChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_IS_VALID_PRODUCT_INFO);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_IS_VALID_PRODUCT_INFO);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the click submit product information button.
        /// </summary>
        [TestMethod()]
        public void TestClickSubmitProductInfoButton()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS_MANAGEMENT_TAB_PAGE_STATE, ProductsManagementTabPageState.EditProduct);
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            int count = 0;
            _productsManagementTabPagePresentationModel.IsEditedProductInfoChanged += () => count++;
            var productInfo = new ProductInfo(TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING);
            _productsManagementTabPagePresentationModel.ClickSubmitProductInfoButton(productInfo);
            Assert.AreSame(( ( Product )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT) ).ProductInfo, productInfo);
            Assert.IsFalse(( bool )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_IS_EDITED_PRODUCT_INFO));
            Assert.AreEqual(count, 1);
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS_MANAGEMENT_TAB_PAGE_STATE, ProductsManagementTabPageState.AddProduct);
            _productsManagementTabPagePresentationModel.ClickSubmitProductInfoButton(productInfo);
            Model model = ( Model )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_MODEL);
            Assert.AreSame(model.GetProduct(1).ProductInfo, productInfo);
        }

        /// <summary>
        /// Tests the set is edited product information and notify observer.
        /// </summary>
        [TestMethod()]
        public void TestSetIsEditedProductInfoAndNotifyObserver()
        {
            int count = 0;
            _productsManagementTabPagePresentationModel.IsEditedProductInfoChanged += () => count++;
            _productsManagementTabPagePresentationModel.SetIsEditedProductInfoAndNotifyObserver(true);
            Assert.IsTrue(( bool )_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_IS_EDITED_PRODUCT_INFO));
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// Tests the notify observer change is edited product information.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeIsEditedProductInfo()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_IS_EDITED_PRODUCT_INFO = "NotifyObserverChangeIsEditedProductInfo";
            int count = 0;
            _productsManagementTabPagePresentationModel.SubmitProductInfoButtonEnabledChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_IS_EDITED_PRODUCT_INFO);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_IS_EDITED_PRODUCT_INFO);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the set products management tab page state and notify observer.
        /// </summary>
        [TestMethod()]
        public void TestSetProductsManagementTabPageStateAndNotifyObserver()
        {
            int count = 0;
            _productsManagementTabPagePresentationModel.ProductsManagementTabPageStateChanged += () => count++;
            _productsManagementTabPagePresentationModel.SetProductsManagementTabPageStateAndNotifyObserver(ProductsManagementTabPageState.EditProduct);
            Assert.AreEqual(_target.GetFieldOrProperty(MEMBER_VARIABLE_NAME_PRODUCTS_MANAGEMENT_TAB_PAGE_STATE), ProductsManagementTabPageState.EditProduct);
            Assert.AreEqual(count, 1);
        }

        /// <summary>
        /// Tests the state of the notify observer change products management tab page.
        /// </summary>
        [TestMethod()]
        public void TestNotifyObserverChangeProductsManagementTabPageState()
        {
            const string MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCTS_MANAGEMENT_TAB_PAGE_STATE = "NotifyObserverChangeProductsManagementTabPageState";
            int count = 0;
            _productsManagementTabPagePresentationModel.ProductsManagementTabPageStateChanged += () => count++;
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCTS_MANAGEMENT_TAB_PAGE_STATE);
            Assert.AreEqual(count, 1);
            _target.Invoke(MEMBER_FUNCTION_NAME_NOTIFY_OBSERVER_CHANGE_PRODUCTS_MANAGEMENT_TAB_PAGE_STATE);
            Assert.AreEqual(count, 2);
        }

        /// <summary>
        /// Tests the name of the get current selected product.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentSelectedProductName()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, null);
            Assert.AreEqual(_productsManagementTabPagePresentationModel.GetCurrentSelectedProductName(), "");
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, new Product(TestDefinition.DUMP_INTEGER, "John Cena", TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            Assert.AreEqual(_productsManagementTabPagePresentationModel.GetCurrentSelectedProductName(), "John Cena");
        }

        /// <summary>
        /// Tests the get current selected product price.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentSelectedProductPrice()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, null);
            Assert.AreEqual(_productsManagementTabPagePresentationModel.GetCurrentSelectedProductPrice(), "");
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(1998), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            Assert.AreEqual(_productsManagementTabPagePresentationModel.GetCurrentSelectedProductPrice(), "1998");
        }

        /// <summary>
        /// Tests the type of the get current selected product.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentSelectedProductType()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, null);
            Assert.AreEqual(_productsManagementTabPagePresentationModel.GetCurrentSelectedProductType(), "");
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, "Diaper", new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING));
            Assert.AreEqual(_productsManagementTabPagePresentationModel.GetCurrentSelectedProductType(), "Diaper");
        }

        /// <summary>
        /// Tests the get current selected product image path.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentSelectedProductImagePath()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, null);
            Assert.AreEqual(_productsManagementTabPagePresentationModel.GetCurrentSelectedProductImagePath(), "");
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, "未來.jpg"));
            Assert.AreEqual(_productsManagementTabPagePresentationModel.GetCurrentSelectedProductImagePath(), "未來.jpg");
        }

        /// <summary>
        /// Tests the get current selected product description.
        /// </summary>
        [TestMethod()]
        public void TestGetCurrentSelectedProductDescription()
        {
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, null);
            Assert.AreEqual(_productsManagementTabPagePresentationModel.GetCurrentSelectedProductDescription(), "");
            _target.SetFieldOrProperty(MEMBER_VARIABLE_NAME_CURRENT_SELECTED_PRODUCT, new Product(TestDefinition.DUMP_INTEGER, TestDefinition.DUMP_STRING, TestDefinition.DUMP_STRING, new Money(TestDefinition.DUMP_INTEGER), TestDefinition.DUMP_INTEGER, "Land of Love.", TestDefinition.DUMP_STRING));
            Assert.AreEqual(_productsManagementTabPagePresentationModel.GetCurrentSelectedProductDescription(), "Land of Love.");
        }
    }
}