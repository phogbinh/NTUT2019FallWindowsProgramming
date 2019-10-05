using OrderAndStorageManagementSystem.Properties;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace OrderAndStorageManagementSystem.Model
{
    public static class DataBaseManager
    {
        private const char FILE_COLUMN_LINE_DELIMITER = ',';
        private const string TABLE_FORMAT_ERROR_CORRUPTED_LINE_LENGTH = "Table format error. Insufficient line length.";
        private const int PRODUCTS_TABLE_COLUMN_COUNT = 5;
        private const int PRODUCT_ID_COLUMN_INDEX = 0;
        private const int PRODUCT_NAME_COLUMN_INDEX = 1;
        private const int PRODUCT_TYPE_COLUMN_INDEX = 2;
        private const int PRODUCT_PRICE_COLUMN_INDEX = 3;
        private const int PRODUCT_DESCRIPTION_COLUMN_INDEX = 4;
        private const char FILE_PRODUCT_DESCRIPTION_LINE_DELIMITER = '|';
        private const char APP_PRODUCT_DESCRIPTION_LINE_DELIMITER = '\n';

        /// <summary>
        /// Get products from text database.
        /// </summary>
        public static List<Product> GetProductsFromProductTable()
        {
            StringReader reader = new StringReader(Resources.ProductsTable);
            reader.ReadLine(); // Skip header row
            List<Product> products = new List<Product>();
            while ( true )
            {
                string line = reader.ReadLine();
                if ( line == null )
                {
                    break;
                }
                products.Add(CreateProduct(GetTableRowValues(line)));
            }
            return products;
        }

        /// <summary>
        /// Create table row values.
        /// </summary>
        private static string[] GetTableRowValues(string line)
        {
            string[] tableRowValues = line.Split(FILE_COLUMN_LINE_DELIMITER);
            if ( tableRowValues.Length < PRODUCTS_TABLE_COLUMN_COUNT )
            {
                throw new IOException(TABLE_FORMAT_ERROR_CORRUPTED_LINE_LENGTH);
            }
            return tableRowValues;
        }

        /// <summary>
        /// Create product from raw row data.
        /// </summary>
        private static Product CreateProduct(string[] tableRowValues)
        {
            int productId = int.Parse(tableRowValues[ PRODUCT_ID_COLUMN_INDEX ]);
            string productName = tableRowValues[ PRODUCT_NAME_COLUMN_INDEX ];
            string productType = tableRowValues[ PRODUCT_TYPE_COLUMN_INDEX ];
            int productPrice = int.Parse(tableRowValues[ PRODUCT_PRICE_COLUMN_INDEX ]);
            string productDescription = tableRowValues[ PRODUCT_DESCRIPTION_COLUMN_INDEX ].Replace(FILE_PRODUCT_DESCRIPTION_LINE_DELIMITER, APP_PRODUCT_DESCRIPTION_LINE_DELIMITER);
            return new Product(productId, productName, productType, productPrice, productDescription);
        }

        /// <summary>
        /// Get product image from resources using product ID.
        /// </summary>
        public static Bitmap GetProductImageFromResources(int productId)
        {
            string productImageName = AppDefinition.APP_DATA_BASE_PRODUCTS_TABLE_IMAGE_NAME + productId.ToString();
            return ( Bitmap )Resources.ResourceManager.GetObject(productImageName);
        }
    }
}
