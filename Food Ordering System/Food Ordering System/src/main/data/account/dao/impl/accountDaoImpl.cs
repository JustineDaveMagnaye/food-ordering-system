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
            // Log the exception if necessary
            Console.WriteLine($"Error: {ex.Message}");
        }

        return null; // Return null if username is not found or an exception occurs
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

                    // Execute the INSERT statement
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if the account was successfully inserted
                    if (rowsAffected > 0)
                    {
                        // Retrieve the last inserted ID
                        command.CommandText = "SELECT LAST_INSERT_ID();";
                        int accountId = Convert.ToInt32(command.ExecuteScalar());

                        // Set the ID to the account object and return it
                        account.Id = accountId;
                        return account;
                    }
                    else
                    {
                        return null; // Return null if the insert failed
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception
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
