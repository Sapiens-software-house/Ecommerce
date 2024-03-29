﻿using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repository;
using Ecommerce.Interface.IOrderItemRepository;
using Ecommerce.UI.Shared.Orders;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.OrderRepository
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(DataContext context) : base(context)
        {
        }
    }
}
