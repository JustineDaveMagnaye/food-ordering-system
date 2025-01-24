using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System.src.main.data.utils
{
    internal class ProductQueryConstant
    {
        public static string GET_TOTAL_PRODUCTS_STATEMENT = "SELECT COUNT(*) FROM tbl_product";

        public static string DELETE_PRODUCT_STATEMENT = "DELETE FROM tbl_product WHERE product_id = @productId";

        public static string ADD_PRODUCT_STATEMENT = "INSERT INTO tbl_product (product_id, category, food_name, price, status, img) VALUES (@product_id, @category, @food_name, @price, @status, @img)";
    }
}
