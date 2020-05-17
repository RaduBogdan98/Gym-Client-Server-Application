using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FitNessCompanionApp.Model
{
    class OrderItem : INotifyPropertyChanged
    {
        public OrderItem(Product Product, int Quantity)
        {
            this.Product = Product;
            this.Quantity = Quantity;
        }

        #region Properties
        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        public double TotalPrice
        {
            get
            {
                return Product.Price * Quantity;
            }
        }
        #endregion

        #region Methods
        internal void ChangeItemQuantity(int newQuantity)
        {
            this.Quantity = newQuantity;
            NotifyPropertyChanged("TotalPrice");
        }
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
