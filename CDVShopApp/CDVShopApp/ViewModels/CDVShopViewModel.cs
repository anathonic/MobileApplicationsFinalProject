using CDVShopApp.Models;
using CDVShopApp.Services;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace CDVShopApp.ViewModels
{
    public class CDVShopViewModel : ViewModelBase
    {
        private ObservableCollection<Product> _products;
        private Product _selectedProduct;
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

        public Product SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
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

        public ICommand SelectCommand => new Command(NavigateToCDVShopDetail);
        private void LoadData()
        {
            Products = new ObservableCollection<Product>(ServiceDummy.Instance.GetProducts());
            var actualBasket = BasketService.Instance.GetActualBasket();
            Basket = new ObservableCollection<BasketItem>(actualBasket);
            Total = actualBasket.Sum(b => b.UnitPrice * b.Quantity);
        }

        private void NavigateToCDVShopDetail()
        {
            NavigationService.Instance.NavigateToAsync<DetailViewModel>(SelectedProduct);
        }

    }
}
