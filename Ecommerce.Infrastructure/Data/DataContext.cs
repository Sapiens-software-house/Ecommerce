using Ecommerce.UI.Shared.Product;
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

        public DbSet<Product> Products {get; set;}
        public DbSet<Image> Images { get; set; }
        public DbSet<PriceLimit> PriceLimits { get; set; }
        public DbSet<Restriction> Restrictions { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Categories> Categories { get; set; }
    }
}
