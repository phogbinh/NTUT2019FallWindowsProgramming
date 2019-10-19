using OrderAndStorageManagementSystem.Models.Utilities;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class OrderProductTabPage
    {
        private const int CONTROL_INDEX_INITIAL_VALUE = -1;
        private string _tabPageProductType;
        private List<Product> _products;
        private List<OrderProductTabPageProductPage> _productPages;

        public OrderProductTabPage(int tabPageIndexData, List<Product> allProducts)
        {
            _tabPageProductType = AppDefinition.ConvertTabPageIndexToProductType(tabPageIndexData);
            InitializeProducts(allProducts);
            InitializeProductPages();
        }

        // Protest on Dr.Smell
        private void InitializeProducts(List<Product> allProducts)
        {
            _products = new List<Product>();
            foreach ( Product product in allProducts )
            {
                if ( product.Type == _tabPageProductType )
                {
                    _products.Add(product);
                }
            }
        }

        // Protest on Dr.Smell
        private void InitializeProductPages()
        {
            _productPages = new List<OrderProductTabPageProductPage>();
            int controlIndex = CONTROL_INDEX_INITIAL_VALUE;
            while ( !IsOutOfRangeOfProducts(controlIndex) )
            {
                OrderProductTabPageProductPage productPage = GetOneProductPage(ref controlIndex);
                _productPages.Add(productPage);
            }
        }

        // Protest on Dr.Smell
        private OrderProductTabPageProductPage GetOneProductPage(ref int controlIndex)
        {
            OrderProductTabPageProductPage productPage = new OrderProductTabPageProductPage();
            for ( int i = 0; i < AppDefinition.TAB_PAGE_MAX_PRODUCTS_COUNT; i++ )
            {
                controlIndex++;
                if ( IsOutOfRangeOfProducts(controlIndex) )
                {
                    break;
                }
                productPage.AddProduct(_products[ controlIndex ]);
            }
            return productPage;
        }

        // Protest on Dr.Smell
        private bool IsOutOfRangeOfProducts(int controlIndex)
        {
            return controlIndex >= _products.Count;
        }

        // Protest on Dr.Smell
        public Product GetProduct(int productPageIndex, int productIndex)
        {
            if ( productPageIndex >= _productPages.Count )
            {
                return null;
            }
            return _productPages[ productPageIndex ].GetProduct(productIndex);
        }

        // Protest on Dr.Smell
        public int GetProductPagesCount()
        {
            return _productPages.Count;
        }
    }
}
