using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class ProductsAndProductTypesManager
    {
        private ProductsManager _productsManager;
        private ProductTypesManager _productTypesManager;

        public ProductsAndProductTypesManager(ProductsManager productsManagerData, ProductTypesManager productTypesManagerData)
        {
            _productsManager = productsManagerData;
            _productTypesManager = productTypesManagerData;
        }

        /// <summary>
        /// Get the number of product pages whose products are of the given product type. Return 1 if there is no product of productType.
        /// </summary>
        public int GetProductTypeProductPagesCount(string productType)
        {
            int productTypeProductsCount = GetProductTypeProductsCount(productType);
            if ( productTypeProductsCount == 0 )
            {
                return 1;
            }
            int completelyPopulatedProductPagesCount = productTypeProductsCount / AppDefinition.TAB_PAGE_MAX_PRODUCTS_COUNT;
            return productTypeProductsCount % AppDefinition.TAB_PAGE_MAX_PRODUCTS_COUNT == 0 ? completelyPopulatedProductPagesCount : completelyPopulatedProductPagesCount + 1;
        }

        /// <summary>
        /// Get the number of products of the given product type.
        /// </summary>
        private int GetProductTypeProductsCount(string productType)
        {
            int productsCount = 0;
            foreach ( Product product in _productsManager.Products )
            {
                if ( product.Type == productType )
                {
                    productsCount++;
                }
            }
            return productsCount;
        }

        /// <summary>
        /// Get the product at productIndex in the product page of productPageIndex, which is of type productType. Return null if product does not exist.
        /// </summary>
        public Product GetProduct(string productType, int productPageIndex, int productIndex)
        {
            List<Product> productTypeProducts = GetProductTypeProducts(productType);
            if ( productTypeProducts.Count == 0 )
            {
                return null;
            }
            int productTypeProductsIndex = productPageIndex * AppDefinition.TAB_PAGE_MAX_PRODUCTS_COUNT + productIndex;
            if ( !AppDefinition.IsInIntervalRange(productTypeProductsIndex, 0, productTypeProducts.Count - 1) )
            {
                return null;
            }
            return productTypeProducts[ productTypeProductsIndex ];
        }

        /// <summary>
        /// Get all products of the given product type.
        /// </summary>
        private List<Product> GetProductTypeProducts(string productType)
        {
            var productTypeProducts = new List<Product>();
            foreach ( Product product in _productsManager.Products )
            {
                if ( product.Type == productType )
                {
                    productTypeProducts.Add(product);
                }
            }
            return productTypeProducts;
        }
    }
}
