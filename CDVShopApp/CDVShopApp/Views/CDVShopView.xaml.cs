using CDVShopApp.ViewModels;
using Xamarin.Forms;

namespace CDVShopApp.Views
{
    public partial class CDVShopView : ContentPage
    {
        public CDVShopView()
        {
            InitializeComponent();

            BindingContext = new CDVShopViewModel();
        }
    }
}