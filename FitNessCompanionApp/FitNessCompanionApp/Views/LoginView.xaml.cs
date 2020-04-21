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
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            VM = new LoginViewModel();
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

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string insertedUsername = this.User_Login.Text;
            string insertedPassword = this.Password_Login.Password;

            this.DialogResult = VM.CheckLoginCredentials(insertedUsername, insertedPassword);
            this.Close();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string insertedName = this.Name_SignUp.Text;
            string insertedEmail = this.Email_SignUp.Text;
            string insertedUsername = this.User_SignUp.Text;
            string insertedPassword = this.Password_SignUp.Password;
            string insertedConfirmPassword = this.PasswordConfirm_SignUp.Password;

            this.DialogResult = VM.CheckSignUpCredentials(insertedName, insertedEmail, insertedUsername, insertedPassword, insertedConfirmPassword);
            this.Close();
        }
        #endregion

        #region Fields
        private LoginViewModel VM;
        #endregion
    }
}
