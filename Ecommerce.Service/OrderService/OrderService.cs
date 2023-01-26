using Ecommerce.Infrastructure.Data;
using Ecommerce.Interface.IAuthService;
using Ecommerce.Interface.ICartItemService;
using Ecommerce.Interface.IUnitOfWork;
using Ecommerce.Service.CartService;
using Ecommerce.UI.Shared.Orders;
using Ecommerce.UI.Shared.ServiceResponse;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.OrderService
{
    public class OrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICartItemService _cartService;
        private readonly IAuthService _authService;

        public OrderService(IUnitOfWork unitOfWork,
        ICartItemService cartService,
            IAuthService authService)
        {
            _unitOfWork = unitOfWork;
            _cartService = cartService;
            _authService = authService;
        }

        public async Task<ServiceResponse<OrderDetailsResponse>> GetOrderDetails(int orderId)
        {
            var response = new ServiceResponse<OrderDetailsResponse>();
            var orderToCheck = new Order();
            var order = await _unitOfWork.OrderRepository.FindAsync(o => o.UserId == _authService.GetUserId().ToString() && o.Id == orderId.ToString());
            if (order != null)
            {
                orderToCheck = order.FirstOrDefault();
            }

            if (orderToCheck == null)
            {
                response.Success = false;
                response.Message = "Order not found.";
                return response;
            }

            var orderDetailsResponse = new OrderDetailsResponse
            {
                OrderDate = (DateTime)orderToCheck.OrderDate,
                TotalPrice = Convert.ToDecimal(orderToCheck.maxPrice),
                Products = new List<OrderDetailsProductResponse>()
            };

            orderToCheck.OrderItems.ForEach(item =>
            orderDetailsResponse.Products.Add(new OrderDetailsProductResponse
            {
                ProductId = item.ProductId,
                ImageUrl = item.Product.images.FirstOrDefault().url,
                Quantity = item.Quantity,
                Title = item.Product.name,
                TotalPrice = item.TotalPrice
            }));

            response.Data = orderDetailsResponse;

            return response;
        }

        public async Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponse>>();
            var ordersToCheck = new Order();
            var orders = await _unitOfWork.OrderRepository.GetAllAsync(o => o.UserId == _authService.GetUserId().ToString());
            
            var orderResponse = new List<OrderOverviewResponse>();

            foreach (var o in orders)
            {
                orderResponse.Add(new OrderOverviewResponse
                {
                    Id = Convert.ToInt32(o.Id),
                    OrderDate = (DateTime)o.OrderDate,
                    TotalPrice = o.TotalPrice,
                    Product = o.OrderItems.Count > 1 ?
                        $"{o.OrderItems.First().Product.name} and" +
                        $" {o.OrderItems.Count - 1} more..." :
                        o.OrderItems.First().Product.name,
                    ProductImageUrl = o.OrderItems.First().Product.images.FirstOrDefault().url
                });
            }

            response.Data = orderResponse;

            return response;
        }

        public async Task<ServiceResponse<bool>> PlaceOrder(int userId)
        {
            var products = (await _cartService.GetDbCartProducts(userId)).Data;
            decimal totalPrice = 0;
            products.ForEach(product => totalPrice += product.Price * product.Quantity);

            var orderItems = new List<OrderItem>();
            products.ForEach(product => orderItems.Add(new OrderItem
            {
                ProductId = Convert.ToInt32(product.ProductId),
                Quantity = product.Quantity,
                TotalPrice = product.Price * product.Quantity
            }));

            var order = new Order
            {
                UserId = userId.ToString(),
                OrderDate = DateTime.Now,
                TotalPrice = totalPrice,
                OrderItems = orderItems
            };

            _unitOfWork.OrderRepository.Add(order);

            _unitOfWork.CartItemRepository.DeleteRange(_unitOfWork.CartItemRepository.Find(ci => ci.UserId == userId));

            await _unitOfWork.SaveAsync();

            return new ServiceResponse<bool> { Data = true };
        }
    }
}
