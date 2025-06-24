using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP5_Dictionary
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int,Product> Products { get; set; }
        public Category() {
            Products = new Dictionary<int,Product>();
        }
        /*
         * Mọi dữ liệu cần làm đủ: CRUD
         */
        public void AddProduct(Product p) {
            if (Products.ContainsKey(p.Id)) {
                return;
            }
            Products.Add(p.Id, p);
        }
        public void PrintAllProduct()
        {
            foreach(KeyValuePair<int,Product> item in Products)
            {
                Product p=item.Value;
                Console.WriteLine(p);
            }
        }
        //Filter products with price range from x to y
        public Dictionary<int,Product> FilterProductByPrice(double min, double max)
        {
            Dictionary<int, Product> results = new Dictionary<int, Product>();
            results=Products.Where(item=>item.Value.Price >= min && 
                                         item.Value.Price <= max).ToDictionary<int,Product>();
            return results;
        }
        //Sort products by price asc
        public Dictionary<int,Product> SortProductByPriceAsc()
        {

            return Products.OrderBy(item=>item.Value.Price).ToDictionary<int,Product>();
        }

        //Sort product by price asc, if same sort by quantity desc

        public Dictionary<int,Product> ComplexSort()
        {
            return Products.OrderByDescending(item=>item.Value.Quantity).ToDictionary<int,Product>()
                .OrderBy(item => item.Value.Price)
                .ToDictionary<int, Product>();
        }
        public bool UpdateProduct(Product p)
        {
            if(p==null) return false;
            if(Products.ContainsKey(p.Id)==false) return false;
            Products[p.Id] = p;
            return true;
        }

        public bool RemoveProduct(int id)
        {
            if(Products.ContainsKey(id)==false) return false;
            return Products.Remove(id);
        }
    }
}
