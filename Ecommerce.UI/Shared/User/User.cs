using Ecommerce.UI.Shared.Cart;
using Ecommerce.UI.Shared.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.User
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public List<Address> Address { get; set; }
        public List<CartItem> CartItem { get; set; }
        public List<Order> Order { get; set; }
        public string Role { get; set; } = "Customer";
    }
}
