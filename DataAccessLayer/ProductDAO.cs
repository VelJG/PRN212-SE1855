using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        static List<Product> products = new List<Product>();
        public void GenerateSampleDataset()
        {
            products.Add(new Product() { Id=1, Name="Coca",Quantity=10,Price=100});
            products.Add(new Product() { Id =2, Name = "Pepsi", Quantity = 20, Price = 200 });
            products.Add(new Product() { Id = 3, Name = "Sting", Quantity = 15, Price = 120 });
            products.Add(new Product() { Id = 4, Name = "Mirinda", Quantity = 12, Price = 150 });
            products.Add(new Product() { Id = 5, Name = "Sprite", Quantity = 50, Price = 180 });

        }
        public List<Product> GetProducts()
        {
            return products;
        }
        public bool SaveProduct(Product product)
        {
            Product old =products.FirstOrDefault(p=>p.Id == product.Id);
            if (old != null) return false;
            products.Add(product);
            return true;
        }
        public bool UpdateProduct(Product product)
        {
            Product old = products.FirstOrDefault(p => p.Id == product.Id);
            if (old != null) return false;
            old.Name = product.Name;
            old.Quantity = product.Quantity;
            old.Price = product.Price;
            return true;
        }
    }
}
