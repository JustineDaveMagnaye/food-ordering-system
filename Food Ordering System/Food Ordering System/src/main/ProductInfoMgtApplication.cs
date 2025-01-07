using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Ordering_System.src.main.appl.facade.product;
using Food_Ordering_System.src.main.appl.facade.product.impl;
using Food_Ordering_System.src.main.data.product.dao;
using Food_Ordering_System.src.main.data.product.dao.impl;

namespace Food_Ordering_System.src.main
{
    internal class ProductInfoMgtApplication
    {
        private productFacade productFacade;
        
        public ProductInfoMgtApplication() {
            productDao productDaoImpl = new productDaoImpl();
            this.productFacade = new productFacadeImpl(productDaoImpl);
        }

        public productFacade getProductFacade() => productFacade;
    }
}
