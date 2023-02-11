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
                .HasKey(oi => new { oi.Id });
            modelBuilder.Entity<PriceLimit>()
                .HasKey(oi => new { oi.Id });
            modelBuilder.Entity<Restriction>()
                .HasKey(oi => new { oi.Id });
            modelBuilder.Entity<Minimal>()
                .HasKey(oi => new { oi.Id });
            modelBuilder.Entity<Recommended>()
                .HasKey(oi => new { oi.Id });
            modelBuilder.Entity<Requirement>()
                .HasKey(oi => new { oi.Id });            
            modelBuilder.Entity<Video>()
                .HasKey(oi => new { oi.Id });
            modelBuilder.Entity<Categories>()
                .HasKey(oi => new { oi.Id });
            modelBuilder.Entity<CartItem>()
                .HasKey(oi => new { oi.Id });
            modelBuilder.Entity<Order>()
                .HasKey(oi => new { oi.Id });
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.Id });
        }

        public DbSet<Product> Product {get; set;}
        public DbSet<Image> Image { get; set; }
        public DbSet<PriceLimit> PriceLimit { get; set; }
        public DbSet<Restriction> Restriction { get; set; }
        public DbSet<Minimal> Minimal { get; set; }
        public DbSet<Recommended> Recommended { get; set; }
        public DbSet<Requirement> Requirement { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Address> Address { get; set; }

    }
}
