using Ecommerce.Infrastructure.AddressRepository;
using Ecommerce.Infrastructure.CartItemRepository;
using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.OrderRepository;
using Ecommerce.Infrastructure.UserRepository;
using Ecommerce.Interface.IAddressRepository;
using Ecommerce.Interface.ICartItemRepository;
using Ecommerce.Interface.IOrderItemRepository;
using Ecommerce.Interface.IOrderReposiotry;
using Ecommerce.Interface.IProductRepository;
using Ecommerce.Interface.IroductRepository;
using Ecommerce.Interface.IUnitOfWork;
using Ecommerce.Interface.IUserRepository;
using Ecommerce.Interface.ProductRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UnitOfWork.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext context;
        public UnitOfWork(DataContext context)
        {
            this.context = context;
            ImageRepository = new ImageRepository(this.context);
            MinimalRepository = new MinimalRepository(this.context);
            PriceLimitRepository = new PriceLimitRepository(this.context);
            ProductRepository = new ProductRepository(this.context);
            RecommendedRepository = new RecommendedRepository(this.context);
            RequirementRepository = new RequirementRepository(this.context);
            RestrictionRepository = new RestrictionRepository(this.context);
            VideoRepository = new VideoRepository(this.context);
            UserRepository = new UserRepository(this.context);
            AddressRepository = new AddressRepository(this.context);
            CartItemRepository = new CartItemRepository(this.context);
            OrderRepository = new OrderRepository(this.context);
            OrderItemRepository = new OrderItemRepository(this.context);
            AddressRepository = new AddressRepository(this.context);
        }
        public IImageRepository ImageRepository { get; private set; }

        public IMinimalRepository MinimalRepository { get; private set; }

        public IPriceLimitRepository PriceLimitRepository { get; private set; }

        public IProductRepository ProductRepository { get; private set; }

        public IRecommendedRepository RecommendedRepository { get; private set; }

        public IRequirementRepository RequirementRepository { get; private set; }

        public IRestrictionRepository RestrictionRepository { get; private set; }

        public IVideoRepository VideoRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IAddressRepository AddressRepository { get; private set; }
        public ICartItemRepository CartItemRepository { get; private set; }
        public IOrderRepository OrderRepository { get; private set; }
        public IOrderItemRepository OrderItemRepository { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
