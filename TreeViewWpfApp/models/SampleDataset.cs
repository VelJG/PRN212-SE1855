using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewWpfApp.models
{
    public class SampleDataset
    {
        public static Dictionary<int,Category> GenerateDataset()
        {
            Dictionary<int, Category> categories = new Dictionary<int, Category>();
            Category c1=new Category()
            {
                Id=1,
                Name="Soda"
            };
            Category c2 = new Category()
            {
                Id = 2,
                Name = "Beer"
            };
            Category c3 = new Category()
            {
                Id = 3,
                Name = "Snack"
            };
            categories.Add(c1.Id,c1);
            categories.Add(c2.Id,c2);
            categories.Add(c3.Id, c3);

            Product p1 = new Product() { Id = 1, Name = "Coca", Quantity = 10, Price = 15 };
            Product p2 = new Product() { Id = 2, Name = "Sting", Quantity = 10, Price = 15 };
            Product p3 = new Product() { Id = 3, Name = "Pepsi", Quantity = 10, Price = 15 };
            Product p4 = new Product() { Id = 4, Name = "Mirinda", Quantity = 10, Price = 15 };
            Product p5 = new Product() { Id = 5, Name = "Redbull", Quantity = 10, Price = 15 };
            Product p6 = new Product() { Id = 6, Name = "Bia 333", Quantity = 10, Price = 15 };
            Product p7 = new Product() { Id = 7, Name = "Bia Tiger", Quantity = 10, Price = 15 };
            Product p8 = new Product() { Id = 8, Name = "Bia 456", Quantity = 10, Price = 15 };
            Product p9 = new Product() { Id = 9, Name = "Bia789", Quantity = 10, Price = 15 };
            Product p10 = new Product() { Id = 10, Name = "Bia234", Quantity = 10, Price = 15 };
            Product p11 = new Product() { Id = 11, Name = "Lays", Quantity = 10, Price = 15 };
            Product p12 = new Product() { Id = 12, Name = "Oishi", Quantity = 10, Price = 15 };
            Product p13 = new Product() { Id = 13, Name = "Oscar", Quantity = 10, Price = 15 };
            Product p14 = new Product() { Id = 14, Name = "Karamucho", Quantity = 10, Price = 15 };
            Product p15 = new Product() { Id = 15, Name = "Pringles", Quantity = 10, Price = 15 };

            c1.AddProduct(p1); // Coca
            c1.AddProduct(p2); // Sting
            c1.AddProduct(p3); // Pepsi
            c1.AddProduct(p4); // Mirinda
            c1.AddProduct(p5); // Redbull

            // Add Beer products
            c2.AddProduct(p6); // Bia 333
            c2.AddProduct(p7); // Bia Tiger
            c2.AddProduct(p8); // Bia 456
            c2.AddProduct(p9); // Bia 789
            c2.AddProduct(p10); // Bia 234


            c3.AddProduct(p11); 
            c3.AddProduct(p12); 
            c3.AddProduct(p13); 
            c3.AddProduct(p14); 
            c3.AddProduct(p15);

            return categories;
        }
    }
}
