using CDVShopApp.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using CDVShopApp.Services;

namespace CDVShopApp.ViewModels
{
    public class CDVShopViewModel : BindableObject
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<BasketItem> _basket;

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
        private void LoadData()
        {
            Products = new ObservableCollection<Product>(ServiceDummy.Instance.GetProducts());
            Basket = new ObservableCollection<BasketItem>(BasketService.Instance.GetActualBasket());
        }
    }
}
