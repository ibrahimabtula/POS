using System.Collections.Generic;
using System.Data.SqlServerCe;

namespace POS.Library
{

    public static class ConnectionBuilder
    {
        private static string _connectionString = @"Data Source=C:\IBRAHIM\POS\POS\POS.sdf;Password=963852741";

        public static Dictionary<int, SqlCeConnection> Connections = new Dictionary<int, SqlCeConnection>();

        public static SqlCeConnection GetConnection(string ConnectionString = "")
        {
            return new SqlCeConnection(ConnectionString.Length > 0 ? ConnectionString : _connectionString);
        }

        public static SqlCeConnection GetOpenedConnection()
        {
            return GetOpenedConnection("");
        }


        public static SqlCeConnection GetOpenedConnection(string ConnectionString = "")
        {
            var cn = string.IsNullOrEmpty(ConnectionString) ? GetConnection() : new SqlCeConnection(ConnectionString);

            try
            {
                cn.Open();
                return cn;
            }
            catch
            {
                throw new POSNoConnectionException();
            }
        }
    }
}
