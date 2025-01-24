using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System.src.main.appl.model
{
    public class Cart
    {
        private List<Item> items;

        public Cart()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public List<Item> GetItems()
        {
            return new List<Item>(items);
        }

        public double GetTotalPrice()
        {
            double total = 0;
            foreach (var item in items)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }

       

        public override string ToString()
        {
            string cartDetails = "Cart: \n";
            foreach (var item in items)
            {
                cartDetails += item.ToString() + "\n";
            }
            cartDetails += $"Total Price: {GetTotalPrice()}";
            return cartDetails;
        }
    }
}
