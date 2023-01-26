using Ecommerce.Interface.Repository;
using Ecommerce.UI.Shared.Cart;
using Ecommerce.UI.Shared.ServiceResponse;

namespace Ecommerce.Interface.ICartItemService
{
    public interface ICartItemService
    {
        Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(IEnumerable<CartItem> cartItems);
        Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems);
        Task<ServiceResponse<int>> GetCartItemsCount();
        Task<ServiceResponse<List<CartProductResponse>>> GetDbCartProducts(int? userId = null);
        Task<ServiceResponse<bool>> AddToCart(CartItem cartItem);
        Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem);
        Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId);
    }
}
