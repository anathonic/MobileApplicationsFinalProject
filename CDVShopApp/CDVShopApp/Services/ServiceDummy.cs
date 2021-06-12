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
                new Product {Name="Bluza CDV", Image="hoodie.jpg", Price= 80, Description ="Bluza 100% bawełna, wykonana w Polsce"},
                new Product {Name="T-shirt CDV", Image="tshirt.jpg", Price= 40, Description ="T-shirt 100% bawełna, wykonany w Polsce"},
                new Product {Name="Czapka CDV", Image="cap.jpg", Price= 30, Description ="Czapka wykonana w Polsce"},
                new Product {Name="Longsleeve CDV", Image="longsleeve.jpg", Price= 50, Description ="Longsleeve 100% bawełna, wykonana w Polsce"},
                new Product {Name="Polo T-shirt CDV", Image="polotshirt.jpg", Price= 50, Description ="Polo T-shirt 100% bawełna, wykonana w Polsce"},
                new Product {Name="Polo Longsleeve CDV", Image="pololongsleeve.jpg", Price= 50, Description ="Polo Longsleeve 100% bawełna, wykonana w Polsce"}
            };

        }
    }
}
