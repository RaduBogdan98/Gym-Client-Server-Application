using FitNessCompanionApp.Model;
using FitNessCompanionApp.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace FitNessCompanionApp.Pages
{
    /// <summary>
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : UserControl
    {
        public UserPage()
        {
            InitializeComponent();
            VM = UserPageViewModel.GetInstance();

            this.DataContext = VM;
            ShowUserDetails(null, null);
        }

        #region ClickEvents
        private void ShowUserDetails(object sender, RoutedEventArgs e)
        {
            this.UserDetailsButton.IsEnabled = false;
            this.OrdersButton.IsEnabled = true;
            this.ProductsButton.IsEnabled = true;
            this.LogOutButton.IsEnabled = true;

            this.UserDetailsGrid.Visibility = Visibility.Visible;
            this.ProductsGrid.Visibility = Visibility.Collapsed;
            this.OrdersGrid.Visibility = Visibility.Collapsed;
        }

        private void ShowOrders(object sender, RoutedEventArgs e)
        {
            this.UserDetailsButton.IsEnabled = true;
            this.OrdersButton.IsEnabled = false;
            this.ProductsButton.IsEnabled = true;
            this.LogOutButton.IsEnabled = true;

            this.UserDetailsGrid.Visibility = Visibility.Collapsed;
            this.ProductsGrid.Visibility = Visibility.Collapsed;
            this.OrdersGrid.Visibility = Visibility.Visible;
        }

        private void ShowProducts(object sender, RoutedEventArgs e)
        {
            this.UserDetailsButton.IsEnabled = true;
            this.OrdersButton.IsEnabled = true;
            this.ProductsButton.IsEnabled = false;
            this.LogOutButton.IsEnabled = true;

            this.UserDetailsGrid.Visibility = Visibility.Collapsed;
            this.ProductsGrid.Visibility = Visibility.Visible;
            this.OrdersGrid.Visibility = Visibility.Collapsed;
        }

        private void LogOut(object sender, RoutedEventArgs e)
        {
            this.UserDetailsButton.IsEnabled = true;
            this.OrdersButton.IsEnabled = true;
            this.ProductsButton.IsEnabled = true;
            this.LogOutButton.IsEnabled = false;

            Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        private void RemoveOrder(object sender, RoutedEventArgs e)
        {
            FindAncestor<ListBoxItem>(sender as Button).IsSelected = true;
            VM.RemoveOrder(this.OrdersList.SelectedIndex);
        }
        #endregion

        #region Methods
        public static T FindAncestor<T>(DependencyObject from)
          where T : class
        {
            if (from == null)
            {
                return null;
            }

            T candidate = from as T;
            if (candidate != null)
            {
                return candidate;
            }

            return FindAncestor<T>(System.Windows.Media.VisualTreeHelper.GetParent(from));
        }
        #endregion

        #region Fields
        private UserPageViewModel VM;
        #endregion
    }
}
