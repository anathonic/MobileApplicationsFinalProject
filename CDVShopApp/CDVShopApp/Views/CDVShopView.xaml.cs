using System;
using CDVShopApp.ViewModels;
using Xamarin.Forms;
using Plugin.LocalNotification;

namespace CDVShopApp.Views
{
    public partial class CDVShopView : ContentPage
    {
        const uint ExpandAnimationDuration = 500;
        const uint CollapsedAnimationDuration = 250;
        double _pageHeight;
        public CDVShopView()
        {
            InitializeComponent();

            BindingContext = new CDVShopViewModel();

            NotificationCenter.Current.NotificationReceived +=
                Current_NotificationReceived;
        }

        private void
            Current_NotificationReceived(NotificationReceivedEventArgs e)
        {
            DisplayAlert(e.Title, e.Description, "OK");
        }
        protected override void OnAppearing()
        {
           
            CartView.OnExpand += OnExpand;
            CartView.OnCollapse += OnCollapse;
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
            
            CartView.OnExpand -= OnExpand;
            CartView.OnCollapse -= OnCollapse;
            base.OnDisappearing();
        }

        private void OnExpand()
        {
            var height = _pageHeight - CartView.PageHeader;
            CartView.TranslateTo(0, Height - height, ExpandAnimationDuration, Easing.SinInOut );
            
        }
        private void OnCollapse()
        {
            CartView.TranslateTo(0, _pageHeight - CartView.PageHeader, CollapsedAnimationDuration, Easing.SinInOut);
        }


        void Button_Clicked(System.Object sender, System.EventArgs e)
        {

            var notification = new NotificationRequest
            {
                BadgeNumber = 1,
                Description = "Teraz będziesz otrzymywać powiadomienia o nowych produktach",
                Title = "Dziękujemy!",
                ReturningData = "Dummy Data",
                NotificationId = 1337,
                NotifyTime = DateTime.Now.AddSeconds(5)
            };

            NotificationCenter.Current.Show(notification);

        }
        private void Tap_Test(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConnectionTest());
        }
    }
}