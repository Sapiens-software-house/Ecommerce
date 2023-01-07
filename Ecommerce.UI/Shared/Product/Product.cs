using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class Product
    {
        public int? page { get; set; }
        public string id { get; set; }
        public int? minQty { get; set; }
        public int? minPriceFrom { get; set; }
        public int minPriceTo { get; set; }
        public int? includeOutOfStock { get; set; }
        public int? updatedAtFrom { get; set; }
        public int? updatedAtTo { get; set; }
    }
}
