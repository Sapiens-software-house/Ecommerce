using Ecommerce.Interface.Repository;
using Ecommerce.UI.Shared.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interface.IOrderReposiotry
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
