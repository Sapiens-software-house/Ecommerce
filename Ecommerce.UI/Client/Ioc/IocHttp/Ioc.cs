using Ecommerce.UI.Client.Interface.IAuthService;
using Ecommerce.UI.Client.Interface.IProductService;
using Ecommerce.UI.Client.Services.AuthService;
using Ecommerce.UI.Client.Services.ProductService;
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
                c.BaseAddress = new Uri("http://localhost:8082/api/Auth");
            });
            services.AddHttpClient<IProductService, ProductService>(c =>
            {
                c.BaseAddress = new Uri("http://localhost:8082/api/Product");
            });
        }
    }
}
