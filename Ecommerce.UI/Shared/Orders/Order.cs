using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Orders
{
    public class Order
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string productId { get; set; }
        public string currency { get; set; }
        public int? maxPrice { get; set; }
        public int? price { get; set; }
        public string key { get; set; }
        public DateTime? OrderDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
