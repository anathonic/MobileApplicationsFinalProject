using System.Threading.Tasks;
using CDVShopApp.Models;


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
    }
}