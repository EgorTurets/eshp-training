using EshpProductCommon;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EshpUserCompanyProvider.HttpClient
{
    public class ProductHttpClient
    {
        public System.Net.Http.HttpClient Client { get; set; }

        public ProductHttpClient(System.Net.Http.HttpClient client)
        {
            client.BaseAddress = new Uri("https://product.eshp.com/api/");

            Client = client;
        }

        public async Task<Product> GetProduct(int productId)
        {
            var response = await Client.GetAsync(Endpoints.GetProduct(productId));
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<Product>();

            return result;
        }
    }
}
