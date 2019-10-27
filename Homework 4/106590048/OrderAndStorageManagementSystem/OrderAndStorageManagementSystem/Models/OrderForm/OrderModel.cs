using OrderAndStorageManagementSystem.Models.Utilities;
using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.OrderForm
{
    public class OrderModel
    {
        private List<Product> _products;
        private List<OrderProductTabPage> _tabPages;

        public OrderModel(List<Product> productsData)
        {
            _products = productsData;
            InitializeTabPages();
        }

        /// <summary>
        /// Initialize all tab pages.
        /// </summary>
        private void InitializeTabPages()
        {
            _tabPages = new List<OrderProductTabPage>();
            for ( int i = 0; i < AppDefinition.TAB_PAGES_COUNT; i++ )
            {
                OrderProductTabPage tabPage = new OrderProductTabPage(i, _products);
                _tabPages.Add(tabPage);
            }
        }

        /// <summary>
        /// Get the product at productIndex in the product page of productPageIndex, which is inside the tab page whose index is tabPageIndex.
        /// </summary>
        public Product GetProduct(int tabPageIndex, int productPageIndex, int productIndex)
        {
            if ( tabPageIndex >= AppDefinition.TAB_PAGES_COUNT )
            {
                throw new ArgumentException(AppDefinition.ERROR_TAB_PAGE_INDEX_OUT_OF_RANGE);
            }
            return _tabPages[ tabPageIndex ].GetProduct(productPageIndex, productIndex);
        }

        /// <summary>
        /// Get the number of product pages of the tab page whose index is tabPageIndex.
        /// </summary>
        public int GetTabPageProductPagesCount(int tabPageIndex)
        {
            if ( tabPageIndex >= AppDefinition.TAB_PAGES_COUNT )
            {
                throw new ArgumentException(AppDefinition.ERROR_TAB_PAGE_INDEX_OUT_OF_RANGE);
            }
            return _tabPages[ tabPageIndex ].GetProductPagesCount();
        }
    }
}
