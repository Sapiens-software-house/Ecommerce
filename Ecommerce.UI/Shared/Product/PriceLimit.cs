using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class PriceLimit
    {
        public int Id { get; set; }
        public string IdProduto { get; set; }
        public Product Produto { get; set; }
        public decimal? max { get; set; } // Maximum price (null if not defined)
        public decimal? mim { get; set; } // Minimum price (null if not defined)
    }
}
