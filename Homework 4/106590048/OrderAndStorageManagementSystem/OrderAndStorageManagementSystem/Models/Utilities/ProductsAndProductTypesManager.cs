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
        /// Get the number of product pages whose products are of the given product type.
        /// </summary>
        public int GetProductTypeProductPagesCount(string productType)
        {
            int productTypeProductsCount = GetProductTypeProductsCount(productType);
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
    }
}
