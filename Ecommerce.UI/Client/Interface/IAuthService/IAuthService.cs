using Ecommerce.UI.Shared.Model.DocModel;
using Ecommerce.UI.Shared.Product;
using Ecommerce.UI.Shared.ServiceResponse;
using Ecommerce.UI.Shared.User;

namespace Ecommerce.UI.Client.Interface.IAuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
        Task<ServiceResponse<string>> Login(UserLogin request);
        Task<bool> IsUserAuthenticated();
    }
}
