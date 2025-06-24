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
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductService productService=new ProductService();
        public ProductWindow()
        {
            InitializeComponent();
            DisplayProduct();
           
        }
        public void DisplayProduct()
        {
            productService.GenerateSampleDataset();
            lvProduct.ItemsSource=productService.GetProducts();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
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
                MessageBox.Show("Có lỗi xảy ra khi thêm mới sản phẩm");
            }
        }
    }
}
