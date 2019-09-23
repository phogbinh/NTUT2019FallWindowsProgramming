using System.Data;
using System.Data.SqlClient;

namespace OrderAndStorageManagementSystem.Model
{
    public class DataBaseManager
    {
        public DataTable DataTable
        {
            get
            {
                return _dataTable;
            }
        }
        private DataTable _dataTable;
        public DataBaseManager(string connectionStringData)
        {
            _dataTable = CreateDataTable(connectionStringData);
        }

        /// <summary>
        /// Create data table from database using connection string.
        /// </summary>
        private DataTable CreateDataTable(string connectionString)
        {
            // Get the adapter of the database
            SqlConnection connection = new SqlConnection(connectionString);
            if ( connection.State != ConnectionState.Open )
            {
                connection.Open();
            }
            string command = AppDefinition.QUERY_COMMAND + AppDefinition.PRODUCTS_TABLE_NAME;
            SqlDataAdapter adapter = new SqlDataAdapter(command, connection);
            // Create the data table
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}
