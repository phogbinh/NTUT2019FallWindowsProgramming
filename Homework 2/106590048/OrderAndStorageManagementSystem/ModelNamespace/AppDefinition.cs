using System;

namespace OrderAndStorageManagementSystem.ModelNamespace
{
    public static class AppDefinition
    {
        public const float ONE_HUNDRED_PERCENT = 100f;
        // Debug
        public const string PRINT_DELIMITER = ", ";
        public const string PRINT_ID = "ID: ";
        public const string PRINT_NAME = "Name: ";
        public const string PRINT_TYPE = "Type: ";
        public const string PRINT_PRICE = "Price: ";
        public const string PRINT_DESCRIPTION = "Description: ";
        public const string PRINT_END_MARK = ".\n";
        public const string ERROR_TAB_PAGE_INDEX_OUT_OF_RANGE = "Tab page index is out of range.";
        // Product
        public const string PRODUCT_PRICE_TEXT = "單價： ";
        public const string PRODUCT_NAME_DESCRIPTION_SEPARATOR = "\n\n";
        public const string APP_DATA_BASE_PRODUCTS_TABLE_IMAGE_NAME = "img_AppDatabase_ProductsTable_";
        // Tab Pages
        public const string MOTHER_BOARD_NAME = "主機板";
        public const string CENTRAL_PROCESSING_UNIT_NAME = "CPU";
        public const string RANDOM_ACCESS_MEMORY_NAME = "記憶體";
        public const string HARD_DISK_NAME = "硬碟";
        public const string GRAPHICS_CARD_NAME = "顯示卡";
        public const string COMPUTER_SET_NAME = "套裝電腦";
        public const int MOTHER_BOARD_INDEX = 0;
        public const int CENTRAL_PROCESSING_UNIT_INDEX = 1;
        public const int RANDOM_ACCESS_MEMORY_INDEX = 2;
        public const int HARD_DISK_INDEX = 3;
        public const int GRAPHICS_CARD_INDEX = 4;
        public const int COMPUTER_SET_INDEX = 5;
        // Functions
        public static string ConvertTabPageIndexToProductType(int index)
        {
            switch ( index )
            {
                case MOTHER_BOARD_INDEX:
                    return MOTHER_BOARD_NAME;
                case CENTRAL_PROCESSING_UNIT_INDEX:
                    return CENTRAL_PROCESSING_UNIT_NAME;
                case RANDOM_ACCESS_MEMORY_INDEX:
                    return RANDOM_ACCESS_MEMORY_NAME;
                case HARD_DISK_INDEX:
                    return HARD_DISK_NAME;
                case GRAPHICS_CARD_INDEX:
                    return GRAPHICS_CARD_NAME;
                case COMPUTER_SET_INDEX:
                    return COMPUTER_SET_NAME;
                default:
                    throw new ArgumentException(ERROR_TAB_PAGE_INDEX_OUT_OF_RANGE);
            }
        }
    }
}
