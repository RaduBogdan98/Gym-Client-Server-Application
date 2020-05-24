using FitNessCompanionApp.Model;
using FitNessCompanionApp.Views;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FitNessCompanionApp.ViewModels
{
    class LoginViewModel
    {
        #region Properties
        public string PasswordHint
        {
            get
            {
                return "Use upper-case and lower-case letters, numbers and separators like: _ -";
            }
        }
        public string EmailHint
        {
            get
            {
                return "<user_email>@<domain>.<tld>";
            }
        }
        #endregion

        #region Methods
        internal bool? CheckLoginCredentials(string username, string password)
        {
            try
            {
                using (HttpClient http = new HttpClient())
                {
                    HttpResponseMessage httpResponse = http.GetAsync("http://localhost:8080//users/login/" + username + "/" + password).Result;
                    string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                    if(responseContent != "")
                    {
                        User logedUser = JsonConvert.DeserializeObject<User>(responseContent);
                        UserPageViewModel.SetCurrentUser(logedUser);
                        return (logedUser != null);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                MessageDialog.ShowMessage("Server is not running!");
                return null;
            }
        }

        internal async Task<bool?> IsUsernameAlreadyExistent(string username)
        {
            try
            {
                using (HttpClient http = new HttpClient())
                {
                    HttpResponseMessage httpResponse = await Task.Run(() => http.GetAsync("http://localhost:8080//users/isUsername/" + username ).Result);
                    string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<bool>(responseContent);
                }
            }
            catch
            {
                MessageDialog.ShowMessage("Server is not running!");
                return null;
            }
        }

        internal async Task<bool?> IsEmailAlreadyExistent(string email)
        {
            try
            {
                using (HttpClient http = new HttpClient())
                {
                    HttpResponseMessage httpResponse = await Task.Run(() => http.GetAsync("http://localhost:8080//users/isEmail/" + email).Result);
                    string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<bool>(responseContent);
                }
            }
            catch
            {
                MessageDialog.ShowMessage("Server is not running!");
                return null;
            }
        }

        internal bool? CheckSignUpCredentials(string username, string email, string password, string confirmPassword)
        {
            try
            {
                if (!password.Equals(confirmPassword))
                {
                    MessageDialog.ShowMessage("Passwords don't match!");
                    return false;
                }
                else
                {
                    using (HttpClient http = new HttpClient())
                    {
                        User newUser = new User(username, email, password);
                        HttpContent postContent = new StringContent(JsonConvert.SerializeObject(newUser), Encoding.UTF8, "application/json");

                        HttpResponseMessage httpResponse = http.PostAsync("http://localhost:8080//users/add", postContent).Result;
                        UserPageViewModel.SetCurrentUser(newUser);

                        return true;
                    }
                }
            }
            catch
            {
                MessageDialog.ShowMessage("Server is not running!");
                return null;
            }
        }

        private bool isUserAlreadyExistent(string username, string email, string password)
        {
            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage httpResponse = http.GetAsync("http://localhost:8080//users/exists/" + username + "/" + email + "/" + password).Result;
                string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<bool>(responseContent);
            }
        }
        #endregion
    }
}
