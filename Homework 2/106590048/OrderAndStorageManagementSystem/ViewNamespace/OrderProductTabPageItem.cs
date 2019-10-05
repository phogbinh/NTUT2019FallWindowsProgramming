using OrderAndStorageManagementSystem.ModelNamespace;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.ViewNamespace
{
    public class OrderProductTabPageItem
    {
        public Button Button
        {
            get
            {
                return _button;
            }
        }
        private OrderForm _orderForm;
        private Button _button;
        private Product _product;

        public OrderProductTabPageItem(OrderForm orderFormData, Button buttonData)
        {
            _orderForm = orderFormData;
            _button = buttonData;
            _button.Click += ClickButton;
        }

        // Protest on Dr.Smell
        private void ClickButton(object sender, System.EventArgs events)
        {
            _orderForm.SelectProduct(_product);
        }

        // Protest on Dr.Smell
        public void SetProduct(Product newProduct)
        {
            _product = newProduct;
            _button.Image = DataBaseManager.GetProductImageFromResources(_product.Id);
        }
    }
}
