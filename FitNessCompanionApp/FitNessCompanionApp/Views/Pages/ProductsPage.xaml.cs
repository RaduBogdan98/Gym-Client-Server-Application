using FitNessCompanionApp.Model;
using FitNessCompanionApp.ViewModels;
using FitNessCompanionApp.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FitNessCompanionApp.Pages
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : UserControl
    {
        public ProductsPage(Window mainWindow)
        {
            InitializeComponent();
            VM = ProductsPageViewModel.Instance;
            this.ListViewProducts.ItemsSource = VM.Products;
            MainWindow = mainWindow;
        }

        #region Methods
        private void DisplayProductDetails(object sender, RoutedEventArgs e)
        {
            Button productButton = sender as Button;

            if (productButton != null)
            {
                string productName = ((TextBlock)productButton.FindName("productName")).Text;
                string productDescription = ((TextBlock)productButton.FindName("productDescription")).Text;
                ImageSource imageSource = ((Image)productButton.FindName("imageSource")).Source;
                string productPrice = ((TextBlock)productButton.FindName("productPrice")).Text;

                MainWindow.Visibility = Visibility.Collapsed;
                ProductPresenterView view = new ProductPresenterView(productName, productDescription, productPrice, imageSource, VM);
                bool? productDialogResult = view.ShowDialog();

                if (true == productDialogResult)
                {
                    MainWindow.Visibility = Visibility.Visible;
                }
                else
                {
                    MainWindow.Close();
                }
            }
        }

        private void AddToCartClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Button productButton = ((Grid)(sender as Button).Parent).Parent as Button;

            string productName = ((TextBlock)productButton.FindName("productName")).Text;

            Product orderedProduct = VM.findProductByName(productName);

            if (orderedProduct.Stock > 0)
            {
                CartViewModel.Instance.AddProduct(orderedProduct);
                MainWindowViewModel.Instance.NotifyCartItemsNumberChanged();
            }
            else
            {
                MessageDialog.ShowMessage("Product out of stock!");
            }
        }
        #endregion

        #region Fields
        private ProductsPageViewModel VM;
        private Window MainWindow;
        #endregion
    }
}
