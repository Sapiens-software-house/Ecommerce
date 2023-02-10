using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.UI.Server.Interface
{
    public interface IAuthService
    {
        Task<string> Register(UserRegister request);
    }
}
