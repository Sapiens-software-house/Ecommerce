using Ecommerce.Interface.IAuthService;
using Ecommerce.Interface.IProductService;
using Ecommerce.Interface.IUnitOfWork;
using Ecommerce.Interface.IUserService;
using Ecommerce.Service.AuthService;
using Ecommerce.Service.ProductService;
using Ecommerce.Service.UserService;
using Ecommerce.UnitOfWork.UOW;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Ioc.Service
{
    public static class Ioc
    {
        public static void IocService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(System.Text.Encoding.UTF8
                        .GetBytes(configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddHttpContextAccessor();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IAddressService, AddressService>();
        }
    }
}
