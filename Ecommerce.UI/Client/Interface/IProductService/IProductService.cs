using Ecommerce.UI.Shared.Model.DocModel;
using Ecommerce.UI.Shared.Product;

namespace Ecommerce.UI.Client.Interface.IProductService
{
    public interface IProductService
    {
        event Action ProductsChanged;
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        docs Products { get; set; }
        Task GetProducts(string? categoryUrl = null);
    }
}
