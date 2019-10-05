using OrderAndStorageManagementSystem.ModelNamespace;
using OrderAndStorageManagementSystem.ViewNamespace;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.PresentationModelNamespace
{
    public class ProductTabPagesManager
    {
        private const string TAB_PAGE_LAYOUT_NAME = "_productTabPageLayout";
        private const int TAB_PAGE_LAYOUT_ROW_COUNT = 2;
        private const int TAB_PAGE_LAYOUT_COLUMN_COUNT = 3;
        private OrderForm _orderForm;
        private TabControl.TabPageCollection _tabPages;
        private IDictionary<int, string> _tabPageIndexToProductTypeMap;
        private List<ProductTabPageItem> _items;

        public ProductTabPagesManager(OrderForm orderFormData, TabControl.TabPageCollection tabPagesData)
        {
            _orderForm = orderFormData;
            _tabPages = tabPagesData;
            InitializeTabPageIndexToProductTypeMap();
        }

        /// <summary>
        /// Initialize map from tab page index to product type.
        /// </summary>
        private void InitializeTabPageIndexToProductTypeMap()
        {
            _tabPageIndexToProductTypeMap = new Dictionary<int, string>();
            _tabPageIndexToProductTypeMap.Add(AppDefinition.MOTHER_BOARD_INDEX, AppDefinition.MOTHER_BOARD_NAME);
            _tabPageIndexToProductTypeMap.Add(AppDefinition.CENTRAL_PROCESSING_UNIT_INDEX, AppDefinition.CENTRAL_PROCESSING_UNIT_NAME);
            _tabPageIndexToProductTypeMap.Add(AppDefinition.RANDOM_ACCESS_MEMORY_INDEX, AppDefinition.RANDOM_ACCESS_MEMORY_NAME);
            _tabPageIndexToProductTypeMap.Add(AppDefinition.HARD_DISK_INDEX, AppDefinition.HARD_DISK_NAME);
            _tabPageIndexToProductTypeMap.Add(AppDefinition.GRAPHICS_CARD_INDEX, AppDefinition.GRAPHICS_CARD_NAME);
            _tabPageIndexToProductTypeMap.Add(AppDefinition.COMPUTER_SET_INDEX, AppDefinition.COMPUTER_SET_NAME);
        }

        /// <summary>
        /// Initialize tab pages.
        /// </summary>
        public void InitializeTabPages()
        {
            InitializeProductTabPageItems();
            for ( int index = 0; index < _tabPages.Count; index++ )
            {
                TabPage tabPage = _tabPages[ index ];
                tabPage.Controls.Add(Model.CreateTableLayout(TAB_PAGE_LAYOUT_NAME, TAB_PAGE_LAYOUT_ROW_COUNT, TAB_PAGE_LAYOUT_COLUMN_COUNT));
                PopulateTabPage(tabPage, _tabPageIndexToProductTypeMap[ index ]);
            }
        }

        /// <summary>
        /// Initialize product tab page items.
        /// </summary>
        private void InitializeProductTabPageItems()
        {
            _items = new List<ProductTabPageItem>();
            foreach ( Product product in _orderForm.Model.Products )
            {
                ProductTabPageItem item = new ProductTabPageItem(_orderForm, product);
                _items.Add(item);
            }
        }

        /// <summary>
        /// Populate tab page with products of corresponding type.
        /// </summary>
        private void PopulateTabPage(TabPage tabPage, string tabPageType)
        {
            TableLayoutPanel tabPageLayout = ( TableLayoutPanel )tabPage.Controls[ TAB_PAGE_LAYOUT_NAME ];
            int tabPageItemCount = 0;
            foreach ( ProductTabPageItem item in _items )
            {
                if ( item.Product.Type == tabPageType )
                {
                    AddItemToTabPage(item, tabPageLayout, tabPageItemCount);
                    tabPageItemCount++;
                }
            }
        }

        /// <summary>
        /// Add button into proper table cell.
        /// </summary>
        private void AddItemToTabPage(ProductTabPageItem item, TableLayoutPanel tabPageLayout, int tabPageItemIndex)
        {
            int row;
            int column;
            Model.GetArrayEntryRowAndColumn(tabPageItemIndex, TAB_PAGE_LAYOUT_COLUMN_COUNT, out row, out column);
            tabPageLayout.Controls.Add(item.Button, column, row);
            item.Button.Dock = DockStyle.Fill; // Make button fill in table cell
        }
    }
}
