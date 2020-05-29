using FitNessCompanionApp.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FitNessCompanionApp.Views
{
    /// <summary>
    /// Interaction logic for CartView.xaml
    /// </summary>
    public partial class CartView : Window
    {
        public CartView()
        {
            InitializeComponent();
            VM = CartViewModel.Instance;
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

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            VM.postOrder();
            this.DialogResult = true;
            this.Close();
        }

        private void RemoveClick(object sender, RoutedEventArgs e)
        {
            String productName = ((TextBlock)((sender as Button).Parent as Grid).FindName("ProductName")).Text;
            VM.removeOrderItem(productName);
        }

        private void QuantityOrdered_TextChanged(object sender, TextChangedEventArgs e)
        {
            String productName = ((TextBlock)(((Grid)((WrapPanel)(sender as TextBox).Parent).Parent).Parent as Grid).FindName("ProductName")).Text;
            String newQuantity = (sender as TextBox).Text;
            if (newQuantity != "")
            {
                CartViewModel.Instance.changeProductQuantity(productName, int.Parse(newQuantity));
            }
        }

        private void QuantityOrdered_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            foreach (char ch in e.Text)
            {
                if(!Char.IsDigit(ch))
                {
                    e.Handled = true;
                    return;
                }
            }

            String productName = ((TextBlock)(((Grid)((WrapPanel)(sender as TextBox).Parent).Parent).Parent as Grid).FindName("ProductName")).Text;
            String newQuantity = (sender as TextBox).Text + e.Text;

            if (newQuantity != "" && int.Parse(newQuantity) > ProductsPageViewModel.Instance.findProductByName(productName).Stock)
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Fields
        private CartViewModel VM;
        #endregion
    }
}
