using Ecommerce.UI.Shared.Cart;
using Ecommerce.UI.Shared.Orders;
using Ecommerce.UI.Shared.Product;
using Ecommerce.UI.Shared.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(oi => new { oi.id });
            modelBuilder.Entity<Image>()
                .HasKey(oi => new { oi.IdProduto });
            modelBuilder.Entity<PriceLimit>()
                .HasKey(oi => new { oi.IdProduto });
            modelBuilder.Entity<Restriction>()
                .HasKey(oi => new { oi.IdProduto });
            modelBuilder.Entity<Minimal>()
                .HasKey(oi => new { oi.IdProduto });
            modelBuilder.Entity<Requirement>()
                .HasKey(oi => new { oi.IdProduto, oi.minimalId, oi.recommendedId });
            modelBuilder.Entity<Recommended>()
                .HasKey(oi => new { oi.ProductId });
            modelBuilder.Entity<Video>()
                .HasKey(oi => new { oi.IdProduto });
            modelBuilder.Entity<Categories>()
                .HasKey(oi => new { oi.ProductId });
            modelBuilder.Entity<CartItem>()
                .HasKey(ci => new { ci.UserId, ci.ProductId });
            modelBuilder.Entity<Order>()
                .HasKey(oi => new { oi.productId, oi.UserId });
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });
        }

        public DbSet<Product> Products {get; set;}
        public DbSet<Image> Images { get; set; }
        public DbSet<PriceLimit> PriceLimits { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<Minimal> Minimal { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Recommended> Recommended { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
