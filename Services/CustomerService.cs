using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }
        public void GenerateSampleDataset()
        {
            _customerRepository.GenerateSampleDataset();
        }

        public List<Customer> GetCustomers()
        {
            return _customerRepository.GetCustomers();
        }
    }
}
