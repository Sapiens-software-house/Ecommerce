using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class Image
    {
        public int Id { get; set; }
        public string IdProduto { get; set; }
        public Product Produto { get; set; }
        public string url { get; set; }
    }
}
