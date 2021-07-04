using System.Threading.Tasks;
using System.Windows.Input;
using CDVShopApp.Models;
using CDVShopApp.Services;
using Xamarin.Forms;

namespace CDVShopApp.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged();
            }
        }
        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData is Product)
                Product = (Product)navigationData;

            return base.InitializeAsync(navigationData);
        }
        public ICommand DeleteItemFromBasketCommand => new Command(() =>
        {
            BasketService.Instance.DeleteItem(new BasketItem
            {
                BasketItemType = BasketItemType.Product,
                ProductImage = _product.Image,
                ProductName = _product.Name,
                UnitPrice = _product.Price,
                Quantity = 1

            });
        });
        public ICommand AddToBasketCommand => new Command(() =>
        {
            BasketService.Instance.AddItemToBasket(new BasketItem
            {
                Product_id = _product.Id,
                BasketItemType = BasketItemType.Product,
                ProductImage = _product.Image,
                ProductName = _product.Name,
                UnitPrice = _product.Price,
                Quantity = 1

            });
        });
    }
}