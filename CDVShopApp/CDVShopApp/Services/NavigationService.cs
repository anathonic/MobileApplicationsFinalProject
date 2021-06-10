using System;
using System.Collections.Generic;
using System.Text;

namespace CDVShopApp.Services
{
    public class NavigationService
    {
        private static NavigationService _instance;
        public static NavigationService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NavigationService();
                return _instance;
            }
        }
    }
}
