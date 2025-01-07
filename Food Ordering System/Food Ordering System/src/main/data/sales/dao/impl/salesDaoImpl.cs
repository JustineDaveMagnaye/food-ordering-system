using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using static Food_Ordering_System.src.main.data.utils.SalesQueryConstant;
namespace Food_Ordering_System.src.main.data.sales.dao.impl
{
    internal class salesDaoImpl : salesDao
    {
        public salesDaoImpl() { }

        connectionHelper.connectionHelper connection = new connectionHelper.connectionHelper();

        public Dictionary<string, List<KeyValuePair<int, double>>> GetSalesData(int selectedMonth)
{
        using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
        {
            connect.Open();

                    string query = GET_SALES_BY_MONTH_AND_PRODUCT_STATEMENT;

            if (selectedMonth > 0)
            {
                        query += GET_SALES_BY_MONTH_WHERE_CONDITION;
            }

                    query += GET_SALES_GROUP_BY_MONTH_AND_PRODUCT;

            using (MySqlCommand command = new MySqlCommand(query, connect))
            {
                if (selectedMonth > 0)
                {
                        string currentYear = DateTime.Now.Year.ToString();
                        command.Parameters.AddWithValue("@selectedMonth", selectedMonth);
                            command.Parameters.AddWithValue("@currentYear", currentYear);
                }

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    var productSales = new Dictionary<string, List<KeyValuePair<int, double>>>();

                    while (reader.Read())
                    {
                        int month = Convert.ToInt32(reader["Month"]);
                        string foodName = reader["food_name"].ToString();
                        double totalSales = Convert.ToDouble(reader["TotalSales"]);

                        if (!productSales.ContainsKey(foodName))
                        {
                            productSales[foodName] = new List<KeyValuePair<int, double>>();
                        }

                        productSales[foodName].Add(new KeyValuePair<int, double>(month, totalSales));
                    }

                    return productSales;
                }
            }
        }
    }

        public decimal getTotalSalesAmount()
        {
            using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
            {
                connect.Open();
                using (MySqlCommand command = new MySqlCommand(GET_TOTAL_SALES_AMOUNT_STATEMENT, connect))
                {
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        decimal totalSalesAmount = Convert.ToDecimal(result);
                        return totalSalesAmount;
                    }
                    else
                    {
                        return Convert.ToDecimal(0);
                    }
                }
            }
                throw new NotImplementedException();
        }
        public string GetBestSellingProduct()
        {
            using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
            {
                connect.Open();

                using (MySqlCommand command = new MySqlCommand(GET_BEST_SELLING_PRODUCT_STATEMENT, connect))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader["food_name"].ToString(); 
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        
        public decimal GetTotalSalesForProduct(string productName)
        {
            using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
            {
                connect.Open();

                using (MySqlCommand command = new MySqlCommand(GET_TOTAL_SALES_PRODUCT_STATEMENT, connect))
                {
                    command.Parameters.AddWithValue("@productName", productName);
                    var result = command.ExecuteScalar();

                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }

        public Dictionary<string, int> GetProductCountByCategory()
        {
            var categoryCounts = new Dictionary<string, int>();

            using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
            {
                connect.Open();

                using (MySqlCommand command = new MySqlCommand(GET_PRODUCT_CATEGORY_COUNT, connect))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string category = reader["category"].ToString();
                            int count = Convert.ToInt32(reader["Count"]);
                            categoryCounts[category] = count;
                        }
                    }
                }
            }
            return categoryCounts;
        }

        public decimal GetTotalSalesForMonth(int month)
        {
            decimal totalSales = 0;

            string query = @"
                SELECT SUM(sales_amount) 
                FROM sales 
                WHERE MONTH(sales_date) = @month";

            using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
            {
                try
                {
                    connect.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connect))
                    {
                        command.Parameters.AddWithValue("@month", month);

                        object result = command.ExecuteScalar();
                        totalSales = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Database error while fetching sales for month {month}: {ex.Message}", ex);
                }
            }

            return totalSales;
        }
    }

}

