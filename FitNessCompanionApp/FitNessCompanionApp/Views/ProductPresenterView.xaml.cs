using FitNessCompanionApp.Model;
using FitNessCompanionApp.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FitNessCompanionApp.Views
{
    /// <summary>
    /// Interaction logic for ProductPresenterView.xaml
    /// </summary>
    public partial class ProductPresenterView : Window
    {
        public ProductPresenterView(string name, string description, string price, ImageSource imageSource, ProductsPageViewModel ProductsVM)
        {
            InitializeComponent();
            VM = new ProductsPresenterViewModel(name, description, price, imageSource);
            this.ProductsVM = ProductsVM;
            this.DataContext = VM;
        }

        #region Methods
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized: this.WindowState = WindowState.Normal; break;
                case WindowState.Normal: this.WindowState = WindowState.Maximized; break;
            }
        }

        private void MenuBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

            Grid productGrid = ((DockPanel)(sender as Button).Parent).Parent as Grid;
            string productName = ((TextBlock)productGrid.FindName("ProductName")).Text;

            Product orderedProduct = ProductsVM.findProductByName(productName);
            CartViewModel.Instance.AddProduct(orderedProduct);
            MainWindowViewModel.Instance.NotifyCartItemsNumberChanged();

            this.Close();
        }
        #endregion

        #region Fields
        private ProductsPresenterViewModel VM;
        private ProductsPageViewModel ProductsVM;
        #endregion
    }
}
