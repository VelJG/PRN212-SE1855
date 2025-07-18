using BusinessObjects_EF;
using DataAccessLayer_EF;
using Services_EF;
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

namespace WpfApp_EF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly ICategoryService _categoryService = new CategoryService();
        private readonly IProductService _productService = new ProductService();

        bool is_loaded_products = false;
        Category selectedCategory = null;
        Product selectedProduct = null;
        public AdminWindow()
        {
            InitializeComponent();
            is_loaded_products = false;
            LoadCategoriesAndProductsIntoTreeView();
            is_loaded_products = true;
        }

        private void LoadCategoriesAndProductsIntoTreeView()
        {
            TreeViewItem rootItem = new TreeViewItem { Header = "Cat Lai Inventory" };
            tvCategory.Items.Add(rootItem);
            List<Category> categories = _categoryService.GetAllCategories();
            foreach (Category category in categories)
            {
                TreeViewItem cate_node = new TreeViewItem
                {
                    Header = category.CategoryName,
                    Tag = category
                };
                rootItem.Items.Add(cate_node);
                var products = _productService.GetProductsByCategory(category.CategoryId);
                category.Products = products;
                foreach (Product product in category.Products)
                {
                    TreeViewItem product_node = new TreeViewItem
                    {
                        Header = product.ProductName,
                        Tag = product
                    };
                    cate_node.Items.Add(product_node);
                }
            }
            rootItem.ExpandSubtree();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                TreeViewItem categoryItem = tvCategory.SelectedItem as TreeViewItem;
                if (categoryItem == null || selectedCategory == null)
                {
                    MessageBox.Show("Please select a category to save.", "Haven't chosen a category", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Product product = new Product
                {
                    ProductName = txtName.Text,
                    UnitPrice = decimal.Parse(txtPrice.Text),
                    UnitsInStock = short.Parse(txtQuantity.Text),
                    CategoryId = selectedCategory.CategoryId
                };
                bool result = _productService.SaveProduct(product);
                if (result)
                {
                    TreeViewItem productNode = new TreeViewItem
                    {
                        Header = product.ProductName,
                        Tag = product
                    };
                    categoryItem.Items.Add(productNode);
                    var products = _productService.GetProductsByCategory(selectedCategory.CategoryId);
                    is_loaded_products = false;
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = products;
                    is_loaded_products = true;
                }
                else
                {
                    MessageBox.Show("Failed to save product. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                is_loaded_products = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TreeViewItem categoryItem = tvCategory.SelectedItem as TreeViewItem;

                if ((categoryItem == null || selectedCategory == null)|| selectedProduct==null)
                {
                    MessageBox.Show("Please select a category to update or product.", "Haven't chosen a category or product", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                Product product = new Product
                {
                    ProductId = int.Parse(txtId.Text),
                    ProductName = txtName.Text,
                    UnitPrice = decimal.Parse(txtPrice.Text),
                    UnitsInStock = short.Parse(txtQuantity.Text),
                    CategoryId = selectedCategory.CategoryId
                };
                bool result = _productService.UpdateProduct(product);
                if (result)
                {
                    is_loaded_products = false;
                    categoryItem.Items.Clear();
                    var products = _productService.GetProductsByCategory(selectedCategory.CategoryId);
                    foreach (var p in products)
                    {
                        TreeViewItem productNode = new TreeViewItem
                        {
                            Header = p.ProductName,
                            Tag = p
                        };
                        categoryItem.Items.Add(productNode);
                    }
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = products;
                    is_loaded_products = true;
                }
                else
                {
                    MessageBox.Show("Failed to update product. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                is_loaded_products = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                TreeViewItem categoryItem = tvCategory.SelectedItem as TreeViewItem;
                if (categoryItem == null || selectedCategory == null)
                {
                    MessageBox.Show("Please select a category to delete.", "Haven't chosen a category", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                MessageBoxResult confirmResult = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if(confirmResult == MessageBoxResult.No)
                {
                    return; 
                }
                bool result = _productService.DeleteProduct(int.Parse(txtId.Text));
                if (result)
                {
                    is_loaded_products = false;
                    categoryItem.Items.Clear();
                    var products = _productService.GetProductsByCategory(selectedCategory.CategoryId);
                    foreach (var p in products)
                    {
                        TreeViewItem productNode = new TreeViewItem
                        {
                            Header = p.ProductName,
                            Tag = p
                        };
                        categoryItem.Items.Add(productNode);
                    }
                    lvProduct.ItemsSource = null;
                    lvProduct.ItemsSource = products;
                    is_loaded_products = true;
                }
                else
                {
                    MessageBox.Show("Failed to delete product. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                is_loaded_products = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while deleting the product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            is_loaded_products = false;
            selectedCategory = null;
            if (e.NewValue == null)
            {
                return;
            }
            TreeViewItem selectedItem = e.NewValue as TreeViewItem;
            if (selectedItem == null)
            {
                return;
            }
            List<Product> products = null;
            object data = selectedItem.Tag;
            if (data == null)
            {// User selected the root item or an empty item => Show all Product
                products = _productService.GetAllProducts();
            }
            else if (data is Category)
            {//User selected a Category
                Category category = data as Category;
                selectedCategory = category;
                products = _productService.GetProductsByCategory(category.CategoryId);
            }
            else if (data is Product)
            {//User selected a Product
                Product product = data as Product;
                products = new List<Product> { product };
            }
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
            is_loaded_products = true;
        }

        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedProduct = null;
            if (is_loaded_products == false)
            {
                return;
            }
            if (e.AddedItems.Count <= 0)
            {
                return;
            }
            Product selectedPro = e.AddedItems[0] as Product;
            txtId.Text = selectedPro.ProductId.ToString();
            txtName.Text = selectedPro.ProductName;
            txtPrice.Text = selectedPro.UnitPrice.ToString();
            txtQuantity.Text = selectedPro.UnitsInStock.ToString();
            selectedProduct = selectedPro;

        }
    }
}
