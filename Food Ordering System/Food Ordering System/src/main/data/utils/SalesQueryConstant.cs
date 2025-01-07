using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System.src.main.data.utils
{
    internal class SalesQueryConstant
    {
        public static string GET_TOTAL_SALES_AMOUNT_STATEMENT = "SELECT SUM(amount) FROM tbl_sales";

        public static string GET_SALES_BY_MONTH_AND_PRODUCT_STATEMENT = @"
        SELECT 
            MONTH(STR_TO_DATE(date, '%M %d, %Y')) AS Month, 
            p.food_name, 
            SUM(s.amount) AS TotalSales
        FROM tbl_sales s
        INNER JOIN tbl_product p ON s.product_id = p.product_id";

        public static string GET_SALES_BY_MONTH_WHERE_CONDITION = @"
        WHERE YEAR(STR_TO_DATE(date, '%M %d, %Y')) = @currentYear
        AND MONTH(STR_TO_DATE(date, '%M %d, %Y')) = @selectedMonth";

        public static string GET_SALES_GROUP_BY_MONTH_AND_PRODUCT = @"
            GROUP BY MONTH(STR_TO_DATE(date, '%M %d, %Y')), p.food_name
            ORDER BY Month, p.food_name";

        public static string GET_TOTAL_SALES_PRODUCT_STATEMENT = @"
                SELECT SUM(s.amount) AS TotalSales
                FROM tbl_sales s
                INNER JOIN tbl_product p ON s.product_id = p.product_id
                WHERE p.food_name = @productName";

        public static string GET_BEST_SELLING_PRODUCT_STATEMENT = @"
                SELECT 
                    p.food_name,
                    SUM(s.amount) AS TotalSales
                FROM tbl_sales s
                INNER JOIN tbl_product p ON s.product_id = p.product_id
                GROUP BY p.food_name
                ORDER BY TotalSales DESC
                LIMIT 1";

        public static string GET_PRODUCT_CATEGORY_COUNT = "SELECT category, COUNT(*) AS Count FROM tbl_product GROUP BY category";

    }
}
