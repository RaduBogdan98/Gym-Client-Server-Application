using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FitNessCompanionApp.Model;

namespace FitNessCompanionApp.ViewModels
{
    class ProductsPresenterViewModel
    {
        public ProductsPresenterViewModel(string name, string description, string price, ImageSource imageSource)
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

        public ImageSource ImageSource
        {
            get; set;
        }
        #endregion
    }
}
