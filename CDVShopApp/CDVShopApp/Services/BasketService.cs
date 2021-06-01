using CDVShopApp.Models;
using System.Collections.Generic;


namespace CDVShopApp.Services
{
   public class BasketService
    {
        private static BasketService _instance;
        public static BasketService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BasketService();
                return _instance;
            }
        }
        public List<BasketItem> GetActualBasket()
        {
            return new List<BasketItem>
            {
                new BasketItem { BasketItemType = BasketItemType.Product, ProductName ="Bluza CDV", ProductImage ="hoodie.jpg", Quantity = 1, unitPrice = 80},
                new BasketItem { BasketItemType = BasketItemType.Product, ProductName ="Longsleeve CDV", ProductImage ="longsleeve.jpg", Quantity = 1, unitPrice = 50},
                new BasketItem { BasketItemType = BasketItemType.Product, ProductName ="Czapka CDV", ProductImage ="cap.jpg", Quantity = 1, unitPrice = 30},
            };
 
        }

    }

}

