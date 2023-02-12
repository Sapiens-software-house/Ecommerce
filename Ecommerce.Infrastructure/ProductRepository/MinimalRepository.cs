using Ecommerce.Infrastructure.Data;
using Ecommerce.Infrastructure.Repository;
using Ecommerce.Interface.IProductRepository;
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
    public class MinimalRepository : Repository<Minimal>, IMinimalRepository
    {
        public MinimalRepository(DataContext context) : base(context) { }
    }
}
