using FitNessCompanionApp.Model;
using FitNessCompanionApp.ViewModels;
using FitNessCompanionApp.Views;
using System.Windows;
using System.Windows.Controls;

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
            VM = new ProductsPageViewModel();
            this.ListViewProducts.ItemsSource = VM.GetProducts();
            MainWindow = mainWindow;
        }

        #region Methods
        private void DisplayProductDetails(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if (b != null)
            {
                string productName = ((TextBlock)b.FindName("productName")).Text;
                string productDescription = ((TextBlock)b.FindName("productDescription")).Text;
                string imageSource = ((Image)b.FindName("imageSource")).Source.ToString();
                string productPrice = ((TextBlock)b.FindName("productPrice")).Text;

                MainWindow.Visibility = Visibility.Collapsed;
                ProductPresenterView view = new ProductPresenterView(productName, productDescription, productPrice, imageSource);
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
        #endregion

        #region Fields
        private ProductsPageViewModel VM;
        private Window MainWindow;
        #endregion
    }
}
