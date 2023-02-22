using Ecommerce.UI.Server.Interface.IG2aAuthentication;
using Ecommerce.UI.Server.Interface;
using Ecommerce.UI.Server.Share;
using Ecommerce.UI.Server.Service;

namespace Ecommerce.UI.Server.Ioc.Injection
{
    public static class Ioc
    {
        public static void IocService(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
