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

        /// <summary>
        /// Initialize the list of products belonging to this tab page.
        /// </summary>
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

        /// <summary>
        /// Initialize product pages for this tab page.
        /// </summary>
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

        /// <summary>
        /// Get one product page out of the list of products belonging to this tab page, starting from the controlIndex.
        /// </summary>
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

        /// <summary>
        /// Return true if the controlIndex is out of range of the list of products belonging to this tab page.
        /// </summary>
        private bool IsOutOfRangeOfProducts(int controlIndex)
        {
            return controlIndex >= _products.Count;
        }

        /// <summary>
        /// Get the product at productIndex in the product page whose index is productPageIndex.
        /// </summary>
        public Product GetProduct(int productPageIndex, int productIndex)
        {
            if ( productPageIndex >= _productPages.Count )
            {
                return null;
            }
            return _productPages[ productPageIndex ].GetProduct(productIndex);
        }

        /// <summary>
        /// Get the number of product pages of this tab page.
        /// </summary>
        public int GetProductPagesCount()
        {
            return _productPages.Count;
        }
    }
}
