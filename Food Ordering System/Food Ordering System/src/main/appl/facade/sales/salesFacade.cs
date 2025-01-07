using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food_Ordering_System.src.main.appl.facade.sales
{
    public interface salesFacade
    {
        string GetBestSellingProduct();
        Dictionary<string, int> GetProductCountByCategory();
        Dictionary<string, List<KeyValuePair<int, double>>> GetSalesData(int selectedMonth);
        decimal getTotalSalesAmount();
        decimal GetTotalSalesForMonth(int month);
        decimal GetTotalSalesForProduct(string productName);
    }
}
