using BusinessObjects_EF;
using DataAccessLayer_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories_EF
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _productDAO = new ProductDAO();

        public List<Product> GetAllProducts()
        {
            return _productDAO.GetAllProducts();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _productDAO.GetProductsByCategory(categoryId);
        }

        public bool SaveProduct(Product product)
        {
            return _productDAO.SaveProduct(product);
        }

        public bool UpdateProduct(Product product)
        {
            return _productDAO.UpdateProduct(product);
        }
        public bool DeleteProduct(int productId)
        {
            return _productDAO.DeleteProduct(productId);
        }
    }
}
