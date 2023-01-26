using Ecommerce.Interface.Repository;
using Ecommerce.UI.Shared.Orders;
using Ecommerce.UI.Shared.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interface.IOrderService
{
    public interface IOrderService
    {
        Task<ServiceResponse<bool>> PlaceOrder(int userId);
        Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders();
        Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(int orderId);
    }
}
