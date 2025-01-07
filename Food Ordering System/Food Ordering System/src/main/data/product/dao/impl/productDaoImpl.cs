using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using static Food_Ordering_System.src.main.data.utils.ProductQueryConstant;

namespace Food_Ordering_System.src.main.data.product.dao.impl
{
    internal class productDaoImpl : productDao
    {
        public productDaoImpl() { }

        connectionHelper.connectionHelper connection = new connectionHelper.connectionHelper();
        public int GetProductCount()
        {
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
                {
                    connect.Open();
                    using (MySqlCommand command = new MySqlCommand(GET_TOTAL_PRODUCTS_STATEMENT, connect))
                    {
                        return Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public void DeleteProduct(String productId)
        {
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
                {
                    connect.Open();
                    using (MySqlCommand command = new MySqlCommand(DELETE_PRODUCT_STATEMENT, connect))
                    {
                        command.Parameters.AddWithValue("@productId", productId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            { 
            }
        }

        public void AddProduct(string productId, string category, string foodName, string price, string status, byte[] imageData)
        {
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
                {
                    connect.Open();

                    using (MySqlCommand command = new MySqlCommand(ADD_PRODUCT_STATEMENT, connect))
                    {
                        command.Parameters.AddWithValue("@product_id", productId);
                        command.Parameters.AddWithValue("@category", category);
                        command.Parameters.AddWithValue("@food_name", foodName);
                        command.Parameters.AddWithValue("@price", price);
                        command.Parameters.AddWithValue("@status", status);
                        command.Parameters.AddWithValue("@img", imageData);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
