using Xamarin.Forms;
namespace CDVShopApp.Views
{
    public partial class CDVShopDetailView : ContentPage
    {
        public CDVShopDetailView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Parallax.ParallaxView = HeaderView;

        }
    }
}