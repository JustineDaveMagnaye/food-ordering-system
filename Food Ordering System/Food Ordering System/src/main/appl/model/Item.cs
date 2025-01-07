using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Food_Ordering_System.src.main.appl.model
{
    public class Item : Product
    {
        public int Quantity { get; set; }

        public Item(string productId, string foodName, double price, string category, int quantity)
            : base(productId, foodName, price, category)
        {
            Quantity = quantity;
        }

        public override string ToString()
        {
            return $"Item {{ Category = {Category}, FoodName = {FoodName}, Price = {Price}, Quantity = {Quantity}, Status = {Status} }}";
        }
    }
}
