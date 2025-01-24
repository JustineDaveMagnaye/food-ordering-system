using System.Drawing;

public class Product
    {
        public string ProductId { get; set; }
        public string Category { get; set; }
        public string FoodName { get; set; }
        public double Price { get; set; }
        public string Status { get; set; }
        public Image Image { get; set; }

        public Product() { }

        public Product(string productId, string foodName, double price, string category)
        {
            ProductId = productId;
            FoodName = foodName;
            Price = price;
            Category = category;
        }

        public override string ToString()
            {
                return $"Product {{ Category = {Category}, FoodName = {FoodName}, Price = {Price}, Status = {Status} }}";
            }
     }