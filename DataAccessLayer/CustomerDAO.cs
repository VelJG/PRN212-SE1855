using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();
        public void GenerateSampleDataset()
        {
            customers.Add(new Customer() { Id = 1, Name="Shiori Novella", PhoneNumber="099355556758" });
            customers.Add(new Customer() { Id = 2, Name="Koseki Bijou", PhoneNumber="093464555445" });
            customers.Add(new Customer() { Id = 3, Name="Nerissa Ravencroft", PhoneNumber="099534665756" });
            customers.Add(new Customer() { Id = 4, Name="Fuwawa Abyssguard", PhoneNumber="095465754598" });
            customers.Add(new Customer() { Id = 5, Name="Mococo Abyssguard", PhoneNumber="09435465466545" });
        }
        public List<Customer> GetCustomers() {
            return customers;
        }
    }
}
