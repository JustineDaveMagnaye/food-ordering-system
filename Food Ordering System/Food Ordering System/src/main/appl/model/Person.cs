using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System.src.main.appl.model
{
    public class Person
    {
        private int id;
        private string fullName;
        private string birthdate;
        private string birthplace;
        private string sex;
        private string civilStatus;
        private string citizenship;
        private string religion;
        private string email;
        private string address;
        private string contactNumber;

        public int Id { get; set; }

        public string FullName { get; set; }

        public string Birthdate { get; set; }

        public string Birthplace { get; set; }

        public string Sex { get; set; }

        public string CivilStatus { get; set; }

        public string Citizenship { get; set; }

        public string Religion { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string ContactNumber { get; set; }
    }
}
