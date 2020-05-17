using FitNessCompanionApp.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;

namespace FitNessCompanionApp.ViewModels
{
    public class ProductsPageViewModel
    {
        private ProductsPageViewModel()
        {
            products = RequestProductsFromServer();
        }

        #region Methods
        private List<Product> RequestProductsFromServer()
        {
            List<Product> products;
            using (HttpClient http = new HttpClient())
            {
                HttpResponseMessage httpResponse = http.GetAsync("http://localhost:8080/products/all").Result;
                string responseContent = httpResponse.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(responseContent);
            }

            return products;
        }

        internal Product findProductByName(string productName)
        {
            return products.FirstOrDefault(p => p.Name == productName);
        }

        internal void Refresh()
        {
            instance = new ProductsPageViewModel();
            MainWindowViewModel.Instance.ShouldProductsPageUpdate = true;
        }
        #endregion

        #region Properties
        public static ProductsPageViewModel Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ProductsPageViewModel();
                }

                return instance;
            }
        } 

        public List<Product> Products
        {
            get
            {
                return products;
            }
        }
        #endregion

        #region Fields
        private static ProductsPageViewModel instance;

        private List<Product> products;
        #endregion
    }
}
