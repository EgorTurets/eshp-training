using EshpProductCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EshpUserCompanyProvider
{
    public class ProductHttpClient
    {
        public HttpClient Client { get; set; }

        public ProductHttpClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://product.eshp.com/api/");

            Client = client;
        }

        public async Task<Product> GetProduct(int productId)
        {
            var response = await Client.GetAsync($"/product/{productId}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Product>();

            return result;
        }
    }
}
