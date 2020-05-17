using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitNessCompanionApp.Model
{
    public class Product
    {
        public Product(string Name, string Description, double Price, string Image, int Stock)
        {
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Image = Image;
            this.Stock = Stock;
        }

        #region Fields
        [JsonProperty("name")]
        public string Name
        {
            get; set;
        }

        [JsonProperty("price")]
        public double Price
        {
            get; set;
        }

        [JsonProperty("description")]
        public string Description
        {
            get; set;
        }

        [JsonProperty("image")]
        public string Image
        {
            get; set;
        }

        [JsonProperty("stock")]
        public int Stock
        {
            get; set;
        }
        #endregion
    }
}
