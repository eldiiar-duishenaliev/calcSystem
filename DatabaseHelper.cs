using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace calcSystem
{
    public class DatabaseHelper
    {
        private string connStr = "Server=localhost\\SQLEXPRESS;Database=calcSystem;Trusted_Connection=True;TrustServerCertificate=True;";

        public DatabaseHelper(string v)
        {
        }

        public bool AddProduct(string name, string description, out string message)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                message = "Ошибка: введите название продукта!";
                return false;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Products (name, description, created_at) VALUES (@name, @description, @createdAt)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@createdAt", DateTime.Now);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            message = "Данные успешно сохранены!";
                            return true;
                        }
                        else
                        {
                            message = "Ошибка при сохранении данных.";
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = $"Ошибка: {ex.Message}";
                    return false;
                }
            }
        }
    }
}
