using Ecommerce.Interface.IUnitOfWork;
using Ecommerce.UnitOfWork.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Ioc.Infrastructure
{
    public static class Ioc
    {
        public static void IocInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddTransient<IUnitOfWork, Ecommerce.UnitOfWork.UOW.UnitOfWork>();
        }
    }
}
