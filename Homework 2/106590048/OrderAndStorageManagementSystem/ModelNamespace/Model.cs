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
        public Order Order
        {
            get
            {
                return _order;
            }
        }
        private List<Product> _products;
        private Order _order;

        public Model()
        {
            _products = DataBaseManager.GetProductsFromProductTable();
            _order = new Order();
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

        // Protest on Dr.Smell
        public void AddProductToOrder(Product product)
        {
            _order.AddTotalPrice(product.Price);
        }

        // Protest on Dr.Smell
        public string GetOrderTotalPrice()
        {
            return _order.TotalPrice.ToString();
        }
    }
}
