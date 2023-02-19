using Ecommerce.UI.Server.Interface;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.UI.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<string> Register(UserRegister request)
        {            
            return await _authService.Register(request);
        }
    }
}
