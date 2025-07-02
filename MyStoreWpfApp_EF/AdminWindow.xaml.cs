using MyStoreWpfApp_EF.Models;
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

namespace MyStoreWpfApp_EF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        MyStoreContext context = new MyStoreContext();
        public AdminWindow()
        {
            InitializeComponent();
            LoadCategoryIntoTreeView();
        }

        private void LoadCategoryIntoTreeView()
        {
            tvCategory.Items.Clear();
            TreeViewItem root = new TreeViewItem
            {
                Header = "Cat Lai Inventory",
            };
            tvCategory.Items.Add(root);
            var categories = context.Categories
                .ToList();
            foreach (var category in categories)
            {
                TreeViewItem cate_node = new TreeViewItem();
                cate_node.Header = category.CategoryName;
                cate_node.Tag = category;
                root.Items.Add(cate_node);

                var products = context.Products
                    .Where(p => p.CategoryId == category.CategoryId)
                    .ToList();
                foreach (var product in products)
                {
                    TreeViewItem product_node = new TreeViewItem();
                    product_node.Header = product.ProductName;
                    product_node.Tag = product;
                    cate_node.Items.Add(product_node);

                }
            }
            root.ExpandSubtree();
        }


        private void LoadProductsIntoListView(Category category)
        {
            var products = context.Products
                 .Where(p => p.CategoryId == category.CategoryId)
                 .ToList();
            lvProduct.ItemsSource = null;
            lvProduct.ItemsSource = products;
        }

        private void tvCategory_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue == null)
            {
                return;
            }
            TreeViewItem selectedItem = e.NewValue as TreeViewItem;
            Category category = selectedItem.Tag as Category;
            if (category != null)
            {
                LoadProductsIntoListView(category);
            }
            Product product = selectedItem.Tag as Product;
            if (product != null)
            {
                var products = new List<Product>();
                products.Add(product);
                lvProduct.ItemsSource = null;
                lvProduct.ItemsSource = products;
            }


        }
        private void lvProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count <= 0)
            {
                return;
            }
            Product product = e.AddedItems[0] as Product;
            if (product != null)
            {
                DisplayProductDetails(product);
            }

        }
        private void DisplayProductDetails(Product product)
        {
            if (product == null)
            {
                txtId.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtQuantity.Text = string.Empty;
            }
            else
            {
                txtId.Text = product.ProductId.ToString();
                txtName.Text = product.ProductName;
                txtPrice.Text = product.UnitPrice.ToString();
                txtQuantity.Text = product.UnitsInStock.ToString();
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            DisplayProductDetails(null);
            txtId.Focus();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Create product
                //Add product to cate
                //Save
                //UPdate View
                Product product = new Product
                {
                    ProductName = txtName.Text,
                    UnitPrice = decimal.Parse(txtPrice.Text),
                    UnitsInStock = short.Parse(txtQuantity.Text)
                };
                TreeViewItem cate_node_selected = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node_selected == null)
                {
                    MessageBox.Show(
                        "Please select a category to add product.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                Category cate = cate_node_selected.Tag as Category;
                if (cate == null)
                {
                    MessageBox.Show(
                        "Please select a category to add product.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                product.CategoryId = cate.CategoryId;
                context.Products.Add(product);
                context.SaveChanges();
                TreeViewItem product_node = new TreeViewItem
                {
                    Header = product.ProductName,
                    Tag = product
                };
                cate_node_selected.Items.Add(product_node);
                LoadProductsIntoListView(cate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Please enter valid data for product.",
                    "Error " + ex.Message,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            //Check if product exists
            //Update product
            //Save Product
            //Update View
            try
            {
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show(
                        "Product not found.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                product.ProductName = txtName.Text;
                product.UnitPrice = decimal.Parse(txtPrice.Text);
                product.UnitsInStock = short.Parse(txtQuantity.Text);
                context.SaveChanges();
                TreeViewItem cate_node_selected = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node_selected != null)
                {
                    Category cate = cate_node_selected.Tag as Category;
                    if (cate != null)
                    {
                        cate_node_selected.Items.Clear();
                        var p = context.Products
                        .Where(p => p.CategoryId == cate.CategoryId)
                        .ToList();
                        foreach (var pro in p)
                        {
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = pro.ProductName;
                            product_node.Tag = pro;
                            cate_node_selected.Items.Add(product_node);
                        }
                        LoadProductsIntoListView(cate);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Please enter valid data for product.",
                    "Error " + ex.Message,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Find product to delete
            // Confirm delete?
            // Delete product
            // Save changes
            // Update view
            try
            {
                int id = int.Parse(txtId.Text);
                Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
                if (product == null)
                {
                    MessageBox.Show(
                        "Product not found.",
                        "Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }
                MessageBoxResult result = MessageBox.Show(
                    "Are you sure you want to delete this product?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                if (result == MessageBoxResult.No)
                {
                    return;
                }
                context.Products.Remove(product);
                context.SaveChanges();
                DisplayProductDetails(null);
                TreeViewItem cate_node_selected = tvCategory.SelectedItem as TreeViewItem;
                if (cate_node_selected != null)
                {
                    Category cate = cate_node_selected.Tag as Category;
                    if (cate != null)
                    {
                        cate_node_selected.Items.Clear();
                        var p = context.Products
                        .Where(p => p.CategoryId == cate.CategoryId)
                        .ToList();
                        foreach (var pro in p)
                        {
                            TreeViewItem product_node = new TreeViewItem();
                            product_node.Header = pro.ProductName;
                            product_node.Tag = pro;
                            cate_node_selected.Items.Add(product_node);
                        }
                        LoadProductsIntoListView(cate);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    "Error deleting product: " + ex.Message,
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            
        }
    }
}
