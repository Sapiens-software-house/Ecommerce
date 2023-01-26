using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interface.IUserService
{
    public interface IAddressService
    {
        Task<ServiceResponse<Address>> GetAddress();
        Task<ServiceResponse<Address>> AddOrUpdateAddress(Address address);
    }
}
