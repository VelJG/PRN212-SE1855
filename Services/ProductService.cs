using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }
        public void GenerateSampleDataset()
        {
            _productRepository.GenerateSampleDataset();
        }

        public List<Product> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public bool SaveProducts(Product product)
        {
            return _productRepository.SaveProducts(product);
        }
        public bool UpdateProducts(Product product)
        {
            return _productRepository.UpdateProducts(product);
        }
        public bool DeleteProducts(Product product)
        {
            return _productRepository.DeleteProducts(product);
        }
    }
}
