using System.Collections.Generic;
using System.IO;

namespace OrderAndStorageManagementSystem.Models.Utilities
{
    public static class DataBaseManager
    {
        private const string ERROR_LINE_VALUES_IS_OF_CORRUPTED_LENGTH = "Line values is of corrupted length.";
        private const int PRODUCT_ATTRIBUTES_COUNT = 5;
        private const int PRODUCT_ID_COLUMN_INDEX = 0;
        private const int PRODUCT_NAME_COLUMN_INDEX = 1;
        private const int PRODUCT_TYPE_COLUMN_INDEX = 2;
        private const int PRODUCT_PRICE_COLUMN_INDEX = 3;
        private const int PRODUCT_STORAGE_QUANTITY_COLUMN_INDEX = 4;
        private const int PRODUCT_DESCRIPTION_COLUMN_INDEX = 5;
        private const char FILE_PRODUCT_DESCRIPTION_LINE_DELIMITER = '|';
        private const char APP_PRODUCT_DESCRIPTION_LINE_DELIMITER = '\n';

        /// <summary>
        /// Get products from text database.
        /// </summary>
        public static List<Product> GetProductsFromFile(string input)
        {
            StringReader reader = new StringReader(input);
            reader.ReadLine(); // Skip header row
            List<Product> products = new List<Product>();
            while ( true )
            {
                string line = reader.ReadLine();
                if ( line == null )
                {
                    break;
                }
                products.Add(CreateProduct(GetLineValues(line)));
            }
            reader.Close();
            return products;
        }

        /// <summary>
        /// Create table row values.
        /// </summary>
        private static string[] GetLineValues(string line)
        {
            string[] lineValues = line.Split(AppDefinition.COMMA);
            if ( lineValues.Length < PRODUCT_ATTRIBUTES_COUNT )
            {
                throw new IOException(ERROR_LINE_VALUES_IS_OF_CORRUPTED_LENGTH);
            }
            return lineValues;
        }

        /// <summary>
        /// Create product from raw row data.
        /// </summary>
        private static Product CreateProduct(string[] lineValues)
        {
            int productId = int.Parse(lineValues[ PRODUCT_ID_COLUMN_INDEX ]);
            string productName = lineValues[ PRODUCT_NAME_COLUMN_INDEX ];
            string productType = lineValues[ PRODUCT_TYPE_COLUMN_INDEX ];
            Money productPrice = new Money(int.Parse(lineValues[ PRODUCT_PRICE_COLUMN_INDEX ]));
            int productStorageQuantity = int.Parse(lineValues[ PRODUCT_STORAGE_QUANTITY_COLUMN_INDEX ]);
            string productDescription = lineValues[ PRODUCT_DESCRIPTION_COLUMN_INDEX ].Replace(FILE_PRODUCT_DESCRIPTION_LINE_DELIMITER, APP_PRODUCT_DESCRIPTION_LINE_DELIMITER);
            return new Product(productId, productName, productType, productPrice, productStorageQuantity, productDescription);
        }
    }
}
