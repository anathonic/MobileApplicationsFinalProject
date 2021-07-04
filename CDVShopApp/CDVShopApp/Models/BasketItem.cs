
namespace CDVShopApp.Models
{
    public enum BasketItemType
    {
        Product
    }
    public class BasketItem
    {
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public decimal UnitPrice { get; set; }
        public BasketItemType BasketItemType { get; set; }
        public decimal Total { get { return Quantity * UnitPrice; } }

    }
}
