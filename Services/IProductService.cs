using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IProductService
    {
        public void GenerateSampleDataset();
        public List<Product> GetProducts();
        public bool UpdateProducts(Product product);
        public bool DeleteProducts(Product product);
    }
}
