using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.SqlServerCe;

namespace POS.Library
{

    public static class ConnectionBuilder
    {
        public static string ConnectionString = string.Empty;

        public static Dictionary<int, SqlCeConnection> Connections = new Dictionary<int, SqlCeConnection>();

        public static SqlCeConnection GetConnection(string ConnectionString = "")
        {
            return new SqlCeConnection(ConnectionString.Length > 0 ? ConnectionString : ConnectionBuilder.ConnectionString);
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

    public static class SQLiteConnectionBuilder
    {
        public static string ConnectionString = string.Empty;

        public static Dictionary<int, SQLiteConnection> Connections = new Dictionary<int, SQLiteConnection>();

        public static SQLiteConnection GetConnection(string ConnectionString = "")
        {
            return new SQLiteConnection(ConnectionString.Length > 0 ? ConnectionString : SQLiteConnectionBuilder.ConnectionString);
        }

        public static SQLiteConnection GetOpenedConnection()
        {
            return GetOpenedConnection("");
        }


        public static SQLiteConnection GetOpenedConnection(string ConnectionString = "")
        {
            var cn = string.IsNullOrEmpty(ConnectionString) ? GetConnection() : new SQLiteConnection(ConnectionString);

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
