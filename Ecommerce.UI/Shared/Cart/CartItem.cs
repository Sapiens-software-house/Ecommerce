using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.UI.Shared.User;

namespace Ecommerce.UI.Shared.Cart
{
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Ecommerce.UI.Shared.User.User User { get; set; }
        public string ProductId { get; set; }
        public Product.Product Product { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
