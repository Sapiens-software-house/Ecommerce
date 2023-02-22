using Ecommerce.UI.Client.Interface.IProductService;
using Ecommerce.UI.Shared.Model.DocModel;
using Ecommerce.UI.Shared.Product;
using Ecommerce.UI.Shared.ServiceResponse;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Ecommerce.UI.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public docs Products { get; set; } = new docs();
        public string Message { get; set; } = "Loading products...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public string LastSearchText { get; set; } = string.Empty;

        public event Action ProductsChanged;

        public async Task GetProducts(string? categoryUrl = null)
        {
            var result = categoryUrl == null ?
                await _http.GetFromJsonAsync<ServiceResponse<docs>>($"api/product/GetProductsFromHell") 
                :
                await _http.GetFromJsonAsync<ServiceResponse<docs>>($"api/product/GetProductsFromHell");
            if (result != null && result.Data != null)
                Products = result.Data;

            CurrentPage = 1;
            PageCount = 0;

            if (Products.Products.Count == 0)
                Message = "No products found";

            ProductsChanged.Invoke();
        }
    }
}
