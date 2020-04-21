using FitNessCompanionApp.Pages;
using FitNessCompanionApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                InitializeComponent();
                this.MainGrid.Children.Add(new HomePage());
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
            this.MainGrid.Children.Add(new HomePage());
        }

        private void GoToProducts(object sender, RoutedEventArgs e)
        {
            this.MainGrid.Children.Clear();
            this.MainGrid.Children.Add(new ProductsPage(this));
        }

        private void GoToContact(object sender, RoutedEventArgs e)
        {
            this.MainGrid.Children.Clear();
            this.MainGrid.Children.Add(new ContactPage());
        }
        #endregion
    }
}
