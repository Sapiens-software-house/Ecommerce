namespace Ecommerce.UI.Server.Interface
{
    public interface IHelper
    {
        string GenerateApiKey(string clientId, string email, string clientSecret);
    }
}
