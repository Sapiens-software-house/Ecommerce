using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repository;
using Ecommerce.Interface.IProductRepository;
using Ecommerce.Interface.IUserRepository;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.UserRepository
{
    public class UserIdentityRepository : IUserIdentityRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IConfiguration _configuration;

        public UserIdentityRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUserAsync(ApplicationUser applicationUser)
        {
            var result = new IdentityResult();

            var userExists = await _userManager.FindByNameAsync(applicationUser.UserName);

            if (userExists == null)
            {             
                result = await _userManager.CreateAsync(applicationUser, applicationUser.PasswordHash.ToString());

                if (result.Succeeded)
                {
                    // Verifique se a role "User" existe
                    var roleExists = await _roleManager.RoleExistsAsync("User");

                    if (!roleExists)
                    {
                        // Crie a role "User" se ela não existir
                        var role = new IdentityRole("User");
                        var createRoleResult = await _roleManager.CreateAsync(role);

                        if (!createRoleResult.Succeeded)
                        {
                            // Lida com o caso em que a criação da role falhou
                            // Aqui você pode tomar alguma ação apropriada, como registrar o erro ou lançar uma exceção
                        }
                    }
                    else
                    {
                        // Lida com o caso em que a role "User" não existe
                        // Aqui você pode criar a role ou tomar outra ação apropriada
                    }

                    // Atribua a role "User" ao usuário
                    var assignRoleResult = await _userManager.AddToRoleAsync(applicationUser, "User");

                    if (!assignRoleResult.Succeeded)
                    {
                        // Lida com o caso em que a atribuição da role falhou
                        // Aqui você pode tomar alguma ação apropriada, como registrar o erro ou lançar uma exceção
                    }
                }
            }
            return result;
        }

        public async Task<ResponseIdentity> Login(ApplicationUserLogin login)
        {
            var user = await _userManager.FindByNameAsync(login.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return new ResponseIdentity ()
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                };
            }
            else
            {
                return new ResponseIdentity() { };
            }
        }

        public async Task<IdentityResult> RegisterAdmin(ApplicationUser model)
        {
            var userExists = await _userManager.FindByNameAsync(model.UserName);
            if (userExists != null)
            {
                //todo
            }

            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(model, model.PasswordHash);
            if (!result.Succeeded)
            { 
                //todo
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(model, UserRoles.Admin);
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _userManager.AddToRoleAsync(model, UserRoles.User);
            }

            return result;

        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtConfig:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtConfig:ValidIssuer"],
                audience: _configuration["JwtConfig:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
