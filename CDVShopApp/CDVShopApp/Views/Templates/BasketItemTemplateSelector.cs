using CDVShopApp.Models;
using Xamarin.Forms;
namespace CDVShopApp.Views.Templates
{
    public class BasketItemDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ProductTemplate { get; set; }
        public DataTemplate OrderTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((BasketItem)item).BasketItemType == BasketItemType.Product ? ProductTemplate : OrderTemplate;
                
        }
    }
}
