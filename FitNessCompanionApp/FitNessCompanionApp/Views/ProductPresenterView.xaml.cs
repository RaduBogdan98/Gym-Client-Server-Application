using FitNessCompanionApp.ViewModels;
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

namespace FitNessCompanionApp.Views
{
    /// <summary>
    /// Interaction logic for ProductPresenterView.xaml
    /// </summary>
    public partial class ProductPresenterView : Window
    {
        public ProductPresenterView(string name, string description, string price, string imageSource)
        {
            InitializeComponent();
            VM = new ProductsPresenterViewModel(name, description, price, imageSource);
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
            this.Close();
        }
        #endregion

        #region Fields
        private ProductsPresenterViewModel VM;
        #endregion
    }
}
