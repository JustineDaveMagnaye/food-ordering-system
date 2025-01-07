using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Ordering_System.src.main.appl.facade.sales;
using Food_Ordering_System.src.main.appl.facade.sales.impl;
using Food_Ordering_System.src.main.data.sales.dao;
using Food_Ordering_System.src.main.data.sales.dao.impl;

namespace Food_Ordering_System.src.main
{
    internal class SalesInfoMgtApplication
    {
        private salesFacade salesFacade;

        public SalesInfoMgtApplication() {
        salesDao salesDaoImpl = new salesDaoImpl();
        this.salesFacade = new salesFacadeImpl(salesDaoImpl);
        }

        public salesFacade GetSalesFacade() => salesFacade;
    }
}
