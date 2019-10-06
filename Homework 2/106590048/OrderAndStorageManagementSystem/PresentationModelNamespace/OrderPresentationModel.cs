using OrderAndStorageManagementSystem.ModelNamespace;

namespace OrderAndStorageManagementSystem.PresentationModelNamespace
{
    public class OrderPresentationModel
    {
        private const int CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE = 0;
        public ControlStates ProductNameAndDescription
        {
            get
            {
                return _productNameAndDescription;
            }
        }
        public ControlStates ProductPrice
        {
            get
            {
                return _productPrice;
            }
        }
        public ControlStates AddButton
        {
            get
            {
                return _addButton;
            }
        }
        public ControlStates CartTotalPrice
        {
            get
            {
                return _cartTotalPrice;
            }
        }
        public ControlStates PageLabel
        {
            get
            {
                return _pageLabel;
            }
        }
        public Product CurrentSelectedProduct
        {
            get
            {
                return _currentSelectedProduct;
            }
        }
        private OrderModel _orderModel;
        private Model _model;
        private ControlStates _productNameAndDescription;
        private ControlStates _productPrice;
        private ControlStates _addButton;
        private ControlStates _cartTotalPrice;
        private ControlStates _pageLabel;
        private Product _currentSelectedProduct;
        private int _currentProductPageIndex;

        public OrderPresentationModel(OrderModel orderModelData, Model modelData)
        {
            _orderModel = orderModelData;
            _model = modelData;
            _productNameAndDescription = new ControlStates();
            _productPrice = new ControlStates();
            _addButton = new ControlStates();
            _cartTotalPrice = new ControlStates();
            _pageLabel = new ControlStates();
        }

        /// <summary>
        /// Select a product.
        /// </summary>
        public void SelectProduct(Product product)
        {
            _currentSelectedProduct = product;
            SetProductInfoText(product.GetProductNameAndDescription(), AppDefinition.PRODUCT_PRICE_TEXT + product.Price.ToString());
            _addButton.Enabled = true;
        }

        /// <summary>
        /// Select no product.
        /// </summary>
        public void SelectNoProduct()
        {
            _currentSelectedProduct = null;
            SetProductInfoText("", "");
            _addButton.Enabled = false;
        }

        /// <summary>
        /// Set product info text, including product name, description and price.
        /// </summary>
        private void SetProductInfoText(string productNameAndDescription, string productPrice)
        {
            _productNameAndDescription.Text = productNameAndDescription;
            _productPrice.Text = productPrice;
        }

        // Protest on Dr.Smell
        private void ResetCurrentProductPageIndex()
        {
            _currentProductPageIndex = CURRENT_PRODUCT_PAGE_INDEX_INITIAL_VALUE;
        }

        // Protest on Dr.Smell
        public Product GetProduct(int tabPageIndex, int productIndex)
        {
            return _orderModel.GetProduct(tabPageIndex, _currentProductPageIndex, productIndex);
        }

        // Protest on Dr.Smell
        public void AddCurrentSelectedProductToOrder()
        {
            _model.AddProductToOrder(_currentSelectedProduct);
            _cartTotalPrice.Text = "總金額： " + _model.GetOrderTotalPrice();
        }

        // Protest on Dr.Smell
        public void SelectProductTabPage(int tabPageIndex)
        {
            ResetCurrentProductPageIndex();
            _pageLabel.Text = "Page: " + "?/ " + _orderModel.GetTabPageProductPagesCount(tabPageIndex).ToString();
        }
    }
}