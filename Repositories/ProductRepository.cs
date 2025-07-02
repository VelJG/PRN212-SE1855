using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        ProductDAO productDAO=new ProductDAO();
        public void GenerateSampleDataset()
        {
            productDAO.GenerateSampleDataset();
        }

        public List<Product> GetProducts()
        {
            return productDAO.GetProducts();
        }

        public bool UpdateProducts(Product product)
        {
            return productDAO.UpdateProduct(product);
        }
        public bool SaveProducts(Product product)
        {
            return productDAO.SaveProduct(product);
        }
        public bool DeleteProducts(Product product)
        {
            return productDAO.DeleteProduct(product);
        }
    }
}
