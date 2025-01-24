using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System.src.main.appl.model
{
    public class Sales
    {
        private Product product;

        private Account account;

        private string date;

        private string time;

        private decimal amount;

        public Product Product { get; set; }

        public Account Account { get; set; }    

        public string Date { get; set; }
        public string Time { get; set; }
        public decimal Amount { get; set; }
    }
}
