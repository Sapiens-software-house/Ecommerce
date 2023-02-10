using Ecommerce.Interface.IProductService;
using Ecommerce.Interface.IUserService;
using Ecommerce.UI.Server.Interface;
using Ecommerce.UI.Server.Service;

namespace Ecommerce.UI.Server.Ioc
{
    public static class Ioc
    {
        public static void IocHttp(IServiceCollection services)
        {
            services.AddHttpClient<IAuthService, AuthService>(c =>
            {
                c.BaseAddress = new Uri("http://localhost:8081/api/Auth");
            });
        }
    }
}
