using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitNessCompanionApp.Model
{
    public class Product
    {
        public Product(string Name, string Description, string Price, string Image)
        {
            this.Name = Name;
            this.Description = Description;
            this.Price = Price;
            this.Image = "../../Images/Products/" + Image;
        }

        #region Fields
        public string Name
        {
            get; set;
        }

        public string Description
        {
            get; set;
        }

        public string Price
        {
            get; set;
        }

        public string Image
        {
            get; set;
        }
        #endregion
    }
}
