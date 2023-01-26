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
        Task<ServiceResponse<bool>> DeleteProduct(int productId);
        Task<ServiceResponse<List<Product>>> GetProductsAsync();
        Task<ServiceResponse<Product>> GetProductAsync(int productId);
        Task<ServiceResponse<ProductSearchResult>> SearchProducts(string searchText, int page);
    }
}
