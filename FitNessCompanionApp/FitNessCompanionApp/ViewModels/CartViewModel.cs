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

namespace FitNessCompanionApp.ViewModels
{
    class CartViewModel : INotifyPropertyChanged
    {
        private CartViewModel()
        {
            orderContent = new ObservableCollection<OrderItem>();
        }

        #region Methods
        internal void AddProduct(Product product)
        {
            OrderItem addedItem = orderContent.FirstOrDefault(item => item.Product.Name == product.Name);

            if (addedItem != null)
            {
                orderContent[orderContent.IndexOf(addedItem)].Quantity++;
            }
            else
            {
                orderContent.Add(new OrderItem(product, 1));
            }

            NotifyPropertyChanged("OrderContent");
        }

        internal int getProductsCount()
        {
            int count = 0;
            foreach (var item in orderContent)
            {
                count += item.Quantity;
            }

            return count;
        }

        internal void changeProductQuantity(string productName, int newQuantity)
        {
            orderContent.FirstOrDefault(item => item.Product.Name == productName).ChangeItemQuantity(newQuantity);
            NotifyPropertyChanged("OrderContent");
        }

        internal void removeOrderItem(string productName)
        {
            OrderItem itemToRemove = OrderContent.FirstOrDefault(item => item.Product.Name == productName);
            OrderContent.Remove(itemToRemove);

            NotifyPropertyChanged("OrderContent");
        }

        internal bool postOrder()
        {
            if (this.getProductsCount() != 0)
            {
                Order submitedOrder = new Order("", UserPageViewModel.GetInstance().CurrentUser, OrderContent.ToList(), this.OrderTotalPrice);

                try
                {
                    using (HttpClient http = new HttpClient())
                    {
                        HttpContent postContent = new StringContent(JsonConvert.SerializeObject(submitedOrder), Encoding.UTF8, "application/json");

                        HttpResponseMessage httpResponse = http.PostAsync("http://localhost:8080//orders/add", postContent).Result;

                        UpdateProductStock();
                        OrderContent.Clear();

                        NotifyPropertyChanged("OrderContent");
                        UserPageViewModel.GetInstance().Refresh();

                        SendOrderConfirmationEmail(submitedOrder);
                        MessageDialog.ShowMessage("Thank you for your order! 😄");

                        return true;
                    }
                }
                catch
                {
                    MessageDialog.ShowMessage("Server is not running!");
                    return false;
                }
            }
            else
            {
                MessageDialog.ShowMessage("Your cart is empty!");
                return false;
            }       
        }

        private void SendOrderConfirmationEmail(Order o)
        {
            using (HttpClient http = new HttpClient())
            {
                string message = BuildOrderEmailMessage(o);
                EmailItem email = new EmailItem(o.User.Email, "support@fitness.com", "Order Confirmation", message);
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(email), Encoding.UTF8, "application/json");
                try
                {
                    HttpResponseMessage response = http.PostAsync("http://localhost:80/Emailer/emailer.php", httpContent).Result;
                }
                catch
                {
                    MessageDialog.ShowMessage("Server error!");
                }
            }
        }
        
        private string BuildOrderEmailMessage(Order o)
        {
            string message = "Hi! Your order has been processed! We will send you order as soon as possible!<br/><br/> Order contents:<br/>";

            foreach(var item in o.OrderContent)
            {
                message += "&emsp;" + item.Product.Name + " of price " + item.Product.Price + "$ x " + item.Quantity + "<br/>";
            }

            message += "<br/>&emsp;Total Price: " + o.TotalPrice + "$<br/><br/>Thank you for ordering from us!<br/>FitNess Team";

            return message;
        }

        private void UpdateProductStock()
        {
            foreach(OrderItem item in OrderContent)
            {
                item.Product.Stock -= item.Quantity;
                UserPageViewModel.GetInstance().UpdateProduct(item.Product);
            }
        }
        #endregion

        #region Properties
        public static CartViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CartViewModel();
                }

                return instance;
            }
        }

        public ObservableCollection<OrderItem> OrderContent
        {
            get
            {
                NotifyPropertyChanged("OrderTotalPrice");
                MainWindowViewModel.Instance.NotifyCartItemsNumberChanged();
                return orderContent;
            }
            set
            {
                orderContent = value;
                NotifyPropertyChanged("OrderContent");
                MainWindowViewModel.Instance.NotifyCartItemsNumberChanged();
            }
        }

        public double OrderTotalPrice
        {
            get
            {
                double sum = 0;
                foreach (var item in orderContent)
                {
                    sum += item.TotalPrice;
                }

                return sum;
            }
        }
        #endregion

        #region Fields
        private ObservableCollection<OrderItem> orderContent;
        private static CartViewModel instance;
        #endregion

        #region PropertyChangedImplementation
        public event PropertyChangedEventHandler PropertyChanged;

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
