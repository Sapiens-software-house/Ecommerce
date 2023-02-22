using Ecommerce.UI.Client.Interface.IAuthService;
using Ecommerce.UI.Client.Services.AuthService;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net.Http;

namespace Ecommerce.UI.Client.Ioc.IocHttp
{
    public class Ioc
    {
        public static void IocHttp(WebAssemblyHostBuilder builder, IServiceCollection services)
        {
            services.AddHttpClient<IAuthService, AuthService>(c =>
            {
                c.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress + "api/auth");
            });
        }
    }
}
