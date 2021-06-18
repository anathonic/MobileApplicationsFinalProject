using CDVShopApp.Models;
using System.Collections.Generic;


namespace CDVShopApp.Services
{
   public class BasketService
    {
        private List<BasketItem> items = new List<BasketItem>
            {
               
            };
        
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
            return items;
 
        }
        public void AddItemToBasket(BasketItem item)
        {
            items.Add(item);
        }
        public void DeleteItemFromBasket(BasketItem item)
        {
            items.Remove(item);
        }
    }

} 

