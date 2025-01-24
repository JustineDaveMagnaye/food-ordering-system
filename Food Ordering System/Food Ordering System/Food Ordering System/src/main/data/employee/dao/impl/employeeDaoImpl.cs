using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Ordering_System.src.main.appl.model;
using Food_Ordering_System.src.main.data.connectionHelper;
using MySql.Data.MySqlClient;
using static Food_Ordering_System.src.main.data.utils.EmployeeQueryConstant;



namespace Food_Ordering_System.src.main.data.employee.dao.impl
{
    internal class employeeDaoImpl : employeeDao
    {
        public employeeDaoImpl() { }

        connectionHelper.connectionHelper connection = new connectionHelper.connectionHelper();
        public Employee AddEmployee(Employee employee)
        {
            try
            {
                using (MySqlConnection connect = new MySqlConnection(connection.ConnectionString))
                {
                    connect.Open();

                    using (MySqlCommand command = new MySqlCommand(SAVE_EMPLOYEE_STATEMENT, connect))
                    {
                        command.Parameters.AddWithValue("@full_name", employee.FullName);
                        command.Parameters.AddWithValue("@birthdate", employee.Birthdate);
                        command.Parameters.AddWithValue("@birthplace", employee.Birthplace);
                        command.Parameters.AddWithValue("@sex", employee.Sex);
                        command.Parameters.AddWithValue("@civil_status", employee.CivilStatus);
                        command.Parameters.AddWithValue("@citizenship", employee.Citizenship);
                        command.Parameters.AddWithValue("@religion", employee.Religion);
                        command.Parameters.AddWithValue("@email", employee.Email);
                        command.Parameters.AddWithValue("@address", employee.Address);
                        command.Parameters.AddWithValue("@contact_number", employee.ContactNumber);
                        command.Parameters.AddWithValue("@date_employed", employee.DateEmployed);
                        command.Parameters.AddWithValue("@sss_no", employee.SssNo);
                        command.Parameters.AddWithValue("@tin_no", employee.TinNo);
                        command.Parameters.AddWithValue("@pagibig_no", employee.PagibigNo);
                        command.Parameters.AddWithValue("@account_id", employee.AccountId);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            return employee;
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
                Console.WriteLine($"Error adding employee: {ex.Message}");
                throw;
            }
        }
    }
}
