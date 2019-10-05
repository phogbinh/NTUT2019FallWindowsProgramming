using OrderAndStorageManagementSystem.Model;
using System;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.ViewNamespace
{
    public class ProductTabPageItem
    {
        public Product Product
        {
            get
            {
                return _product;
            }
        }
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
                Image = DataBaseManager.GetProductImageFromResources(_product.Id)
            };
            _button.Click += ClickButton;
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
