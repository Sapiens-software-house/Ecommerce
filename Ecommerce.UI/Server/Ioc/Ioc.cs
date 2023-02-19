using Ecommerce.UI.Server.Interface;
using Ecommerce.UI.Server.Interface.IAuthentication;
using Ecommerce.UI.Server.Service;
using Ecommerce.UI.Server.Share;

namespace Ecommerce.UI.Server.Ioc
{
    public static class Ioc
    {
        public static void IocHttp(IServiceCollection services)
        {
            services.AddScoped<IHelper,Helper>();
            services.AddScoped<IG2aAuthentication, G2aAuthentication>();

            services.AddHttpClient<IAuthService, AuthService>(c =>
            {
                c.BaseAddress = new Uri("http://localhost:8081/api/Auth");
            });
            services.AddHttpClient<IProductService, ProductService>(c =>
            {
                c.BaseAddress = new Uri("https://sandboxapi.g2a.com/v1/");
            });
        }
    }
}
