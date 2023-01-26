using Ecommerce.Infrastructure.Repository;
using Ecommerce.Interface.IOrderReposiotry;
using Ecommerce.UI.Shared.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.OrderRepository
{
    public class OrderRepository : Repository<Order>, IOrderReposiotry
    {
        public OrderRepository(DbContext context) : base(context)
        {
        }
    }
}
