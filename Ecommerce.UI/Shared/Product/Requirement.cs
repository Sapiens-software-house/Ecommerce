using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class Requirement
    {

        public int Id { get; set; }
        public string IdProduto { get; set; }
        public Product Produto { get; set; }
        public int MinimalId { get; set; }
        public Minimal Minimal { get; set; }
        public int RecommendedId { get; set; }
        public Recommended Recommended { get; set; }
    }
}
