using OrderAndStorageManagementSystem.ModelNamespace;

namespace OrderAndStorageManagementSystem.PresentationModelNamespace
{
    public class OrderPresentationModel
    {
        public RichTextBoxStates ProductNameAndDescription
        {
            get
            {
                return _productNameAndDescription;
            }
        }
        public RichTextBoxStates ProductPrice
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
        public Product CurrentSelectedProduct
        {
            get
            {
                return _currentSelectedProduct;
            }
        }

        private RichTextBoxStates _productNameAndDescription;
        private RichTextBoxStates _productPrice;
        private ControlStates _addButton;
        private Product _currentSelectedProduct;

        public OrderPresentationModel()
        {
            _productNameAndDescription = new RichTextBoxStates();
            _productPrice = new RichTextBoxStates();
            _addButton = new ControlStates();
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
    }
}