using Ecommerce.UI.Shared.Model.DocModel;
using Ecommerce.UI.Shared.ServiceResponse;

namespace Ecommerce.UI.Server.Interface
{
    public interface IProductService
    {
        Task<ServiceResponse<docs>> GetProductFrom();
    }
}
