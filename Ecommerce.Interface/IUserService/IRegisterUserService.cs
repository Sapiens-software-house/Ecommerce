using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interface.IUserService
{
    public interface IRegisterUserService
    {
        Task<IdentityResult> RegisterUser(ApplicationUser applicationUser);
        Task<ResponseIdentity> Login(ApplicationUserLogin applicationUser);
        Task<IdentityResult> RegisterAdmin(ApplicationUser applicationUser);
    }
}
