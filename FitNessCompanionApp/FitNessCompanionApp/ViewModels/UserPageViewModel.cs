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

        internal void RemoveOrder(int index)
        {
            this.ordersList.RemoveAt(index);
            NotifyPropertyChanged("OrdersList");
        }

        private bool isAdmin(User user)
        {
            return user.Username.StartsWith("Admin") && user.Password.EndsWith("FitAdmin@FitnessCorp.com");
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
                new MessageDialog("Server is not running!");
                return null;
            }
        }
        #endregion

        #region Properties
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
