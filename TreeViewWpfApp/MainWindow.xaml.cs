using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TreeViewWpfApp.models;

namespace TreeViewWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Dictionary<int, Category> categories = SampleDataset.GenerateDataset();
        public MainWindow()
        {
            InitializeComponent();
            DisplayDatasetOnTreeView();
        }
        private void DisplayDatasetOnTreeView()
        {
            tvCategories.Items.Clear();
            TreeViewItem root = new TreeViewItem();
            root.Header = "Binh Duong Storage";
            tvCategories.Items.Add(root);
            //Use first loop to add Category to tree
            foreach(KeyValuePair<int, Category> item in categories)
            {
                Category cate=item.Value;
                TreeViewItem cate_node=new TreeViewItem();
                cate_node.Header = cate;
                root.Items.Add(cate_node);
                foreach(KeyValuePair<int,Product> subitem in cate.Products)
                {
                    Product product=subitem.Value;
                    TreeViewItem product_node=new TreeViewItem();
                    product_node.Header = product;
                    cate_node.Items.Add(product_node);
                }
            }
        }
    }
}