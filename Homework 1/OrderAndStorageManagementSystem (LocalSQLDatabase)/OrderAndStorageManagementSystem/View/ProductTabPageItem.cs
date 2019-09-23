using OrderAndStorageManagementSystem.Model;
using OrderAndStorageManagementSystem.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.View
{
    public class ProductTabPageItem
    {
        public Button Button
        {
            get
            {
                return _button;
            }
        }
        private OrderForm _orderForm;
        private Product _product;
        private Button _button;
        public ProductTabPageItem(OrderForm orderFormData, Product productData)
        {
            _orderForm = orderFormData;
            _product = productData;
            _button = new Button()
            {
                Image = GetProductImage(_product.Id)
            };
            _button.Click += ClickButton;
        }

        /// <summary>
        /// Get product image from resources using productId.
        /// </summary>
        private Bitmap GetProductImage(int productId)
        {
            return ( Bitmap )Resources.ResourceManager.GetObject(AppDefinition.APP_DATA_BASE_PRODUCTS_TABLE_IMAGE_NAME + productId.ToString());
        }

        /// <summary>
        /// Display product info on button clicked. At the same time, update the current selected product.
        /// </summary>
        private void ClickButton(object sender, EventArgs events)
        {
            _orderForm.SelectProduct(_product);
        }
    }
}
