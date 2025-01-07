using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System.src.main.appl.model
{
    [Serializable]
    public class Employee : Person
    {
        private int accountId;
        private String dateEmployed;
        private String sssNo;
        private String tinNo;
        private String pagibigNo;

        public int AccountId { get; set; }
        public String DateEmployed { get; set; }
        public String SssNo { get; set; }

        public String TinNo { get; set; }

        public String PagibigNo { get; set; }
    }
}
