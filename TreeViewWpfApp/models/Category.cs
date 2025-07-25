﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewWpfApp.models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<int, Product> Products { get; set; }
        public Category()
        {
            Products = new Dictionary<int, Product>();
        }
        public void AddProduct(Product p)
        {
            if (p != null && !Products.ContainsKey(p.Id))
            {
                Products.Add(p.Id, p);
            }
        }
    }
}
