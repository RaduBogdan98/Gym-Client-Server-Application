using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitNessCompanionApp.ViewModels
{
    class ProductsPresenterViewModel
    {
        public ProductsPresenterViewModel(string name, string description, string price, string imageSource)
        {
            this.ProductName = name;
            this.ProductDescription = description;
            this.ProductPrice = price;
            this.ImageSource = imageSource;
        }

        #region Properties
        public string ProductName
        {
            get; set;
        }

        public string ProductDescription
        {
            get; set;
        }

        public string ProductPrice
        {
            get; set;
        }

        public string ImageSource
        {
            get; set;
        }
        #endregion
    }
}
