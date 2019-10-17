using OrderAndStorageManagementSystem.ModelNamespace;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.ViewNamespace
{
    public class OrderProductTabPageButton
    {
        public Button Button
        {
            get
            {
                return _button;
            }
        }
        public Product Product
        {
            set
            {
                _product = value;
                _button.Visible = _product != null;
                if ( _product != null )
                {
                    _button.Image = DataBaseManager.GetProductImageFromResources(_product.Id);
                }
            }
        }
        private OrderForm _orderForm;
        private Button _button;
        private Product _product;

        public OrderProductTabPageButton(OrderForm orderFormData, Button buttonData)
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
    }
}
