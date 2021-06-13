using System;
using CDVShopApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDVShopApp

{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CDVShopView();
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
