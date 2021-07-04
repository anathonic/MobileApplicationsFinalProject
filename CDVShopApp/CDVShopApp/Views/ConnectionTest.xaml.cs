using CDVShopApp.Models;
using CDVShopApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CDVShopApp.api;

namespace CDVShopApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectionTest : ContentPage
    {
        public ObservableCollection<Product> Products;
        public ConnectionTest()
        {
            InitializeComponent();
            Products = new ObservableCollection<Product>();
            FindItems();
        }

        private async void FindItems()
        {
            ApiService apiservices = new ApiService();
            var items = await apiservices.Gimme();
            foreach (var item in items.ToList())
            {
                Products.Add(item);
            }
            LvlItems.ItemsSource = Products;
        }
    }
}