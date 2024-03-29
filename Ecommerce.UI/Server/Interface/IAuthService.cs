﻿using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.UI.Server.Interface
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin request);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
        Task<bool> IsUserAuthenticated();
    }
}
