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
