using Ecommerce.Interface.Repository;
using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;

namespace Ecommerce.Interface.IUserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        bool ExistsByEmail(string email);
    }
}