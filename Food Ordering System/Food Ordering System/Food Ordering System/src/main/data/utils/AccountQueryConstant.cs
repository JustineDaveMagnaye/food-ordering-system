using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System.src.main.data.utils
{
    internal class AccountQueryConstant
    {
        public static string GET_USER_BY_USERNAME_STATEMENT = "SELECT * FROM tbl_account WHERE username = @username";

        public static string SAVE_USER_STATEMENT = "INSERT INTO tbl_account ( username, password, role) VALUES (@username, @password, @role)";

        public static string GET_USER_COUNT = "SELECT COUNT(*) FROM tbl_account";
    }
}
