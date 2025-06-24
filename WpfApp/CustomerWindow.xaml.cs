using BusinessObjects;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly CustomerService customerService = new CustomerService();

        public CustomerWindow()
        {
            InitializeComponent();
            DisplayAllCustomer();
        }

        private void DisplayAllCustomer()
        {
            customerService.GenerateSampleDataset();

            List<Customer> customers = customerService.GetCustomers();

            lvCustomer.ItemsSource = customers;
        }
    }
}
