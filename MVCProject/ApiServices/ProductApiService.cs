using MVCProject.Models.ApiModel;
using Newtonsoft.Json;

namespace MVCProject.ApiServices
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:5246/");
        }

        public async Task<List<ProductResponse>?> GetListAsync()
        {
            List<ProductResponse>? products = null;
         

            var responseMessage = await _httpClient.GetAsync("api/Products");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ProductResponse>?>(jsonString);
            }

            return products;
        }

        public async Task<ProductResponse?> GetByIdAsync(int id)
        {

            ProductResponse? product = null;
            var responseMessage = await _httpClient.GetAsync($"api/Products/{id}");


            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                product  = JsonConvert.DeserializeObject<ProductResponse?>(jsonString);
            }

            return product;
          
        }
    }
}
