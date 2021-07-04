using CDVShopApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CDVShopApp.api
{
    class ApiService
    {
        public async Task<List<Product>> Gimme()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://cdv-web2.azurewebsites.net/api/Products");
            var json = JsonConvert.DeserializeObject<List<Product>>(response);
            return json;
        }
    }
}
