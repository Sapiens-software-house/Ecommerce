using Ecommerce.UI.Shared.Authentication;

namespace Ecommerce.UI.Server.Interface.IG2aAuthentication
{
    public interface IG2aAuthentication
    {
        Task<AccessToken> GetToken();
        Task<AccessToken> RefreshToken(string refreshToken);
    }
}
