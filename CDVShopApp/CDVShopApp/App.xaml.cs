using CDVShopApp.Services;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CDVShopApp

{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitNavigation();
        }

        Task InitNavigation()
        {
            return NavigationService.Instance.InitializeAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
