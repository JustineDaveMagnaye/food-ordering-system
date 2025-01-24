using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System.src.main.data.utils
{
    internal class EmployeeQueryConstant
    {
        public static string SAVE_EMPLOYEE_STATEMENT =
             "INSERT INTO tbl_employee (full_name, birthdate, birthplace, sex, civil_status, citizenship, religion, email, address, contact_number, date_employed, sss_no, tin_no, pagibig_no, account_id) " +
             "VALUES (@full_name, @birthdate, @birthplace, @sex, @civil_status, @citizenship, @religion, @email, @address, @contact_number, @date_employed, @sss_no, @tin_no, @pagibig_no, @account_id)";


    }
}
