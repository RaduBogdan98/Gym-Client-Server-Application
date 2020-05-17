using FitNessCompanionApp.ViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        private void PreviewPasswordInput(object sender, TextCompositionEventArgs e)
        {

        }

        private async void PreviewEmailInput(object sender, TextChangedEventArgs e)
        {
            string email = (sender as TextBox).Text;

            if (email != "")
            {
                bool? isExistent = await VM.IsEmailAlreadyExistent(email);

                if (true == isExistent)
                {
                    this.EmailBubble.Fill = Brushes.Red;
                }
                else
                {
                    this.EmailBubble.Fill = Brushes.Green;
                }
            }
            else
            {
                this.EmailBubble.Fill = Brushes.Red;
            }
        }


        private async void PreviewUsernameInput(object sender, TextChangedEventArgs e)
        {
            string username = (sender as TextBox).Text;

            if (username != "")
            {
                bool? isExistent = await VM.IsUsernameAlreadyExistent(username);
                if (true == isExistent)
                {
                    this.UsernameBubble.Fill = Brushes.Red;
                }
                else
                {
                    this.UsernameBubble.Fill = Brushes.Green;
                }
            }
            else
            {
                this.UsernameBubble.Fill = Brushes.Red;
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string insertedUsername = this.Name_Login.Text;
            string insertedPassword = this.Password_Login.Password;

            if (Enumerable.All(new string[] { insertedUsername, insertedPassword }, s => s != ""))
            {
                bool? requestRestult = VM.CheckLoginCredentials(insertedUsername, insertedPassword);
                if (true == requestRestult)
                {
                    this.DialogResult = true;
                    this.Close();
                }
                else if (false == requestRestult)
                {
                    new MessageDialog("Wrong credentials! Retry or Sign Up!").Show();
                }
            }
            else
            {
                new MessageDialog("Wrong input!").Show();
            }
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            string insertedUsername = this.Name_SignUp.Text;
            string insertedEmail = this.Email_SignUp.Text;
            string insertedPassword = this.Password_SignUp.Password;
            string insertedConfirmPassword = this.PasswordConfirm_SignUp.Password;

            if (Enumerable.All(new string[] { insertedUsername, insertedEmail, insertedPassword, insertedConfirmPassword }, s => s != "") && AllSignUpChecksAreCorrect())
            {
                bool? requestResult = VM.CheckSignUpCredentials(insertedUsername, insertedEmail, insertedPassword, insertedConfirmPassword);
                if (true == requestResult)
                {
                    this.DialogResult = true;
                    this.Close();
                }
            }
            else
            {
                new MessageDialog("Wrong input!").Show();
            }
        }

        private bool AllSignUpChecksAreCorrect()
        {
            return (this.EmailBubble.Fill == Brushes.Green &&
                    this.UsernameBubble.Fill == Brushes.Green);
        }
        #endregion

        #region Fields
        private LoginViewModel VM;
        #endregion
    }
}
