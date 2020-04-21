using FitNessCompanionApp.ViewModels;
using System.Windows.Controls;

namespace FitNessCompanionApp.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        public HomePage()
        {
            InitializeComponent();
            VM = new HomePageViewModel(this.FadingCanvas);
            this.DataContext = VM;
            VM.setImageChangeTimer();
        }

        #region Fields
        private HomePageViewModel VM;
        #endregion
    }
}
