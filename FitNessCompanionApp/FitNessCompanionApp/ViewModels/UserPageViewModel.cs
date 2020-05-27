using FitNessCompanionApp.Model;
using FitNessCompanionApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FitNessCompanionApp.ViewModels
{
    class UserPageViewModel : INotifyPropertyChanged
    {
        private UserPageViewModel(User user)
        {
            this.user = user;

            if (isAdmin(user))
            {
                this.userType = UserType.Admin;

            }
            else
            {
                this.userType = UserType.Regular;
            }

            products = RequestProductsFromServer();
            ordersList = RequestOrdersFromServer();

        }

        #region Methods
        internal static UserPageViewModel GetInstance()
        {
            return instance;
        }

        internal void Refresh()
        {
            instance = new UserPageViewModel(CurrentUser);
            MainWindowViewModel.Instance.ShouldUserPageUpdate = true;
        }

        internal static void SetCurrentUser(User user)
        {
            instance = new UserPageViewModel(user);
        }

        internal void RemoveProduct(int index)
        {
            this.products.RemoveAt(index);
            NotifyPropertyChanged("StoreProducts");
        }

        private ObservableCollection<Product> RequestProductsFromServer()
        {
            ObservableCollection<Product> products;
            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage httpResponse = http.GetAsync("http://localhost:8080/products/all").Result;
                string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(responseContent);
            }

            return products;
        }

        internal Product GetProductByName(string productName)
        {
            return StoreProducts.FirstOrDefault(x => x.Name == productName);
        }

        internal void UpdateProduct(Product product)
        {
            try
            {
                using (HttpClient http = new HttpClient())
                {
                    HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");
                    HttpResponseMessage httpResponse = http.PutAsync("http://localhost:8080/products/update", httpContent).Result;

                    string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                    JsonConvert.DeserializeObject<List<Product>>(responseContent);

                    ProductsPageViewModel.Instance.Refresh();
                }
            }
            catch
            {
                MessageDialog.ShowMessage("Server is not running!");
            }
        }

        private bool isAdmin(User user)
        {
            return user.Username.StartsWith("Admin") && user.Password.EndsWith("admin");
        }

        private ObservableCollection<Order> RequestOrdersFromServer()
        {
            string httpRequest;
            if (userType == UserType.Admin)
            {
                httpRequest = "http://localhost:8080/orders/all";
            }
            else
            {
                httpRequest = "http://localhost:8080/orders/" + user.Username;
            }

            try
            {
                ObservableCollection<Order> orders;
                using (HttpClient http = new HttpClient())
                {

                    HttpResponseMessage httpResponse = http.GetAsync(httpRequest).Result;
                    string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<ObservableCollection<Order>>(responseContent);
                }

                return orders;
            }
            catch
            {
                MessageDialog.ShowMessage("Server is not running!");
                return null;
            }
        }
        #endregion

        #region Properties
        public Visibility AdminVisibility
        {
            get
            {
                if (isAdmin(user)) return Visibility.Visible;
                else return Visibility.Collapsed;
            }
        }

        public ObservableCollection<Product> StoreProducts
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
            }
        }

        public ObservableCollection<Order> OrdersList
        {
            get
            {
                return ordersList;
            }
            set
            {
                ordersList = value;
            }
        }

        public int OrdersCount
        {
            get
            {
                return ordersList.Count;
            }
        }

        public double OrdersValue
        {
            get
            {
                double sum = 0;
                foreach (var o in ordersList)
                {
                    sum += o.TotalPrice;
                }

                return sum;
            }
        }

        public User CurrentUser
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
        #endregion

        #region Fields
        private ObservableCollection<Order> ordersList;
        private ObservableCollection<Product> products;
        private User user;
        private UserType userType;
        private static UserPageViewModel instance;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Enums
        private enum UserType
        {
            Regular, Admin
        }
        #endregion

        #region PropertyChangedImplementation
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
