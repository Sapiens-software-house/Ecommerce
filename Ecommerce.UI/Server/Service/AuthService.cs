using Ecommerce.UI.Server.Interface;
using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Formatting;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace Ecommerce.UI.Server.Service
{
    public class AuthService : IAuthService
    {
        private HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;

        public AuthService(HttpClient httpClient, AuthenticationStateProvider authStateProvider)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await _authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<ServiceResponse<int>> Register(UserRegister request)
        {
            string APIURL = $"/Register";
            var response = await _httpClient.PostAsync(APIURL, request, new JsonMediaTypeFormatter());
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<string>> Login(UserLogin request)
        {
            string APIURL = $"/login";
            var result = await _httpClient.PostAsJsonAsync(APIURL, request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request)
        {
            string APIURL = $"/change-password";
            var result = await _httpClient.PostAsJsonAsync(APIURL, request.Password);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
    }
}
