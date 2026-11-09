using System;
using System.Data;
using System.Data.SqlClient;

namespace Lab4_Basic_Command
{
    /// <summary>
    /// Lớp tiện ích hỗ trợ kết nối và truy vấn cơ sở dữ liệu ADO.NET
    /// </summary>
    public static class DatabaseHelper
    {
        public static string ConnectionString = @"server=.\MSSQLSERVER01; database=RestaurantManagement; Integrated Security=true; TrustServerCertificate=True;";

        /// <summary>
        /// Tạo và trả về một đối tượng SqlConnection mới
        /// </summary>
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        /// <summary>
        /// Thực thi truy vấn SELECT và trả về kết quả dưới dạng DataTable
        /// </summary>
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable table = new DataTable();
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(table);
                    }
                }
            }
            return table;
        }

        /// <summary>
        /// Thực thi lệnh INSERT, UPDATE, DELETE và trả về số dòng bị tác động
        /// </summary>
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Thực thi truy vấn và trả về ô đầu tiên của dòng đầu tiên (dùng cho COUNT, SUM, MAX,...)
        /// </summary>
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }
    }
}
