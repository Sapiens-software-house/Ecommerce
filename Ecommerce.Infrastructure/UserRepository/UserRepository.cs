using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repository;
using Ecommerce.Interface.IProductRepository;
using Ecommerce.Interface.IUserRepository;
using Ecommerce.UI.Shared.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.UserRepository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context) { }

        public async Task<bool> ExistsByEmail(string email)
        {
            var bAux = false;
            try
            {
                bAux = await context.Set<User>().AnyAsync(e => e.Email == email);
            }
            catch (Exception ex)
            {
                throw;
            }
            return bAux;
        }
    }
}
