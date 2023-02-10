using Ecommerce.UI.Server.Interface;
using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Formatting;
using System.Net.Http.Json;

namespace Ecommerce.UI.Server.Service
{
    public class AuthService : IAuthService
    {
        private HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> Register(UserRegister request)
        {
            string APIURL = $"/Register";
            var response = await _httpClient.PostAsync(APIURL, request, new JsonMediaTypeFormatter());
            return await response.Content.ReadAsStringAsync();
        }
    }
}
