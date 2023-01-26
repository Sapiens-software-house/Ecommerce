using Ecommerce.Infrastructure.Repository;
using Ecommerce.Interface.ICartItemRepository;
using Ecommerce.UI.Shared.Cart;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.CartItemRepository
{
    public class CartItemRepository : Repository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(DbContext context) : base(context) { }
    }
}
