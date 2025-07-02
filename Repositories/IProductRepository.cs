using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductRepository
    {
        public void GenerateSampleDataset();
        public List<Product> GetProducts();
        public bool SaveProducts(Product product);
        public bool UpdateProducts(Product product);
        public bool DeleteProducts(Product product);
    }
}
