using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class PriceLimit
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int? max { get; set; } // Maximum price (null if not defined)
        public int? mim { get; set; } // Minimum price (null if not defined)
    }
}
