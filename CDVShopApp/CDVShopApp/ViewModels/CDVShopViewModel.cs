using CDVShopApp.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using CDVShopApp.Services;
using System.Linq;

namespace CDVShopApp.ViewModels
{
    public class CDVShopViewModel : BindableObject
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<BasketItem> _basket;
        public decimal _total;

        public CDVShopViewModel()
        {
            LoadData();
        }

        public ObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<BasketItem> Basket
        {
            get { return _basket; }
            set
            {
                _basket = value;
                OnPropertyChanged();
            }
        }
            public decimal Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged();
            }
        }
        private void LoadData()
        {
            Products = new ObservableCollection<Product>(ServiceDummy.Instance.GetProducts());
            var actualBasket = BasketService.Instance.GetActualBasket();
            Basket = new ObservableCollection<BasketItem>(BasketService.Instance.GetActualBasket());
            Total = actualBasket.Sum(b => b.UnitPrice * b.Quantity);
        }

    }
}
