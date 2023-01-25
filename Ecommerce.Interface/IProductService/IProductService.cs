using Ecommerce.UI.Shared.Product;
using Ecommerce.UI.Shared.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interface.IProductService
{
    public interface IProductService
    {
        Task<ServiceResponse<Product>> CreateProduct(Product product);
    }
}
