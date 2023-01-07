using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Orders
{
    public class Order
    {
        public string Id { get; set; }
        public string productId { get; set; }
        public string currency { get; set; }
        public int? maxPrice { get; set; }
        public int? price { get; set; }
        public string key { get; set; }
    }
}
