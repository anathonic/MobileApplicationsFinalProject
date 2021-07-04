using CDVShopApp.api;
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
            _products = new ObservableCollection<Product>();
            FindItems();
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
        private async void FindItems()
        {
            ApiService apiservices = new ApiService();
            var items = await apiservices.Gimme();
            foreach (var item in items.ToList())
            {
                Products.Add(item);
            }
        }
        public ICommand SelectCommand => new Command(NavigateToCDVShopDetail);
        private void LoadData()
        {
            _products = new ObservableCollection<Product>();
            FindItems();
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
