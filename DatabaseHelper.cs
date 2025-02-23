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
        public bool AddMaterial(string name, string unit, decimal cost, out string message)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                message = "Ошибка: введите название материала!";
                return false;
            }
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Materials (name, unit, cost, created_at) VALUES (@name, @unit, @cost, @createdAt)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@unit", unit);
                        cmd.Parameters.AddWithValue("@cost", cost);
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

        public bool AddOperation(string name, decimal cost, out string message)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                message = "Ошибка: введите название операции!";
                return false;
            }
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Operations (name, cost, created_at) VALUES (@name, @cost, @createdAt)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@cost", cost);
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
        public bool AddEmployee(string name, string position, decimal salary, out string message)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                message = "Ошибка: введите имя сотрудника!";
                return false;
            }
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Employees (name, position, salary, created_at) VALUES (@name, @position, @salary, @createdAt)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@position", position);
                        cmd.Parameters.AddWithValue("@salary", salary);
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
        public bool AddExpense(string category, decimal amount, DateTime date, out string message)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                message = "Ошибка: введите категорию расхода!";
                return false;
            }
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Expenses (category, amount, date, created_at) VALUES (@category, @amount, @date, @createdAt)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@category", category);
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@date", date);
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
