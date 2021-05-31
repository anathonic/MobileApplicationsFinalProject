using CDVShopApp.ViewModels;
using Xamarin.Forms;

namespace CDVShopApp.Views
{
    public partial class CDVShopView : ContentPage
    {
        double _pageHeight;
        public CDVShopView()
        {
            InitializeComponent();

            BindingContext = new CDVShopViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            _pageHeight = height;
            CartView.TranslationY = _pageHeight - CartView.PageHeader;
            base.OnSizeAllocated(width, height);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}