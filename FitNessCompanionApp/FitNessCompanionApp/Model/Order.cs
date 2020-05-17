using Newtonsoft.Json;
using System.Collections.Generic;

namespace FitNessCompanionApp.Model
{
    class Order
    {
        public Order(string OrderDate, User User, List<OrderItem> OrderedContent, double TotalPrice)
        {
            this.OrderDate = OrderDate;
            this.User = User;
            this.OrderContent = OrderedContent;
            this.TotalPrice = TotalPrice;
        }

        #region Methods
        private double computePrice(List<OrderItem> orderContent)
        {
            double sum = 0;
            foreach(OrderItem item in orderContent)
            {
                sum += item.Product.Price * item.Quantity;
            }

            return sum;
        }
        #endregion

        #region Fields
        [JsonProperty("orderDate")]
        public string OrderDate { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("orderContent")]
        public List<OrderItem> OrderContent { get; set; }

        [JsonProperty("totalPrice")]
        public double TotalPrice { get; set; }
        #endregion
    }
}
