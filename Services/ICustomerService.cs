using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal interface ICustomerService
    {
        public void GenerateSampleDataset();
        public List<Customer> GetCustomers(); 
    }
}
