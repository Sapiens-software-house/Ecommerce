using Ecommerce.Interface.IUserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interface.Repository
{
    public interface IRepositoryManager
    {
        IUserIdentityRepository UserIdentityRepository { get; }
    }
}
