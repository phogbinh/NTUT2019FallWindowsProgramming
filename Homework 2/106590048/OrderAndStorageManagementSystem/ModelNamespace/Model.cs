using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderAndStorageManagementSystem.ModelNamespace
{
    public class Model
    {
        public List<Product> Products
        {
            get
            {
                return _products;
            }
        }
        public int CartTotalPrice
        {
            get
            {
                return _cartTotalPrice;
            }
        }
        private List<Product> _products;
        private int _cartTotalPrice;

        public Model()
        {
            _products = DataBaseManager.GetProductsFromProductTable();
            _cartTotalPrice = 0;
        }

        /// <summary>
        /// Add total price by addtional price.
        /// </summary>
        public void AddTotalPrice(int additionalPrice)
        {
            SetTotalPrice(_cartTotalPrice + additionalPrice);
        }

        /// <summary>
        /// Set total price.
        /// </summary>
        private void SetTotalPrice(int newTotalPrice)
        {
            _cartTotalPrice = newTotalPrice;
        }

        /// <summary>
        /// Get the row and column index of an entry of a array by the entry index count and the number of columns of the array.
        /// </summary>
        public static void GetArrayEntryRowAndColumn(int indexCount, int columnCount, out int row, out int column)
        {
            row = indexCount / columnCount;
            column = indexCount - row * columnCount;
        }

        /// <summary>
        /// Create a specified size table layout with a pre-defined name.
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
            tableLayout.ColumnCount = columnCount;
            for ( int row = 0; row < rowCount; row++ )
            {
                tableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, AppDefinition.ONE_HUNDRED_PERCENT / rowCount));
            }
            for ( int col = 0; col < columnCount; col++ )
            {
                tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, AppDefinition.ONE_HUNDRED_PERCENT / columnCount));
            }
            return tableLayout;
        }
    }
}
