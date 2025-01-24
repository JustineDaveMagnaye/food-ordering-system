using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System.src.main.appl.model
{
    public class Account
    {
        private int id;
        private string username;
        private string password;
        private string role;
        private DateTime createdAt;

        public int Id { get; set; }
        public String FullName { get; set; }
        public String Username {  get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
