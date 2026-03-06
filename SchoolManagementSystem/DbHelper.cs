using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SchoolManagementSystem
{
    /// <summary>
    /// Database helper for SQL Server connection and common operations.
    /// </summary>
    public static class DbHelper
    {
        private static string _connectionString;

        static DbHelper()
        {
            try
            {
                var conn = ConfigurationManager.ConnectionStrings["SchoolDB"];
                _connectionString = conn != null ? conn.ConnectionString : 
                    "Data Source=.\\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;";
            }
            catch
            {
                _connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=School;Integrated Security=True;";
            }
        }

        public static string ConnectionString => _connectionString;

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        /// <summary>
        /// Execute non-query and return number of rows affected.
        /// </summary>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Execute scalar and return first column of first row (e.g. SCOPE_IDENTITY()).
        /// </summary>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Fill DataTable using SqlDataAdapter.
        /// </summary>
        public static DataTable FillTable(string sql, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            using (var conn = GetConnection())
            {
                using (var adapter = new SqlDataAdapter(sql, conn))
                {
                    if (parameters != null)
                        adapter.SelectCommand.Parameters.AddRange(parameters);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// Read single row using SqlDataReader (e.g. for auto-fetch by Student_id).
        /// </summary>
        public static void ReadSingleRow(string sql, Action<SqlDataReader> readAction, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                            readAction(reader);
                    }
                }
            }
        }
    }
}
