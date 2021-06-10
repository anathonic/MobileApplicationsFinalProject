using CDVShopApp.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using CDVShopApp.Services;
using System.Linq;
using System.Windows.Input;

namespace CDVShopApp.ViewModels
{
    public class CDVShopViewModel : BindableObject
    {
        private Product _selectedProduct;
        private ObservableCollection<Product> _products;
        public ObservableCollection<BasketItem> _basket;
        public decimal _total;

        public CDVShopViewModel()
        {
            LoadData();
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

        public ICommand DetailCommand => new Command(NavigateToCDVShopDetail);

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

        private void NavigateToCDVShopDetail()
        {
           
        }

    }
}
