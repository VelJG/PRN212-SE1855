using BusinessObjects;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductService productService=new ProductService();
  
        bool isCompleted = false;

        public ProductWindow()
        {
            InitializeComponent();
            
            DisplayProduct();
           
        }
        public void DisplayProduct()
        {
            isCompleted = false;
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource=productService.GetProducts();
            isCompleted = true;
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            isCompleted = false;

            Product p = new Product();
            p.Id=int.Parse(txtId.Text);
            p.Name=txtName.Text;
            p.Price=double.Parse(txtPrice.Text);
            p.Quantity=int.Parse(txtQuantity.Text);
            bool ret = productService.SaveProducts(p);
            if (ret) {
                lvProduct.ItemsSource=null;
                lvProduct.ItemsSource = productService.GetProducts();
            }
            else
            {
                MessageBox.Show("Error adding product");
            }
            isCompleted = true;

        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isCompleted == false)
            {
                return; //CRUD not done yet
            }
            if(e.AddedItems.Count < 0)
            {
                return; //User hasnt choose an item yet
            }
            Product p = e.AddedItems[0] as Product;
            if (p == null)
            {
                return; //Nope not doing this today
            }
            txtId.Text=p.Id.ToString();
            txtName.Text=p.Name.ToString();
            txtQuantity.Text=p.Quantity.ToString();
            txtPrice.Text=p.Price.ToString();

        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                isCompleted = false;
                int id = int.Parse(txtId.Text);
                string name = txtName.Text;
                double price = double.Parse(txtPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);
                Product p = new Product() { Id = id, Name = name, Price = price, Quantity = quantity };
                bool kq = productService.UpdateProducts(p);
                if (kq == true)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProducts();
                }
                isCompleted = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nuh uh, error"+ex.Message);
            }
           
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                MessageBoxResult ret= MessageBox.Show(
                    "Are you sure you want to delete this?",
                    "Confirm deletion",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                    );
                if(ret == MessageBoxResult.No)
                {
                    return;
                }
                isCompleted = false;
                Product pDel=new Product();
                pDel.Id=int.Parse(txtId.Text);
                bool kq = productService.DeleteProducts(pDel);
                if (kq == true)
                {
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = productService.GetProducts();
                }
                isCompleted = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Nuh uh, error" + ex.Message);
            }
        }
    }
}
