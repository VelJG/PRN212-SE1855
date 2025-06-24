using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQToObject2
{
    public class ListProduct
    {
        List<Product> products;
        public ListProduct()
        {
            products = new List<Product>();
        }
        public void gen_products()
        {
            products.Add(new Product() { Id = 1, Name = "P1", Quantity = 10, Price=20 });
            products.Add(new Product() { Id = 2, Name = "P2", Quantity = 30, Price=23 });
            products.Add(new Product() { Id = 3, Name = "P3", Quantity = 50, Price=223 });
            products.Add(new Product() { Id = 4, Name = "P4", Quantity = 60, Price=10 });
            products.Add(new Product() { Id = 5, Name = "P5", Quantity = 70, Price=130 });
            products.Add(new Product() { Id = 6, Name = "P6", Quantity = 80, Price=50 });
            products.Add(new Product() { Id = 7, Name = "P7", Quantity = 90, Price=70 });
            products.Add(new Product() { Id = 8, Name = "P8", Quantity = 120, Price=80 });
            products.Add(new Product() { Id = 9, Name = "P9", Quantity = 5, Price=250 });
            products.Add(new Product() { Id = 10, Name = "P10", Quantity = 15, Price=103 });
        }
        public List<Product> FilterProductByPrice(double a, double b)
        {
            return products.Where(p=>p.Price>=a&&p.Price<=b).ToList();
        }
        public List<Product> FilterProductByPrice2(double a, double b)
        {
            var result = from p in products where p.Price >= a && p.Price <= b select p;
            return result.ToList();
        }
        public List<Product> SortProductByPriceDesc()
        {
            return products.OrderByDescending(p => p.Price).ToList();
        }
        public List<Product> SortProductByPriceDesc2() 
        {
            var result = from p in products orderby p.Price descending select p;
            return result.ToList();
        }
        public double TotalPrice()
        {
            return products.Sum(p=>p.Price);
        }
        public double TotalPrice2()
        {
            var result= (from p in products select p.Price).Sum();
            return result;
        }

    }
}
