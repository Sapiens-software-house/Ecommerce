using Ecommerce.Interface.IAuthService;
using Ecommerce.Interface.IUserService;
using Ecommerce.Service.UserService;
using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IRegisterUserService _registerUserService;

        public RegisterUserController(IRegisterUserService registerUserService)
        {
            _registerUserService = registerUserService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<IdentityResult>>> RegisterUser([FromBody] ApplicationUser request)
        {
            IdentityUser user = new()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.ApplicationUsername,
                PasswordHash = request.PasswordHash,
            };

            var response = await _registerUserService.RegisterUser(request);

            if (!response.Succeeded)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<ResponseIdentity>>> Login(ApplicationUserLogin request)
        {
            var response = await _registerUserService.Login(request);

            return Ok(response);
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] ApplicationUser request)
        {
            var response = await _registerUserService.RegisterAdmin(request);

            return Ok(response);
        }

        //[HttpPost("change-password"), Authorize]
        //public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        //    var response = await _authService.ChangePassword(int.Parse(userId), newPassword);

        //    if (!response.Success)
        //    {
        //        return BadRequest(response);
        //    }

        //    return Ok(response);
        //}
    }
}
