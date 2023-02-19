using Ecommerce.UI.Server.Interface;
using Ecommerce.UI.Server.Share;
using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using Ecommerce.UI.Shared.Authentication;
using Ecommerce.UI.Server.Interface.IG2aAuthentication;
using System.Text.Json;
using Ecommerce.UI.Shared.Model.DocModel;

namespace Ecommerce.UI.Server.Service
{
    public class ProductService : IProductService
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;
        private IG2aAuthentication _authentication;
        private AccessToken _accessToken;

        public ProductService(HttpClient httpClient, IConfiguration config, IG2aAuthentication authentication)
        {
            _httpClient = httpClient;
            _configuration = config;
            _authentication = authentication;
            _accessToken = new AccessToken();
        }

        public async Task<ServiceResponse<docs>> GetProductFrom()
        {
            docs aux = new docs();

            try
            {
                _accessToken = await _authentication.GetToken();

                if (_accessToken.ExpiresIn == 0)
                {
                    _accessToken = await _authentication.RefreshToken(_accessToken.Token);
                }

                string APIURL = $"products";
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_accessToken.TokenType, _accessToken.Token);
                var response = await _httpClient.GetAsync(APIURL);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Failed to retrieve products");
                    //return;
                }

                var responseContent = await response.Content.ReadAsStringAsync();

                aux = JsonSerializer.Deserialize<docs>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            }
            catch (Exception)
            {

                throw;
            }

            var serviceresponse = new ServiceResponse<docs>
            {
                Data = aux
            };

            return serviceresponse;
        }
    }
}
