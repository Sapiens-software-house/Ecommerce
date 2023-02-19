using Ecommerce.Interface.IG2aService;
using Ecommerce.Service.G2aService;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Ioc.Http
{
    public static class Ioc
    {
        public static void IocHttp(IServiceCollection services)
        {
            //services.AddHttpClient<IG2aService, G2aService>(c =>
            //{
            //    c.BaseAddress = new Uri("http://localhost:8081/api/Auth");
            //});
        }
    }
}
