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
using Ecommerce.UI.Server.Interface.IAuthentication;

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

        public async Task<string> GetProductFrom()
        {
            try
            {
                _accessToken = await _authentication.GetToken();

                if (_accessToken.ExpiresIn == 0)
                {
                    _accessToken = await _authentication.RefreshToken(_accessToken.Token);
                }

            }
            catch (Exception)
            {

                throw;
            }

            return "";
        }
    }
}
