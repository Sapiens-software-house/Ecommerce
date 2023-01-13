using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class Categories
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }

        public string id { get; set; } // Category identifier
        public string name { get; set; } // Category name
    }
}
