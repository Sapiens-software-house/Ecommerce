using Ecommerce.Infrastructure.Data;
using Ecommerce.Interface.IAuthService;
using Ecommerce.Interface.ICartItemRepository;
using Ecommerce.Interface.ICartItemService;
using Ecommerce.Interface.IUnitOfWork;
using Ecommerce.UI.Shared.Cart;
using Ecommerce.UI.Shared.Product;
using Ecommerce.UI.Shared.ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.CartService
{
    public class CartService : ICartItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public CartService(IUnitOfWork unitOfWork, IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _authService = authService;
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> GetCartProducts(IEnumerable<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponse>>
            {
                Data = new List<CartProductResponse>()
            };

            foreach (var item in cartItems)
            {
                var productToCheck = new Product();
                var product = await _unitOfWork.ProductRepository.FindAsync(p => p.id == item.ProductId.ToString());

                if (product == null)
                {
                    continue;
                }
                else
                {
                    productToCheck = product.FirstOrDefault();
                }

                var cartProduct = new CartProductResponse
                {
                    ProductId = productToCheck.id,
                    Title = productToCheck.name,
                    ImageUrl = productToCheck.images.FirstOrDefault().url,
                    Price = Convert.ToDecimal(productToCheck.retailMinBasePrice),
                    Quantity = item.Quantity
                };

                result.Data.Add(cartProduct);
            }

            return result;
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems)
        {
            cartItems.ForEach(cartItem => cartItem.UserId = _authService.GetUserId());
            _unitOfWork.CartItemRepository.AddRange(cartItems);
            await _unitOfWork.SaveAsync();

            return await GetDbCartProducts();
        }

        public async Task<ServiceResponse<int>> GetCartItemsCount()
        {
            var count = 0;
            var cartItem = await _unitOfWork.CartItemRepository.FindAsync(ci => ci.UserId == _authService.GetUserId());

            if (cartItem != null)
            {
                count = cartItem.Count();
            }

            return new ServiceResponse<int> { Data = count };
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> GetDbCartProducts(int? userId = null)
        {
            if (userId == null)
                userId = _authService.GetUserId();

            var cartItem = await _unitOfWork.CartItemRepository.GetAllAsync(ci => ci.UserId == userId);

            return await GetCartProducts(cartItem);
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId = _authService.GetUserId();
            var sameItemToCheck = new CartItem();
            var sameItem = await _unitOfWork.CartItemRepository.FindAsync(ci => ci.ProductId == cartItem.ProductId &&
                ci.UserId == cartItem.UserId);
            if (sameItem == null)
            {
                _unitOfWork.CartItemRepository.Add(cartItem);
            }
            else
            {
                sameItemToCheck = sameItem.FirstOrDefault();
                sameItemToCheck.Quantity += cartItem.Quantity;
            }

            await _unitOfWork.SaveAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            var dbCatItemToCheck = new CartItem();

            var dbCartItem = await _unitOfWork.CartItemRepository.FindAsync(ci => ci.ProductId == cartItem.ProductId &&  
            ci.UserId == _authService.GetUserId());

            if (dbCartItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist."
                };
            }
            else
            {
                dbCatItemToCheck = dbCartItem.FirstOrDefault();
            }

            dbCatItemToCheck.Quantity = cartItem.Quantity;

            await _unitOfWork.SaveAsync();

            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<bool>> RemoveItemFromCart(int productId, int productTypeId)
        {
            var dbCartItemToCheck = new CartItem();
            var dbCartItem = await _unitOfWork.CartItemRepository
                .FindAsync(ci => ci.ProductId == productId &&
                ci.UserId == _authService.GetUserId());

            if (dbCartItem == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Success = false,
                    Message = "Cart item does not exist."
                };
            }
            else
            {
                dbCartItemToCheck = dbCartItem.FirstOrDefault();
            }

            _unitOfWork.CartItemRepository.Delete(dbCartItemToCheck);
            await _unitOfWork.SaveAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
