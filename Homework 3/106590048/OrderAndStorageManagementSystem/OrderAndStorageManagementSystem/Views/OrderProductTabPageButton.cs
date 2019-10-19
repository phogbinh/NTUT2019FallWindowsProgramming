using OrderAndStorageManagementSystem.Models;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.Views
{
    public class OrderProductTabPageButton : Button
    {
        public Product Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                this.Visible = _product != null;
                if ( _product != null )
                {
                    this.Image = DataBaseManager.GetProductImageFromResources(_product.Id);
                }
            }
        }
        private Product _product;

        public OrderProductTabPageButton()
        {
            /* Body intentionally empty */
        }
    }
}
