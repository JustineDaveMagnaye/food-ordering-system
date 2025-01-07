using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System.src.main.data.product.dao
{
    public interface productDao
    {
        void AddProduct(string productId, string category, string foodName, string price, string status, byte[] imageData);
        void DeleteProduct(string productId);
        int GetProductCount();
    }
}
