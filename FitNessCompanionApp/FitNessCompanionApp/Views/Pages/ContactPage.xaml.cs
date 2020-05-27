using FitNessCompanionApp.Model;
using FitNessCompanionApp.Views;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FitNessCompanionApp.Pages
{
    /// <summary>
    /// Interaction logic for ContactPage.xaml
    /// </summary>
    public partial class ContactPage : UserControl
    {
        public ContactPage()
        {
            InitializeComponent();
        }

        private async void SendFeedback(object sender, System.Windows.RoutedEventArgs e)
        {
            using (HttpClient http = new HttpClient())
            {
                EmailItem email = new EmailItem("feedback@fitness.com", this.Email.Text, "Feedback from - " + this.Name.Text, this.Message.Text);
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = await http.PostAsync("http://localhost:80/Emailer/emailer.php", httpContent);
                    MessageDialog.ShowMessage("Feedback was sent!");

                    this.Email.Clear();
                    this.Name.Clear();
                    this.Message.Clear();
                }
                catch
                {
                    MessageDialog.ShowMessage("Server error!");
                }
            }
        }
    }
}
