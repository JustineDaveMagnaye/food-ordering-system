using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Food_Ordering_System.src.main.data.connectionHelper
{
    internal class connectionHelper
    {
        private string connectionString = "Server=localhost;Database=db_food_ordering_system;UserId=root;Password=jaydev;";    
        public string ConnectionString
        {
            get { return connectionString; }
        }

    }
}
