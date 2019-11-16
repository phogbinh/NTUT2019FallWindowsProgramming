using System;
using System.Collections.Generic;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public class ProductsAndProductTypesManager
    {
        private const string ERROR_PRODUCTS_MANAGER_IS_NULL = "The given products manager is null.";
        private const string ERROR_PRODUCT_TYPES_MANAGER_IS_NULL = "The given product types manager is null.";
        private const string ERROR_PRODUCT_TYPE_PRODUCTS_INDEX_IS_OUT_OF_RANGE = "The product type products index calculated by the given product page index and the product index is out of range.";
        private const string ERROR_PRODUCT_TYPE_IS_NOT_EXISTING = "The given product type is not existing.";
        private const int EMPTY_PAGE_PAGES_COUNT = 1;
        private ProductsManager _productsManager;
        private ProductTypesManager _productTypesManager;

        public ProductsAndProductTypesManager(ProductsManager productsManagerData, ProductTypesManager productTypesManagerData)
        {
            if ( productsManagerData == null )
            {
                throw new ArgumentNullException(ERROR_PRODUCTS_MANAGER_IS_NULL);
            }
            if ( productTypesManagerData == null )
            {
                throw new ArgumentNullException(ERROR_PRODUCT_TYPES_MANAGER_IS_NULL);
            }
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
                return EMPTY_PAGE_PAGES_COUNT;
            }
            int fullPopulatedProductPagesCount = productTypeProductsCount / AppDefinition.TAB_PAGE_MAX_PRODUCTS_COUNT;
            return productTypeProductsCount % AppDefinition.TAB_PAGE_MAX_PRODUCTS_COUNT == 0 ? fullPopulatedProductPagesCount : fullPopulatedProductPagesCount + 1;
        }

        /// <summary>
        /// Get the number of products of the given product type.
        /// </summary>
        private int GetProductTypeProductsCount(string productType)
        {
            return GetProductTypeProducts(productType).Count;
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
                throw new ArgumentOutOfRangeException(ERROR_PRODUCT_TYPE_PRODUCTS_INDEX_IS_OUT_OF_RANGE);
            }
            return productTypeProducts[ productTypeProductsIndex ];
        }

        /// <summary>
        /// Get all products of the given product type.
        /// </summary>
        private List<Product> GetProductTypeProducts(string productType)
        {
            if ( !_productTypesManager.IsExisting(productType) )
            {
                throw new ArgumentException(ERROR_PRODUCT_TYPE_IS_NOT_EXISTING);
            }
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
