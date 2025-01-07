using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Ordering_System.src.main.data.sales.dao;
using Food_Ordering_System.src.main.data.sales.dao.impl;

namespace Food_Ordering_System.src.main.appl.facade.sales.impl
{
    internal class salesFacadeImpl : salesFacade
    {
        private salesDao salesDao;

        public salesFacadeImpl(salesDao salesDao) { this.salesDao = salesDao; }
        public decimal getTotalSalesAmount()
        {
            return(salesDao.getTotalSalesAmount());
            throw new NotImplementedException();
        }

        public Dictionary<string, List<KeyValuePair<int, double>>> GetSalesData(int selectedMonth)
        {
            return salesDao.GetSalesData(selectedMonth);
        }
        public string GetBestSellingProduct()
        {
            return salesDao.GetBestSellingProduct();
        }

        public decimal GetTotalSalesForProduct(string productName)
        {
            return salesDao.GetTotalSalesForProduct(productName);
        }

        public Dictionary<string, int> GetProductCountByCategory()
        {
            return salesDao.GetProductCountByCategory();
        }

        public decimal GetTotalSalesForMonth(int month)
        {
            try
            {
                return salesDao.GetTotalSalesForMonth(month);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching total sales for month {month}: {ex.Message}", ex);
            }
        }

    }
}
