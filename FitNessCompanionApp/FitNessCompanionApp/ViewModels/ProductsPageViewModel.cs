using FitNessCompanionApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitNessCompanionApp.ViewModels
{
    class ProductsPageViewModel
    {
        #region Methods
        internal List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product("Whey Protein","Description","2.00","protein.jpg"),
                new Product("Whey Protein","Description","2.00","protein.jpg"),
                new Product("Whey Protein",
                            "100% Gold Whey Standard a fost desemnată de 11 ori câștigătoarea anului în categoria proteinelor de top. Aceasta este cea mai bine vândută proteină din lume, disponibilă în diverse arome delicioase, se dizolvă rapid și asigură o masă musculară fără grăsime. Concentrat proteic din zer cu o proporție de 82% proteine, 4,8 grame de glutamină și 5,5 g de BCAA.",
                            "2.00",
                            "protein.jpg"),
                new Product("Whey Protein","Description","2.00","protein.jpg"),
                new Product("Whey Protein","Description","2.00","protein.jpg"),
                new Product("Whey Protein","Description","2.00","protein.jpg"),
                new Product("Whey Protein","Description","2.00","protein.jpg"),
                new Product("Whey Protein","Description","2.00","protein.jpg")
            };
        }
        #endregion
    }
}
