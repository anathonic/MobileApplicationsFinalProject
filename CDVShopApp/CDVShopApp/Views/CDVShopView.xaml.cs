using CDVShopApp.ViewModels;
using Xamarin.Forms;

namespace CDVShopApp.Views
{
    public partial class CDVShopView : ContentPage
    {
        const uint AnimationDuration = 500;
        double _pageHeight;
        public CDVShopView()
        {
            InitializeComponent();

            BindingContext = new CDVShopViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CartView.OnExpand += OnExpand;
            CartView.OnCollapse += OnCollapse;
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
            CartView.OnExpand -= OnExpand;
            CartView.OnCollapse -= OnCollapse;
        }

        private void OnExpand()
        {
            var height = _pageHeight - CartView.PageHeader;
            CartView.TranslateTo(0, Height - height, AnimationDuration, Easing.SinInOut );
        }
        private void OnCollapse()
        {
            CartView.TranslateTo(0, _pageHeight - CartView.PageHeader, AnimationDuration, Easing.SinInOut);
        }
    }
}