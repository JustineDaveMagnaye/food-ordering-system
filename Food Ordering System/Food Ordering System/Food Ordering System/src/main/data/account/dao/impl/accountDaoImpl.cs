using Food_Ordering_System.src.main.appl.model;
using Food_Ordering_System.src.main.data.account;
using Food_Ordering_System.src.main.data.connectionHelper;
using static Food_Ordering_System.src.main.data.utils.AccountQueryConstant;
using MySql.Data.MySqlClient;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

internal class accountDaoImpl : accountDao
{
    public accountDaoImpl() { }

    connectionHelper connection = new connectionHelper();

    public Account GetAccountByUsername(string username)
    {
        try
        {
            using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
            {
                connect.Open();

                using (MySqlCommand command = new MySqlCommand(GET_USER_BY_USERNAME_STATEMENT, connect))
                {
                    command.Parameters.AddWithValue("@username", username);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Account
                            {
                                Id = reader.GetInt32("account_id"),
                                Username = reader.GetString("username"),
                                Password = reader.GetString("password"),
                                Role = reader.GetString("role"),
                            };
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return null; 
    }



    public Account Register(Account account)
    {
        try
        {
            using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
            {
                connect.Open();

                using (MySqlCommand command = new MySqlCommand(SAVE_USER_STATEMENT, connect))
                {
                    command.Parameters.AddWithValue("@username", account.Username);
                    command.Parameters.AddWithValue("@password", account.Password);
                    command.Parameters.AddWithValue("@role", account.Role);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        command.CommandText = "SELECT LAST_INSERT_ID();";
                        int accountId = Convert.ToInt32(command.ExecuteScalar());

                        account.Id = accountId;
                        return account;
                    }
                    else
                    {
                        return null; 
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error registering account: {ex.Message}", ex);
        }
    }


    public int GetAccountCount()
    {
        try
        {
            using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
            {
                connect.Open();
                using (MySqlCommand command = new MySqlCommand(GET_USER_COUNT, connect))
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
}
