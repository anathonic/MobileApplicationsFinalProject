using CDVShopApp.Models;
using System.Collections.Generic;
namespace CDVShopApp.Services
{
    public class ServiceDummy
    {
        private static ServiceDummy _instance;
        public static ServiceDummy Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ServiceDummy();
                return _instance;
            }
        }
        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product {Name="Bluza CDV", Image="hoodie.png", Price= 80, Description =""},
                new Product {Name="T-shirt CDV", Image="tshirt.png", Price= 40, Description =""},
                new Product {Name="Czapka CDV", Image="cap.png", Price= 30, Description =""},
                new Product {Name="Longsleeve CDV", Image="longsleeve.png", Price= 50, Description =""},
                new Product {Name="Polo T-shirt CDV", Image="polotshirt.png", Price= 50, Description =""},
                new Product {Name="Polo Longsleeve CDV", Image="pololongsleeve.png", Price= 50, Description =""}
            };

        }
    }
}
