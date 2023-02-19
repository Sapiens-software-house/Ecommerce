using Ecommerce.UI.Server.Interface.IG2aAuthentication;
using Ecommerce.UI.Shared.Authentication;
using System.Data.SqlTypes;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Ecommerce.UI.Server.Share
{
    public class G2aAuthentication : IG2aAuthentication
    {
        private readonly IConfiguration _configuration;
        public G2aAuthentication(IConfiguration cofiguration)
        {
            _configuration = cofiguration;
        }

        public async Task<AccessToken> GetToken()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["OAuth:Authority"]);

            var clientId = _configuration["OAuth:ClientId"];
            var clientSecret = _configuration["OAuth:ClientSecret"];

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Basic",
            Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}")));

            var requestBody = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" }
                , {"client_id", clientId}
                , {"client_secret", clientSecret}
            };

            var requestContent = new FormUrlEncodedContent(requestBody);

            var response = await client.PostAsync("oauth/token", requestContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<AccessToken>(responseContent);

            return responseData;
        }

        public async Task<AccessToken> RefreshToken(string refreshToken)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["OAuth:Authority"]);

            var clientId = _configuration["OAuth:ClientId"];
            var clientSecret = _configuration["OAuth:ClientSecret"];

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
            "Basic",
            Convert.ToBase64String(Encoding.ASCII.GetBytes($"{clientId}:{clientSecret}")));

            var requestBody = new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" }
                , {"client_id", clientId}
                , {"client_secret", clientSecret}
                , {"refresh_token", refreshToken}
            };

            var requestContent = new FormUrlEncodedContent(requestBody);

            var response = await client.PostAsync("oauth/token", requestContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseData = JsonSerializer.Deserialize<AccessToken>(responseContent);

            return responseData;
        }
    }
}
