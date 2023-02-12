using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repository;
using Ecommerce.Interface.Repository;
using Ecommerce.UI.Shared.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Interface.ProductRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository.IProductRepository
    {
        public ProductRepository(DataContext context) : base(context) { }
    }
}
