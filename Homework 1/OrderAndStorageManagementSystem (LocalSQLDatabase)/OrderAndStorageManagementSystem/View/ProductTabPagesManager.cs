using OrderAndStorageManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.View
{
    public class ProductTabPagesManager
    {
        private const string TAB_PAGE_LAYOUT_NAME = "_productTabPageLayout";
        private const int TAB_PAGE_LAYOUT_ROW_COUNT = 2;
        private const int TAB_PAGE_LAYOUT_COLUMN_COUNT = 3;
        private List<ProductTabPageItem> _items = new List<ProductTabPageItem>();
        private OrderForm _orderForm;
        private TabControl _tabControl;
        public ProductTabPagesManager(OrderForm orderFormData)
        {
            _orderForm = orderFormData;
            _tabControl = _orderForm.ProductTabControl;
        }

        /// <summary>
        /// Initialize tab pages.
        /// </summary>
        public void InitializeTabPages()
        {
            TabControl.TabPageCollection tabPages = _tabControl.TabPages;
            for ( int index = 0; index < tabPages.Count; index++ )
            {
                TabPage tabPage = tabPages[ index ];
                tabPage.Controls.Add(CreateTableLayout(TAB_PAGE_LAYOUT_NAME, TAB_PAGE_LAYOUT_ROW_COUNT, TAB_PAGE_LAYOUT_COLUMN_COUNT));
                PopulateTabPageWithProducts(ref tabPage, index);
            }

            _tabControl.SelectedIndexChanged += new EventHandler(ChangeTabPage);
        }

        /// <summary>
        /// Create a 'rowCount' by 'colCount' table layout with name 'tableLayoutName'.
        /// </summary>
        public static TableLayoutPanel CreateTableLayout(string tableLayoutName, int rowCount, int columnCount)
        {
            var tableLayout = new TableLayoutPanel();
            tableLayout.Name = tableLayoutName;
            tableLayout.Dock = DockStyle.Fill;
            tableLayout.RowStyles.Clear();
            tableLayout.ColumnStyles.Clear();
            tableLayout.Controls.Clear();
            tableLayout.RowCount = rowCount;
            for ( int row = 0; row < rowCount; row++ )
            {
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, AppDefinition.ONE_HUNDRED_PERCENT / rowCount));
            }
            tableLayout.ColumnCount = columnCount;
            for ( int col = 0; col < columnCount; col++ )
            {
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, AppDefinition.ONE_HUNDRED_PERCENT / columnCount));
            }
            return tableLayout;
        }

        /// <summary>
        /// Populate tab page with products of corresponding type.
        /// </summary>
        private void PopulateTabPageWithProducts(ref TabPage tabPage, int tabPageIndex)
        {
            TableLayoutPanel tabPageLayout = ( TableLayoutPanel )tabPage.Controls[ TAB_PAGE_LAYOUT_NAME ];
            int tabPageItemCount = 0;
            foreach ( Product product in _orderForm.Model.Products )
            {
                int productTabPageIndex = ( int )product.Type;
                if ( productTabPageIndex != tabPageIndex )
                {
                    continue;
                }
                ProductTabPageItem item = new ProductTabPageItem(_orderForm, product);
                _items.Add(item); // Make the item live with the form
                AddItemToTabPage(item, tabPageLayout, ref tabPageItemCount);
            }
        }

        /// <summary>
        /// Add button into proper table cell.
        /// </summary>
        private void AddItemToTabPage(ProductTabPageItem item, TableLayoutPanel tabPageLayout, ref int tabPageItemCount)
        {
            int row;
            int column;
            GetRowAndColumn(tabPageItemCount, TAB_PAGE_LAYOUT_COLUMN_COUNT, out row, out column);
            tabPageLayout.Controls.Add(item.Button, column, row);
            item.Button.Dock = DockStyle.Fill; // Make button fill in table cell
            tabPageItemCount++; // Increment tab page item count
        }

        /// <summary>
        /// Get the row and column index of an array by the index count and the number of columns of the array.
        /// </summary>
        private void GetRowAndColumn(int indexCount, int columnCount, out int row, out int column)
        {
            row = indexCount / columnCount;
            column = indexCount - row * columnCount;
        }

        /// <summary>
        /// Change tab page event handler.
        /// </summary>
        private void ChangeTabPage(object sender, EventArgs events)
        {
            _orderForm.SelectNoProduct();
        }
    }
}
