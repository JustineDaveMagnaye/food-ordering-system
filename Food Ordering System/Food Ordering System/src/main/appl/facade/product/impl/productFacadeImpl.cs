using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Food_Ordering_System.src.main.data.product.dao;

namespace Food_Ordering_System.src.main.appl.facade.product.impl
{
    internal class productFacadeImpl : productFacade
    {
        private productDao productDaoImpl;

        public productFacadeImpl(productDao productDaoImpl)
        {
            this.productDaoImpl = productDaoImpl;
        }

        public int GetProductCount()
        {
            return productDaoImpl.GetProductCount();
            throw new NotImplementedException();
        }

        public void DeleteProduct(String productId)
        {
            productDaoImpl.DeleteProduct(productId);
            return;
        }

        public void AddProduct(String productId, String category, String foodName, String price, String status, byte[] imageData)
        {
            productDaoImpl.AddProduct(productId,category, foodName, price, status, imageData);
            return;
        }
    }
}
