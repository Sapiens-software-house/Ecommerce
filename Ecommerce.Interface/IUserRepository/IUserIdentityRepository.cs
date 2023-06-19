using Ecommerce.Interface.Repository;
using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Ecommerce.Interface.IUserRepository
{
    public interface IUserIdentityRepository
    {
        Task<IdentityResult> RegisterUserAsync(ApplicationUser userForRegistration);
        Task<ResponseIdentity> Login(ApplicationUserLogin login);
        Task<IdentityResult> RegisterAdmin(ApplicationUser model);

    }
}