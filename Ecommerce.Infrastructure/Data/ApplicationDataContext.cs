using Ecommerce.UI.Shared.Cart;
using Ecommerce.UI.Shared.Orders;
using Ecommerce.UI.Shared.Product;
using Ecommerce.UI.Shared.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data
{
    public class ApplicationDataContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options)
            : base(options)
        {
        }
    }
}
