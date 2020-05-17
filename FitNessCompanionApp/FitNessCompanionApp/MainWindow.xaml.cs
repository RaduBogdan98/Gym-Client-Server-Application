using FitNessCompanionApp.Pages;
using FitNessCompanionApp.ViewModels;
using FitNessCompanionApp.Views;
using System.Windows;
using System.Windows.Input;

namespace FitNessCompanionApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            LoginView login = new LoginView();
            bool? accepted = login.ShowDialog();

            if (true == accepted)
            {
                try
                {
                    InitializeComponent();
                    homePage = new HomePage();
                    productsPage = new ProductsPage(this);
                    contactPage = new ContactPage();
                    userPage = new UserPage();
                    VM = MainWindowViewModel.Instance;

                    this.MainGrid.Children.Add(homePage);
                    this.DataContext = VM;
                }
                catch
                {
                    MessageBox.Show("Server is not running! Start the server and restart the application!");
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
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

        private void GoToHome(object sender, RoutedEventArgs e)
        {
            this.MainGrid.Children.Clear();
            this.MainGrid.Children.Add(homePage);
        }

        private void GoToProducts(object sender, RoutedEventArgs e)
        {
            this.MainGrid.Children.Clear();

            if (VM.ShouldProductsPageUpdate == true)
            {
                productsPage = new ProductsPage(this);
                MainWindowViewModel.Instance.ShouldProductsPageUpdate = false;
            }

            this.MainGrid.Children.Add(productsPage);
        }

        private void GoToContact(object sender, RoutedEventArgs e)
        {
            this.MainGrid.Children.Clear();
            this.MainGrid.Children.Add(contactPage);
        }

        private void GoToUserPage(object sender, RoutedEventArgs e)
        {
            this.MainGrid.Children.Clear();

            if(VM.ShouldUserPageUpdate == true)
            {
                userPage = new UserPage();
                MainWindowViewModel.Instance.ShouldUserPageUpdate = false;
            }

            this.MainGrid.Children.Add(userPage);
        }

        private void DisplayCart(object sender, RoutedEventArgs e)
        {
            new CartView().ShowDialog();
        }
        #endregion

        #region Fields
        private HomePage homePage;
        private ProductsPage productsPage;
        private ContactPage contactPage;
        private UserPage userPage;
        private MainWindowViewModel VM;
        #endregion
    }
}
