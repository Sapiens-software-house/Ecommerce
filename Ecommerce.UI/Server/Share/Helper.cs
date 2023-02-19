using Ecommerce.UI.Server.Interface;
using System.Text;

namespace Ecommerce.UI.Server.Share
{
    public class Helper : IHelper
    {
        public string GenerateApiKey(string clientId, string email, string clientSecret)
        {
            // Calculate the API key as the SHA256 sum of the Client ID, email, and Client Secret
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var input = Encoding.UTF8.GetBytes($"{clientId}{email}{clientSecret}");
                var hash = sha256.ComputeHash(input);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
