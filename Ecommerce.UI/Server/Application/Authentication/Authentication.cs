using Ecommerce.UI.Server.Interface.IG2aAuthentication;
using Ecommerce.UI.Server.Interface;
using Ecommerce.UI.Server.Share;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.UI.Server.Application.Authentication
{
    public static class Authentication
    {
        public static void AuthenticationOn(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(System.Text.Encoding.UTF8
                        .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void AuthenticationGoogle(WebApplicationBuilder builder, IServiceCollection services)
        {
            services.AddAuthentication()
            .AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = builder.Configuration.GetSection("GoogleAuthentication:Google:ClientId").Value;
                googleOptions.ClientSecret = builder.Configuration.GetSection("GoogleAuthentication:Google:ClientSecret").Value;
            });
        }
    }
}
