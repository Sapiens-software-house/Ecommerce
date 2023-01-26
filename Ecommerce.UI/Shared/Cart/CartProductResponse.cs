using Ecommerce.UI.Shared.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Cart
{
    public class CartProductResponse
    {
        public string ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ProductTypeId { get; set; }
        public string ProductType { get; set; } = string.Empty;
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
