using Ecommerce.Interface.IProductService;
using Ecommerce.Interface.IUnitOfWork;
using Ecommerce.Service.ProductService;
using Ecommerce.UnitOfWork.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Ioc.Service
{
    public static class Ioc
    {
        public static void IocService(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}
