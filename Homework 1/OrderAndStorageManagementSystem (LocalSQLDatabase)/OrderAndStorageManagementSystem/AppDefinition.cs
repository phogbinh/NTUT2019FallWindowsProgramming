namespace OrderAndStorageManagementSystem
{
    public static class AppDefinition
    {
        public const string PRINT_DELIMITER = ", ";
        public const string PRINT_ID = "ID: ";
        public const string PRINT_NAME = "Name: ";
        public const string PRINT_TYPE = "Type: ";
        public const string PRINT_PRICE = "Price: ";
        public const string PRINT_DESCRIPTION = "Description: ";
        public const string PRINT_END_MARK = ".\n";
        public const string PRODUCT_ID = "ProductId";
        public const string PRODUCT_NAME = "ProductName";
        public const string PRODUCT_TYPE = "ProductType";
        public const string PRODUCT_PRICE = "ProductPrice";
        public const string PRODUCT_DESCRIPTION = "ProductDescription";
        public const string PRODUCT_PRICE_TEXT = "單價： ";
        public const string PRODUCT_NAME_DESCRIPTION_SEPARATOR = "\n\n";
        public const string APP_DATA_BASE_PRODUCTS_TABLE_IMAGE_NAME = "img_AppDatabase_ProductsTable_";
        public const string MOTHER_BOARD = "主機板";
        public const string CENTRAL_PROCESSING_UNIT = "CPU";
        public const string RANDOM_ACCESS_MEMORY = "記憶體";
        public const string HARD_DISK = "硬碟";
        public const string GRAPHICS_CARD = "顯示卡";
        public const string COMPUTER_SET = "套裝電腦";
        public const string PRODUCTS_TABLE_NAME = "ProductsTable";
        public const string QUERY_COMMAND = "SELECT * FROM ";
        public const float ONE_HUNDRED_PERCENT = 100f;
    }

    public enum ProductTypes
    {
        MotherBoard = 0,
        CentralProcessingUnit,
        RandomAccessMemory,
        HardDisk,
        GraphicsCard,
        ComputerSet
    }
}
