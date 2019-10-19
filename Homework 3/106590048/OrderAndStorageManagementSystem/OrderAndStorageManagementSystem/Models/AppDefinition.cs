using System;

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
        public const string PAGE_LABEL_TEXT = "Page: ";
        public const string PAGE_LABEL_DELIMITER = "/ ";
        public const string CART_TOTAL_PRICE_TEXT = "總金額： ";
        // Tab Pages
        public const int TAB_PAGE_LAYOUT_ROW_COUNT = 2;
        public const int TAB_PAGE_LAYOUT_COLUMN_COUNT = 3;
        public const int TAB_PAGE_MAX_PRODUCTS_COUNT = TAB_PAGE_LAYOUT_ROW_COUNT * TAB_PAGE_LAYOUT_COLUMN_COUNT;
        public const int TAB_PAGES_COUNT = 6;
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

        // Protest on Dr.Smell
        public static int GetHumanIndex(int machineIndex)
        {
            return machineIndex + 1;
        }
    }
}
