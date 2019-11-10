namespace OrderAndStorageManagementSystem.Models
{
    public static class AppDefinition
    {
        public const float ONE_HUNDRED_PERCENT = 100f;
        // Other
        public const string TAIWAN_CURRENCY_UNIT = "元";
        public const char COMMA = ',';
        public const char SPACE = ' ';
        public const string EMPTY_STRING = "";
        public const int TWO = 2;
        public const string RELATIVE_PATH_FROM_APPLICATION_BINARY_DIRECTORY_TO_RESOURCES_FOLDER = @"\..\..\Resources\";
        public const string FILE_NAME_EXTENSION_JOINT_PHOTOGRAPHIC_GROUP = ".jpg";
        // Product
        public const string PRODUCT_STORAGE_QUANTITY_TEXT = "庫存數量： ";
        public const string PRODUCT_PRICE_TEXT = "單價： ";
        public const string PRODUCT_NAME_DESCRIPTION_SEPARATOR = "\n\n";
        public const string APP_DATA_BASE_PRODUCTS_TABLE_IMAGE_NAME = "img_AppDatabase_ProductsTable_";
        public const string PAGE_LABEL_TEXT = "Page: ";
        public const string PAGE_LABEL_DELIMITER = "/ ";
        public const string CART_TOTAL_PRICE_TEXT = "總金額： ";
        // Tab Pages
        public const int TAB_PAGE_LAYOUT_ROW_COUNT = 2;
        public const int TAB_PAGE_LAYOUT_COLUMN_COUNT = 3;
        public const int TAB_PAGE_MAX_PRODUCTS_COUNT = TAB_PAGE_LAYOUT_ROW_COUNT * TAB_PAGE_LAYOUT_COLUMN_COUNT;
        /// <summary>
        /// Get human index of machine index.
        /// </summary>
        public static int GetHumanIndex(int machineIndex)
        {
            return machineIndex + 1;
        }

        /// <summary>
        /// Return true if value is in [ intervalLeftValue, intervalRightValue ].
        /// </summary>
        public static bool IsInIntervalRange(int value, int intervalLeftValue, int intervalRightValue)
        {
            return intervalLeftValue <= value && value <= intervalRightValue;
        }
    }
}
