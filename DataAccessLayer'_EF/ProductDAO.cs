using BusinessObjects_EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer_EF
{
    public class ProductDAO
    {
        MyStoreContext context = new MyStoreContext();
        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }
        public List<Product> GetProductsByCategory(int categoryId)
        {
            return context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }
        public bool SaveProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }
            Product existingProduct = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct != null)
            {
                return false;
            }
            context.Products.Add(product);
            return context.SaveChanges() > 0;
        }
        public bool UpdateProduct(Product product)
        {
            if (product == null)
            {
                return false;
            }
            Product existingProduct = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (existingProduct == null)
            {
                return false;
            }
            existingProduct.ProductName = product.ProductName;
            existingProduct.UnitPrice = product.UnitPrice;
            existingProduct.UnitsInStock = product.UnitsInStock;
            existingProduct.CategoryId = product.CategoryId;
            return context.SaveChanges() > 0;
        }
        public bool DeleteProduct(int productId)
        {
            Product product = context.Products.FirstOrDefault(p => p.ProductId == productId);
            if (product == null)
            {
                return false;
            }
            context.Products.Remove(product);
            return context.SaveChanges() > 0;
        }
    }
}
